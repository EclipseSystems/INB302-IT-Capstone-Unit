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
            StackLayout innerContent = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            /*this stacklayout is needed for the scrollview
            / if you do the padding and background colour in
            / the scrollview, it makes the background colour
            / of the grid disappear, but placing it in a stacklayout
            / and having the same padding/background colour
            / makes the scrollview not affect the grid.
            / see this thread for more info:
            / forums.xamarin.com/discussion/53974/grid-background-colour-disappears-on-load-any-way-to-fix
            */
            StackLayout instructionContent = new StackLayout
            {
                Padding = new Thickness(5, 0, 2, 0),
                BackgroundColor = Color.Black
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
                Padding = new Thickness(.5, 1, .5, 0),
                RowDefinitions = {
                    new RowDefinition {Height = 0},
                    new RowDefinition {Height = App.screenHeight / 12},
                    new RowDefinition {Height = App.screenHeight / 1.35},
                    new RowDefinition {Height = App.screenHeight / 12},
                    new RowDefinition {Height = 0}
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition {Width = 0},
                    new ColumnDefinition {Width = App.screenWidth / 4},
                    new ColumnDefinition {Width = App.screenWidth / 4},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 28},
                    new ColumnDefinition {Width = App.screenWidth / 4},
                    new ColumnDefinition {Width = 0}
                }
            };

			Label instructionLbl = new Label
			{
				Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin sollicitudin eget est volutpat varius. Aenean lorem urna, lacinia nec mollis ut, scelerisque quis odio. Integer maximus, ligula at aliquet vehicula, tortor erat aliquet neque, a venenatis nisl dui eu lorem. Fusce pulvinar felis sed orci commodo consectetur. Pellentesque a tempor nulla. Pellentesque fermentum elit et erat elementum, vitae tempus nisi molestie. Maecenas nisl odio, accumsan quis ligula eu, tincidunt ultrices orci. Quisque porttitor bibendum dui, blandit aliquam sem gravida id. Proin ut sem lorem. Etiam eu dapibus libero, vitae eleifend eros. Fusce vulputate nunc sem, ut rutrum mi convallis vel. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam eu eleifend turpis. Proin eget neque orci. Sed rhoncus lectus in sapien congue ultricies. Nulla odio erat, condimentum nec faucibus eget, volutpat quis quam. Morbi convallis luctus erat, sed ultrices ipsum elementum ut. Quisque accumsan quam in ligula varius, a ultricies diam dignissim. Fusce lobortis, risus vitae pellentesque semper, ligula nulla iaculis purus, at pharetra nisi ex in nunc. Duis vel mattis nisi. Vestibulum sagittis ac nibh sit amet vehicula. Vestibulum eleifend semper nisl sit amet vehicula. Sed sit amet lacinia est. Nulla in ex maximus, pharetra tortor suscipit, semper felis. Donec maximus quam turpis, eget facilisis ante interdum et. In et laoreet lacus. Donec bibendum sed metus pretium pretium. Duis at pretium nisi, non molestie dui. Morbi nec diam quis magna commodo vehicula vitae eget purus.",
				TextColor = Color.Gray,
				BackgroundColor = Color.Black,
			};

            ScrollView instructions = new ScrollView
            {
                IsClippedToBounds = true,
                Content = instructionLbl
            };

            instructionContent.Children.Add(instructions);
            pageGrid.Children.Add(instructionContent, 1, 5, 2, 3);

            pageGrid.Children.Add(new Label
            {
                Text = " Instructions:",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 24,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            }, 1, 5, 1, 2); 

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
                FontSize = 24,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            skipLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToHomeScreen()),
            });

            pageGrid.Children.Add(skipLbl, 4, 3);

            innerContent.Children.Add(pageGrid);

            this.Content = innerContent;
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BackgroundImage = "background.png";
        }

        private void goToHomeScreen()
        {
            App.Current.MainPage = new HomeScreen();
        }
    }
}
