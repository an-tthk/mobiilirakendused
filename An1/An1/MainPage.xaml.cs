using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace An1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var vf_btn = new Button
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.YellowGreen
            };

            vf_btn.Clicked += async (sender, e) => { await Navigation.PushAsync(new VfPage()); };

            Content = new StackLayout
            {
                Children =
                {
                    vf_btn
                }
            };
        }
    }
}
