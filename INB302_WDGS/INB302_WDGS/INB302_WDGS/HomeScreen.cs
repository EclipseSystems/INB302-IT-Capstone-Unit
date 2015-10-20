﻿using System;
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
            //NavigationPage.SetTitleIcon(this, "logo.png");
            NavigationPage.SetHasNavigationBar(this, false);

            Image backgroundImage = new Image()
            {
                Source = "background.png",
            };

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

            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    skipLbl
                }
            };

            this.Content = innerContent;
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BackgroundImage = "background.png";
        }

		private void goToQuestionsScreen()
		{
            App.Current.MainPage = new QuestionsScreen();
		}
    }
}
