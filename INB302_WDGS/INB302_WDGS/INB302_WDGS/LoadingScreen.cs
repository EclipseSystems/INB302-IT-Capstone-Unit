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
                //VerticalOptions = LayoutOptions.FillAndExpand,
                //HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var logoImage = new Image()
            {
                Source = "logo.png",
                
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            ActivityIndicator loadActivity = new ActivityIndicator
            {
                Color = Device.OnPlatform(Color.Default, Color.Blue, Color.Default),
                IsRunning = true,
                IsVisible = true,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var innerContent = new StackLayout
            {
                Padding = new Thickness(App.screenWidth / 7, App.screenHeight / 5, 0, 0),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            innerContent.Children.Add(logoImage);
            innerContent.Children.Add(loadActivity);

            RelativeLayout content = new RelativeLayout();
            
            content.Children.Add(backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => {return Parent.Width;}),
                Constraint.RelativeToParent((Parent) => {return Parent.Height;}));

            content.Children.Add(innerContent,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => {return Parent.Width / 2;}),
                Constraint.RelativeToParent((Parent) => {return Parent.Height / 2;}));

            this.Content = content;
        }
    }
}
