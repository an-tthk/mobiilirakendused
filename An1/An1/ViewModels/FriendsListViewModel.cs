using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using An1.Views;
using Xamarin.Forms;

namespace An1.ViewModels
{
	public class FriendsListViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<FriendViewModel> Friends { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
		public ICommand CreateFriendCommand { get; protected set; }
		public ICommand DeleteFriendCommand { get; protected set; }
		public ICommand SaveFriendCommand { get; protected set; }
		public ICommand BackCommand { get; protected set; }

		FriendViewModel selectedFriend;
		public INavigation Navigation { get; set; }

		public FriendsListViewModel()
		{
			Friends = new ObservableCollection<FriendViewModel>();
			CreateFriendCommand = new Command(CreateFriend);
			DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);
        }

        public FriendViewModel SelectedFriend
		{
			get { return selectedFriend; }
			set
			{
				if (selectedFriend != value)
				{
					FriendViewModel tempFriend = value;
					selectedFriend = null;
					OnPropertyChanged("SelectedFriend");
					Navigation.PushAsync(new FriendPage(tempFriend));
				}
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveFriend(object obj)
        {
            FriendViewModel friend = obj as FriendViewModel;
            if (friend != null && friend.IsValid && !Friends.Contains(friend))
            {
                Friends.Add(friend);
            }
            Back();
        }

        private void DeleteFriend(object obj)
        {
            FriendViewModel friend = obj as FriendViewModel;
            if (friend != null)
            {
                Friends.Remove(friend);
            }
            Back();
        }

        private void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel = this }));
        }

    }
}
