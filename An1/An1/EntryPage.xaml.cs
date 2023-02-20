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
    public partial class EntryPage : ContentPage
    {
        Editor ed;
        Label lb;

        int i = 0;

        public EntryPage()
        {
            //InitializeComponent();

            ed = new Editor
            {
                Placeholder = "Sisesta siis teksti",
                BackgroundColor = Color.White,
                TextColor = Color.Red
            };

            ed.TextChanged += (sender, e) =>
            {
                lock (this)
                {
                    char key = e.NewTextValue?.LastOrDefault() ?? ' ';

                    if (key == 'A')
                    {
                        i++;
                        lb.Text = key.ToString() + ": " + i;
                    }
                }
            };

            lb = new Label
            {
                Text = "Mingi tekst",
                TextColor = Color.Orange
            };

            Button tagasi = new Button
            {
                Text = "Tagasi"
            };

            tagasi.Clicked += async (sender, e) => { await Navigation.PopAsync(); };

            StackLayout st = new StackLayout
            {
                Children =
                {
                    ed, lb, tagasi
                }
            };

            st.BackgroundColor = Color.Aqua;
            Content = st;
        }

        private void Ed_TextChanged(object sender, TextChangedEventArgs e)
        {
            ed.TextChanged -= Ed_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (key == 'A')
            {
                i++;
                lb.Text = key.ToString() + ": " + i;
            }

            ed.TextChanged += Ed_TextChanged;
        }
    }
}