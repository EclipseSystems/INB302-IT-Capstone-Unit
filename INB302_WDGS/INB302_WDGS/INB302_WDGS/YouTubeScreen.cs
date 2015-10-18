using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace INB302_WDGS {
    public class YouTubeScreen : ContentPage {
        public YouTubeScreen() {
			NavigationPage.SetHasNavigationBar (this, false);

			RelativeLayout content = new RelativeLayout ();

			Grid pageGrid = new Grid {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent,
				RowDefinitions = {
					new RowDefinition { },
					new RowDefinition { },
					new RowDefinition { },
					new RowDefinition { }
				},
				ColumnDefinitions = {
					new ColumnDefinition {},
					new ColumnDefinition {},
					new ColumnDefinition {},
					new ColumnDefinition {}
				}
			};

			ScrollView instructions = new ScrollView {
				Padding = new Thickness (5, 0, 2, 0),
				BackgroundColor = Color.Black,
				Content = new Label {
					Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
					"Morbi et felis ut libero faucibus porta ut vitae diam. Integer " +
					"lacinia facilisis iaculis. Sed sed felis accumsan, dictum enim ac, " +
					"pretium nulla. Duis hendrerit lectus ut sapien sagittis, et eleifend " +
					"urna iaculis. Sed convallis odio tristique pulvinar feugiat. Cum ",
					TextColor = Color.Gray,
					BackgroundColor = Color.Black,
					XAlign = TextAlignment.Start,
					YAlign = TextAlignment.Start
				}
			};

			pageGrid.Children.Add (new Label {
				Text = "1. Old Government House",
				BackgroundColor = Color.Transparent,
				TextColor = Color.White,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Start
			}, 1, 3);

			pageGrid.Children.Add (instructions, 1, 5, 2, 3);

			nextPage.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goToHomeScreen ()),
			});

			var backgroundImage = new Image () {
				Source = "background.png",
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			content.Children.Add (backgroundImage,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((Parent) => {
					return App.screenHeight;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return App.screenWidth;
				}));

			this.Content = content;
        }

		private void goToHomeScreen() {
			this.Navigation.PushModalAsync (new HomeScreen ());
		}
    }
}
