using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SearchPage : ContentPage
    {
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DescribeProblemPage()); 
        }
        public IList<TypeProblem> TypeProblems { get; private set; }
        public SearchPage()
        {
            InitializeComponent();

            TypeProblems = new List<TypeProblem>();

            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Accident",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Language",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Car repair",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "DMV & Driver License",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Law",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Translate",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Ticket",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Car Service",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Visa",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Insurance",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Health",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Tax",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Finance",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Credit",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Housing",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Writing",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Inbound/Outbound Custom",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "Repair / Fix",
            });
            TypeProblems.Add(new TypeProblem
            {
                ProblemType = "House repair/Fix",
            });

            BindingContext = this;
        }
    }
}
