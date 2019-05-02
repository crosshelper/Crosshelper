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
            return tmpstar;
        }

        public List<UserPro> BindingHelpersConvert(IList<UserPro> helpers)
        {
            List<UserPro> newhelpers = new List<UserPro>();
            HelperLabel tmp = new HelperLabel();
            foreach (UserPro helper in helpers)
            {
                tmp.Name = helper.FirstName + helper.LastName;
                tmp.Rating = StarNoToStarSign(helper.Rating);
                tmp.Language = "Language: " + helper.FLanguage + "/" + helper.SLanguage;
                tmp.Baseprice = "$" + helper.PriceSign + "starting cost";
                tmp.Location = "8 miles away";
                tmp.StatusColor = Color.FromHex("79B563");
                tmp.StatusText = "Available";
                tmp.LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png";
                tmp.ImageUrl = helper.Icon;
            }
            return newhelpers;
                
        }
    }
}
