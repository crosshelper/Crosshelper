using Crosshelper.MessageCells;
using SendBird;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crosshelper.Helpers
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as UserMessage;
            if (messageVm == null)
                return null;


            return (messageVm.Sender.UserId == Settings.ChatID) ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}
