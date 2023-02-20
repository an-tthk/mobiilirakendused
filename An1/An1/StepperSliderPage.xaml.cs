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
    public partial class StepperSliderPage : ContentPage
    {
        public StepperSliderPage()
        {
            var lbl = new Label
            {
                Text = "...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var sld = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red,
            };

            sld.ValueChanged += (sender, e) =>
            {
                lbl.Text = String.Format("Valitud: {0:F1}", e.NewValue);
                lbl.FontSize = e.NewValue;
                lbl.Rotation = e.NewValue;
            };

            var stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 1,
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.EndAndExpand
            };

            stp.ValueChanged += (sender, e) =>
            {
                lbl.Text = String.Format("Valitud: {0:F1}", e.NewValue);
                lbl.FontSize = e.NewValue;
                lbl.Rotation = e.NewValue;
            };

            Content = new StackLayout
            {
                Children =
                {
                    sld, lbl, stp
                }
            };
        }
    }
}