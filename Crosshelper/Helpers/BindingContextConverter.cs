using Crosshelper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crosshelper.Helpers
{
    class BindingContextConverter
    {
        private string starsign = "★";

        private string StarNoToStarSign(int no)
        {
            string tmpstar = "";
            for (int i = 0; i < no; i++)
            {
                tmpstar += "★";
            }
            for (int i = 0; i < 5 - no; i++)
            {
                tmpstar += "☆";
            }
            return tmpstar;
        }

        private Color StatusColorConverter(int sno)
        {
            switch (sno)
            {
                case 1:
                    return Color.FromHex("79B563");
                case 2:
                    return Color.Red;
                case 3:
                    return Color.Yellow;
                default:
                    return Color.Black;
            }
        }

        private String StatusTextConverter(int sno)
        {
            switch (sno)
            {
                case 1:
                    return "Available";
                case 2:
                    return "Unavailable";
                case 3:
                    return "Busy";
                default:
                    return "Offline"; 
            }
        }

        public List<HelperLabel> BindingHelpersConvert(IList<UserPro> helpers)
        {
            List<HelperLabel> newhelpers = new List<HelperLabel>();
            HelperLabel tmp = new HelperLabel();
            foreach (UserPro helper in helpers)
            {
                tmp.HelperID = helper.UserID;
                tmp.Name = helper.FirstName + helper.LastName;
                tmp.Rating = StarNoToStarSign(helper.Rating);
                tmp.Language = "Language: " + helper.FLanguage + "/" + helper.SLanguage;
                tmp.Baseprice = "$" + helper.PriceSign + "starting cost";
                tmp.Location = "8 miles away";//TODO:应该绑定为真实数据
                tmp.StatusColor = StatusColorConverter(helper.Status);
                tmp.StatusText = StatusTextConverter(helper.Status); ;
                tmp.LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png";
                tmp.ImageUrl = helper.Icon;
            }
            return newhelpers;
                
        }
    }
}
