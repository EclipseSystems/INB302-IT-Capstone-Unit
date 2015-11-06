using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace INB302_WDGS
{
	public class MainActivityScreen : ContentPage
	{
		public static int countActivity = 0;

		public MainActivityScreen ()
		{
			#region imageIconLayout
			StackLayout logoLayout = new StackLayout {
				BackgroundColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (4, 0, 0, 0)
			};

			StackLayout homeIconLayout = new StackLayout {
				BackgroundColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (0, 2, 0, 0)
			};

			StackLayout mapIconLayout = new StackLayout {
				BackgroundColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (0, 2, 0, 0)
			};

			StackLayout questionIconLayout = new StackLayout {
				BackgroundColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (0, 2, 0, 0)
			};

			StackLayout linksIconLayout = new StackLayout {
				BackgroundColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (0, 2, 0, 0)
			};
			#endregion

			#region videoEmbed
			StackLayout videoContent = new StackLayout {
				Padding = new Thickness (0, 2, 0, 0),
				BackgroundColor = Color.Transparent
			};

			// To do - YouTube plugin
			var browser = new WebView ();
			var htmlSource = new HtmlWebViewSource ();

			browser.HeightRequest = 324;
			browser.WidthRequest = 243;

			htmlSource.Html = @"<html>
<body>
<iframe id=""ytplayer"" type=""text/html"" width=""324"" height=""243""
src=""https://www.youtube.com/embed/PUizT-hqDbw?enablejsapi=1&fs=0&modestbranding=1&playsinline=1&rel=0&showinfo=0&iv_load_policy=3""
frameborder=""0"" allowfullscreen>
	<script>
		var tag = document.createElement('script');
		tag.src = ""https://www.youtube.com/iframe_api"";

		var firstScriptTag = document.getElementsByTagName('script')[0];
		firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

		var player;
		function onYouTubeIframeAPIReady() {
			player = new YT.Player('player', {
				height: '243',
				width: '324',
				videoId: 'PUizT-hqDbw',
				events: {
					'onReady': onPlayerReady,
					'onStateChange': onPlayerStateChange
				}
			});
		}

		function onPlayerReady(event) {
			event.target.playVideo();
		}

		var done = false;
		function onPlayerStateChange(event) {
			if (event.data == YT.PlayerState.PLAYING && !done) {
				setTimeout(stopVideo, 6000);
				done = true;
			}
		}
		function stopVideo() {
			player.stopVideo();
		}
	</script>
</body>
</html>";
			browser.Source = htmlSource;

			videoContent.Children.Add (browser);
			#endregion

			StackLayout descripContent = new StackLayout {
				Padding = new Thickness (3, 0, 4, 0),
				BackgroundColor = Color.Black
			};
					
			#region imageIcons
			Image logo = new Image {
				Source = "QutLogoWhite.png",
				HeightRequest = (App.screenHeight / 12) - 4,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Image homeIcon = new Image {
				Source = "homeIcon.png",
				HeightRequest = (App.screenHeight / 12) - 4,
				WidthRequest = 30
			};

			Image mapIcon = new Image {
				Source = "mapIcon.png",
				HeightRequest = (App.screenHeight / 12) - 4,
				WidthRequest = 30
			};

			Image questionIcon = new Image {
				Source = "questionIcon.png",
				BackgroundColor = Color.Black,
				HeightRequest = (App.screenHeight / 12) - 4,
				WidthRequest = 30
			};

			Image linksIcon = new Image {
				Source = "relevantLinksIcon.png",
				HeightRequest = (App.screenHeight / 12) - 4,
				WidthRequest = 30
			};

			homeIcon.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goHome ())
			});

			mapIcon.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToMap ())
			});

			questionIcon.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToQuestions ())
			});

			linksIcon.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToLinks ())
			});
			#endregion

			logoLayout.Children.Add (logo);
			homeIconLayout.Children.Add (homeIcon);
			mapIconLayout.Children.Add (mapIcon);
			questionIconLayout.Children.Add (questionIcon);
			linksIconLayout.Children.Add (linksIcon);

			Grid pageGrid = new Grid {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White,
				Opacity = 0.8,
				RowSpacing = 2,
				ColumnSpacing = 2,
				IsClippedToBounds = true,
				Padding = new Thickness (.5, 1, .5, 0),
				RowDefinitions = {
					new RowDefinition { Height = 0 },
					new RowDefinition { Height = App.screenHeight / 12 },
					new RowDefinition { Height = App.screenHeight / 2.35 },
					new RowDefinition { Height = App.screenHeight / 3.1725 },
					new RowDefinition { Height = App.screenHeight / 12 },
					new RowDefinition { Height = 0 }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = 0 },
					new ColumnDefinition { Width = App.screenWidth / 10 },
					new ColumnDefinition { Width = App.screenWidth / 5 - 32 },
					new ColumnDefinition { Width = App.screenWidth / 5 },
					new ColumnDefinition { Width = App.screenWidth / 5 },
					new ColumnDefinition { Width = App.screenWidth / 5 },
					new ColumnDefinition { Width = App.screenWidth / 10 },
					new ColumnDefinition { Width = 0 }
				}
			};

			#region descriptions
			Label govHouse_des = new Label {
				Text = "1. Old Government House",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
				XAlign = TextAlignment.Start
			};

			Label parHouse_des = new Label {
				Text = "2. Parliament House",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
				XAlign = TextAlignment.Start
			};

			Label execBuild_des = new Label {
				Text = "3. Executive Building",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
				XAlign = TextAlignment.Start
			};

			Label innsCourt_des = new Label {
				Text = "4. Inns of Court",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
				XAlign = TextAlignment.Start
			};

			Label comCourt_des = new Label {
				Text = "5. Commonwealth Law Courts",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
				XAlign = TextAlignment.Start
			};

			Label magCourt_des = new Label {
				Text = "6. Magistrates Court",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
				XAlign = TextAlignment.Start
			};

			Label qeIICourt_des = new Label {
				Text = "7. Queen Elizabeth II Court Complex",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
				XAlign = TextAlignment.Start
			};
			#endregion

			Label backLbl = new Label {
				Text = "<",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 24,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			backLbl.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goBack ())
			});
				
			Label nextLbl = new Label {
				Text = ">",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 24,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			nextLbl.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToNextActivity ())
			});

			#region descLoad
			if (App.currentActivity == "1") {
				descripContent.Children.Add (govHouse_des);
			} else if (App.currentActivity == "2") {
				descripContent.Children.Add (parHouse_des);
			} else if (App.currentActivity == "3") {
				descripContent.Children.Add (execBuild_des);
			} else if (App.currentActivity == "4") {
				descripContent.Children.Add (innsCourt_des);
			} else if (App.currentActivity == "5") {
				descripContent.Children.Add (comCourt_des);
			} else if (App.currentActivity == "6") {
				descripContent.Children.Add (magCourt_des);
			} else if (App.currentActivity == "7") {
				descripContent.Children.Add (qeIICourt_des);
			}
			#endregion

			pageGrid.Children.Add (backLbl, 1, 1);
			pageGrid.Children.Add (logoLayout, 2, 7, 1, 2);
			pageGrid.Children.Add (videoContent, 1, 7, 2, 3);
			pageGrid.Children.Add (descripContent, 1, 7, 3, 4);
			pageGrid.Children.Add (homeIconLayout, 1, 3, 4, 5);
			pageGrid.Children.Add (mapIconLayout, 3, 4);
			pageGrid.Children.Add (questionIconLayout, 4, 4);
			pageGrid.Children.Add (linksIconLayout, 5, 4);
			pageGrid.Children.Add (nextLbl, 6, 4);

			StackLayout innerContent = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			innerContent.Children.Add (pageGrid);

			this.Content = innerContent;

			this.Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			this.BackgroundImage = "background.png";
		}

		private void goBack ()
		{
			App.Current.MainPage = new HomeScreen ();
		}

		private void goHome ()
		{
			App.Current.MainPage = new HomeScreen ();
		}

		private void goToMap ()
		{
			App.Current.MainPage = new MapScreen ();
		}

		private void goToQuestions ()
		{
			App.Current.MainPage = new QuestionsScreen ();
		}

		private void goToLinks ()
		{
			App.Current.MainPage = new RelevantLinksScreen ();
		}

		private void goToNextActivity ()
		{
			countActivity = Int32.Parse (App.currentActivity);
			countActivity++;
			App.currentActivity = countActivity.ToString ();
			App.Current.MainPage = new MainActivityScreen ();
		}
	}
}


