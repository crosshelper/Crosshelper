﻿using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Transfer;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Permission = Plugin.Permissions.Abstractions.Permission;

namespace Crosshelper.Views
{
    public partial class ProfilePage : ContentPage
    {
        // 初始化 Amazon Cognito 凭证提供程序
        CognitoAWSCredentials credentials = new CognitoAWSCredentials(
            "us-east-1:220800bd-8233-4785-b80e-7f440926f503", // 身份池 ID
            RegionEndpoint.USEast1 // 区域
        );

        private string filename = Settings.ChatID + DateTime.Now.ToShortDateString();
        private const string bucketName = "image.cycbis.com/UserProfileIcon";
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest1;
        private static IAmazonS3 s3Client = new AmazonS3Client(bucketRegion);

        void Handle_Saved(object sender, System.EventArgs e)
        {
            _usr.FirstName = FirstName;
            _usr.LastName = LastName;
            _ac.Email = Email;
            _ac.ContactNo = PhoneNumber;

            uih.UpdateUserInfo(_usr);
            uih.UpdateUac(_ac);

            Navigation.PopAsync(false);
        }
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_ResetPassword(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResetPasswordPage(_ac));
        }

        async void Handle_ChangePhoto(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Change the photo", "Cencel", null, "Take photo", "From album");
            switch (action)
            {
                case "Take photo":
                    await TakePhotoFromCameraAsync();
                    break;
                case "From album":
                    await SelectFromImageLibrary();
                    break;
            }
        }

        private async Task TakePhotoFromCameraAsync()
        {
            var media = CrossMedia.Current;

            //check Permisson
            if (await CheckPermisson())
            {
                if (!media.IsCameraAvailable || !media.IsTakePhotoSupported)
                {
                    await DisplayAlert("Alert", "Can not access Camera", "OK");
                    return;
                }
                var file = await media.TakePhotoAsync(new StoreCameraMediaOptions {
                    AllowCropping = true,
                    SaveToAlbum = true
                });
                //fileImage.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                if (file == null)
                    return;
            }
        }
        private async Task SelectFromImageLibrary()
        {
            var media = CrossMedia.Current;
            if(await CheckPermisson())
            {
                if (!media.IsPickPhotoSupported)
                {
                    await DisplayAlert("Alert", "Can not access album", "OK");
                    return;
                }
                var file = await media.PickPhotoAsync(new PickMediaOptions {
                    //RotateImage = true
                 });

                if (file == null)
                {
                    return;
                }
                else
                {
                    var fileTransferUtility =
                    new TransferUtility(s3Client);

                    //await fileTransferUtility.UploadAsync(file.GetStream(), bucketName,"123");

                    //await fileTransferUtility.UploadAsync(filename + file.AlbumPath, bucketName);

                    await fileTransferUtility.UploadAsync(filename + file.Path, bucketName);

                }
            }
        }
        ////check Permisson method
        private async Task<bool> CheckPermisson()
        {
            var permissons = CrossPermissions.Current;
            var storageStatus = await permissons.CheckPermissionStatusAsync(Permission.Storage);
            if(storageStatus != PermissionStatus.Granted)
            {
                var results = await permissons.RequestPermissionsAsync(Permission.Storage);
                storageStatus = results[Permission.Storage];
            }
            return storageStatus == PermissionStatus.Granted;
        }

        User _usr;
        Uac _ac;
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        UserInfoHelper uih = new UserInfoHelper();

        public ProfilePage(User user)
        {
            InitializeComponent();
            _usr = user;
            NameCell.Title = user.FirstName + " " + user.LastName;
            NameCell.IconSource = user.Icon;
            FirstName = user.FirstName;
            LastName = user.LastName;
            _ac = uih.GetUacByID(user.UserID);
            Email = _ac.Email;
            PhoneNumber = _ac.ContactNo;
            BindingContext = this;
        }
    }
}
