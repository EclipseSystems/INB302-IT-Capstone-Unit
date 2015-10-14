using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace INB302_WDGS
{
    public class QuestionsScreen : ContentPage
    {
        public QuestionsScreen()
        {
            Image backgroundImage = new Image()
            {
                Source = "background.png",
            };

            Editor Answer1 = new Editor
            {
                Text = "Click here to answer",
                Keyboard = Keyboard.Default
            };

            RelativeLayout content = new RelativeLayout();
            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            innerContent.Children.Add(Answer1);

            content.Children.Add(backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return App.screenWidth; }),
                Constraint.RelativeToParent((Parent) => { return Device.OnPlatform(App.screenHeight + 20, App.screenHeight, App.screenHeight); }));

            content.Children.Add(innerContent,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return Parent.Width; }),
                Constraint.RelativeToParent((Parent) => { return Parent.Height; }));

            Content = content;
        }
    }
}
