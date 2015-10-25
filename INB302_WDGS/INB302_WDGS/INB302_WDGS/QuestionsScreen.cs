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
    /*
     * A public class extending the editor Xamarin.Forms element
     */ 
    public class MyEditor : Editor
    {
        /*
         * Class constructer
         * 
         * Instantiates an Editor object using
         * the parent constructor
         */ 
        public MyEditor() : base() { }

        /*
         * Invalidates the Editor
         * 
         * When text is entered into the editor box
         * it does not increase the size of the editor
         * element. With this function being called
         * the editor "invalidates" its size and
         * resizes itself to match the length of
         * the text
         */ 
        public void InvalidateLayout()
        {
            this.InvalidateMeasure();
        }
    }

    public class QuestionsScreen : ContentPage
    {
        private String currentFile = "activity" + App.currentActivity + "Questions.txt";
        private Camera cameraOps = null;

        public QuestionsScreen()
        {
            //instantiates the camera class for use
            //to take images
            cameraOps = new Camera();

            //creating layouts to store each of the images within the grid
            //without this the background of the grid is white when we want
            //it to be black
            #region imageIconLayouts
 
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

            #endregion

            //stacklayout to host the questions editor, and scrollview
            //this is necessary because without it the scrollview
            //will override the grid layout and flow out of the grid
            StackLayout questionContent = new StackLayout
            {
                Padding = new Thickness(5, 0, 2, 0),
                BackgroundColor = Color.Black
            };

            MyEditor questions = new MyEditor
            {
                Text = "",
                Keyboard = Keyboard.Default,
                BackgroundColor = Color.Black,
            };

            //try load from file
            loadText(questions, currentFile);

            //when questions editor is unfocused save
            questions.Unfocused += (sender, e) =>
            {
                saveText(questions, currentFile);
            };

            //scrollview for the question editor
            ScrollView questionText = new ScrollView
            {
                IsClippedToBounds = true,
                Content = questions
            };

            questionContent.Children.Add(questionText);

            //creating each of the image icons for
            //the grid with their tap commands to load
            //correct file
            #region imageIcons

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

            questionIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity" + App.currentActivity + "Questions.txt"))
            });

            triviaIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity" + App.currentActivity + "Trivia.txt"))
            });

            taskIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => loadText(questions, "activity" + App.currentActivity + "Tasks.txt")),
            });

            cameraIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => takePicture()),
            });

            #endregion

            //adding each of the image icons to the relevant layout
            questionIconLayout.Children.Add(questionIcon);
            triviaIconLayout.Children.Add(triviaIcon);
            taskIconLayout.Children.Add(taskIcon);
            cameraIconLayout.Children.Add(cameraIcon);
            logoLayout.Children.Add(logo);

            //creating a new 5x8 grid
            Grid pageGrid = new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
                Opacity = 0.8,
                //row and column spacing creates a "bordered"
                //effect around each element
                RowSpacing = 2,
                ColumnSpacing = 2,
                IsClippedToBounds = true,
                Padding = new Thickness(.5, 1, .5, 0),
                //all row heights, and column widths are relative to
                //the devices screen size/resolution so they should
                //be an appropriate size on each type of device
                RowDefinitions = {
                    new RowDefinition {Height = 0},
                    new RowDefinition {Height = App.screenHeight / 12},
                    new RowDefinition {Height = App.screenHeight / 1.35},
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


            //adding each element to the grid
            pageGrid.Children.Add(backLbl, 1, 1); //back button

            pageGrid.Children.Add(logoLayout, 2, 7, 1, 2); //qut logo

            pageGrid.Children.Add(questionContent, 1, 7, 2, 3); //scrolling editor text

            pageGrid.Children.Add(questionIconLayout, 1, 3, 3, 4); //questions button

            pageGrid.Children.Add(triviaIconLayout, 3, 3); //trivia button

            pageGrid.Children.Add(taskIconLayout, 4, 3); //tasks button

            pageGrid.Children.Add(cameraIconLayout, 5, 3); //camera button

            pageGrid.Children.Add(nextLbl, 6, 3); //next activity button

            //creating a stacklayout and adding the grid to it
            StackLayout innerContent = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            innerContent.Children.Add(pageGrid);

            //making the pages content the stacklayout with the grid
            this.Content = innerContent;

            //add padding to account for the iOS status bar
            this.Padding = new Thickness(0, Device.OnPlatform(60, 0, 0), 0, 0);
            this.BackgroundImage = "background.png";

            //when the editor with the questions is unfocused
            //invalidate it so that it reformats the height
            questions.TextChanged += (s, e) =>
            {
                reformatEditorHeight(questions);
            };

            //on iOS when you click the text in the editor, it doesn't
            //automatically scroll the editor down to where the text is
            //with this added functionality when the question editor is
            //focused it should scroll to the position the user clicked
            //and when unfocused scroll back to the beginning of the
            //editor element.
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
                };
            }
        }

        /* 
         * simple function to move to the next activity
         * when the next button is clicked
         */
        private void goToNextActivity()
        {
            App.Current.MainPage = new HomeScreen();
        }

        /* simple function to go back to the activity
         * home screen when back button is clicked
         */ 
        private void goBack()
        {
            App.Current.MainPage = new HomeScreen();
        }

        /* 
         * function to reformat the question editors
         * height when text is entered that would
         * exceed the current editor height
         * i.e. makes the editor height grow dynamically
         */ 
        private void reformatEditorHeight(MyEditor questionElement)
        {
            questionElement.InvalidateLayout();
        }

        /*
         * gets the initial text for each question/trivia/task
         * of each activity. This is used for the first time the
         * application is loaded, and before any text files are
         * saved.
         * 
         * Params:
         * String fileName: which file text to grab
         * 
         * Returns:
         * the text for the question/trivia/task of the file
         */ 
        private String getBaseFileText(String fileName)
        {
            if (App.currentActivity == "1") 
            {
                switch (fileName)
                {
                    case "activity1Questions.txt":
                        return currentFile;
                    case "activity1Trivia.txt":
                        return currentFile;
                    case "activity1Tasks.txt":
                        return currentFile;
                    default:
                        break;
                }

            }
            else if (App.currentActivity == "2")
            {
                switch (fileName)
                {
                    case "activity2Questions.txt":
                        return currentFile;
                    case "activity2Trivia.txt":
                        return currentFile;
                    case "activity2Tasks.txt":
                        return currentFile;
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "3")
            {
                switch (fileName)
                {
                    case "activity3Questions.txt":
                        return currentFile;
                    case "activity3Trivia.txt":
                        return currentFile;
                    case "activity3Tasks.txt":
                        return currentFile;
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "4")
            {
                switch (fileName)
                {
                    case "activity4Questions.txt":
                        return currentFile;
                    case "activity4Trivia.txt":
                        return currentFile;
                    case "activity4Tasks.txt":
                        return currentFile;
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "5")
            {
                switch (fileName)
                {
                    case "activity5Questions.txt":
                        return currentFile;
                    case "activity5Trivia.txt":
                        return currentFile;
                    case "activity5Tasks.txt":
                        return currentFile;
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "6")
            {
                switch (fileName)
                {
                    case "activity6Questions.txt":
                        return currentFile;
                    case "activity6Trivia.txt":
                        return currentFile;
                    case "activity6Tasks.txt":
                        return currentFile;
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "7")
            {
                switch (fileName)
                {
                    case "activity7Questions.txt":
                        return currentFile;
                    case "activity7Trivia.txt":
                        return currentFile;
                    case "activity7Tasks.txt":
                        return currentFile;
                    default:
                        break;
                }
            }

            return "Something went wrong while loading," +
                   "Please try again by clicking the buttons" +
                   "below or clicking back and reloading the page";
        }

        /*
         * when the questions screen loads, or when the user
         * clicks to change from the questions to trivia or tasks,
         * or vice versa. This function loads the text for the current
         * activity for the question, trivia, or task in the activity.
         * 
         * Params:
         * Editor questionElement: the editor element that needs the text changed
         * String fileName: the file name to load the text from
         * 
         * Returns:
         * none
         */ 
        private void loadText(Editor questionElement, String fileName)
        {
            /*  
             * save the text from the previous question set before it swaps
             * this is only here because editor.unfocused() does not call
             * at all if the user clicks one of the question buttons
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
                questionElement.Text = getBaseFileText(fileName);
            }
        }

        /*
         * saves the text from the editor element into the filename
         * provided so that it can reloaded for later use
         * 
         * Params:
         * Editor questionElement: the editor element to get text from
         * String fileName: the file name used to save the text to
         */ 
        private void saveText(Editor questionElement, String fileName)
        {
            DependencyService.Get<ISaveAndLoad>().SaveText(fileName, questionElement.Text);
        }

        /*
         * Take a picture using the Xamarin.Forms.XLabs camera class
         */
        private async void takePicture()
        {
            if (App.cameraAccessGranted) {
                //call the take picture function from the XLabs camera class
                var mediaFile = await cameraOps.TakePicture();

                //if image failed for any reason
                if (mediaFile == null)
                {
                    //check if image failed because user cancelled it,
                    //or an error occured when capturing
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
                        if (DependencyService.Get<ISaveAndLoad>().saveImageToGallery("image", memoryStream.ToArray()) == "error")
                        {
                            await DisplayAlert("Image", "Your photo failed to save, please take it and try again", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Image", "The image has been saved to your gallery", "OK");
                        }
                    } 
                }
            }
            else
            { 
                await DisplayAlert("Error", "Camera access denied, please allow it in your settings and try again", "OK");
            }
        }
    }
}
