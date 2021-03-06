﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Model;
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
        private string filename = Settings.ChatID + "_ProfileIcon.png";// + DateTime.Now.ToShortDateString();

        // Specify your bucket region (an example region is shown).
        //private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest1;
        //private static IAmazonS3 s3Client = new AmazonS3Client(bucketRegion);
        public TransferUtility s3transferUtility;
        IAmazonS3 s3client;

        void Handle_Saved(object sender, System.EventArgs e)
        {
            _usr.FirstName = FirstName;
            _usr.LastName = LastName;
            _ac.ContactNo = PhoneNumber;
            _usr.Email = Email;
            _usr.Icon = GetIconUrlFromS3();
            uih.UpdateUserInfo(_usr);
            uih.UpdateUac(_ac);
            Navigation.PopAsync(false);
        }

        void Handle_ResetPassword(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResetPasswordPage(_ac));
        }

        private string GetIconUrlFromS3()
        {
            /*
            s3client.getObjectUrl()
            GetPreSignedUrlRequest request =
                new GetPreSignedUrlRequest
                {
                    BucketName = "imagetest123bibi",
                    Key = string.Format(filename),
                    Expires=DateTime.Now.AddMinutes(5) 
                };
            */
            var s3 = Properties.Resources.S3_BUCKETNAME;
            string url = "https://" + s3 + ".s3.amazonaws.com/" + filename; //s3client.GetPreSignedURL(request); //s3.getSignedUrl('getObject', params);
            return url; 
        }

        async void Handle_ChangePhoto(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Change the photo", "Cancel", null, "Take photo", "From album");
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

        async Task SelectFromImageLibrary()
        {
            bool IsAvailable = await CrossMedia.Current.Initialize();
            if (!IsAvailable)
            {
                return;
            }
            //check Permisson
            if (await CheckPhotoPermisson())
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Alert", "Can not access Photo", "OK");
                    return;
                }
                
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file == null)
                {
                    return;
                }
                try
                {
                    TransferUtilityUploadRequest request =
                        new TransferUtilityUploadRequest
                        {
                            BucketName = "imagetest123bibi",
                            FilePath = file.Path,
                            Key = string.Format(filename),
                            ContentType = "image/png"
                        };
                    //The cancellationToken is not used within this example, however you can pass it to the UploadAsync consutructor as well
                    //CancellationToken cancellationToken = new CancellationToken();
                    await this.s3transferUtility.UploadAsync(request).ContinueWith(((x) =>
                    {
                        Debug.WriteLine("Image Uploaded");
                    }));

                    NameCell.IconSource = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                    await Task.Delay(5000);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                await DisplayAlert("Photo lib not access", "Go your system [Setting], change permission and try again.", "OK");
                return;
            }
        }

        private async Task TakePhotoFromCameraAsync()
        {
            bool IsAvailable = await CrossMedia.Current.Initialize();
            if (!IsAvailable)
            {
                return;
            }
            //check Permisson
            if (await CheckCameraPermisson())
            {
                if (await CheckPhotoPermisson())
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("Alert", "Can not access Camera", "OK");
                        return;
                    }
                    var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        AllowCropping = true,
                        SaveToAlbum = true
                    });
                    //fileImage.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                    if (file == null)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            TransferUtilityUploadRequest request =
                                new TransferUtilityUploadRequest
                                {
                                    BucketName = "imagetest123bibi",
                                    FilePath = file.Path,
                                    Key = string.Format(filename),
                                    ContentType = "image/png"
                                };
                            //The cancellationToken is not used within this example, however you can pass it to the UploadAsync consutructor as well
                            //CancellationToken cancellationToken = new CancellationToken();
                            await this.s3transferUtility.UploadAsync(request).ContinueWith(((x) =>
                            {
                                Debug.WriteLine("Image Uploaded");
                            }));

                            NameCell.IconSource = ImageSource.FromStream(() =>
                            {
                                var stream = file.GetStream();
                                file.Dispose();
                                return stream;
                            });
                            await Task.Delay(5000);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Photo lib not access", "Go your system [Setting], change permission and try again.", "OK");
                    return;
                }
                
            }
            else
            {
                await DisplayAlert("Camera not access", "Go your system [Setting], change permission and try again.", "OK");
                return;
            }
        }

        private async Task<bool> CheckMediaLibraryPermisson()
        {
            var permissons = CrossPermissions.Current;
            var storageStatus = await permissons.CheckPermissionStatusAsync(Permission.MediaLibrary);
            if (storageStatus != PermissionStatus.Granted)
            {
                var results = await permissons.RequestPermissionsAsync(Permission.MediaLibrary);
                storageStatus = results[Permission.MediaLibrary];
            }
            return storageStatus == PermissionStatus.Granted;
        }

        private async Task<bool> CheckPhotoPermisson()
        {
            var permissons = CrossPermissions.Current;
            var storageStatus = await permissons.CheckPermissionStatusAsync(Permission.Photos);
            if (storageStatus != PermissionStatus.Granted)
            {
                var results = await permissons.RequestPermissionsAsync(Permission.Photos);
                storageStatus = results[Permission.Photos];
            }
            return storageStatus == PermissionStatus.Granted;
        }

        //check Permisson method
        private async Task<bool> CheckCameraPermisson()
        {
            var permissons = CrossPermissions.Current;
            var storageStatus = await permissons.CheckPermissionStatusAsync(Permission.Camera);
            if(storageStatus != PermissionStatus.Granted)
            {
                var results = await permissons.RequestPermissionsAsync(Permission.Camera);
                storageStatus = results[Permission.Camera];
            }
            return storageStatus == PermissionStatus.Granted;
        }

        UserInfo _usr;
        Uac _ac;
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        UserInfoHelper uih = new UserInfoHelper();

        public ProfilePage(UserInfo user)
        {
            InitializeComponent();
            _usr = user;
            NameCell.Title = user.FirstName + " " + user.LastName;
            NameCell.IconSource = user.Icon;
            FirstName = user.FirstName;
            LastName = user.LastName;
            _ac = uih.GetUacByID(user.UserID);
            Email = _usr.Email;
            PhoneNumber = _ac.ContactNo;
            BindingContext = this;
            SetupAWSCredentials();
        }

        private void SetupAWSCredentials()
        {
            // 初始化 Amazon Cognito 凭证提供程序
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(
                "us-east-1:be56bffa-67eb-40f0-b7cf-18caf9df0a20", // 身份池 ID
                RegionEndpoint.USEast1 // 区域
            );

            this.s3client = new AmazonS3Client(credentials, RegionEndpoint.USEast1);//new AmazonS3Client("your awsAccessKeyId", "your awsSecretKeyId", RegionEndpoint.USEast1);
            //var config = new AmazonS3Config() { RegionEndpoint = Amazon.RegionEndpoint.USEast1, Timeout = TimeSpan.FromSeconds(30), UseHttp = true };
            AWSConfigsS3.UseSignatureVersion4 = true;
            this.s3transferUtility = new TransferUtility(s3client);
        }
    }
}