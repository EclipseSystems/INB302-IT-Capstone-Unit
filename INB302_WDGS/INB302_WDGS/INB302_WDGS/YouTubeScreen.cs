using System;

using Xamarin.Forms;

namespace INB302_WDGS
{
	public class YouTubeScreen : ContentPage
	{
		public YouTubeScreen ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


