using System;
using System.Collections.Generic;
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
        public GetHelpPage()
        {
            InitializeComponent();
            ////ProblemsCategory////
            ProblemsCategory = new List<TypeProblem>();
            ProblemsCategory.Add(new TypeProblem
            {
                Pcategory = "Daily life",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom002.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                Pcategory = "Language",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom004.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                Pcategory = "Law",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                Pcategory = "Health",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom005.png"
            });


            //////International Recommendation///////
            RecommendationOne = new List<TypeProblem>();
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repai1",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair2",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair3",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair4",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair5",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });

            //////Immigrant Recommendation///////
            RecommendationTwo = new List<TypeProblem>();
            RecommendationTwo.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });

            //////International Recommendation///////
            RecommendationThree = new List<TypeProblem>();
            RecommendationThree.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                Pcategory = "Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });


            BindingContext = this;
        }

        void Handle_Search(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new SearchPage()));
        }

        void Handle_PickProblem(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new DescribeProblemPage()));
        }
    }
}
