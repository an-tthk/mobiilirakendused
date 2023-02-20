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
    public partial class BoxViewPage : ContentPage
    {
        BoxView box;
        Random random;
        public BoxViewPage()
        {
            int r = 0, g = 0, b = 0;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            
            box = new BoxView
            {
                Color = Color.FromRgb(r, g, b),
                CornerRadius = 10,
                WidthRequest = 200,
                HeightRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                GestureRecognizers =
                {
                    tap
                }
            };
            
            tap.Tapped += Tap_Tapped;
            
            Content = new StackLayout
            {
                Children =
                {
                    box
                }
            };
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            random = new Random();
            box.Color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}