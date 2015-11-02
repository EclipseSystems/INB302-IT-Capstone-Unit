﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace INB302_WDGS
{
    public class MainActivities : ContentPage
    {
        public MainActivities()
        {
            //creating layouts to store each of the images within the grid
            //without this the background of the grid is white when we want
            //it to be black

            #region imageIconLayouts
            StackLayout logoLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(4, 0, 0, 0)
            };
            #endregion

            //creating each of the image icons for
            //the grid with their tap commands to load
            //correct file
            #region imageIcons

            Image logo = new Image
            {
                Source = "QutLogoWhite.png",
                HeightRequest = (App.screenHeight / 12) - 4,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            #endregion

            logoLayout.Children.Add(logo);

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
                    new RowDefinition {Height = App.screenHeight /9},
                    new RowDefinition {Height = App.screenHeight /9},
                    new RowDefinition {Height = App.screenHeight /9},
                    new RowDefinition {Height = App.screenHeight /9},
                    new RowDefinition {Height = App.screenHeight /9},
                    new RowDefinition {Height = App.screenHeight /9},
                    new RowDefinition {Height = App.screenHeight /9},
                    new RowDefinition {Height = App.screenHeight /9},
                    new RowDefinition {Height = 0}
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition {Width = 0},
                    new ColumnDefinition {Width = App.screenWidth / 10},
                    new ColumnDefinition {Width = App.screenWidth / 2 - 32},
                    new ColumnDefinition {Width = 3*App.screenWidth / 10},
                    new ColumnDefinition {Width = 0}

                }
            };

            //Labels for each building activity
            #region ActivitiesLabels
            Label Activity1 = new Label
            {
                Text = " 1. OLD GOVERNMENT HOUSE",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 12,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity2 = new Label
            {
                Text = " 2. PARLIAMENT HOUSE",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 12,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity3 = new Label
            {
                Text = " 3. EXECUTIVE BUILDING",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 12,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity4 = new Label
            {
                Text = " 4. INNS OF COURT",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 12,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity5 = new Label
            {
                Text = " 5. COMMONWEALTH LAW COURTS",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 12,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity6 = new Label
            {
                Text = " 6. MAGISTRATES COURT",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 12,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity7 = new Label
            {
                Text = " 7. QUEEN ELIZABETH II COURTS COMPLEX",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 12,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            #endregion

            //Layouts for each building activity
            #region Activitieslayouts
            StackLayout Activity1Layout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(4, 0, 0, 0)
            };
            #endregion

            //tap register for each activity
            # region ActivityGestures
            Activity1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("1"))
            });
            Activity2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("2"))
            });
            Activity3.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("3"))
            });
            Activity4.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("4"))
            });
            Activity5.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("5"))
            });
            Activity6.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("6"))
            });
            Activity7.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("7"))
            });
            #endregion
            Label backLbl = new Label
            {
                Text = "<",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 24,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            backLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goBack())
            });
            
            //adding each element to the grid
            pageGrid.Children.Add(backLbl, 1, 1); //back button
            pageGrid.Children.Add(logoLayout, 2, 4, 1, 2);
            pageGrid.Children.Add(Activity1, 1, 3, 2, 3);
            pageGrid.Children.Add(Activity2, 1, 3, 3, 4);
            pageGrid.Children.Add(Activity3, 1, 3, 4, 5);
            pageGrid.Children.Add(Activity4, 1, 3, 5, 6);
            pageGrid.Children.Add(Activity5, 1, 3, 6, 7);
            pageGrid.Children.Add(Activity6, 1, 3, 7, 8);
            pageGrid.Children.Add(Activity7, 1, 3, 8, 9);

            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            innerContent.Children.Add(pageGrid);

            //making the pages content the stacklayout with the grid
            this.Content = innerContent;
            //add padding to account for the iOS status bar
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BackgroundImage = "background.png";
        }
        private void goBack()
        {
            App.Current.MainPage = new HomeScreen();
        }
        private void goToQuestionsScreen1(string act)
        {
            App.currentActivity = act;
            App.Current.MainPage = new QuestionsScreen();
        }
        
    }

}
