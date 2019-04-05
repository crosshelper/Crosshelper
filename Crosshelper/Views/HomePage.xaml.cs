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
            // NameId: HPDate, HPLanguage, HPProjectDescription, HPProjectStatus
            HPProject.GestureRecognizers.Add(new TapGestureRecognizer
            { Command = new Command(() => { HPProject.BackgroundColor = Color.Blue; }) });
            
        }

        //Top Ring&Menu button
        void HPBell(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!"; 
        }
        void HPBurgerMenu(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        //Profile image button
        void HPProfileImage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }

        //Location&language button
        void HPLocation(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        void Handle_Setting(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UserSettingPage());
        }

        void Handle_Notice(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NoticePage());
        }

        void HPLanguage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }

        //Get help button
        void HPGetHelp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewcomersProblemCategoryPage());
        }

    }
}
