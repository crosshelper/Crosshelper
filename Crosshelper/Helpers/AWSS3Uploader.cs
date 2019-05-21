using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Crosshelper.Helpers
{
    class AWSS3Uploader
    {
        public TransferUtility transferUtility;
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest1;
        public AWSS3Uploader()
        {
        }

        public async void UploadFileAsync(string filePath, string bucketName, string keyname)
        {
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(
            "us-east-1:220800bd-8233-4785-b80e-7f440926f503", // 身份池 ID
            RegionEndpoint.USEast1 // 区域
            );

            var config = new TransferUtilityConfig();
            config.ConcurrentServiceRequests = 10;
            config.MinSizeBeforePartUpload = 16 * 1024 * 1024;

            var s3Client = new AmazonS3Client(credentials, bucketRegion);

            transferUtility = new TransferUtility(s3Client);//, config);

            try
            {
                await transferUtility.UploadAsync(
                    filePath,
                    bucketName,
                    keyname
                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("AWSS3 upload file exception = " + e);
            }


        }




        /*
        private const string bucketName = "image.cycbis.com";//"*** provide bucket name ***";
        private const string keyName = "*** provide a name for the uploaded object ***";
        private const string filePath = "*** provide the full path name of the file to upload ***";
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest1;
        private static IAmazonS3 s3Client;

        public AWSS3Uploader()
        {
            s3Client = new AmazonS3Client(bucketRegion);
            UploadFileAsync().Wait();
        }

        //public static void Main()
        //{
            //s3Client = new AmazonS3Client(bucketRegion);
            //UploadFileAsync().Wait();
        //}

        public static async Task UploadFileAsync()
        {
            try
            {
                var fileTransferUtility =
                    new TransferUtility(s3Client);

                // Option 1. Upload a file. The file name is used as the object key name.



                await fileTransferUtility.UploadAsync(filePath, bucketName);
                Console.WriteLine("Upload 1 completed");

                /*
                // Option 2. Specify object key name explicitly.
                await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
                Console.WriteLine("Upload 2 completed");

                // Option 3. Upload data from a type of System.IO.Stream.
                using (var fileToUpload =
                    new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    await fileTransferUtility.UploadAsync(fileToUpload,
                                               bucketName, keyName);
                }
                Console.WriteLine("Upload 3 completed");

                // Option 4. Specify advanced settings.
                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = bucketName,
                    FilePath = filePath,
                    StorageClass = S3StorageClass.StandardInfrequentAccess,
                    PartSize = 6291456, // 6 MB.
                    Key = keyName,
                    CannedACL = S3CannedACL.PublicRead
                };
                fileTransferUtilityRequest.Metadata.Add("param1", "Value1");
                fileTransferUtilityRequest.Metadata.Add("param2", "Value2");

                await fileTransferUtility.UploadAsync(fileTransferUtilityRequest);
                Console.WriteLine("Upload 4 completed");
                
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            

        }
        */
    }
}
