using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace An1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjaplaanPage : ContentPage
    {
        public AjaplaanPage()
        {
            TimePicker tp = new TimePicker
            {
                Time = new TimeSpan(0, 0, 0),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };
            
            tp.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Time")
                {
                    string[] messages = { "01:00 - Magama", "06:00 - Varahommik", "07:00 - Hommikusöök", "8:30 - Õppima", "12:00 - Õppima", "13:00 - Lõunasöök", "14:00 -Õppima", "16:00 - Sport", "17:00 - Kodune aeg", "18:00 - Õhtusöök", "19:00 -Õhtu ", "22:00 - Õhtu", "23:00 -Magama" };
                    string[] imageSources = { "magama.png", "sun.png", "hommikusook.png", "tool.png", "tool.png", "lounasook.png", "tool.png", "sport.png", "kodu.png", "ohtusook.png", "luna.png", "luna.png", "magama.png", };

                    var mes = messages.Where((m) =>
                    {
                        var next_m = messages.ElementAt(m == messages.Last() ? 0 : messages.IndexOf(m) + 1);
                        TimeSpan.TryParse(m.Split('-')[0].Trim(), out TimeSpan messageTime_m);
                        TimeSpan.TryParse(next_m.Split('-')[0].Trim(), out TimeSpan messageTime_next_m);

                        return tp.Time >= messageTime_m && tp.Time < messageTime_next_m;
                    }).FirstOrDefault();

                    if (!String.IsNullOrEmpty(mes))
                    {
                        var img = (this.Content as StackLayout).Children.Where((o) => o.GetType() == typeof(Image)).FirstOrDefault() as Image;
                        var lbl = (this.Content as StackLayout).Children.Where((o) => o.GetType() == typeof(Label)).FirstOrDefault() as Label;
                        lbl.Text = mes.Split('-')[1].Trim();
                        img.Source = ImageSource.FromFile(imageSources[messages.IndexOf(mes)]);
                    }
                }
            };

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    tp,
                    new Label
                    {
                        Text = "Label",
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Start
                    },
                    new Image
                    {
                        Source = "ggf.png"
                    }
                }
            };
        }
    }
}