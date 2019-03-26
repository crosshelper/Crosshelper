using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{

    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();
            // Lable&text Change
            // NameId: HomeDate, HomeLanguage, HomeProjectDescription, HomeProjectStatus

        }

        //Top Ring&Menu button
        void HomeBell(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void HomeBurgerMenu(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        //Profile image button
        void HomeProfileImage(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        //Location&language button
        void HomeLocation(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void HomeLanguage(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        //Get help button
        void HomeGetHelp(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        //Project view button

        void HomeMore(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }


    }
}
