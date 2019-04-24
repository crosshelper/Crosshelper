using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Crosshelper.Models;
using Xamarin.Forms;

namespace CollectionViewDemos.ViewModels
{
    public class MonkeysViewModel : INotifyPropertyChanged
    {
        readonly IList<SearchpageViewcellItem> source;
        SearchpageViewcellItem selectedMonkey;
        int selectionCount = 1;

        public ObservableCollection<SearchpageViewcellItem> Monkeys { get; private set; }
        public IList<SearchpageViewcellItem> EmptyMonkeys { get; private set; }

        public SearchpageViewcellItem SelectedMonkey
        {
            get
            {
                return selectedMonkey;
            }
            set
            {
                if (selectedMonkey != value)
                {
                    selectedMonkey = value;
                }
            }
        }

        public string SelectedMonkeyMessage { get; private set; }

        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand MonkeySelectionChangedCommand => new Command(MonkeySelectionChanged);

        public MonkeysViewModel()
        {
            source = new List<SearchpageViewcellItem>();
            CreateMonkeyCollection();

            selectedMonkey = Monkeys.Skip(3).FirstOrDefault();
            MonkeySelectionChanged();
        }

        void CreateMonkeyCollection()
        {
            source.Add(new SearchpageViewcellItem
            {
                Name = "Baboon",
                Location = "Africa & Asia",
                Language = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });

            source.Add(new SearchpageViewcellItem
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Language = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
            });

            source.Add(new SearchpageViewcellItem
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Language = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
            });

            source.Add(new SearchpageViewcellItem
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Language = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg"
            });

            source.Add(new SearchpageViewcellItem
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Language = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg"
            });

            source.Add(new SearchpageViewcellItem
            {
                Name = "Howler Monkey",
                Location = "South America",
                Language = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg"
            });


            Monkeys = new ObservableCollection<SearchpageViewcellItem>(source);
        }

        void FilterItems(string filter)
        {
            var filteredItems = source.Where(monkey => monkey.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var monkey in source)
            {
                if (!filteredItems.Contains(monkey))
                {
                    Monkeys.Remove(monkey);
                }
                else
                {
                    if (!Monkeys.Contains(monkey))
                    {
                        Monkeys.Add(monkey);
                    }
                }
            }
        }

        void MonkeySelectionChanged()
        {
            SelectedMonkeyMessage = $"Selection {selectionCount}: {SelectedMonkey.Name}";
            OnPropertyChanged("SelectedMonkeyMessage");
            selectionCount++;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
