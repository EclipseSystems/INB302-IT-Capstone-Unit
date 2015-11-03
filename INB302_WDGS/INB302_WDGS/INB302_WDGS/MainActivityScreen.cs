using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace INB302_WDGS
{
	public class MainActivityScreen : ContentPage
	{
		public MainActivityScreen ()
		{
			//Layout definition
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

			StackLayout triviaIconLayout = new StackLayout {
				BackgroundColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (0, 2, 0, 0)
			};

			//Images
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
				HeightRequest = (App.screenHeight / 12) - 4,
				WidthRequest = 30
			};

			Image triviaIcon = new Image {
				Source = "triviaIcon.png",
				HeightRequest = (App.screenHeight / 12) - 4,
				WidthRequest = 30
			};

			homeIcon.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToHomePage ()),
			});

			mapIcon.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToMapPage ()),
			});

			questionIcon.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToQuestionPage ()),
			});

			homeIconLayout.Children.Add (homeIcon);
			mapIconLayout.Children.Add (mapIcon);
			triviaIconLayout.Children.Add (triviaIcon);
			questionIconLayout.Children.Add (questionIcon);
			logoLayout.Children.Add (logo);

			//Grid definition
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
					new RowDefinition { Height = App.screenHeight / 6 },
					new RowDefinition { Height = App.screenHeight / 3 },
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

			//YouTube player section
			var browser = new WebView ();
			var htmlSource = new HtmlWebViewSource ();
			htmlSource.Html = @"<html>
<body>
	<iframe id=""ytplayer""
	type=""text/html""
	width=""720""
	height=""540""
	src=""https://www.youtube.com/embed/PUizT-hqDbw?enablejsapi=1&modestbranding=1&rel=0&showinfo=0""
	frameborder=""0"" allowfullscreen>
	<script>
		var tag = document.createElement('script');
		tag.src = ""https://www.youtube.com/iframe_api"";

		var firstScriptTag = document.getElementsByTagName('script')[0];
		firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

		var player;
		function onYouTubeIframeAPIReady() {
			player = new YT.Player('player', {
				height: '390',
				width: '640',
				videoId: 'M7lc1UVf-VE',
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
			Content = browser;

			StackLayout videoContent = new StackLayout {
				Padding = new Thickness (5, 0, 2, 0),
				BackgroundColor = Color.Black,
				Children = {
					browser
				}
			};

			//Video description section
			StackLayout despContent = new StackLayout {
				Padding = new Thickness (5, 0, 2, 0),
				BackgroundColor = Color.Black
			};

			Label descriptionLbl = new Label {
				Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin sollicitudin eget est volutpat varius. Aenean lorem urna, lacinia nec mollis ut, scelerisque quis odio. Integer maximus, ligula at aliquet vehicula, tortor erat aliquet neque, a venenatis nisl dui eu lorem. Fusce pulvinar felis sed orci commodo consectetur. Pellentesque a tempor nulla.",
				TextColor = Color.Gray,
				BackgroundColor = Color.Black
			};

			ScrollView description = new ScrollView {
				IsClippedToBounds = true,
				Content = descriptionLbl
			};

			despContent.Children.Add (description);

			//Go back button
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

			//Next activity button
			Label nextLbl = new Label {
				Text = ">",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 24,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			nextLbl.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToNextActivity ()),
			});

			pageGrid.Children.Add (backLbl, 1, 1);

			pageGrid.Children.Add (logoLayout, 2, 7, 1, 2);

			pageGrid.Children.Add (videoContent, 1, 7, 2, 3);

			pageGrid.Children.Add (despContent, 1, 7, 3, 3);

			pageGrid.Children.Add (homeIconLayout, 1, 4, 4, 4);

			pageGrid.Children.Add (mapIconLayout, 3, 4);

			pageGrid.Children.Add (questionIconLayout, 4, 4);

			pageGrid.Children.Add (triviaIconLayout, 5, 4);

			pageGrid.Children.Add (nextLbl, 6, 4);

			RelativeLayout content = new RelativeLayout ();
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
		
		private void goToNextActivity ()
		{
			App.Current.MainPage = new HomeScreen ();
		}

		private void goToHomePage ()
		{
			App.Current.MainPage = new HomeScreen ();
		}

		private void goToMapPage()
		{
			App.Current.MainPage = new MapScreen ();
		}
		
		private void goToQuestionPage()
		{
			App.currentActivity = "1";
			App.Current.MainPage = new QuestionsScreen();
		}
	}
}


