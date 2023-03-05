﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

using Rectangle = Xamarin.Forms.Rectangle;

namespace An1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LumememmPage : ContentPage
	{
		List<Button> buttons = new List<Button>();
		public Button createBtn(string text)
		{
			var btn = new Button
			{
				Text = text,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 60
			};
			
			buttons.Add(btn);
			return btn;
		}

		public void LockButtons(Button[] btn_except = null) => buttons.Where((btn) => btn_except?.Contains(btn) != true).ForEach((btn) => btn.IsEnabled = false);
		public void UnlockButtons() => buttons.ForEach((btn) => btn.IsEnabled = true);

		public LumememmPage()
		{
			Random rnd = new Random();
			bool lumm_disco = false, lumm_disco_block = false;

			var top_lbl = new Label
			{
				Margin = new Thickness(0, 20, 0, 0),
				Text = "Снеговик",
				FontSize = 16,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.DarkSlateGray,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			};

			var off_btn = createBtn("Спрятать");
			var on_btn = createBtn("Отобразить");
			var melt_btn = createBtn("Растопить");
			var rgb_btn = createBtn("Диско снеговик");

			var lmemm_abs = new AbsoluteLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children =
				{
					// Подставочка
					{
						new BoxView { BackgroundColor = Color.Silver, CornerRadius = 0 },
						new Rectangle { X = 0.5, Y = 0.78, Width = 200, Height = 20 },
						AbsoluteLayoutFlags.PositionProportional
					},

					// Ведро
					{
						new BoxView { BackgroundColor = Color.Silver, CornerRadius = 0 },
						new Rectangle { X = 0.5, Y = 0.75, Width = 80, Height = 45 },
						AbsoluteLayoutFlags.PositionProportional
					},

					// Голова
					{
						new BoxView { BackgroundColor = Color.Snow, CornerRadius = 60 },
						new Rectangle { X = 0.5, Y = 0.2, Width = 120, Height = 120 },
						AbsoluteLayoutFlags.PositionProportional
					},

					// Тело
					{
						new BoxView { BackgroundColor = Color.Snow, CornerRadius = 75 },
						new Rectangle { X = 0.5, Y = 0.38, Width = 150, Height = 150 },
						AbsoluteLayoutFlags.PositionProportional
					},

					// Низ
					{
						new BoxView { BackgroundColor = Color.Snow, CornerRadius = 90 },
						new Rectangle { X = 0.5, Y = 0.63, Width = 180, Height = 180 },
						AbsoluteLayoutFlags.PositionProportional
					}
				}
			};

			melt_btn.Clicked += async (sender, e) =>
			{
				var lmemm_enum = lmemm_abs.Children.Where(c => c.Opacity == 1 && c.BackgroundColor == Color.Snow);

				if (lmemm_enum.FirstOrDefault() != null)
				{
					top_lbl.Text = "Снеговик тает...";

					LockButtons(new Button[] { on_btn, off_btn, melt_btn });

					foreach (var c in lmemm_enum)
						await c.FadeTo(0, 2000);

					top_lbl.Text = "Снеговик растаял!";
				}

				//lmemm_abs.Children.ForEach(async (c) => await c.FadeTo(0, 2000));
			};

			on_btn.Clicked += (sender, e) =>
			{
				lmemm_abs.Children.ForEach((c) => c.Opacity = 1);
				top_lbl.Text = "Снеговик";
				UnlockButtons();
			};

			off_btn.Clicked += (sender, e) =>
			{
				lmemm_abs.Children.ForEach((c) => c.Opacity = 0);
				top_lbl.Text = "Снеговик пропал!";
				LockButtons(new Button[] { on_btn, off_btn });
			};

			rgb_btn.Clicked += async (sender, e) =>
			{
				lumm_disco = !lumm_disco;

				if (lumm_disco == true && lumm_disco_block == false)
				{
					LockButtons(new Button[] { sender as Button });
					lumm_disco_block = true;
					top_lbl.Text = "Снеговик танцует на диско!";

					await Task.WhenAll(
						Task.Run(async () =>
						{
							while (lumm_disco)
							{
								var rand = rnd.Next(0, 1);
								rand = rand == 1 ? -1 : 1;

								var scale_var = rand * rnd.NextDouble();
								
								await lmemm_abs.ScaleTo(0.9 + scale_var, 1000);
							}

							lmemm_abs.Scale = 1;
						}),
						Task.Run(async () =>
						{
							await this.ColorTo(this.BackgroundColor, Color.Tomato, cl => this.BackgroundColor = cl, 2500, Easing.SinInOut);
							while (lumm_disco)
							{
								await this.ColorTo(Color.Tomato, Color.DarkOliveGreen, cl => this.BackgroundColor = lumm_disco ? cl : Color.LightGray, lumm_disco ? 2500u : 0u, Easing.SinInOut);
								await this.ColorTo(Color.DarkOliveGreen, Color.DarkSlateBlue, cl => this.BackgroundColor = lumm_disco ? cl : Color.LightGray, lumm_disco ? 2500u : 0u, Easing.SinInOut);
								await this.ColorTo(Color.DarkSlateBlue, Color.Tomato, cl => this.BackgroundColor = lumm_disco ? cl : Color.LightGray, lumm_disco ? 2500u : 0u, Easing.SinInOut);
							}

							this.BackgroundColor = Color.LightGray;
						})
					);

					lumm_disco_block = false;
					top_lbl.Text = "Снеговик";
					UnlockButtons();
				}
				else
				{
					LockButtons();
				}
			};

			BackgroundColor = Color.LightGray;
			
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
				{
					top_lbl,
					lmemm_abs,
					new FlexLayout
					{
						Direction = FlexDirection.Row,
						AlignItems = FlexAlignItems.Center,
						JustifyContent = FlexJustify.SpaceEvenly,
						HeightRequest = 60,
						Children =
						{
							on_btn,
							off_btn,
							melt_btn,
							rgb_btn
						}
					}
				}
			};
		}
	}
}