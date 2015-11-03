using System;
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
                
            };
            StackLayout ActivityImageLayout1 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                
            };
            StackLayout ActivityImageLayout2 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
               
            };
            StackLayout ActivityImageLayout3 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                
            };
            StackLayout ActivityImageLayout4 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
               
            };
            StackLayout ActivityImageLayout5 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                
            };
            StackLayout ActivityImageLayout6 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                
            };
            StackLayout ActivityImageLayout7 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                
            };
            #endregion

            //Layouts for the activity labels, to add padding
            # region LabelLayouts
            StackLayout ActivityLabelLayout1 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(8, 0, 0, 0)
                
            };
            StackLayout ActivityLabelLayout2 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(8, 0, 0, 0)
            };
            StackLayout ActivityLabelLayout3 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(8, 0, 0, 0)
            };
            StackLayout ActivityLabelLayout4 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(8, 0, 0, 0)
            };
            StackLayout ActivityLabelLayout5 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(8, 0, 0, 0)
            };
            StackLayout ActivityLabelLayout6 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(8, 0, 0, 0)
            };
            StackLayout ActivityLabelLayout7 = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(8, 0, 0, 0)
            };
            #endregion

            //creating each of the image icons for
            //the grid with their tap commands to load
            //correct file
            #region imageIcons

            Image logo = new Image
            {
                Source = "QutLogoWhite.png",
                HeightRequest = (App.screenHeight / 9),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Building1 = new Image
            {
                Source = "activityBuilding1.png",
                HeightRequest = (App.screenHeight / 9),
                WidthRequest = 3 * App.screenWidth / 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Building2 = new Image
            {
                Source = "activityBuilding2.png",
                HeightRequest = (App.screenHeight / 9),
                WidthRequest = 3 * App.screenWidth / 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Building3 = new Image
            {
                Source = "activityBuilding3.png",
                HeightRequest = (App.screenHeight / 9),
                WidthRequest = 3 * App.screenWidth / 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Building4 = new Image
            {
                Source = "activityBuilding4.png",
                HeightRequest = (App.screenHeight / 9),
                WidthRequest = 3 * App.screenWidth / 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Building5 = new Image
            {
                Source = "activityBuilding5.png",
                HeightRequest = (App.screenHeight / 9),
                WidthRequest = 3 * App.screenWidth / 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Building6 = new Image
            {
                Source = "activityBuilding6.png",
                HeightRequest = (App.screenHeight / 9),
                WidthRequest = 3 * App.screenWidth / 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image Building7 = new Image
            {
                Source = "activityBuilding7.png",
                HeightRequest = (App.screenHeight / 9),
                WidthRequest = 3 * App.screenWidth / 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            #endregion

            logoLayout.Children.Add(logo);
            ActivityImageLayout1.Children.Add(Building1);
            ActivityImageLayout2.Children.Add(Building2);
            ActivityImageLayout3.Children.Add(Building3);
            ActivityImageLayout4.Children.Add(Building4);
            ActivityImageLayout5.Children.Add(Building5);
            ActivityImageLayout6.Children.Add(Building6);
            ActivityImageLayout7.Children.Add(Building7);

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
                    new ColumnDefinition {Width = App.screenWidth / 2 },
                    new ColumnDefinition {Width = App.screenWidth / 3.33333},
                    new ColumnDefinition {Width = 0}

                }
            };

            //Labels for each building activity
            #region ActivitiesLabels
            Label Activity1 = new Label
            {
                Text = "1. Old Government House",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 14,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity2 = new Label
            {
                Text = "2. Parliament House",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 14,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity3 = new Label
            {
                Text = "3. Executive Building",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 14,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity4 = new Label
            {
                Text = "4. Inns of Court",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 14,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity5 = new Label
            {
                Text = "5. Commonwealth Law Courts",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 14,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity6 = new Label
            {
                Text = "6. Magistrates Court",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 14,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            Label Activity7 = new Label
            {
                Text = "7. Queen Elizabeth II Court Complex",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 14,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            #endregion

            ActivityLabelLayout1.Children.Add(Activity1);
            ActivityLabelLayout2.Children.Add(Activity2);
            ActivityLabelLayout3.Children.Add(Activity3);
            ActivityLabelLayout4.Children.Add(Activity4);
            ActivityLabelLayout5.Children.Add(Activity5);
            ActivityLabelLayout6.Children.Add(Activity6);
            ActivityLabelLayout7.Children.Add(Activity7);
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

            ActivityImageLayout1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("1"))
            });

            Activity2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("2"))
            });

            ActivityImageLayout2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("2"))
            });

            Activity3.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("3"))
            });

            ActivityImageLayout3.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("3"))
            });

            Activity4.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("4"))
            });

            ActivityImageLayout4.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("4"))
            });

            Activity5.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("5"))
            });

            ActivityImageLayout5.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("5"))
            });

            Activity6.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("6"))
            });

            ActivityImageLayout6.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("6"))
            });

            Activity7.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("7"))
            });

            ActivityImageLayout7.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToQuestionsScreen1("7"))
            });

            #endregion

            //The Back Button label
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
            pageGrid.Children.Add(ActivityLabelLayout1, 1, 3, 2, 3);
            pageGrid.Children.Add(ActivityLabelLayout2, 1, 3, 3, 4);
            pageGrid.Children.Add(ActivityLabelLayout3, 1, 3, 4, 5);
            pageGrid.Children.Add(ActivityLabelLayout4, 1, 3, 5, 6);
            pageGrid.Children.Add(ActivityLabelLayout5, 1, 3, 6, 7);
            pageGrid.Children.Add(ActivityLabelLayout6, 1, 3, 7, 8);
            pageGrid.Children.Add(ActivityLabelLayout7, 1, 3, 8, 9);
            pageGrid.Children.Add(ActivityImageLayout1, 3, 4, 2, 3);
            pageGrid.Children.Add(ActivityImageLayout2, 3, 4, 3, 4);
            pageGrid.Children.Add(ActivityImageLayout3, 3, 4, 4, 5);
            pageGrid.Children.Add(ActivityImageLayout4, 3, 4, 5, 6);
            pageGrid.Children.Add(ActivityImageLayout5, 3, 4, 6, 7);
            pageGrid.Children.Add(ActivityImageLayout6, 3, 4, 7, 8);
            pageGrid.Children.Add(ActivityImageLayout7, 3, 4, 8, 9);
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
