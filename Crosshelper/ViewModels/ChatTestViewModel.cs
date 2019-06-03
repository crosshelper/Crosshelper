using Crosshelper.Views;
using SendBird;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static SendBird.SendBirdClient;

namespace Crosshelper.ViewModels
{
    public class ChatTestViewModel : INotifyPropertyChanged
    {
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<UserMessage> DelayedMessages { get; set; } = new Queue<UserMessage>();
        public ObservableCollection<UserMessage> Messages { get; set; } = new ObservableCollection<UserMessage>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        private GroupChannel channel;

        public GroupChannel Channel
        {
            get; //{ return channel; }
            set; //{ SetProperty(ref channel, value); }
        }

        public ChatTestViewModel()
        {
            /*
            Messages.Insert(0, new Message() { Text = "Hi" });
            Messages.Insert(0, new Message() { Text = "How are you?", User = App.User });
            Messages.Insert(0, new Message() { Text = "What's new?" });
            Messages.Insert(0, new Message() { Text = "How is your family", User = App.User });
            Messages.Insert(0, new Message() { Text = "How is your dog?", User = App.User });
            Messages.Insert(0, new Message() { Text = "How is your cat?", User = App.User });
            Messages.Insert(0, new Message() { Text = "How is your sister?" });
            Messages.Insert(0, new Message() { Text = "When we are going to meet?" });
            Messages.Insert(0, new Message() { Text = "I want to buy a laptop" });
            Messages.Insert(0, new Message() { Text = "Where I can find a good one?" });
            Messages.Insert(0, new Message() { Text = "Also I'm testing this chat" });
            Messages.Insert(0, new Message() { Text = "Oh My God!" });
            Messages.Insert(0, new Message() { Text = " No Problem", User = App.User });
            Messages.Insert(0, new Message() { Text = "Hugs and Kisses", User = App.User });
            Messages.Insert(0, new Message() { Text = "When we are going to meet?" });
            Messages.Insert(0, new Message() { Text = "I want to buy a laptop" });
            Messages.Insert(0, new Message() { Text = "Where I can find a good one?" });
            Messages.Insert(0, new Message() { Text = "Also I'm testing this chat" });
            Messages.Insert(0, new Message() { Text = "Oh My God!" });
            Messages.Insert(0, new Message() { Text = " No Problem" });
            Messages.Insert(0, new Message() { Text = "Hugs and Kisses" });
            */

            MessageAppearingCommand = new Command<UserMessage>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<UserMessage>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                //IsBusy = true;
                try
                {
                    if (string.IsNullOrEmpty(TextToSend))
                    {
                        //IsBusy = false; 
                        return;
                    }
                    Channel.SendUserMessage(TextToSend, "", (UserMessage userMessage, SendBirdException e) =>
                    {
                        if (e != null)
                        {
                            // Error.
                            return;
                        }

                        Messages.Add(userMessage);
                        //ChatPage.CurrentActivity.ScrollDown(Messages.Last());
                    });
                    TextToSend = string.Empty;
                    //IsBusy = false;
                }
                catch (NullReferenceException ex)
                {
                    ex.ToString();
                    //IsBusy = false;
                }

                //if (!string.IsNullOrEmpty(TextToSend))
                //{
                    //Messages.Insert(0, new UserMessage() { Text = TextToSend, User = App.User });
                    //TextToSend = string.Empty;
                //}

            });

            //Code to simulate reveing a new message procces
            /*
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (LastMessageVisible)
                {
                    Messages.Insert(0, new UserMessage() { Text = "New message test", User = "Mario" });
                }
                else
                {
                    DelayedMessages.Enqueue(new UserMessage() { Text = "New message test", User = "Mario" });
                    PendingMessageCount++;
                }
                return true;
            });
            */
        }

        private ChannelHandler ch = new ChannelHandler();




        public void Init()
        {
            var seconds = TimeSpan.FromSeconds(1);
            Device.StartTimer(seconds, () => {
                if (LastMessageVisible)
                {
                    ch.OnMessageReceived = (BaseChannel baseChannel, BaseMessage baseMessage) => {
                        Messages.Add((UserMessage)baseMessage);
                        //ChatPage.CurrentActivity.ScrollDown(Messages.Last());1
                    };
                }
                else
                {
                    ch.OnMessageReceived = (BaseChannel baseChannel, BaseMessage baseMessage) => {
                        DelayedMessages.Enqueue((UserMessage)baseMessage);
                        PendingMessageCount++;
                    };
                }
                return true;
            });
            AddChannelHandler("MyKey", ch);
        }

        public async void Load()
        {
            //IsBusy = true;
            await Task.Delay(1000);
            PreviousMessageListQuery mPrevMessageListQuery = Channel.CreatePreviousMessageListQuery();
            mPrevMessageListQuery.Load(30, true, (List<BaseMessage> messages, SendBirdException e) => {
                if (e != null)
                {
                    // Error.
                    return;
                }
                messages = messages.OrderByDescending(x => x.CreatedAt).ToList();
                foreach (var item in messages)
                {
                    Messages.Insert(0, (UserMessage)item);
                }
                //ChatPage.CurrentActivity.ScrollDown(Messages.Last());
            });
            //IsBusy = false;
            Init();
        }


        void OnMessageAppearing(UserMessage message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(UserMessage message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}