using Crosshelper.MessageCells;
using SendBird;
using Xamarin.Forms;

namespace Crosshelper.Helpers
{
    public class ItemsDataTemplateSelector : DataTemplateSelector 
    {
        //public DataTemplate FirstItemTemplate { get; set; }
        //public DataTemplate OtherItemTemplate { get; set; }

        public ItemsDataTemplateSelector()
        {
            // Retain instances!
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //if (!(item is UserMessage messageVm))
                //return null;
            //return messageVm.IsIncoming ? this.incomingDataTemplate : this.outgoingDataTemplate;

            DataTemplate _returnTemplate = new DataTemplate();
            //_returnTemplate = ((SearchpageViewcellItem)item).PanelID > 0 ? FirstItemTemplate : OtherItemTemplate;
            return _returnTemplate;
        }
        private readonly DataTemplate incomingDataTemplate;
        private readonly DataTemplate outgoingDataTemplate;
    }
}
