using System;
using System.Collections.Generic;
using System.Linq;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class GetHelpPage : ContentPage
    {
        public IList<HelperLabel> Helpers { get; private set; }
        public IList<TypeProblem> ProblemsCategory { get; private set; }
        public IList<TypeProblem> RecommendationOne { get; private set; }
        public IList<TypeProblem> RecommendationTwo { get; private set; }
        public IList<TypeProblem> RecommendationThree { get; private set; }
        public IList<TypeProblem> RecommendationFour { get; private set; }
        public GetHelpPage()
        {
            InitializeComponent();

            
            ////ProblemsCategory////
            ProblemsCategory = new List<TypeProblem>();
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 1,
                Pcategory = "Daily life",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Daily+life.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = "Language",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Language.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 8,
                Pcategory = "Law",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Law.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Repair.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 14,
                Pcategory = "Health",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Health.png"
            });


            //////International Recommendation///////
            RecommendationOne = new List<TypeProblem>();
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom005.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom002.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });

            //////Immigrant Recommendation///////
            RecommendationTwo = new List<TypeProblem>();
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom002.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom004.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom005.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });

            //////Traveler Recommendation///////
            RecommendationThree = new List<TypeProblem>();
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom005.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom002.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom004.png"
            });

            //////Business Recommendation///////
            RecommendationFour = new List<TypeProblem>();
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom002.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom004.png"
            });


            BindingContext = this;
        }

        void Handle_Search(object sender, FocusEventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new SearchPage()));
        }
        void Handle_PickProblem(object sender, SelectionChangedEventArgs e)
        {
            TypeProblem tmp = e.CurrentSelection.FirstOrDefault() as TypeProblem;
            if (cv1.SelectedItem != null || cv2.SelectedItem != null || cv3.SelectedItem != null || cv4.SelectedItem != null || cv5.SelectedItem != null)
            {
                Navigation.PushModalAsync(new NavigationPage(new DescribeProblemPage(tmp)));
            }
        }
        protected override void OnAppearing()
        {
            RefreshSelection();
        }

        public void RefreshSelection()
        {
            if (cv1.SelectedItem != null)
            {
                cv1.SelectedItem = null;
            }
        }
    }
}
