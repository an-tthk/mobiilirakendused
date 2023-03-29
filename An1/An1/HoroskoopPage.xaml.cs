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
    public partial class HoroskoopPage : ContentPage
    {
        Entry zodiacEntry;
        Picker chooseZodiacSign;
        DatePicker zodiacDatePicker;
        Image zodiacImage;
        Label header, zodiacDescribe;
        ScrollView scrollView;
        public char[] charsToTrim = { '$', '*', ' ', '\'', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.', ':', ';', '-', '+', '#', '!', '/', '¤', '%', '&', '(', ')', '=', '?', '`', '[', ']', '{', '}', '<', '>' };
        public HoroskoopPage()
        {
            zodiacDatePicker = new DatePicker
            {
                Format = "D",
                Date = DateTime.Now
            };
            zodiacDatePicker.DateSelected += datePicker_DateSelected;

            chooseZodiacSign = new Picker
            {
                Title = "Выбери знак зодиака"
            };
            addingDataToPicker();
            chooseZodiacSign.SelectedIndexChanged += ChooseZodiacSign_SelectedIndexChanged;

            zodiacImage = new Image
            {
                Source = "koleso.jpeg"
            };

            zodiacDescribe = new Label
            {
                Text = "Описание",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            zodiacEntry = new Entry
            {
                Placeholder = "Введи знак зодиака",
                WidthRequest = 10,
                MaxLength = 10,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing, // кнопка полной очистки поля // field clear button
                Keyboard = Keyboard.Text, // клавиатура только для поля // field-only keyboard
                ReturnType = ReturnType.Search, // отображает в клавиатуре иконку лупы // displays a magnifying glass icon in the keyboard

            };
            zodiacEntry.Completed += Entry_Completed;

            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            grid.Children.Add
                (
                    header = new Label
                    {
                        Text = "Выбери дату, введи знак зодиака или выбери из списка:",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    }, 0, 0 // column, row
                );
            Grid.SetColumnSpan(header, 2);

            grid.Children.Add
                (
                    zodiacImage, 1, 1 // column, row
                );
            Grid.SetRowSpan(zodiacImage, 3);

            grid.Children.Add
                (
                    zodiacDatePicker, 0, 1 // column, row
                );

            grid.Children.Add
                (
                    zodiacEntry, 0, 2 // column, row
                );

            grid.Children.Add
                (
                    chooseZodiacSign, 0, 3 // column, row
                );

            grid.Children.Add
                (
                    scrollView = new ScrollView { Content = zodiacDescribe }, 0, 4 // column, row
                );
            Grid.SetColumnSpan(scrollView, 2);

            Content = grid;
        }



        private void ChooseZodiacSign_SelectedIndexChanged(object sender, EventArgs e)
        {
            zodiacEntry.Text = chooseZodiacSign.SelectedItem.ToString();
            Entry_Completed(sender, e);
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            header.Text = "Выбранная дата: " + e.NewDate.ToString("M");
            var month = e.NewDate.Month;
            var day = e.NewDate.Day;
            if (month == 3 && day >= 21 || month == 4 && day <= 20)
            {
                Oven();
            }
            else if (month == 4 && day >= 21 || month == 5 && day <= 20)
            {
                Telec();
            }
            else if (month == 5 && day >= 21 || month == 6 && day <= 20)
            {
                Bliznec();
            }
            else if (month == 6 && day >= 21 || month == 7 && day <= 22)
            {
                Rak();
            }
            else if (month == 7 && day >= 23 || month == 8 && day <= 22)
            {
                Lev();
            }
            else if (month == 8 && day >= 23 || month == 9 && day <= 22)
            {
                Deva();
            }
            else if (month == 9 && day >= 23 || month == 10 && day <= 22)
            {
                Vesi();
            }
            else if (month == 10 && day >= 23 || month == 11 && day <= 21)
            {
                Skorp();
            }
            else if (month == 11 && day >= 22 || month == 12 && day <= 21)
            {
                Strela();
            }
            else if (month == 12 && day >= 22 || month == 1 && day <= 19)
            {
                Koza();
            }
            else if (month == 1 && day >= 20 || month == 2 && day <= 18)
            {
                Voda();
            }
            else if (month == 2 && day >= 19 || month == 3 && day <= 20)
            {
                Ribi();
            }
            else
            {
                Pusto();
            }
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string zodiacEntryText = zodiacEntry.Text.ToLower().Trim(charsToTrim);

            if (zodiacEntryText == "овен")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 04, 14);
            }
            else if (zodiacEntryText == "телец")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 05, 15);
            }
            else if (zodiacEntryText == "близнецы")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 06, 15);
            }
            else if (zodiacEntryText == "рак")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 07, 17);
            }
            else if (zodiacEntryText == "лев")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 08, 17);
            }
            else if (zodiacEntryText == "дева")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 09, 17);
            }
            else if (zodiacEntryText == "весы")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 10, 18);
            }
            else if (zodiacEntryText == "скорпион")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 11, 17);
            }
            else if (zodiacEntryText == "стрелец")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 12, 16);
            }
            else if (zodiacEntryText == "козерог")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 01, 15);
            }
            else if (zodiacEntryText == "водолей")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 02, 13);
            }
            else if (zodiacEntryText == "рыбы")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 03, 15);
            }
            else
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                Pusto();
            }

            header.Text = "Твой выбор: " + zodiacEntryText;
        }

        public void Oven()
        {
            zodiacEntry.Text = "Овен";
            zodiacImage.Source = "oven.jpeg";
            zodiacDescribe.Text = "Дата: 21 марта – 20 апреля\nСтихия - огонь\nХарактеристика - амбициозный, независимый, нетерпеливый\nЦвета - ярко-красный, кармин, оранжевый, голубой, сиреневый, малиновый и все блестящие (фиолетовый цвет - неудачный)";
            chooseZodiacSign.SelectedIndex = 0;
        }

        public void Telec()
        {
            zodiacEntry.Text = "Телец";
            zodiacImage.Source = "telec.jpeg";
            zodiacDescribe.Text = "Дата: 21 апреля – 20 мая\nСтихия - земля\nХарактеристика - основательный, музыкальный, практичный\nЦвета - лимонный, желтый, ярко голубой, глубокий оранжевый, лимонно-зеленый, оранжевый и все весенние (красный цвет неудачный)";
            chooseZodiacSign.SelectedIndex = 1;
        }

        public void Bliznec()
        {
            zodiacEntry.Text = "Близнецы";
            zodiacImage.Source = "bliz.jpeg";
            zodiacDescribe.Text = "Дата: 21 мая – 20 июня\nСтихия - воздух\nХарактеристика - любопытный, нежный, добрый\nЦвета - фиолетовый, серый, светло-желтый, серо-голубой, оранжевый (зеленый цвет - неудачный)";
            chooseZodiacSign.SelectedIndex = 2;
        }

        public void Rak()
        {
            zodiacEntry.Text = "Рак";
            zodiacImage.Source = "rak.jpeg";
            zodiacDescribe.Text = "Дата: 21 июня – 22 июля\nСтихия - вода\nХарактеристика - интуитивный, эмоциональный, умный, страстный\nЦвета - белый, светло-голубой, синий, серебряный, цвет зеленого горошка (серый цвет - неудачный)";
            chooseZodiacSign.SelectedIndex = 3;
        }

        public void Lev()
        {
            zodiacEntry.Text = "Лев";
            zodiacImage.Source = "lev.jpeg";
            zodiacDescribe.Text = "Дата: 23 июля – 22 августа\nСтихия - огонь\nХарактеристика - горделивый, самоуверенный\nЦвета - пурпурный, золотой, оранжевый, алый, черный (белый цвет - неудачный)";
            chooseZodiacSign.SelectedIndex = 4;
        }

        public void Deva()
        {
            zodiacEntry.Text = "Дева";
            zodiacImage.Source = "deva.jpeg";
            zodiacDescribe.Text = "Дата: 23 августа – 22 сентября\nСтихия - земля\nХарактеристика - элегантный, организованный, добрый\nЦвета - белый, голубой, фиолетовый, зеленый";

            chooseZodiacSign.SelectedIndex = 5;
        }

        public void Vesi()
        {
            zodiacEntry.Text = "Весы";
            zodiacImage.Source = "vesi.jpeg";
            zodiacDescribe.Text = "Дата: 23 сентября – 22 октября\nСтихия - воздух\nХарактеристика - дипломатичный, артистичный, интеллигентный\nЦвета - темно-голубой, зеленый, морской волны и пастельные тона";
            chooseZodiacSign.SelectedIndex = 6;
        }

        public void Skorp()
        {
            zodiacEntry.Text = "Скорпион";
            zodiacImage.Source = "skorp.jpeg";
            zodiacDescribe.Text = "Дата: 23 октября – 21 ноября\nСтихия - вода\nХарактеристика - чарующий, страстный, независимый\nЦвета - желтый, темно-красный, алый, малиновый";
            chooseZodiacSign.SelectedIndex = 7;
        }

        public void Strela()
        {
            zodiacEntry.Text = "Стрелец";
            zodiacImage.Source = "strela.jpeg";
            zodiacDescribe.Text = "Дата: 22 ноября – 21 декабря\nСтихия - огонь\nХарактеристика - авантюрный, творческий, волевой\nЦвета - синий, голубой, фиолетовый, багровый";
            chooseZodiacSign.SelectedIndex = 8;
        }

        public void Koza()
        {
            zodiacEntry.Text = "Козерог";
            zodiacImage.Source = "koza.jpeg";
            zodiacDescribe.Text = "Дата: 22 декабря – 19 января\nСтихия - земля\nХарактеристика - дотошный, умный, деятельный\nЦвета - темно-зеленый, черный, пепельно-серый, синий, бледно-желтый, темно-коричневый и все темные тона";
            chooseZodiacSign.SelectedIndex = 9;
        }

        public void Voda()
        {
            zodiacEntry.Text = "Водолей";
            zodiacImage.Source = "voda.jpeg";
            zodiacDescribe.Text = "Дата: 20 января – 18 февраля\nСтихия - воздух\nХарактеристика - одаренный воображением, идеалистический, интуитивный\nЦвета - серый, лиловый, синезеленый, фиолетовый (черный цвет - неудачный)";
            chooseZodiacSign.SelectedIndex = 10;
        }

        public void Ribi()
        {
            zodiacEntry.Text = "Рыбы";
            zodiacImage.Source = "ribi.jpeg";
            zodiacDescribe.Text = "Дата: 19 февраля – 20 марта\nСтихия - вода\nХарактеристика - творческий, чувствительный, артистичный\nЦвета - пурпурный, фиолетовый, морской зелени, синий, лиловый, морской волны, стальной";
            chooseZodiacSign.SelectedIndex = 11;
        }

        public void Pusto()
        {
            zodiacEntry.Text = "";
            zodiacImage.Source = "kosmos.jpeg";
            zodiacDescribe.Text = "Данные отсутствуют";

        }

        public void addingDataToPicker()
        {
            chooseZodiacSign.Items.Add("Овен");
            chooseZodiacSign.Items.Add("Телец");
            chooseZodiacSign.Items.Add("Близнецы");
            chooseZodiacSign.Items.Add("Рак");
            chooseZodiacSign.Items.Add("Лев");
            chooseZodiacSign.Items.Add("Дева");
            chooseZodiacSign.Items.Add("Весы");
            chooseZodiacSign.Items.Add("Скорпион");
            chooseZodiacSign.Items.Add("Стрелец");
            chooseZodiacSign.Items.Add("Козерог");
            chooseZodiacSign.Items.Add("Водолей");
            chooseZodiacSign.Items.Add("Рыбы");
        }
    }
}