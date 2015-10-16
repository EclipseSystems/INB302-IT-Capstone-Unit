using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace INB302_WDGS
{
    public class Instructions : ContentPage
    {
        public Instructions()
        {
            //creating each layout to host all the pages content
            RelativeLayout content = new RelativeLayout();
            StackLayout innerContent = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            //creating a 5x6 grid 
            //background set to white with row/column spacing
            //which enables a border effect on the grid
            Grid pageGrid = new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
                Opacity = 0.8,
                RowSpacing = 2,
                ColumnSpacing = 2,
                IsClippedToBounds = true,
                Padding = new Thickness(.5, 1, .5, 0),
                RowDefinitions = {
                    new RowDefinition {Height = 0},
                    new RowDefinition {Height = 30},
                    new RowDefinition {Height = App.screenHeight - 140},
                    new RowDefinition {Height = 30},
                    new RowDefinition {Height = 0}
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition {Width = 0},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4},
                    new ColumnDefinition {Width = 0}
                }
            };

            //scrollview for the large instruction text
            ScrollView instructionText = new ScrollView
            {
                Padding = new Thickness(5, 0, 2, 0),
                BackgroundColor = Color.Black,
                IsClippedToBounds = true,
                Content = new Label
                {
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                            "Morbi et felis ut libero faucibus porta ut vitae diam. Integer " +
                            "lacinia facilisis iaculis. Sed sed felis accumsan, dictum enim ac, " +
                            "pretium nulla. Duis hendrerit lectus ut sapien sagittis, et eleifend " +
                            "urna iaculis. Sed convallis odio tristique pulvinar feugiat. Cum " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "ridiculus mus. Suspendisse rhoncus augue urna, sed posuere orci",
                    TextColor = Color.Gray,
                    BackgroundColor = Color.Black,
                    XAlign = TextAlignment.Start,
                    YAlign = TextAlignment.Start
                }
            };

            pageGrid.Children.Add(new Label
            {
                Text = " Instructions:",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 20,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            }, 1, 5, 1, 2);

            pageGrid.Children.Add(instructionText, 1, 5, 2, 3);

            pageGrid.Children.Add(new Label
            {
                Text = "",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            }, 1, 4, 3, 4);

            Label skipLbl = new Label
            {
                Text = "Skip",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 20,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            skipLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToHomeScreen()),
            });

            pageGrid.Children.Add(skipLbl, 4, 3);

            Image backgroundImage = new Image()
            {
                Source = "background.png",
            };

            innerContent.Children.Add(pageGrid);

            content.Children.Add(backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return App.screenWidth; }),
                Constraint.RelativeToParent((Parent) => { return App.screenHeight; }));

            content.Children.Add(innerContent,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return Parent.Width; }),
                Constraint.RelativeToParent((Parent) => { return Parent.Height; }));

            //this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            //if (Device.OS == TargetPlatform.iOS)
            //{
            //    content.Padding = new Thickness(0, 20, 0, 0);
            //}

            this.Content = content;
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
        }

        private void goToHomeScreen()
        {
            App.Current.MainPage = new HomeScreen();
        }
    }
}
