using System;
using System.Threading.Tasks;
using Foundation;
using Security;
using WebSocketSharp;
using Xamarin.Essentials;

namespace Crosshelper.Helpers
{
    public class KeyChainHelper
    {
        public KeyChainHelper()
        {
        }

        /// <summary>
        /// Use SecureStorage
        /// </summary>
        /// <param name="oauth_token">Oauth token.</param>
        /// <param name="secret_value">Secret value.</param>

        public async void SavetoSecureStorage(string oauth_token, string secret_value)
        {
            try
            {
                await SecureStorage.SetAsync(oauth_token, secret_value);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        public async Task<string> GetFromSecureStorage(string oauth_token)
        {
            try
            {
                var oauthToken = await SecureStorage.GetAsync(oauth_token);
                return oauthToken;
            }
            catch (Exception ex)
            {
                return "";
                // Possible that device doesn't support secure storage on device.
            }
        }

        public void DeleteTheKeyInSecureStorage(string oauth_token)
        {
            SecureStorage.Remove(oauth_token);
        }




        /// <summary>
        /// Real KeyChain Method
        /// </summary>
        /// <returns>The key chain password.</returns>
        /// <param name="account">Account.</param>
        public string GetKeyChainPassword(string account)
        {
            var query = new SecRecord(SecKind.InternetPassword)
            {
                Server = "com.crosshelper.cycbis",
                Service = "com.crosshelper.cycbis",
                Account = account,
                ApplicationLabel = "Cycbis"
            };
            var password = SecKeyChain.QueryAsData(query).ToString();
            return password;
        }

        public void AddKeyChainPassword(string account, string password)
        {
            SecRecord secRecord = new SecRecord(new SecKey(new IntPtr(1)))
            {
                Server = "com.crosshelper.cycbis",
                Service = "com.crosshelper.cycbis",
                Account = account,
                ApplicationLabel = "Cycbis",
                ValueData = password
            };
            SecKeyChain.Add(secRecord);
        }

        public void UpdateKeyChainPassword(string account, string password)
        {
            SecRecord query = new SecRecord(SecKind.InternetPassword)
            {
                Server = "com.crosshelper.cycbis",
                Service = "com.crosshelper.cycbis",
                Account = account,
                ApplicationLabel = "Cycbis",
            };
            SecRecord newAttributes = new SecRecord(SecKind.InternetPassword)
            {
                Server = "com.crosshelper.cycbis",
                Service = "com.crosshelper.cycbis",
                Account = account,
                ApplicationLabel = "Cycbis",
                ValueData = password
            };
            SecKeyChain.Update(query, newAttributes);
        }

        /// <summary>
        /// Find an existing key, create a new key, delete a previous key.
        /// </summary>
        /// <returns>The for key.</returns>
        /// <param name="key">Key.</param>


        public string ValueForKey(string key)
        {
            var record = ExistingRecordForKey(key);
            var match = SecKeyChain.QueryAsRecord(record, out SecStatusCode resultCode);

            if (resultCode == SecStatusCode.Success)
                return NSString.FromData(match.ValueData, NSStringEncoding.UTF8);
            else
                return String.Empty;
        }

        public void SetValueForKey(string value, string key)
        {
            var record = ExistingRecordForKey(key);
            if (value.IsNullOrEmpty())
            {
                if (!ValueForKey(key).IsNullOrEmpty())
                    RemoveRecord(record);

                return;
            }

            // if the key already exists, remove it
            if (!ValueForKey(key).IsNullOrEmpty())
                RemoveRecord(record);

            var result = SecKeyChain.Add(CreateRecordForNewKeyValue(key, value));
            if (result != SecStatusCode.Success)
            {
                throw new Exception(String.Format("Error adding record: {0}", result));
            }
        }




        private SecRecord CreateRecordForNewKeyValue(string key, string value)
        {
            return new SecRecord(SecKind.GenericPassword)
            {
                Account = key,
                Service = "com.crosshelper.cycbis",
                Label = key,
                ValueData = NSData.FromString(value, NSStringEncoding.UTF8),
            };
        }

        private SecRecord ExistingRecordForKey(string key)
        {
            return new SecRecord(SecKind.GenericPassword)
            {
                Account = key,
                Service = "com.crosshelper.cycbis",
                Label = key,
            };
        }

        private bool RemoveRecord(SecRecord record)
        {
            var result = SecKeyChain.Remove(record);
            if (result != SecStatusCode.Success)
            {
                throw new Exception(String.Format("Error removing record: {0}", result));
            }

            return true;
        }

    }
}
