using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace Crosshelper.Helpers
{
    class AWSS3Uploader
    {
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest1;

        public TransferUtility s3transferUtility;
        IAmazonS3 s3client;

        public void SetupAWSCredentials()
        {
            // 初始化 Amazon Cognito 凭证提供程序
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(
                "us-east-1:be56bffa-67eb-40f0-b7cf-18caf9df0a20", // 身份池 ID
                RegionEndpoint.USEast1 // 区域
            );

            this.s3client = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
            AWSConfigsS3.UseSignatureVersion4 = true;
            this.s3transferUtility = new TransferUtility(s3client);
        }

        public async Task UploadFileAsync(string filePath, string bucketName, string keyname)
        {
            try
            {
                TransferUtilityUploadRequest request =
                    new TransferUtilityUploadRequest
                    {
                        BucketName = bucketName,
                        FilePath = filePath,
                        Key = keyname,
                        ContentType = "image/png"
                    };
                await this.s3transferUtility.UploadAsync(request).ContinueWith(((x) =>
                {
                    Debug.WriteLine("Image Uploaded");
                }));
                await Task.Delay(5000);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
