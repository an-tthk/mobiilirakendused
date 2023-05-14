using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using An1.Models;

namespace An1.ViewModels
{
    public class FriendViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FriendsListViewModel lvm;
        public Friend Friend { get; private set; }

        public FriendViewModel()
        {
            Friend = new Friend();
        }

        public FriendViewModel(Friend friend)
        {
            Friend = friend;
        }

        public FriendsListViewModel ListViewModel
        {
            get => lvm;
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get => Friend.Name;
            set
            {
                if (Friend.Name != value)
                {
                    Friend.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Email
        {
            get => Friend.Email;
            set
            {
                if (Friend.Email != value)
                {
                    Friend.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Phone
        {
            get => Friend.Phone;
            set
            {
                if (Friend.Phone != value)
                {
                    Friend.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        public string PictureUrl
        {
            get => Friend.PictureUrl;
            set
            {
                if (Friend.PictureUrl != value)
                {
                    Friend.PictureUrl = value;
                    OnPropertyChanged("PictureUrl");
                }
            }
        }

        public bool IsValid
        {
            /* PictureUrl is excluded, since it's optional field. */
            get
            {
                return ((!string.IsNullOrEmpty(Name?.Trim())) ||
                    (!string.IsNullOrEmpty(Email?.Trim())) ||
                    (!string.IsNullOrEmpty(Phone?.Trim())));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
