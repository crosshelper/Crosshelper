using System;
using Xamarin.Forms;

namespace Crosshelper.Models
{
    public class ItemsDataTemplateSelector : DataTemplateSelector 
    {
        public DataTemplate FirstItemTemplate { get; set; }
        public DataTemplate OtherItemTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            DataTemplate _returnTemplate = new DataTemplate();
            //_returnTemplate = ((SearchpageViewcellItem)item).PanelID > 0 ? FirstItemTemplate : OtherItemTemplate;
            return _returnTemplate;
        }
    }
}
