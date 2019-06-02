using System;
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
            _ac.Email = Email;
            _ac.ContactNo = PhoneNumber;
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
            try
            {
                GetPreSignedUrlRequest request =
                    new GetPreSignedUrlRequest
                    {
                        BucketName = "imagetest123bibi",
                        Key = string.Format(filename),
                        ContentType = "image/png"
                    };
                //The cancellationToken is not used within this example, however you can pass it to the UploadAsync consutructor as well
                //CancellationToken cancellationToken = new CancellationToken();
                string url = s3client.GetPreSignedURL(request); //s3.getSignedUrl('getObject', params);
                return url; 
            }
            catch (Exception e)
            {
                throw e;
            }
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

        async Task SelectFromImageLibrary()
        {
            var media = CrossMedia.Current;
            var file = await media.PickPhotoAsync();

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

                NameCell.IconSource = ImageSource.FromStream(() => {
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

                        NameCell.IconSource = ImageSource.FromStream(() => {
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
            var config = new AmazonS3Config() { RegionEndpoint = Amazon.RegionEndpoint.USEast1, Timeout = TimeSpan.FromSeconds(30), UseHttp = true };

            AWSConfigsS3.UseSignatureVersion4 = true;
            this.s3transferUtility = new TransferUtility(s3client);
        }
    }
}