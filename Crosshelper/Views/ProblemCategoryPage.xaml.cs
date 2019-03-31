using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ProblemCategoryPage : ContentPage
    {
        public ProblemCategoryPage()
        {
            InitializeComponent();
            //PCPMoreButton
        }

        void PCPDailylifeTranslateButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void PCPRepairCarButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void PCPLawButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void PCPHealthButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

    }

}
