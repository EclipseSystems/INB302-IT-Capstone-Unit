using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace INB302_WDGS
{
    public class Instructions : ContentPage
    {
        public Instructions()
        {
            //NavigationPage.SetTitleIcon(this, "logo.png");

            this.Navigation.PushModalAsync(new LoadingScreen());
            this.loadInstructions();

            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            RelativeLayout content = new RelativeLayout();

            Grid pageGrid = new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Black,
                Opacity = 0.5,
                RowSpacing = 2,
                ColumnSpacing = 2,
                //WidthRequest = 10000,
                RowDefinitions = {
                    //new RowDefinition {Height = App.screenHeight - 170},
                    new RowDefinition {Height = 30}
                },
                ColumnDefinitions = 
                {
                    //new ColumnDefinition {Width = 20},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4}
                }
            };

            ScrollView instructionText = new ScrollView
            {
                Content = new Label
                {
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                            "Morbi et felis ut libero faucibus porta ut vitae diam. Integer " +
                            "lacinia facilisis iaculis. Sed sed felis accumsan, dictum enim ac, " +
                            "pretium nulla. Duis hendrerit lectus ut sapien sagittis, et eleifend " +
                            "urna iaculis. Sed convallis odio tristique pulvinar feugiat. Cum " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "sociis natoque penatibus et magnis dis parturient montes, nascetur " +
                            "ridiculus mus. Suspendisse rhoncus augue urna, sed posuere orci",
                    TextColor = Color.Silver,
                    XAlign = TextAlignment.Start,
                    YAlign = TextAlignment.Start
                }
            };

            //pageGrid.Children.Add(instructionText, 0, 4, 0, 1);

            //pageGrid.Children.Add(new Label
            //{
            //    Text = "1",
            //    TextColor = Color.Silver,
            //    XAlign = TextAlignment.Center,
            //    YAlign = TextAlignment.Center
            //}, 0, 1);

            //pageGrid.Children.Add(new Label
            //{
            //    Text = "2",
            //    TextColor = Color.Silver,
            //    XAlign = TextAlignment.Center,
            //    YAlign = TextAlignment.Center
            //}, 1, 1);

            //pageGrid.Children.Add(new Label
            //{
            //    Text = "3",
            //    TextColor = Color.Silver,
            //    XAlign = TextAlignment.Center,
            //    YAlign = TextAlignment.Center
            //}, 2, 1);

            //Label skipLbl = new Label
            //{
            //    Text = "Skip",
            //    TextColor = Color.Silver,
            //    XAlign = TextAlignment.End,
            //    YAlign = TextAlignment.Center
            //};

            //skipLbl.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => goToHomeScreen()),
            //});

            //pageGrid.Children.Add(skipLbl, 3, 1);

            pageGrid.Children.Add(new Label
            {
                Text = "1",
                TextColor = Color.Silver,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            }, 0, 0);

            pageGrid.Children.Add(new Label
            {
                Text = "2",
                TextColor = Color.Silver,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            }, 1, 0);

            pageGrid.Children.Add(new Label
            {
                Text = "3",
                TextColor = Color.Silver,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            }, 2, 0);

            Label skipLbl = new Label
            {
                Text = "Skip",
                TextColor = Color.Silver,
                XAlign = TextAlignment.End,
                YAlign = TextAlignment.Center
            };

            skipLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goToHomeScreen()),
            });

            pageGrid.Children.Add(skipLbl, 3, 0);

            var backgroundImage = new Image()
            {
                Source = FileImageSource.FromFile("image.png"),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var logoImage = new Image()
            {
                Source = "icon.png",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            TableView innerContentTable = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot()
                {
                    new TableSection() 
                    { 
                        new ViewCell
                        {
                            View = instructionText
                        },
                        new ViewCell
                        {
                            View = pageGrid
                        }
                    }
                }
            };

            //innerContent.Children.Add(backgroundImage);
            //innerContent.Children.Add(pageGrid);
            innerContent.Children.Add(innerContentTable);

            Frame innerContentWrapper = new Frame
            {
                Padding = new Thickness(.5, 1, .5, 0),
                Content = innerContent
            };

            content.Children.Add(backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return Parent.Width; }),
                Constraint.RelativeToParent((Parent) => { return Parent.Height; }));

            content.Children.Add(innerContentWrapper,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((Parent) => { return Parent.Width; }),
                Constraint.RelativeToParent((Parent) => { return Parent.Height; }));

            //innerContent.Children.Add(content);
            //innerContent.Children.Add(pageGrid);

            this.Content = content;
        }

        private async void loadInstructions()
        {
            await Task.Delay(3000);
            await this.Navigation.PopModalAsync();
        }

        private void goToHomeScreen()
        {
            this.Navigation.PushAsync(new HomeScreen());
        }
    }
}
