﻿using Crosshelper.Helpers;
using SendBird;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Crosshelper.Converters
{
    public class TypeToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int parameterType = int.Parse(parameter.ToString());
            Xamarin.Forms.Color background = Color.Silver;
            var user = (User)value;
            var userName = Settings.ChatID;
            if (user.UserId == userName)
            {
                background = Color.FromHex("#999999"); 
                if (parameterType == 0)
                    background = Color.Black;
            }
            else
            {
                background = Color.Black;
                if (parameterType == 0)
                    background = Color.White;
            }

            return background;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw null;
        }
    }
}
