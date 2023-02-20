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
    public partial class TimerPage : ContentPage
    {
        bool on_off = false;
        public TimerPage()
        {
            InitializeComponent();
        }

        private async void ShowTime()
        {
            while (on_off)
            {
                timer_btn.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            lbl.Text = "Vajutatud";
        }

        private void timer_btn_Clicked(object sender, EventArgs e)
        {
            on_off = !on_off;

            if (on_off)
            {
                ShowTime();
            }
        }

        private async void tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}