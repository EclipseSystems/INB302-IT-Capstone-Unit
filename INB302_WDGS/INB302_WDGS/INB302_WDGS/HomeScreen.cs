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
            #region imageIcons
            Image logo = new Image
            {
                Source = "QutLogoWhite.png",
                HeightRequest = (App.screenHeight / 12) - 4,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image WDGS_logo = new Image
            {
                Source = "logo.png",
                HeightRequest = App.screenHeight / 2.5,
                WidthRequest = App.screenWidth / 1.8,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Activities = new Image
            {
                Source = "activitiesIcon.png",
                HeightRequest = (App.screenHeight / 6) - 4,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Instruction = new Image
            {
                Source = "instructionIcon.png",
                HeightRequest = (App.screenHeight / 6) - 4,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            
            Activities.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen())
            });
            Instruction.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToInstructions())
            });
            #endregion

            #region imageIconLayouts
            StackLayout logoLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(4, 0, 0, 0)
            };
            StackLayout WDGS_logoLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(4, 0, 0, 0)
            };
            StackLayout ActivitiesLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(4, 0, 0, 0)
            };
            StackLayout InstructionLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(4, 0, 0, 0)
            };
            #endregion

            

            Grid pageGrid = new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
                Opacity = 0.8,
                //row and column spacing creates a "bordered"
                //effect around each element
                RowSpacing = 2,
                ColumnSpacing = 2,
                IsClippedToBounds = true,
                Padding = new Thickness(.5, 1, .5, 0),
                //all row heights, and column widths are relative to
                //the devices screen size/resolution so they should
                //be an appropriate size on each type of device
                RowDefinitions = {
                    new RowDefinition {Height = 0},
                    new RowDefinition {Height = App.screenHeight / 12},
                    new RowDefinition {Height = App.screenHeight / 1.52},
                    new RowDefinition {Height = App.screenHeight / 6 + 20},
                    new RowDefinition {Height = 0}
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition {Width = 0},
                    new ColumnDefinition {Width = App.screenWidth / 2 - 16},
                    new ColumnDefinition {Width = App.screenWidth / 2 - 16},
                    new ColumnDefinition {Width = 0}
                }
            };
            Label Act = new Label
            {
                Text = "ACTIVITIES",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 10,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };
            Label Ins = new Label
            {
                Text = "INSTRUCTIONS",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 10,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            logoLayout.Children.Add(logo);
            pageGrid.Children.Add(logoLayout, 1, 3, 1, 2);
            WDGS_logoLayout.Children.Add(WDGS_logo);
            pageGrid.Children.Add(WDGS_logoLayout, 1, 3, 2, 3);
            ActivitiesLayout.Children.Add(Activities);
            ActivitiesLayout.Children.Add(Act);
            pageGrid.Children.Add(ActivitiesLayout, 1, 2, 3, 4);
            InstructionLayout.Children.Add(Instruction);
            InstructionLayout.Children.Add(Ins);
            pageGrid.Children.Add(InstructionLayout, 2, 3, 3, 4);

           
            Label skipLbl = new Label
			{
				Text = "Go to Activity questions",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 10,
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
                FontSize = 10,
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
                FontSize = 10,
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
                FontSize = 10,
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

             };
            innerContent.Children.Add(pageGrid);

           
           


            this.Content = innerContent;
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BackgroundImage = "background.png";
        }

		private void goToQuestionsScreen()
		{
            App.currentActivity = "1";
            App.Current.MainPage = new MainActivities();
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
        private void goToInstructions()
        {
            App.Current.MainPage = new Instructions();
        }
    }
}
