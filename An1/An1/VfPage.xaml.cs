using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace An1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VfPage : ContentPage
	{
		bool on_off_valgufoor = false, virvenda_valgufoor = false;
		private List<Button> buttons = new List<Button>();

		Label status = new Label
		{
			Padding = new Thickness(0, 30, 0, 0),
			FontAttributes = FontAttributes.Bold,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Ei ole sisestatud.",
			VerticalOptions = LayoutOptions.EndAndExpand
		};

		public async void CallGestureTap(Label lbl, string llbl, string rlbl)
		{
			if (lbl == null)
				return;

			if (lbl.Text == "Alusta valgusfoor palun!" || lbl.Text == llbl)
				return;
			
			var vf_hint = on_off_valgufoor || virvenda_valgufoor;
			
			lbl.Text = vf_hint ? llbl : "Alusta valgusfoor palun!";
			new Timer((o) => lbl.Dispatcher.BeginInvokeOnMainThread(() => lbl.Text = rlbl),
				null, 1500, System.Threading.Timeout.Infinite);
			
			await lbl.ScaleTo(vf_hint ? 3.0 : 1.2, 500, Easing.SinOut);
			await lbl.ScaleTo(1.0, 500, Easing.SinIn);
		}

		public Frame createDefFrame(string rlbl, string llbl)
		{
			var lbl = new Label
			{
				FontSize = 14,
				TextColor = Color.White,
				Text = rlbl,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			};

			return new Frame
			{
				Content = new StackLayout
				{
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					Children =
					{
						lbl
					}
				},
				BackgroundColor = Color.DarkGray,
				Opacity = 0.8,
				CornerRadius = 100,
				WidthRequest = 120,
				HeightRequest = 120,
				GestureRecognizers =
				{
					new TapGestureRecognizer
					{
						Command = new Command(() => CallGestureTap(lbl, llbl, rlbl))
					}
				}
			};
		}

		public void LockButtons(Button[] btn_except = null) => buttons?.Where((btn) => btn_except?.Contains(btn) != true)?.ForEach((btn) => btn.IsEnabled = false);
		public void UnlockButtons() => buttons?.ForEach((btn) => btn.IsEnabled = true);

		public VfPage()
		{
			var f1 = createDefFrame("PUNANE", "STOP!");
			var f2 = createDefFrame("KOLLANE", "OOTA!");
			var f3 = createDefFrame("ROHELINE", "MINE!");

			Button btn_sisse = new Button();
			Button btn_valja = new Button();
			Button btn_virvenda = new Button();

			btn_sisse = new Button
			{
				Text = "SISSE",
				BackgroundColor = Color.Khaki,
				TextColor = Color.DarkSlateGray,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Margin = new Thickness(10, 0),
				Command = new Command(() =>
				{
					if (on_off_valgufoor)
					{
						return;
					}

					on_off_valgufoor = true;
					LockButtons(new Button[] { btn_sisse, btn_valja });
					status.Text = "Oli sisestatud.";

					f1.BackgroundColor = Color.DarkRed;
					f2.BackgroundColor = Color.DarkGoldenrod;
					f3.BackgroundColor = Color.DarkGreen;
				})
			};

			btn_valja = new Button
			{
				Text = "VALJA",
				BackgroundColor = Color.Khaki,
				TextColor = Color.DarkSlateGray,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				Margin = new Thickness(10, 0),
				Command = new Command(() =>
				{
					if (!on_off_valgufoor && !virvenda_valgufoor)
					{
						return;
					}

					on_off_valgufoor = virvenda_valgufoor = false;
					status.Text = "Ei ole sisestatud.";

					f1.BackgroundColor = f2.BackgroundColor = f3.BackgroundColor = Color.DarkGray;
					UnlockButtons();
				})
			};

			btn_virvenda = new Button
			{
				Text = "VIRVENDA",
				BackgroundColor = Color.Khaki,
				TextColor = Color.DarkSlateGray,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Margin = new Thickness(10, 0),
				Command = new Command(async () =>
				{
					virvenda_valgufoor = !virvenda_valgufoor;
					status.Text = "Oli vareleb.";
					LockButtons(new Button[] { btn_virvenda, btn_valja });

					await Task.Run(async () =>
					{
						Frame[] vf_enum = { f1, f2, f3 };
						Color[] vf_colors = { Color.DarkRed, Color.DarkGoldenrod, Color.DarkGreen };

						while (virvenda_valgufoor == true)
						{
							int i = 0;
							foreach (var vf in vf_enum)
							{
								if (virvenda_valgufoor == false)
									break;

								vf_enum.ForEach((_vf) => _vf.BackgroundColor = Color.DarkGray);
								vf.BackgroundColor = vf_colors[i++];

								await Task.Delay(1000);
							}
						}
					});

					status.Text = "Ei ole sisestatud.";
					f1.BackgroundColor = f2.BackgroundColor = f3.BackgroundColor = Color.DarkGray;
					UnlockButtons();
				})
			};

			buttons.AddRange(new[] { btn_sisse, btn_valja, btn_virvenda });

			BackgroundColor = Color.LightGray;
			Content = new StackLayout
			{
				Padding = new Thickness(0, 10, 0, 10),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
				{
					new StackLayout
					{
						Children =
						{
							new Grid
							{
								Children =
								{
									new BoxView
									{
										BackgroundColor = Color.DimGray,
										HeightRequest = 510,
										WidthRequest = 190,
										VerticalOptions = LayoutOptions.Center,
										HorizontalOptions = LayoutOptions.Center,
										CornerRadius = 90
									},
									new StackLayout
									{
										Orientation = StackOrientation.Vertical,
										VerticalOptions = LayoutOptions.StartAndExpand,
										HorizontalOptions = LayoutOptions.CenterAndExpand,
										Margin = new Thickness(10),
										Children =
										{
											f1, f2, f3
										}
									}
								}
							}
						}
					},
					status,
					new FlexLayout
					{
						HeightRequest = 60,
						Margin = new Thickness(0, 10),
						Direction = FlexDirection.Row,
						AlignItems = FlexAlignItems.Stretch,
						JustifyContent = FlexJustify.SpaceEvenly,
						Children =
						{
							btn_sisse, btn_virvenda, btn_valja
						}
					}
				}
			};
		}
	}
}