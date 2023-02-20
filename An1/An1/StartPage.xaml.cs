using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace An1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            // InitializeComponent();

            var Entry_btn = new Button
            {
                Text = "Ava Entry leht",
                TextColor = Color.DarkSlateGray,
                BackgroundColor = Color.Gold
            };

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.LightGray,
                Children = {
                    Entry_btn
                }
            };

            Entry_btn.Clicked += Entry_btn_Clicked;
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}