using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using An1.Views;
using Plugin.Messaging;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

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
		public ICommand CallFriendCommand { get; protected set; }
		public ICommand SendSmsCommand { get; protected set; }

		FriendViewModel selectedFriend;
		public INavigation Navigation { get; set; }

		public FriendsListViewModel()
		{
			Friends = new ObservableCollection<FriendViewModel>();
			CreateFriendCommand = new Command(CreateFriend);
			DeleteFriendCommand = new Command(DeleteFriend);
			SaveFriendCommand = new Command(SaveFriend);
			BackCommand = new Command(Back);
			CallFriendCommand = new Command(CallFriend);
			SendSmsCommand = new Command(SendSmsFriend);

			if (Friends != null)
			{
				App.Db.GetItems().ForEach(
					friend => Friends.Add(new FriendViewModel(friend) { ListViewModel = this })
				);
			}
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
				App.Db.SaveItem(friend.Friend);
			}
			Back();
		}

		private void DeleteFriend(object obj)
		{
			FriendViewModel friend = obj as FriendViewModel;
			if (friend != null)
			{
				Friends.Remove(friend);
				App.Db.DeleteItem(friend.Friend.Id);
			}
			Back();
		}

		private void CreateFriend()
		{
			Navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel = this }));
		}

		private async void CallFriend(object obj)
		{
			FriendViewModel friend = obj as FriendViewModel;
			var phoneDialer = CrossMessaging.Current.PhoneDialer;

			if (!phoneDialer.CanMakePhoneCall)
			{
				await Application.Current.MainPage.DisplayAlert("Error!", $"Person doesn't have permission to made calls.", "Cancel");
				return;
			}

			if (friend != null && friend.IsValid)
				phoneDialer.MakePhoneCall(friend.Phone);
		}

		private async void SendSmsFriend(object obj)
		{
			FriendViewModel friend = obj as FriendViewModel;
			var smsMessenger = CrossMessaging.Current.SmsMessenger;
            
			if (!smsMessenger.CanSendSms)
			{
				await Application.Current.MainPage.DisplayAlert("Error!", $"Person doesn't have permission to send SMS messages.", "Cancel");
				return;
			}

			var _message = await Application.Current.MainPage.DisplayPromptAsync("Enter a message!", "", placeholder: "SMS Message.");

			if (friend != null && friend.IsValid && !string.IsNullOrEmpty(_message))
			   smsMessenger.SendSms(friend.Phone, _message);
		}
	}
}
