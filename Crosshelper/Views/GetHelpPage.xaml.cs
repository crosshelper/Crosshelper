using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Plugin.Geolocator;
using UIKit;
using Xamarin.Essentials;
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
            InitializeComponent();
            //TODO Get help page 数据放到后端.
            ////ProblemsCategory////
            ProblemsCategory = new List<TypeProblem>();
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 2,
                Pcategory = AppResources.DailyLife,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Daily+life.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = AppResources.Interpreter,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Language.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 8,
                Pcategory = AppResources.Law,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Law.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = AppResources.CarRepair,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Repair.png"
            });
            ProblemsCategory.Add(new TypeProblem
            {
                TagID = 9,
                Pcategory = AppResources.Doctor,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/GetHelpIcon/Health.png"
            });

            //////International Recommendation///////
            RecommendationOne = new List<TypeProblem>();
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 1,
                Pcategory = AppResources.AirportPickup,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/AirportPick.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 19,
                Pcategory = AppResources.Writing,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Writing.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 7,
                Pcategory = AppResources.DMVDriverLicense,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/DMV%26Driver.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 24,
                Pcategory = AppResources.PhoneLineService,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/PhoneLineService.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 12,
                Pcategory = AppResources.VisaStatus,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Visa%26Status.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 5,
                Pcategory = AppResources.CarRepair,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/CarRepair.png"
            });
            RecommendationOne.Add(new TypeProblem
            {
                TagID = 23,
                Pcategory = AppResources.PhonePCRepair,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Phone%26PC+repair.png"
            });

            //////Immigrant Recommendation///////
            RecommendationTwo = new List<TypeProblem>();
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = AppResources.Interpreter,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Interpreter.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 22,
                Pcategory = AppResources.Housing,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Housing.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 13,
                Pcategory = AppResources.Insurance,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Insurance.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 15,
                Pcategory = AppResources.Tax,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Tax.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 25,
                Pcategory = AppResources.MedicineCare,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/MedicineCare.png"
            });
            RecommendationTwo.Add(new TypeProblem
            {
                TagID = 4,
                Pcategory = AppResources.Accident,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Accident.png"
            });


            //////Traveler Recommendation///////
            RecommendationThree = new List<TypeProblem>();
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 18,
                Pcategory = AppResources.CarRental,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/CarRental.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 6,
                Pcategory = AppResources.TourGuide,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Tourguide.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 11,
                Pcategory = AppResources.Emergency,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Emergency.png"
            });
            RecommendationThree.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = AppResources.Interpreter,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Interpreter.png"
            });

            //////Business Recommendation///////
            RecommendationFour = new List<TypeProblem>();
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 26,
                Pcategory = AppResources.BusinessInfo,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/BusinessInfo.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 8,
                Pcategory = AppResources.Law,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Law.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 3,
                Pcategory = AppResources.Interpreter,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/Interpreter.png"
            });
            RecommendationFour.Add(new TypeProblem
            {
                TagID = 1,
                Pcategory = AppResources.AirportPickup,
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/AirportPick.png"
            });

            BindingContext = this;
            //WakeUpLocationService();
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
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    if (location.Longitude > 0)
                    {
                        return;
                    }
                    Settings.CurrentLongitude = location.Longitude;
                    Settings.CurrentLatitude = location.Latitude;
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                else
                {
                    return;
                }
                //var locator = CrossGeolocator.Current;
                //locator.DesiredAccuracy = 50;
                //var position = await locator.GetPositionAsync();
                //if (position.Longitude > 0)
                //{
                    //return;
                //}
                //Settings.CurrentLongitude = position.Longitude;
                //Settings.CurrentLatitude = position.Latitude;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                bool action = await DisplayAlert("Location Error", "Feature not accessable.", "go to Settings", "Cancel");
                switch (action)
                {
                    case true:
                        await GoToLocationSettingAsync();
                        break;
                }
                throw pEx;
            }
        }

        private async Task GoToLocationSettingAsync()
        {
            Device.OpenUri(new Uri("app-settings:"));
            //UIApplication.SharedApplication.OpenUrl(new NSUrl("app-settings:"));
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
