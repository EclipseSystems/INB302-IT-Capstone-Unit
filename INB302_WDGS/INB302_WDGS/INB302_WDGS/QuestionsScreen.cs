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
        String currentFile = "activity1Questions.txt";
        public QuestionsScreen()
        {
            Image backgroundImage = new Image()
            {
                Source = "background.png",
            };

            Image logo = new Image
            {
                Source = "QutLogo.png",
                HeightRequest = 45,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            StackLayout logoLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(2, 0, 0, 0)
            };

            logoLayout.Children.Add(logo);

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
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = App.screenHeight - 140},
                    new RowDefinition {Height = 30},
                    new RowDefinition {Height = 0}
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition {Width = 0},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 15},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 15},
                    new ColumnDefinition {Width = App.screenWidth / 4 - 15},
                    new ColumnDefinition {Width = App.screenWidth / 4},
                    new ColumnDefinition {Width = 0}
                }
            };

            Editor questions = new Editor
            {
                Text = "",
                Keyboard = Keyboard.Default,
                //BackgroundColor = Color.Black //can't do this until after I make the custom renderer for iOS
            };

            //try load from file
            loadText(questions, currentFile);

            //when questions unfocused save
            questions.Unfocused += (sender, e) =>
            {
                saveText(questions, currentFile);
            };

            ScrollView QAText = new ScrollView
            {
                Padding = new Thickness(5, 0, 2, 0),
                BackgroundColor = Color.Black,
                IsClippedToBounds = true,
                Content = questions
            };

            Label backLbl = new Label
            {
                Text = "<",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 24,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            backLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => goBack())
            });

            Label questLbl = new Label
            {
                Text = "Questions",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            questLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity1Questions.txt"))
            });

            Label triviaLbl = new Label
            {
                Text = "Trivia",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            triviaLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity1Trivia.txt"))
            });

            Label taskLbl = new Label
            {
                Text = "Tasks",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            taskLbl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity1Tasks.txt")),
            });

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
                Command = new Command(() => goToNextActivity()),
            });

            pageGrid.Children.Add(backLbl, 1, 1); //back button

            pageGrid.Children.Add(logoLayout, 2, 5, 1, 2); //qut logo

            pageGrid.Children.Add(QAText, 1, 5, 2, 3); //scrolling editor text

            pageGrid.Children.Add(questLbl, 1, 3); //questions button

            pageGrid.Children.Add(triviaLbl, 2, 3); //trivia button

            pageGrid.Children.Add(taskLbl, 3, 3); //tasks button

            pageGrid.Children.Add(nextLbl, 4, 3); //next activity button

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
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
        }
        private void goToNextActivity()
        {
            App.Current.MainPage = new HomeScreen();
        }
        private void goBack()
        {
            App.Current.MainPage = new HomeScreen();
        }

        private void loadText(Editor questionElement, String fileName)
        {
            /*  save the text from the previous question set before it swaps
                this is only here because editor.unfocused() does not call
                at all if the user clicks one of the question buttons
            */
            if (questionElement.Text != "")
            {
                saveText(questionElement, currentFile);
            }

            //change current file to the one loaded when saving
            currentFile = fileName;

            try
            {
                questionElement.Text = DependencyService.Get<ISaveAndLoad>().LoadText(fileName);
            }
            catch
            {
                switch (fileName)
                {
                    case "activity1Questions.txt":
                        questionElement.Text = currentFile;
                        break;
                    case "activity1Trivia.txt":
                        questionElement.Text = currentFile;
                        break;
                    case "activity1Tasks.txt":
                        questionElement.Text = currentFile;
                        break;
                    default:
                        currentFile = "null";
                        questionElement.Text = "Something went wrong while loading," +
                                               "Please try again by clicking the buttons" +
                                               "below or going back and reloading the page";
                        break;
                }
            }
        }

        private void saveText(Editor questionElement, String fileName)
        {
            if (fileName != "null")
            {
                DependencyService.Get<ISaveAndLoad>().SaveText(fileName, questionElement.Text);
            }
        }
    }
}
