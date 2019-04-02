using System;
using Xamarin.Forms;

namespace Crosshelper.Models
{
    public class ItemsDataTemplateSelector : DataTemplateSelector 
    {
        public DataTemplate FirstItem { get; set; }
        public DataTemplate OtherItem { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            DataTemplate _returnTemplate = new DataTemplate();
            _returnTemplate = ((SearchpageViewcellItem)item).PanelID > 0 ? FirstItem : OtherItem;
            return _returnTemplate;
        }
    }
}
