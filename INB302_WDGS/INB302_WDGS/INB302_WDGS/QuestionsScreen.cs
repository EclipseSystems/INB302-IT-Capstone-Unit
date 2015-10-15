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

            Grid pageGrid = new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
                Opacity = 0.8,
                RowSpacing = 2,
                ColumnSpacing = 2,
                IsClippedToBounds = true,
                Padding = new Thickness(.5, 1, .5, 0),
                RowDefinitions = {
                    new RowDefinition {Height = 0},
                    new RowDefinition {Height = 30},
                    new RowDefinition {Height = App.screenHeight - 140},
                    new RowDefinition {Height = 30},
                    new RowDefinition {Height = 0}
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition {Width = 0},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 20},
                    new ColumnDefinition {Width = App.screenWidth / 4},
                    new ColumnDefinition {Width = 0}
                }
            };

            Editor questions = new Editor
            {
                Keyboard = Keyboard.Default
                //BackgroundColor = Color.Black
            };

            try
            {
                setQuestionText(questions);
            }
            catch
            {
                questions.Text = "1. hi talk to me please";
            }

            ScrollView QAText = new ScrollView
            {
                Padding = new Thickness(5, 0, 2, 0),
                BackgroundColor = Color.Black,
                IsClippedToBounds = true,
                Content = questions
            };

            Label backLbl = new Label
            {
                Text = " <",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 24,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };

            backLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => saveText(questions, 0))
            });

            pageGrid.Children.Add(backLbl, 1, 1);

            pageGrid.Children.Add(new Label
            {
                Text = "Qut logo",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 20,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            }, 2, 5, 1, 2);

            pageGrid.Children.Add(QAText, 1, 5, 2, 3);

            pageGrid.Children.Add(new Label
            {
                Text = "1",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            }, 1, 3);

            pageGrid.Children.Add(new Label
            {
                Text = "2",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            }, 2, 3);

            pageGrid.Children.Add(new Label
            {
                Text = "3",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            }, 3, 3);

            Label nextLbl = new Label
            {
                Text = ">",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 24,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            nextLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => saveText(questions, 1)),
            });

            pageGrid.Children.Add(nextLbl, 4, 3);

            RelativeLayout content = new RelativeLayout();
            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            innerContent.Children.Add(pageGrid);

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
            this.Padding = new Thickness(0, Device.OnPlatform(10, 0, 0), 0, 0);
        }
        private void goToNextActivity()
        {
            App.Current.MainPage = new HomeScreen();
        }
        private void goBack()
        {
            App.Current.MainPage = new HomeScreen();
        }

        private void setQuestionText(Editor questionElement)
        {
            questionElement.Text = DependencyService.Get<ISaveAndLoad>().LoadText("activity1Questions.txt");
        }

        private void saveText(Editor questionElement, int page)
        {
            DependencyService.Get<ISaveAndLoad>().SaveText("activity1Questions.txt", questionElement.Text);
            if (page == 0)
            {
                goBack();
            } else {
                goToNextActivity();
            }
        }
    }
}
