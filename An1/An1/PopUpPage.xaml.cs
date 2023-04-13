using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace An1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpPage : ContentPage
    {
        Random rnd = new Random();

        public PopUpPage()
        {
            string[] btns =
            {
                "Check your knowledge of easy arifmetics.",
                "Check your knowledge of alphabet.",
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { }
            };

            foreach (string btn_name in btns)
            {
                (Content as StackLayout)
                    .Children
                    .Add(
                        new Button 
                        {
                            Text = btn_name,
                            TabIndex = btns.IndexOf(btn_name)
                        }
                    );
            }

            foreach (Button btn in (Content as StackLayout).Children.Where((o) => o.GetType() == typeof(Button)))
            {
                switch(btn.TabIndex)
                {
                    case 0:
                        btn.Clicked += OnCheckArifmeticsClicked;
                        break;
                    case 1:
                        btn.Clicked += OnCheckAlphabetClicked;
                        goto default; /* fallthrough */
                    default:
                        break;
                }
            }
        }

        async void OnCheckArifmeticsClicked(object sender, EventArgs e)
        {
            List<string> arifmetics = new List<string>();
            
            for (int i = 0; i < 9; i++)
            {
                arifmetics.Add(String.Format("multiply by {0}", i + 1));
            }

            string act = await DisplayActionSheet("Choose a multiplier", "Cancel", null, arifmetics.ToArray());
            string val = await DisplayPromptAsync("Input a number from 1 to 10", "");

            if (int.TryParse(val, out int number) == false || number < 1 || number > 10)
            {
                await DisplayAlert("Error", "Input a number from 1 to 10", "OK");
                return;
            }

            int.TryParse(act.Split(' ')[2], out int act_val);
            await DisplayAlert("Answer", $"{ number } x { act_val } = { number * act_val }", "OK");

            if (await DisplayAlert("Repeat?", "Do you want to repeat?", "Yes", "Cancel"))
            {
                OnCheckArifmeticsClicked(sender, e);
            }
        }

        async void OnCheckAlphabetClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Let's check your alphabet knowledge.", "Press OK to continue..", "OK");

            while (true)
            {
                char letter = (char)(rnd.Next(26) + 65);
                string input = await DisplayPromptAsync($"Input the next letter after \'{ letter }\'", "");

                if (string.IsNullOrEmpty(input) || char.IsLetter(input[0]) == false || input.Length > 1)
                {
                    await DisplayAlert("Error", "Please, input a letter!", "OK");
                }
                else if (char.ToUpper(input[0]) == letter + 1)
                {
                    await DisplayAlert("Correct!", $"Letter { input.ToUpper() } is the next letter after { letter }", "OK");
                }
                else
                {
                    await DisplayAlert("Incorrect!", $"Letter { input.ToUpper() } is NOT the next letter after { letter }, the next letter is { (char)(letter + 1) }", "OK");
                }

                if (await DisplayAlert("Repeat?", "Do you want to repeat?", "Yes", "Cancel") == false)
                    break;
            }
        }

    }
}