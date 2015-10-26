using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace INB302_WDGS
{
    public class HomeScreen : ContentPage
    {
        public HomeScreen()
        {
            /*
             * This isn't the actual home screen
             * it's just a placeholder for until
             * the real screen is developed
             */ 
			Label skipLbl = new Label
			{
				Text = "Go to Activity questions",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
			};

			skipLbl.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => goToQuestionsScreen()),
			});

            Label skip2Lbl = new Label
            {
                Text = "Go to Second Activity questions",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 20,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            skip2Lbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen2()),
            });

            Label skip3Lbl = new Label
            {
                Text = "this leads to youtube screen",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 20,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            skip3Lbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToYouTube()),
            });

            Label skip4Lbl = new Label
            {
                Text = "this leads to maps",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 20,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            skip4Lbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToMaps()),
            });

            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    skipLbl,
                    skip2Lbl,
                    skip3Lbl,
                    skip4Lbl
                }
            };

            this.Content = innerContent;
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BackgroundImage = "background.png";
        }

		private void goToQuestionsScreen()
		{
            App.currentActivity = "1";
            App.Current.MainPage = new QuestionsScreen();
		}

        private void goToQuestionsScreen2()
        {
            App.currentActivity = "2";
            App.Current.MainPage = new QuestionsScreen();
        }

        private void goToYouTube()
        {
            App.Current.MainPage = new YouTubeScreen();
        }

        private void goToMaps()
        {
            App.Current.MainPage = new MapScreen();
        }
    }
}
