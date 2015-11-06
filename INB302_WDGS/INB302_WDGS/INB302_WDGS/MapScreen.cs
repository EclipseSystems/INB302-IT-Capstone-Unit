using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Geolocator.Plugin;

namespace INB302_WDGS
{
	public class MapScreen : ContentPage
	{
		public MapScreen ()
		{
			#region imageIconLayout
			StackLayout logoLayout = new StackLayout {
				BackgroundColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (4, 0, 0, 0)
			};
			#endregion

			#region imageIcons
			Image logo = new Image {
				Source = "QutLogoWhite.png",
				HeightRequest = (App.screenHeight / 12) - 4,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			#endregion

			logoLayout.Children.Add (logo);

			#region mapContent
			StackLayout mapContent = new StackLayout {
				Padding = new Thickness (0, 2, 0, 0),
				BackgroundColor = Color.Black,
				Spacing = 0
			};

			var map = new Map (
				MapSpan.FromCenterAndRadius (new Position (37, -122), Distance.FromKilometers (10))) {
				IsShowingUser = true,
				HasZoomEnabled = true,
				HasScrollEnabled = true,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var govHouse = new Pin {
				Type = PinType.Place,
				Position = new Position (-27.4773531, 153.0289662),
				Label = "Old Government House",
				Address = "2 George Street, Brisbane, QLD 4000"
			};

			var parHouse = new Pin {
				Type = PinType.Place,
				Position = new Position (-27.4754214, 153.0249879),
				Label = "Parliament House",
				Address = "George St, Brisbane QLD 4000"
			};

			var execBuild = new Pin {
				Type = PinType.Place,
				Position = new Position (-27.4727061, 153.0242916),
				Label = "Executive Building",
				Address = "130 William Street, Brisbane QLD 4000"
			};

			var innsCourt = new Pin {
				Type = PinType.Place,
				Position = new Position (-27.4693386, 153.0186364),
				Label = "Inns of Court",
				Address = "107 North Quay, Brisbane QLD 4000"
			};

			var lawCourts = new Pin {
				Type = PinType.Place,
				Position = new Position (-27.468916, 153.0192682),
				Label = "Commonwealth Law Courts",
				Address = "119 North Quay, Brisbane QLD 4000"
			};

			var magCourt = new Pin {
				Type = PinType.Place,
				Position = new Position (-27.468916, 153.0192682),
				Label = "Magistrates' Court",
				Address = "363 George Street, Brisbane QLD 4000"
			};

			var queenCourts = new Pin {
				Type = PinType.Place,
				Position = new Position (-27.4674193, 153.0192154),
				Label = "QEII Courts Complex",
				Address = "415 George St, Brisbane QLD 4000"
			};

			var loc = CrossGeolocator.Current;
			loc.DesiredAccuracy = 100;

			var getLocation = new TapGestureRecognizer();
			getLocation.Tapped += async (sender, e) => {
				var posG = await loc.GetPositionAsync(timeoutMilliseconds:10000);
				map.MoveToRegion(new MapSpan (map.VisibleRegion.Center, posG.Latitude, posG.Longitude));
			};

			getLocation.NumberOfTapsRequired = 2;

			map.MapType = MapType.Street;
			map.PropertyChanged += (sender, e) => {
				Debug.WriteLine(e.PropertyName + " just changed!");
				if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
					CalculateBoundingCoordinates (map.VisibleRegion);
			};

			mapContent.Children.Add (map);

			map.Pins.Add (govHouse);
			map.Pins.Add (parHouse);
			map.Pins.Add (execBuild);
			map.Pins.Add (innsCourt);
			map.Pins.Add (lawCourts);
			map.Pins.Add (magCourt);
			map.Pins.Add (queenCourts);

			#endregion

			Grid pageGrid = new Grid {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White,
				Opacity = 0.8,
				RowSpacing = 2,
				ColumnSpacing = 2,
				IsClippedToBounds = true,
				Padding = new Thickness (.5, 1, .5, 0),
				RowDefinitions = {
					new RowDefinition { Height = 0 },
					new RowDefinition { Height = App.screenHeight / 12 },
					new RowDefinition { Height = App.screenHeight / 1.213 },
					new RowDefinition { Height = 0 }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = 0 },
					new ColumnDefinition { Width = App.screenWidth / 10 },
					new ColumnDefinition { Width = App.screenWidth / 5 - 32 },
					new ColumnDefinition { Width = App.screenWidth / 5 },
					new ColumnDefinition { Width = App.screenWidth / 5 },
					new ColumnDefinition { Width = App.screenWidth / 5 },
					new ColumnDefinition { Width = App.screenWidth / 10 },
					new ColumnDefinition { Width = 0 }
				}
			};

			Label backLbl = new Label {
				Text = "<",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 24,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			backLbl.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => goBack ())
			});

			pageGrid.Children.Add (backLbl, 1, 1);
			pageGrid.Children.Add (logoLayout, 2, 7, 1, 2);
			pageGrid.Children.Add (mapContent, 1, 7, 2, 3);

			StackLayout innerContent = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			innerContent.Children.Add (pageGrid);

			this.Content = innerContent;

			this.Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			this.BackgroundImage = "background.png";
		}

		private void goBack ()
		{
			App.Current.MainPage = new MainActivityScreen ();
		}

		static void CalculateBoundingCoordinates (MapSpan region)
		{
			// WARNING: I haven't tested the correctness of this exhaustively!
			var center = region.Center;
			var halfheightDegrees = region.LatitudeDegrees / 2;
			var halfwidthDegrees = region.LongitudeDegrees / 2;

			var left = center.Longitude - halfwidthDegrees;
			var right = center.Longitude + halfwidthDegrees;
			var top = center.Latitude + halfheightDegrees;
			var bottom = center.Latitude - halfheightDegrees;

			// Adjust for Internation Date Line (+/- 180 degrees longitude)
			if (left < -180) left = 180 + (180 + left);
			if (right > 180) right = (right - 180) - 180;
			// I don't wrap around north or south; I don't think the map control allows this anyway

			Debug.WriteLine ("Bounding box:");
			Debug.WriteLine ("                    " + top);
			Debug.WriteLine ("  " + left + "                " + right);
			Debug.WriteLine ("                    " + bottom);
		}
	}
}


