using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Geolocator.Plugin;

namespace INB302_WDGS
{
	public class MapScreen : ContentPage
	{
		Map map;

		public MapScreen ()
		{
            StackLayout logoLayout = new StackLayout {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness (4, 0, 0, 0)
            };

            Image logo = new Image {
                Source = "QutLogoWhite.png",
                HeightRequest = (App.screenHeight / 12) - 4,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button getlocation = new Button {
                Text = String.Format ("Touch to get location.")
            };

            logoLayout.Children.Add (logo);

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
                    new RowDefinition { Height = App.screenHeight - (App.screenHeight / 12) },
                    new RowDefinition { Height = 0 }
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = 0 },
                    new ColumnDefinition { Width = App.screenWidth / 10 },
                    new ColumnDefinition { Width = App.screenWidth / 5 - 32 },
                    new ColumnDefinition { Width = 0 }
                }
            };

            StackLayout mapContent = new StackLayout {
                Padding = new Thickness (5, 0, 2, 0),
                BackgroundColor = Color.Black
            };

            //Define map content
            map = new Map {
                IsShowingUser = true,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            
            getlocation.Clicked += async (sender, e) => {
                var loc = CrossGeolocator.Current;

                loc.DesiredAccuracy = 100;

                var pos = await loc.GetPositionAsync (timeoutMilliseconds: 10000);

                map.MoveToRegion (MapSpan.FromCenterAndRadius (
                    new Position (pos), Distance.FromKilometers (0.5)));
            };
            
            var pin = new Pin {
                Type = PinType.Place,
                Position = new Position (-27.4773531, 153.0289662),
                Label = "Old Government House",
                Address = "2 George Street, Brisbane, QLD 4000"
            });
            
            var pin = new Pin {
            	Type = PinType.Place,
            	Position = new Position (-27.4754214, 153.0249879),
            	Label = "Parliament House",
            	Address = "George St, Brisbane QLD 4000"
            });
            
            var pin = new Pin {
            	Type = PinType.Place,
            	Position = new Position (-27.4727061,153.0242916),
            	Label = "Executive Building",
            	Address = "130 William Street, Brisbane QLD 4000"
            };
            
            var pin = new Pin {
            	Type = PinType.Place,
            	Position = new Position (-27.4693386, 153.0186364),
            	Label = "Inns of Court",
            	Address = "107 North Quay, Brisbane QLD 4000"
            };
            
            var pin = new Pin {
            	Type = PinType.Place,
            	Position = new Position (-27.468916, 153.0192682),
            	Label = "Commonwealth Law Courts",
            	Address = "119 North Quay, Brisbane QLD 4000"
            };
            
            var pin = new Pin {
            	Type = PinType.Place,
            	Position = new Position (-27.468916, 153.0192682),
            	Label = "Magistrates' Court",
            	Address = "363 George Street, Brisbane QLD 4000"
            };

            var pin = new Pin {
            	Type = PinType.Place,
            	Position = new Position (-27.4674193, 153.0192154),
            	Label = "QEII Courts Complex",
            	Address = "415 George St, Brisbane QLD 4000"
            };            
            map.Pins.Add (pin);

            var slider = new Slider (1, 18, 1);
            slider.ValueChanged += (sender, e) => {
                var zoomLevel = e.NewValue;
                var latlongdegrees = 360 / (Math.Pow (2, zoomLevel));
                Debug.WriteLine (zoomLevel + " -> " + latlongdegrees);
                if (map.VisibleRegion != null)
                    map.MoveToRegion (new MapSpan (map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };

            mapContent.Children.Add (map);
			mapContent.Children.Add (getlocation);
            mapContent.Children.Add (slider);
            //End map content

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

            pageGrid.Children.Add (logoLayout, 2, 1);

            pageGrid.Children.Add (mapContent, 1, 2);

			RelativeLayout content = new RelativeLayout ();
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
			App.Current.MainPage = new HomeScreen ();
		}
	}
}


