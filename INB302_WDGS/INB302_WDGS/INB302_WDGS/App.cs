using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace INB302_WDGS {
    public class App : Application {

        static public int screenWidth;
        static public int screenHeight;

        public App() {

            MainPage = new NavigationPage(new Instructions());

        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
