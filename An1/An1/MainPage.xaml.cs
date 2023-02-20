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
            var btn_dateTime = new Button { Text = "DateTime Page" };
            var btn_stepperSlider = new Button { Text = "StepperSlider Page" };

            btn_dateTime.Clicked += async (sender, e) =>
                await Navigation.PushAsync(new DateTimePage());
            
            btn_stepperSlider.Clicked += async (sender, e) =>
                await Navigation.PushAsync(new StepperSliderPage());

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    btn_dateTime,
                    btn_stepperSlider
                }
            };
        }
    }
}
