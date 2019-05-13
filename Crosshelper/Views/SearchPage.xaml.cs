using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SearchPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        void Handle_ProblemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DescribeProblemPage(e.SelectedItem as TypeProblem)); 
        }
        public IList<TypeProblem> TypeProblems { get; private set; }
        public SearchPage()
        {
            InitializeComponent();

            TypeProblems = new List<TypeProblem>();

            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Accident",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Language",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Car repair",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "DMV & Driver License",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Law",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Translate",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Ticket",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Car Service",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Visa",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Insurance",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Health",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Tax",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Finance",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Credit",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Housing",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Writing",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Inbound/Outbound Custom",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "Repair / Fix",
            });
            TypeProblems.Add(new TypeProblem
            {
                Pcategory = "House repair/Fix",
            });

            BindingContext = this;
        }
    }
}
