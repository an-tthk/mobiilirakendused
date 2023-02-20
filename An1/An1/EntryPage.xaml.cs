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
    public partial class EntryPage : ContentPage
    {
        Editor ed_user, ed_passwd;
        public EntryPage()
        {
            // InitializeComponent();
            ed_user = new Editor
            {
                Placeholder = "Sisesta siia tekst",
                BackgroundColor = Color.White,
                TextColor = Color.DarkGray
            };

            ed_passwd = new Editor
            {
                Placeholder = "Sisesta siia tekst",
                BackgroundColor = Color.White,
                TextColor = Color.DarkGray
            };

            var Back_btn = new Button
            {
                Text = "Tagasi",
                TextColor = Color.DarkSlateGray,
                BackgroundColor = Color.Gold
            };

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.LightGray,
                Children = {
                    ed_user, ed_passwd, Back_btn
                }
            };

            Back_btn.Clicked += Back_btn_Clicked;
        }

        private async void Back_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}