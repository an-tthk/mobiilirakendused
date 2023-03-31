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

        string[] zodiac = { "Козерог", "Водолей", "Рыбы", "Овен", "Телец", "Близнецы", "Рак", "Лев", "Дева", "Весы", "Скорпион", "Стрелец" };

        public HoroskoopPage()
        {
            zodiacDatePicker = new DatePicker { Format = "D", Date = DateTime.Now };
            zodiacDatePicker.DateSelected += datePicker_DateSelected;

            chooseZodiacSign = new Picker { Title = "Выбери знак зодиака" };
            foreach (var item in zodiac)
            {
                chooseZodiacSign.Items.Add(item);
            }

            chooseZodiacSign.SelectedIndexChanged += (sender, e) =>
            {
                zodiacEntry.Text = chooseZodiacSign.SelectedItem.ToString();
                Entry_Completed(sender, e);
            };

            zodiacImage = new Image { Source = "koleso.jpeg" };
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
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
                Keyboard = Keyboard.Text,
                ReturnType = ReturnType.Search,
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
                },
                Children =
                {
                    {
                        header = new Label
                        {
                            Text = "Выбери дату, введи знак зодиака или выбери из списка:",
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                        },
                        0, 0
                    },
                    { zodiacImage, 1, 1 },
                    { zodiacDatePicker, 0, 1 },
                    { zodiacEntry, 0, 2 },
                    { chooseZodiacSign, 0, 3 },
                    { scrollView = new ScrollView { Content = zodiacDescribe }, 0, 4 }
                }
            };

            Grid.SetColumnSpan(header, 2);
            Grid.SetRowSpan(zodiacImage, 3);
            Grid.SetColumnSpan(scrollView, 2);

            Content = grid;
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            header.Text = "Выбранная дата: " + e.NewDate.ToString("M");

            var month = e.NewDate.Month;
            var day = e.NewDate.Day;

            string[] zodiacPics = { "koza.jpeg", "voda.jpeg", "ribi.jpeg", "oven.jpeg", "telec.jpeg", "bliz.jpeg", "rak.jpeg", "lev.jpeg", "deva.jpeg", "vesi.jpeg", "skorp.jpeg", "strela.jpeg" };
            string[] discribe =
            {
                "Дата: 22 декабря – 19 января\nСтихия - земля\nХарактеристика - дотошный, умный, деятельный\nЦвета - темно-зеленый, черный, пепельно-серый, синий, бледно-желтый, темно-коричневый и все темные тона",
                "Дата: 20 января – 18 февраля\nСтихия - воздух\nХарактеристика - одаренный воображением, идеалистический, интуитивный\nЦвета - серый, лиловый, синезеленый, фиолетовый (черный цвет - неудачный)",
                "Дата: 19 февраля – 20 марта\nСтихия - вода\nХарактеристика - творческий, чувствительный, артистичный\nЦвета - пурпурный, фиолетовый, морской зелени, синий, лиловый, морской волны, стальной",
                "Дата: 21 марта – 20 апреля\nСтихия - огонь\nХарактеристика - амбициозный, независимый, нетерпеливый\nЦвета - ярко-красный, кармин, оранжевый, голубой, сиреневый, малиновый и все блестящие (фиолетовый цвет - неудачный)",
                "Дата: 21 апреля – 20 мая\nСтихия - земля\nХарактеристика - основательный, музыкальный, практичный\nЦвета - лимонный, желтый, ярко голубой, глубокий оранжевый, лимонно-зеленый, оранжевый и все весенние (красный цвет неудачный)",
                "Дата: 21 мая – 20 июня\nСтихия - воздух\nХарактеристика - любопытный, нежный, добрый\nЦвета - фиолетовый, серый, светло-желтый, серо-голубой, оранжевый (зеленый цвет - неудачный)",
                "Дата: 21 июня – 22 июля\nСтихия - вода\nХарактеристика - интуитивный, эмоциональный, умный, страстный\nЦвета - белый, светло-голубой, синий, серебряный, цвет зеленого горошка (серый цвет - неудачный)",
                "Дата: 23 июля – 22 августа\nСтихия - огонь\nХарактеристика - горделивый, самоуверенный\nЦвета - пурпурный, золотой, оранжевый, алый, черный (белый цвет - неудачный)",
                "Дата: 23 августа – 22 сентября\nСтихия - земля\nХарактеристика - элегантный, организованный, добрый\nЦвета - белый, голубой, фиолетовый, зеленый",
                "Дата: 23 сентября – 22 октября\nСтихия - воздух\nХарактеристика - дипломатичный, артистичный, интеллигентный\nЦвета - темно-голубой, зеленый, морской волны и пастельные тона",
                "Дата: 23 октября – 21 ноября\nСтихия - вода\nХарактеристика - чарующий, страстный, независимый\nЦвета - желтый, темно-красный, алый, малиновый",
                "Дата: 22 ноября – 21 декабря\nСтихия - огонь\nХарактеристика - авантюрный, творческий, волевой\nЦвета - синий, голубой, фиолетовый, багровый"
            };

            int[] zodiacD = { 21, 20, 21, 22, 23, 23, 23, 23, 22, 22, 20, 19 };
            int index = (day <= zodiacD[month - 1]) ? month - 1 : (month + 10) % 12;
            zodiacEntry.Text = zodiac[index];
            zodiacDescribe.Text = discribe[index];
            zodiacImage.Source = ImageSource.FromFile(zodiacPics[index]);
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string zodiacEntryText = zodiacEntry.Text.ToLower().Trim();

            Dictionary<string, DateTime> zodiacEntryPairs = new Dictionary<string, DateTime>
            {
                { "овен", new DateTime(DateTime.Now.Year, 04, 14) },
                { "телец", new DateTime(DateTime.Now.Year, 05, 15) },
                { "близнецы", new DateTime(DateTime.Now.Year, 06, 15) },
                { "рак",  new DateTime(DateTime.Now.Year, 07, 17) },
                { "лев", new DateTime(DateTime.Now.Year, 08, 17) },
                { "дева", new DateTime(DateTime.Now.Year, 09, 17) },
                { "весы", new DateTime(DateTime.Now.Year, 10, 18) },
                { "скорпион", new DateTime(DateTime.Now.Year, 11, 17) },
                { "стрелец", new DateTime(DateTime.Now.Year, 12, 16) },
                { "козерог", new DateTime(DateTime.Now.Year, 01, 15) },
                { "водолей", new DateTime(DateTime.Now.Year, 02, 13) },
                { "рыбы", new DateTime(DateTime.Now.Year, 03, 15) }
            };

            zodiacDatePicker.Date = zodiacEntryPairs[zodiacEntryText];
            header.Text = "Твой выбор: " + zodiacEntryText;
        }
    }
}