using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace An1
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string, ContentPage> _pages = new Dictionary<string, ContentPage>
        {
            { "Valgusfoor", new VfPage() },
            { "Lumememm", new LumememmPage() }
        };

        public MainPage()
        {
            BackgroundColor = Color.LightGray;
            Content = new StackLayout { Orientation = StackOrientation.Vertical };

            foreach (var p in _pages)
            {
                var btn = new Button
                {
                    Text = p.Key,
                    TextColor = Color.Black,
                    BackgroundColor = Color.DarkKhaki,
                    TabIndex = _pages.IndexOf(p)
                };

                (Content as StackLayout).Children.Add(btn);
                btn.Clicked += async (sender, e) =>
                    await Navigation.PushAsync(_pages[(sender as Button).Text]);
            }
        }
    }
}
