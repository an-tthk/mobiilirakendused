using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using An1.ViewModels;
using An1.Models;
using Plugin.Messaging;

namespace An1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendsListPage : ContentPage
    {
        public FriendsListPage()
        {
            InitializeComponent();
            this.BindingContext = new FriendsListViewModel() { Navigation = this.Navigation };
        }
    }
}