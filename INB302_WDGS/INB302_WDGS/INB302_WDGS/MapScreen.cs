using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace INB302_WDGS {
    public class MapScreen : ContentPage {
        public MapScreen() {
            //NavigationPage.SetHasNavigationBar(this, false);

            //this.Navigation.PushModalAsync(new LoadingScreen());

            RelativeLayout content = new RelativeLayout();

            //Grid pageGrid = new Grid {
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    BackgroundColor = Color.Transparent,
            //    RowDefinitions = {
            //        new RowDefinition {Height = 60},
            //        new RowDefinition {Height = App.screenHeight - 60}
            //    },
            //    ColumnDefinitions = {
            //        new ColumnDefinition {Width = 0},
            //        new ColumnDefinition {Width = 0}
            //    }
            //};
            //
            var pageMap = new Map(
                MapSpan.FromCenterAndRadius(
                new Position(37, -122), Distance.FromMiles(0.3))) {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            //
            //pageGrid.Children.Add(pageMap, 1, 5, 2, 3);

            var backgroundImage = new Image() {
                Source = "background.png",
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            content.Children.Add(backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return App.screenWidth; }),
                Constraint.RelativeToParent((Parent) => { return App.screenHeight; }));

            content.Children.Add(pageMap,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return App.screenWidth; }),
                Constraint.RelativeToParent((Parent) => { return App.screenHeight; }));

            this.Content = content;
        }

        private void goToHomeScreen() {
            this.Navigation.PushModalAsync(new HomeScreen());
        }
    }
}
