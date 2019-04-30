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
        public IList Items { get; } = new ObservableCollection<PickerItem>();
        public ObservableCollection<PickerItem> ItemsSource { get; } = new ObservableCollection<PickerItem>();
        public ObservableCollection<PickerItem> SelectedItems { get; set; } = new ObservableCollection<PickerItem>();

        public PickerTestPage()
        {
            InitializeComponent();

            BindingContext = this;

            Items.Add("abc");
            Items.Add("def");

            ItemsSource.Add(new PickerItem { Name = "abc" });
            ItemsSource.Add(new PickerItem { Name = "def" });
        }

        public class PickerItem
        {
            public string Name { get; set; }
        }
    }
}