using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XPA_PickMedia_XLabs_XFP;

namespace INB302_WDGS
{
    public class MyEditor : Editor
    {
        public MyEditor()
            : base()
        {

        }

        public void InvalidateLayout()
        {
            this.InvalidateMeasure();
        }
    }

    public class QuestionsScreen : ContentPage
    {
        String currentFile = "activity" + App.currentActivity + "Questions.txt";
        private MyEditor questions;
        CameraViewModel cameraOps = null;

        public QuestionsScreen()
        {
            cameraOps = new CameraViewModel();

            StackLayout logoLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(4, 0, 0, 0)
            };

            StackLayout questionIconLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 2, 0, 0)
            };

            StackLayout triviaIconLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 2, 0, 0)
            };

            StackLayout taskIconLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 2, 0, 0)
            };

            StackLayout cameraIconLayout = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 2, 0, 0)
            };

            Image logo = new Image
            {
                Source = "QutLogoWhite.png",
                HeightRequest = (App.screenHeight / 12) - 4,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Image cameraIcon = new Image
            {
                Source = "cameraIcon.png",
                HeightRequest = (App.screenHeight / 12) - 4,
                WidthRequest = 30
            };

            Image questionIcon = new Image
            {
                Source = "questionIcon.png",
                HeightRequest = (App.screenHeight / 12) - 4,
                WidthRequest = 30
            };

            Image triviaIcon = new Image
            {
                Source = "triviaIcon.png",
                BackgroundColor = Color.Black,
                HeightRequest = (App.screenHeight / 12) - 4,
                WidthRequest = 30
            };

            Image taskIcon = new Image
            {
                Source = "taskIcon.png",
                HeightRequest = (App.screenHeight / 12) - 4,
                WidthRequest = 30
            };

            questionIconLayout.Children.Add(questionIcon);
            triviaIconLayout.Children.Add(triviaIcon);
            taskIconLayout.Children.Add(taskIcon);
            cameraIconLayout.Children.Add(cameraIcon);
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
                    new RowDefinition {Height = App.screenHeight / 12},
                    new RowDefinition {Height = App.screenHeight - 140},
                    new RowDefinition {Height = App.screenHeight / 12},
                    new RowDefinition {Height = 0}
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition {Width = 0},
                    new ColumnDefinition {Width = App.screenWidth / 10},
                    new ColumnDefinition {Width = App.screenWidth / 5 - 32},
                    new ColumnDefinition {Width = App.screenWidth / 5},
                    new ColumnDefinition {Width = App.screenWidth / 5},
                    new ColumnDefinition {Width = App.screenWidth / 5},
                    new ColumnDefinition {Width = App.screenWidth / 10},
                    new ColumnDefinition {Width = 0}
                }
            };

            StackLayout questionContent = new StackLayout
            {
                Padding = new Thickness(5, 0, 2, 0),
                BackgroundColor = Color.Black
            };

            questions = new MyEditor
            {
                Text = "",
                Keyboard = Keyboard.Default,
                BackgroundColor = Color.Black,
            };

            //try load from file
            loadText(questions, currentFile);

            //when questions unfocused save
            questions.Unfocused += (sender, e) =>
            {
                saveText(questions, currentFile);
            };

            ScrollView questionText = new ScrollView
            {
                IsClippedToBounds = true,
                Content = questions
            };

            questionContent.Children.Add(questionText);

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

            questionIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity" + App.currentActivity + "Questions.txt"))
            });

            Label triviaLbl = new Label
            {
                Text = "Trivia",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            triviaIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity" + App.currentActivity + "Trivia.txt"))
            });

            Label taskLbl = new Label
            {
                Text = "Tasks",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            taskIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity" + App.currentActivity + "Tasks.txt")),
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

            Label cameraLbl = new Label
            {
                Text = "camera",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            cameraIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => takePicture()),
            });

            pageGrid.Children.Add(backLbl, 1, 1); //back button

            pageGrid.Children.Add(logoLayout, 2, 7, 1, 2); //qut logo

            pageGrid.Children.Add(questionContent, 1, 7, 2, 3); //scrolling editor text

            pageGrid.Children.Add(questionIconLayout, 1, 3, 3, 4); //questions button

            pageGrid.Children.Add(triviaIconLayout, 3, 3); //trivia button

            pageGrid.Children.Add(taskIconLayout, 4, 3); //tasks button

            pageGrid.Children.Add(cameraIconLayout, 5, 3); //camera button

            pageGrid.Children.Add(nextLbl, 6, 3); //next activity button

            RelativeLayout content = new RelativeLayout();
            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            innerContent.Children.Add(pageGrid);

            this.Content = innerContent;
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BackgroundImage = "background.png";

            if (Device.OS == TargetPlatform.iOS)
            {
                questions.Focused += (s, e) =>
                {
                    double scrollPosition = questions.Y;
                    questionText.ScrollToAsync(0, scrollPosition, false);
                };

                questions.Unfocused += (s, e) =>
                {
                    questionText.ScrollToAsync(0, 0, false);
                    reformatEditorHeight();
                };
            }
        }
        private void goToNextActivity()
        {
            App.Current.MainPage = new HomeScreen();
        }
        private void goBack()
        {
            App.Current.MainPage = new HomeScreen();
        }

        private void reformatEditorHeight()
        {
            questions.InvalidateLayout();
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

        private async void takePicture()
        {
            if (App.cameraAccessGranted) { 
                var mediaFile = await cameraOps.TakePicture();

                if (mediaFile == null)
                {
                    if (cameraOps.Status != "Canceled")
                    {
                        await DisplayAlert("Error", "There was an error taking your picture, please try again", "OK");
                    }              
                }
                else
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        //converting to byte array for saving process
                        mediaFile.Source.CopyTo(memoryStream);

                        //saving the image to the devices gallery
                        DependencyService.Get<ISaveAndLoad>().saveImageToGallery("image", memoryStream.ToArray());
                    }

                    await DisplayAlert("Image", "The image has been saved to your gallery", "OK");
                }
            }
            else
            { 
                await DisplayAlert("Error", "Camera access denied, please allow it in your settings and try again", "OK");
            }
        }
    }
}
