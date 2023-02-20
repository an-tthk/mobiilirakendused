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
            Button Ent_Btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.Fuchsia
            };

            Button Timer_Btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.Fuchsia
            };

            Button BoxView_Btn = new Button
            {
                Text = "BoxView",
                BackgroundColor = Color.Fuchsia
            };

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { Ent_Btn, Timer_Btn, BoxView_Btn }
            };

            st.BackgroundColor = Color.Aqua;
            Content = st;

            Ent_Btn.Clicked += Ent_Btn_Clicked;
            Timer_Btn.Clicked += Timer_Btn_Clicked;
            BoxView_Btn.Clicked += BoxView_Btn_Clicked;
        }

        private async void BoxView_Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxViewPage());
        }

        private async void Timer_Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Ent_Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}
