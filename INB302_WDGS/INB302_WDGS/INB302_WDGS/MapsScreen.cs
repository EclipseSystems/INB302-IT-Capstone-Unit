using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace INB302_WDGS
{
	public class MapsScreen : ContentPage
	{
		public MapsScreen ()
		{
			var map = new Map (
				          MapSpan.FromCenterAndRadius (
					          new Position (37, -122), Distance.FromMiles (0.3))) {
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add (map);
			Content = stack;

			var backgroundImage = new Image () {
				Source = "background.png",
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
		}

		private void goToHomeScreen()
		{
			this.Navigation.PushModalAsync (new HomeScreen ());
		}
	}
}


