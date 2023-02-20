using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace An1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VfPage : ContentPage
    {
        bool on_off_valgufoor = false;
        Label status = new Label
        {
            Padding = new Thickness(0, 30, 0, 0),
            FontAttributes = FontAttributes.Bold,
            HorizontalTextAlignment = TextAlignment.Center,
            Text = "Ei ole sisestatud.",
        };

        public Frame createDefFrame(string rlbl, string llbl)
        {
            var tap = new TapGestureRecognizer();
            var lbl = new Label
            {
                FontSize = 14,
                TextColor = Color.White,
                Text = rlbl
            };

            var innerStackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    lbl
                }
            };

            tap.Tapped += async (sender, e) =>
            {
                if (lbl.Text == "Alusta valgusfoor palun!" || lbl.Text == llbl)
                    return;

                lbl.Text = on_off_valgufoor ? llbl : "Alusta valgusfoor palun!";
                new Timer((o) => lbl.Dispatcher.BeginInvokeOnMainThread(() => lbl.Text = rlbl),
                    null, 1500, System.Threading.Timeout.Infinite);

                await lbl.ScaleTo(on_off_valgufoor ? 3.0 : 1.2, 500);
                await lbl.ScaleTo(1.0, 500);
            };

            return new Frame
            {
                Content = innerStackLayout,
                BackgroundColor = Color.DarkGray,
                Opacity = 0.8,
                CornerRadius = 100,
                WidthRequest = 150,
                HeightRequest = 150,
                GestureRecognizers =
                {
                    tap
                }
            };
        }

        public VfPage()
        {
            var f1 = createDefFrame("PUNANE", "STOP!");
            var f2 = createDefFrame("KOLLANE", "OOTA!");
            var f3 = createDefFrame("ROHELINE", "MINE!");

            var btn_sisse = new Button
            {
                Text = "SISSE",
                BackgroundColor = Color.Khaki
            };

            var btn_valja = new Button
            {
                Text = "VALJA",
                BackgroundColor = Color.Khaki
            };

            var i_st = new StackLayout
            {
                Padding = new Thickness(0, 10, 0, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Children =
                {
                    btn_sisse, btn_valja
                }
            };

            btn_sisse.Clicked += (sender, e) =>
            {
                if (on_off_valgufoor)
                {
                    return;
                }

                on_off_valgufoor = true;
                status.Text = "Oli sisestatud.";

                f1.BackgroundColor = Color.DarkRed;
                f2.BackgroundColor = Color.DarkGoldenrod;
                f3.BackgroundColor = Color.DarkGreen;
            };

            btn_valja.Clicked += (sender, e) =>
            {
                if (!on_off_valgufoor)
                {
                    return;
                }

                on_off_valgufoor = false;
                status.Text = "Ei ole sisestatud.";

                f1.BackgroundColor = f2.BackgroundColor = f3.BackgroundColor = Color.DarkGray;
            };
            
            Content = new StackLayout
            {
                Padding = new Thickness(0, 10, 0, 0),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    f1, f2, f3, status, i_st
                }
            };
        }
    }
}