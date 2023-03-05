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
            var lmemm_btn = new Button
            {
                Text = "Lumememm",
                TextColor = Color.Black,
                BackgroundColor = Color.DarkKhaki
            };

            lmemm_btn.Clicked += async (sender, e) => await Navigation.PushAsync(new LumememmPage());

            Content = new StackLayout
            {
                Children =
                {
                    lmemm_btn
                }
            };
        }
    }
}
