using System;
using System.Collections.Generic;
using System.Linq;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class GetHelpPage : ContentPage
    {
        public List<HelperLabel> Helpers { get; private set; }
        public List<TypeProblem> ProblemsCategory { get; private set; }
        public List<TypeProblem> RecommendationOne { get; private set; }
        public List<TypeProblem> RecommendationTwo { get; private set; }
        public List<TypeProblem> RecommendationThree { get; private set; }
        public List<TypeProblem> RecommendationFour { get; private set; }
        public GetHelpPage()
        {
            WakeUpLocationService();
            InitializeComponent();
            //TODO Get help page 数据放到后端.
            ////ProblemsCategory////
            ProblemsCategory = new List<TypeProblem>();
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 2,
                Pcategory = "Daily life",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Daily+life.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = "Interpreter",
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
                TagID = 9,
                Pcategory = "Doctor",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Health.png"
            });

            //////International Recommendation///////
            RecommendationOne = new List<TypeProblem>();
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 1,
                Pcategory = "Airport Pickup",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/AirportPick.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 19,
                Pcategory = "Writing",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Writing.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 7,
                Pcategory = "DMV & Driver License",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/DMV%26Driver.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 24,
                Pcategory = "Phone Line Service",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/PhoneLineService.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 12,
                Pcategory = "Visa & Status",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Visa%26Status.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = "Car Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/CarRepair.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 23,
                Pcategory = "Phone & PC Repair",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Phone%26PC+repair.png"
            });

            //////Immigrant Recommendation///////
            RecommendationTwo = new List<TypeProblem>();
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = "Interpreter",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Interpreter.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 22,
                Pcategory = "Housing",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Housing.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 13,
                Pcategory = "Insurance",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Insurance.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 15,
                Pcategory = "Tax",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Tax.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 25,
                Pcategory = "Medicine Care",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/MedicineCare.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 4,
                Pcategory = "Accident",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Accident.png"
            });


            //////Traveler Recommendation///////
            RecommendationThree = new List<TypeProblem>();
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 18,
                Pcategory = "Car Rental",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/CarRental.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 6,
                Pcategory = "Tour Guide",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Tourguide.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 11,
                Pcategory = "Emergency",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Emergency.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = "Interpreter",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Interpreter.png"
            });

            //////Business Recommendation///////
            RecommendationFour = new List<TypeProblem>();
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 26,
                Pcategory = "Business Info",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/BusinessInfo.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 8,
                Pcategory = "Law",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Law.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = "Interpreter",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Interpreter.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 1,
                Pcategory = "Airport Pickup",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/AirportPick.png"
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
                Navigation.PushAsync(new DescribeProblemPage(tmp));
            }
        }

        private async void WakeUpLocationService()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
            if (position.Longitude > 0)
            {
                return;
            }
            Settings.CurrentLongitude = position.Longitude;
            Settings.CurrentLatitude = position.Latitude;
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
            if (cv2.SelectedItem != null)
            {
                cv2.SelectedItem = null;
            }
            if (cv3.SelectedItem != null)
            {
                cv3.SelectedItem = null;
            }
            if (cv4.SelectedItem != null)
            {
                cv4.SelectedItem = null;
            }
            if (cv5.SelectedItem != null)
            {
                cv5.SelectedItem = null;
            }
        }
    }
}
