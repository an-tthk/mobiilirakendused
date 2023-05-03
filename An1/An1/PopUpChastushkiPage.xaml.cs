using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace An1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpChastushkiPage : ContentPage
	{
		Random rnd = new Random();
		List<string> chastushkiDb = new List<string>();
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		public PopUpChastushkiPage()
		{
			string[] btns =
			{
				"Hear some \"chastushka\"",
                "Add a \"chastushka\" to file"
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
				switch (btn.TabIndex)
				{
					case 0:
						btn.Clicked += OnCheckChistushkiClicked;
						break;
					case 1:
                        btn.Clicked += OnAddChistushkaClicked;
                        goto default; /* fallthrough */
					default:
						break;
				}
			}
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateChastushkiDb();
			CreateChastushkiDbIfEmpty();
        }

        private void UpdateChastushkiDb()
        {
            try
            {
                string chastushki = File.ReadAllText(Path.Combine(folderPath, "chastushki.txt"));

                foreach (string c in chastushki.Split(';'))
                {
                    if (string.IsNullOrEmpty(c))
                        continue;
					if (chastushkiDb.Exists((c_) => c_.Equals(c)))
						continue;

                    chastushkiDb.Add(c);
                }
            }
            catch (Exception e)
            {
                ;
            }
        }

		private void CreateChastushkiDbIfEmpty()
		{
			if (File.Exists(Path.Combine(folderPath, "chastushki.txt")))
				return;

			string chastushki = @"
				Сколько лет тебе - не знаю,
				И зачем мне это знать,
				На огромном торте свечки
				Можно взять и посчитать!..
				;
				Мы давно уже не пели,
				Берегли мы горлышко,
				А сейчас начнем мы петь
				Частушечки про солнышко...
				;
				Во всемирной паутине
				Можно сгинуть, словно, в тине
				Кликни ""Солнышко"" - поможет,
				Руку помощи предложит!..
				;
				Будем громко петь частушки,
				Чтобы стало веселей,
				Мы сегодня поздравляем
				Наших воспитателей!..
				;
				Выйду, выйду я плясать
				В новеньких ботинках,
				Все ребята говорят,
				Что я как картинка!..
				Школьные частушки
				;
				Эх, раз, ещё раз,
				Падежи, глаголы!
				Добрый день, любимый класс,
				Наша здравствуй, школа!..
				;
				На компьютере в игру
				Доиграл Денис к утру.
				В школе у доски Денис,
				Как компьютер, сам «завис»...
				;
				День учителя настал,
				Долго этот день я ждал,
				Нужно начинать скорей
				Праздник для учителей!..
				;
				Вот и лето пролетело,
				Школа ждёт своих ребят,
				Приглашает вновь учиться
				И мальчишек, и девчат!..
				;
				Ой, спасибо тебе, школа,
				Собрала ты снова нас,
				Дзынь! В звоночек позвонила,
				Позвала учиться в класс!..
				;
				К сентябрю, к сентябрю
				Я цветы друзьям дарю.
				Раз букет, два букет -
				Есть подарки, клумбы - нет!..
				;
				Подросли наши ребята,
				В школу все они пришли,
				Ну и мамы, папы тоже,
				Будто в первый класс пошли...
				;
				Побывал я в Паутине
				И залез я в Интернет.
				В голове от Интернета
				Просто полный винегрет!..
				;
				Вон Танюша побежала,
				В руках ""Эйвон"" каталог.
				Некогда учить уроки,
				Тени с тушью продает...
				;
				Мы веселые частушки
				Пропоем для вас сейчас,
				О себе, о дружбе нашей
				И о кое-ком из нас...
				;
				На плечах твоих не репа,
				Это, братец, голова!
				И поэтому нелепо
				Получать оценку ""ДВА""!..
				;
				Математику списать
				Разрешила Ленка,
				Что ж придется целоваться
				С ней на переменке!..
				;
				Целых 45 минут
				Ждем мы перемены.
				Только прозвенит звонок,
				Затрясутся стены...
				;
				Николай пример решал,
				А Сергей ему мешал.
				Вот, ребята, вам пример,
				Как нельзя решать пример!..
				;
				Спрячу я свои тетрадки,
				Закопаю свой дневник.
				Здравствуй, лето золотое,
				Я уже не ученик!..
				;
			";

            File.WriteAllText(Path.Combine(folderPath, "chastushki.txt"), chastushki);

            foreach (string c in chastushki.Split(';'))
			{
				if (string.IsNullOrEmpty(c))
					continue;
                if (chastushkiDb.Exists((c_) => c_.Equals(c)))
                    continue;

                chastushkiDb.Add(c);
            }
		}

        async void OnCheckChistushkiClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Let's hear some \"chastushki\".", "Press OK to continue..", "OK");

			if (chastushkiDb.Count != 0)
			{
				int c_id = -1;
                string act = await DisplayActionSheet($"Show random \"chastushka\" or enter a number (1-{chastushkiDb.Count}).", "Cancel", null,
                    "Show random \"chastushka\"", "Enter number");

				switch (act)
				{
					case "Show random \"chastushka\"":
						c_id = rnd.Next(1, chastushkiDb.Count) - 1;
						break;
					case "Enter number":
                        var chastushka_id = await DisplayPromptAsync("Enter number", $"A number of \"chastushka\" (1-{chastushkiDb.Count})", placeholder: "Number");
						Int32.TryParse(chastushka_id, out c_id);
                        c_id -= 1;
						goto default; /* fallthrough */
                    default:
                        break;
                }

				if (c_id >= 0 && c_id < chastushkiDb.Count)
				{
                    await DisplayAlert("Chastushka!", chastushkiDb.ElementAt(c_id), "Back");
                }
				else
				{
                    await DisplayAlert("Error", $"No chastushki with id {c_id}", "Cancel");
                } 
			}

            return;
        }

        async void OnAddChistushkaClicked(object sender, EventArgs e)
		{
			string chastushka = await DisplayPromptAsync("Enter a \"chastushka\".", "", placeholder: "Chastushka text.");
			
			if (chastushka != null && chastushkiDb.Any((o) => o.Equals(chastushka)) == false)
			{
                chastushkiDb.Add(chastushka);
				File.AppendAllText(Path.Combine(folderPath, "chastushki.txt"), chastushka + Environment.NewLine + ";");

                await DisplayAlert("Message!", "A \"chastushka\" added.", "Back");
            }

			return;
		}
    }
}