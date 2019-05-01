using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Crosshelper.Helpers
{
    public static class Settings
    {
        /*private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }*/

        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants



        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string UserKey = "user_key";
        private static readonly int UserDefault = 0;

        private const string IsLoginKey = "login_key";
        private static readonly bool IsLoginDefault = false;

        #endregion

        public static string ChatID
        {
            get => AppSettings.GetValueOrDefault(nameof(ChatID), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ChatID), value);
        }

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static int UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserKey, UserDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserKey, value);
            }
        }

        public static bool IsLogin
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsLoginKey, IsLoginDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsLoginKey, value);
            }
        }

    }
}
