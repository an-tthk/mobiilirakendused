using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using An1.Views;
using An1.Models;
using System.IO;

namespace An1
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "friends.db";
        public static FriendRepository db;
        public static FriendRepository Db
        {
            get
            {
                if (db == null)
                {
                    db = new FriendRepository(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FriendsListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
