using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class UserSettingPage : ContentPage
    {
        public UserSettingPage()
        {
            InitializeComponent();
            commandcell.IconSource = ImageSource.FromFile("Resources.idphoto.jpeg");  
        }
    }
}
