using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace INB302_WDGS
{
    public class RelevantLinks : ContentPage
    {
        public RelevantLinks()
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
            StackLayout LinksContent = new StackLayout
            {
                Padding = new Thickness(3, 0, 4, 0),
                BackgroundColor = Color.Black
            };
           
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
                    new RowDefinition {Height = App.screenHeight / 1.213},
                    new RowDefinition {Height = 0}
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition {Width = 0},
                    new ColumnDefinition {Width = App.screenWidth / 10},
                    new ColumnDefinition {Width = App.screenWidth / 5 - 32},
                    new ColumnDefinition {Width = App.screenWidth / 5},
                    new ColumnDefinition {Width = App.screenWidth / 5},
                    new ColumnDefinition {Width = App.screenWidth / 5},
                    new ColumnDefinition {Width = App.screenWidth / 10},
                    new ColumnDefinition {Width = 0}
                }
            };
            # region Links
            Label Activity1 = new Label
            {
                Text = "1. Old Government House",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 18,
                XAlign = TextAlignment.Start
            };
            Label ogh = new Label
            {
                Text = "• http://www.ogh.qut.edu.au/",
                BackgroundColor = Color.Black,
                TextColor = Color.Blue,
                FontSize = 12,
                XAlign = TextAlignment.Start
            };
            Label atg = new Label
            {
                Text = "• http://www.govhouse.qld.gov.au/the-governor-of-queensland/about-the-governor.aspx",
                BackgroundColor = Color.Black,
                TextColor = Color.Blue,
                FontSize = 12,
                XAlign = TextAlignment.Start
            };
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
            ogh.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>  Device.OpenUri(new Uri("http://www.ogh.qut.edu.au/")))
            });
           
            LinksContent.Children.Add(Activity1);
            LinksContent.Children.Add(ogh);
            LinksContent.Children.Add(atg);

            //scrollview for the question editor
            ScrollView LinksText = new ScrollView
            {
                IsClippedToBounds = true,
                Content = LinksContent
            };
            //adding each element to the grid
            pageGrid.Children.Add(backLbl, 1, 1); //back button
            pageGrid.Children.Add(logoLayout, 2, 7, 1, 2); //qut logo
            pageGrid.Children.Add(LinksText, 1, 7, 2, 3);//scrolling text

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
            /* simple function to go back to the activity
             * home screen when back button is clicked
             */ 
            private void goBack()
            {
                App.Current.MainPage = new HomeScreen();
            }
      
        
    }
}
