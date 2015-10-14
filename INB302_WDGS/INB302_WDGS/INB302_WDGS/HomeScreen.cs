using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace INB302_WDGS
{
    public class HomeScreen : ContentPage
    {
        public HomeScreen()
        {
            //NavigationPage.SetTitleIcon(this, "logo.png");
            NavigationPage.SetHasNavigationBar(this, false);

            Image backgroundImage = new Image()
            {
                Source = "background.png",
            };

			Label skipLbl = new Label
			{
				Text = "Go to Activity questions",
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				FontSize = 20,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
			};

			skipLbl.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => goToQuestionsScreen()),
			});

            RelativeLayout content = new RelativeLayout();

			content.Children.Add(backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return Parent.Width; }),
                Constraint.RelativeToParent((Parent) => { return Parent.Height; }));

            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    skipLbl
                }
            };

            content.Children.Add(innerContent,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return Parent.Width; }),
                Constraint.RelativeToParent((Parent) => { return Parent.Height; }));

            this.Content = content;
        }

		private void goToQuestionsScreen()
		{
            App.Current.MainPage = new QuestionsScreen();
		}
    }
}
