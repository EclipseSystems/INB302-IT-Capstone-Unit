using System;

using Xamarin.Forms;

namespace INB302_WDGS
{
	public class TwitterScreen : ContentPage
	{
		public TwitterScreen ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


