using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace INB302_WDGS {
	public class YouTubeScreen : ContentPage {
		public YouTubeScreen() {
            //Image backgroundImage = new Image () {
            //    Source = "background.png",
            //};

            //Image logo = new Image {
            //    Source = "QutLogo.png",
            //    HeightRequest = 45,
            //    HorizontalOptions = LayoutOptions.StartAndExpand,
            //    VerticalOptions = LayoutOptions.CenterAndExpand
            //};

            //StackLayout logoLayout = new StackLayout {
            //    BackgroundColor = Color.Black,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    Padding = new Thickness (2, 0, 0, 0)
            //};

            //logoLayout.Children.Add (logo);

            ////To be defined

            //Grid pageGrid = new Grid {
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    BackgroundColor = Color.White,
            //    Opacity = 0.8,
            //    RowSpacing = 2,
            //    ColumnSpacing = 2,
            //    IsClippedToBounds = true,
            //    Padding = new Thickness (.5, 1, .5, 0)
            //};

            //Label backLbl = new Label {
            //    Text = "<",
            //    BackgroundColor = Color.Black,
            //    TextColor = Color.White,
            //    FontSize = 24,
            //    XAlign = TextAlignment.Center,
            //    YAlign = TextAlignment.Center
            //};

            //backLbl.GestureRecognizers.Add (new TapGestureRecognizer {
            //    Command = new Command (() => goBack ())
            //});

            //Label nextLbl = new Label {
            //    Text = ">",
            //    BackgroundColor = Color.Black,
            //    TextColor = Color.White,
            //    FontSize = 24,
            //    XAlign = TextAlignment.Center,
            //    YAlign = TextAlignment.Center
            //};

            //nextLbl.GestureRecognizers.Add (new TapGestureRecognizer {
            //    Command = new Command (() => goToNextActivity ())
            //});

            ////Finished elements of grid

            //pageGrid.Children.Add (backLbl, 1, 1);
            //pageGrid.Children.Add (logoLayout, 2, 5, 1, 2);
            //pageGrid.Children.Add (nextLbl, 4, 3);

            //RelativeLayout content = new RelativeLayout ();
            //StackLayout innerContent = new StackLayout {
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center
            //};

            //innerContent.Children.Add (pageGrid);

            //content.Children.Add (backgroundImage,
            //    Constraint.Constant (0),
            //    Constraint.Constant (0),
            //    Constraint.RelativeToParent ((Parent) => {
            //        return App.screenWidth;
            //    }),
            //    Constraint.RelativeToParent ((Parent) => {
            //        return App.screenHeight;
            //    }));

            //this.Content = content;
            //this.Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
		}
		private void goToNextActivity() {
			App.Current.MainPage = new HomeScreen ();
		}

		private void goBack() {
			App.Current.MainPage = new HomeScreen ();
		}
    }
}
