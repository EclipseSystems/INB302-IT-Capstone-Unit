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

            RelativeLayout content = new RelativeLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            content.Children.Add(new Label { Text = "this is the home screen, it doesn't exist yet" },
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return Parent.Width; }),
                Constraint.RelativeToParent((Parent) => { return Parent.Height; }));

            this.Content = content;
        }
    }
}
