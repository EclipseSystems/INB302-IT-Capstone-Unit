using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace INB302_WDGS
{
    public class LoadingScreen : ContentPage
    {
        public LoadingScreen()
        {
            var backgroundImage = new Image()
            {
                Source = "background.png",
            };

            var logoImage = new Image()
            {
                Source = "logo.png",
            };

            ActivityIndicator loadActivity = new ActivityIndicator
            {
                Color = Device.OnPlatform(Color.Default, Color.Default, Color.Default),
                IsRunning = true,
                IsVisible = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            AbsoluteLayout innerContent = new AbsoluteLayout();

            innerContent.Children.Add(logoImage);
            AbsoluteLayout.SetLayoutFlags(logoImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(logoImage, new Rectangle(0.5, 0.4, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            innerContent.Children.Add(loadActivity);
            AbsoluteLayout.SetLayoutFlags(loadActivity, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(loadActivity, new Rectangle(0.5, 0.8, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            RelativeLayout content = new RelativeLayout();

            content.Children.Add(backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return App.screenWidth; }),
                Constraint.RelativeToParent((Parent) => { return App.screenHeight; }));

            content.Children.Add(innerContent,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return Parent.Width; }),
                Constraint.RelativeToParent((Parent) => { return Parent.Height; }));

            this.Content = content;
        }
    }
}
