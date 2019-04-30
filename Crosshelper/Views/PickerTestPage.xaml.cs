using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerTestPage : ContentPage
    {
        public IList Items { get; }
        public ObservableCollection<PickerItem> ItemsSource { get; } = new ObservableCollection<PickerItem>();
        public ObservableCollection<PickerItem> SelectedItems { get; set; } = new ObservableCollection<PickerItem>();

        public PickerTestPage()
        {
            InitializeComponent();

            List<string> list = new List<string>
            {
                "abc",
                "def",
                "ghi"
            };
            Items = list;

            ItemsSource.Add(new PickerItem { Name = "abc" });
            ItemsSource.Add(new PickerItem { Name = "def" });

            BindingContext = this;
        }

        public class PickerItem
        {
            public string Name { get; set; }
        }
    }
}