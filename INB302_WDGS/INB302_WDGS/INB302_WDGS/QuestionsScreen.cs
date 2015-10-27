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
        private String currentFile = "activity" + App.currentActivity + "Tasks.txt";
        private Camera cameraOps = null;
        private Label questionTypeLabel;

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
                Padding = new Thickness(3, 0, 4, 0),
                BackgroundColor = Color.Black
            };

            MyEditor questions = new MyEditor
            {
                Text = "",
                Keyboard = Keyboard.Default,
                BackgroundColor = Color.Black,
            };

            questionTypeLabel = new Label
            {
                Text = "Activity Tasks",
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                FontSize = 20
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

            questionContent.Children.Add(questionTypeLabel);
            questionContent.Children.Add(questionText);
            //questionContent.Children.Add(scrollViewFix);

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
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
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
                        return "1. Eleven Queensland governors have lived and worked at Old Government House. What are the duties and responsibilities of the Governor?\n\n\n2. The land now referred to as Gardens Point is part of the traditional country of which people?\n\n\n3. What was the traditional name for Gardens Point?\n\n\n4. What was the official Government policy with respect to Indigenous Australians in the late nineteenth century?\n\n";
                    case "activity1Trivia.txt":
                        return "1. Why is the statue of Lady Diamantina positioned on the western side of Old Government House?\n\n\n2. What long-standing feud between New Zealand and Australia may be settled by looking at the history of Old Government House and the influence of one of its famous residents?\nHint: See Old Government House website (link provided in activities relevant links)\n\n";
                    case "activity1Tasks.txt":
                        return "Take a picture of, or with:\n\n1. The statue of Lady Diamantina Bowen.\n\n\n2. The shield on the wall at the entrance to OGH and make a note of who opened the building after its most recent renovations.\n\n";
                    default:
                        break;
                }

            }
            else if (App.currentActivity == "2")
            {
                switch (fileName)
                {
                    case "activity2Questions.txt":
                        return "Scroll down to see all questions\n\n1. In what year was the Queensland Parliament founded?\n\n\n2. What Coat of Arms is displayed on the plaque at the entrance? What do the various components of the Coat of Arms represent?\n\n\n3. The Queensland Parliament passed legislation in 1897 that significantly restricted the rights of Indigenous Australians. What was the name of this Act of Parliament?\n\n\n4. What is a referendum?\n\n\n5. What used to be located at the site (close to the Parliament House entrance) on which a statue of Queen Elizabeth II now stands? What are two interesting facts about the former building?\n\n";
                    case "activity2Trivia.txt":
                        return "1. Can you find another building of historical note nearby and what is the significance of this building? Take a photo of the building or a sign identifying the building\n\n";
                    case "activity2Tasks.txt":
                        return "1. Take a picture of the Parliament House Foundation plaque\n\n\n2. Locate a statue of Queen Elizabeth II not far from the entrance to Parliament House and take a selfie at the statue\n\n";
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "3")
            {
                switch (fileName)
                {
                    case "activity3Questions.txt":
                        return "1. What is the Executive Council? Who are its members?\n\n\n2. Who opened the Executive Building in 1971? What is an interesting fact about this person?\n\n\n3. Who are the current tenants of the former Executive building?\n\n\n4. Locate a marble tablet set into the George Street entrance of the former Executive Building. Who inscribed the message on this tablet? For what purpose was the message inscribed?\n\n";
                    case "activity3Trivia.txt":
                        return "1. The Queensland Government Printing Office (GoPrint) was established in 1862 to coordinate and regulate information concerning the Queensland Parliament. GoPrint’s functions included supporting the workings of Parliament and ensuring there was a permanent record of Parliament, legislation and government declarations. The GoPrint office was formerly located on George Street. Today, where can you find the Government Printing Office?\n\n\n2. Making your way down George Street, where was the District Court and the Supreme Court located prior to construction of the QEII Courts complex?\n\n";
                    case "activity3Tasks.txt":
                        return "1. At the current Executive Building, take a picture of the plaque at the front of the building\n\n\n2. Take a photo of the statue of a Queen and a judge on/or in the vicinity of the old building and make note of who the statues represent\n\n\n3. Take a picture of the old courtyard entrance\n\n";
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "4")
            {
                switch (fileName)
                {
                    case "activity4Questions.txt":
                        return "1. Who officially opened the current Inns of Court building in 1986?\n\n\n2. What is the title of the sculpture in the Inns of Court foyer?\n\n\n3. What is the sculptor’s connection to the Queensland Bar?\n\n\n4. What is a barrister?\n\n\n5. What is a solicitor?\n\n";
                    case "activity4Trivia.txt":
                        return "1. What does it mean for a barrister to ‘take silk’?\n\n";
                    case "activity4Tasks.txt":
                        return "1. Take a picture of the statue inside the Inns of Court foyer or a selfie with the plaque at the entrance of Inns of Court\n\n\n2. Find a building in the Central Business District (other than Inns of Court), that houses barristers’ chambers\n\n";
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "5")
            {
                switch (fileName)
                {
                    case "activity5Questions.txt":
                        return "1. Where does the High Court sit when in Brisbane?\n\n\n2. Who are the current High Court justices?\n\n\n3. Are any of the current justices of the High Court from Queensland?\n\n\n4. What are the qualifications required of a High Court justice?\n\n\n5. There are two plaques outside the building entrance: what does each of the plaques commemorate?\n\n";
                    case "activity5Trivia.txt":
                        return "1. Who was the first Chief Justice of Australia? What other important roles did he play in Australia’s political history?\n\n";
                    case "activity5Tasks.txt":
                        return "1. Take a picture of one of the plaques outside the Commonwealth Law Courts\n\n\n2. Take a picture at the Harry Gibbs Commonwealth Law Courts sign\n\n";
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "6")
            {
                switch (fileName)
                {
                    case "activity6Questions.txt":
                        return "1. What types of matters may be heard in the Magistrates Court? Provide 3 examples of a matter that may come before the Magistrates Court\n\n\n2. Where was the Brisbane Magistrates Court previously located?\n\n";
                    case "activity6Trivia.txt":
                        return "1. What do the waves at the right-hand side of the Magistrates’ Court entrance represent/symbolise?\n\n";
                    case "activity6Tasks.txt":
                        return "1. Take a photo at the entrance to the Courts complex\n\n";
                    default:
                        break;
                }
            }
            else if (App.currentActivity == "7")
            {
                switch (fileName)
                {
                    case "activity7Questions.txt":
                        return "Scroll down to see all questions\n\n1. You’ll find an extract of legislation on display near Themis. What is the citation to the Act?\n\n\n2. Where was the sculpture of Themis made?\n\n\n3. Read through the linked speech by the Honourable Paul De Jersey, former Queensland Chief Justice and current Queensland Governor. According to the former Chief Justice, what are the ‘themes’ of Themis and what values must Australians strive to preserve?\n\n\n4. What types of matters may be heard in the District Court?\n\n\n5. What types of matters may be heard in the Supreme Court?\n\n";
                    case "activity7Trivia.txt":
                        return "1. Why isn’t Themis blindfolded?\n\n";
                    case "activity7Tasks.txt":
                        return "1. Locate Themis and take a selfie with her\n\n\n2. Find an extract of legislation on display on George Street (near Themis) and take a picture\n\n\n3. Provide a quote from Sir Harry Gibbs inscribed near the statue of Themis\n\n\n4. Enter the Courts Complex through security, provided you are suitably dressed. Walk towards the entrance of the QEII Courts Complex.\n\n\n5. After you pass through security, walk to the right and enter the 'Sir Harry Gibbs Legal Heritage Centre'.\n\n";
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

            //change the header of the questions to be relevant
            String questionType = fileName.Substring(9);
            if (questionType == "Tasks.txt")
            {
                questionTypeLabel.Text = "Activity Tasks";
            }
            else if (questionType == "Questions.txt")
            {
                questionTypeLabel.Text = "Activity Questions";
            }
            else if (questionType == "Trivia.txt")
            {
                questionTypeLabel.Text = "Activity Trivia";
            }

            //try load the text from the saved file
            //else it is the first time the user has
            //opened the app to that screen, so load
            //the initial questions unedited.
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
                        await DisplayAlert("Error", "There was an error taking your photo, please try again", "OK");
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
                            await DisplayAlert("Error", "Your photo failed to save, please take it and try again", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Image Saved", "The photo has been saved to your gallery", "OK");
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
