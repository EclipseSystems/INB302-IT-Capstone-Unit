using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;

namespace INB302_WDGS.Droid {
    [Activity(Label = "INB302_WDGS", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity {
        protected override void OnCreate(Bundle bundle) {
            App.screenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
            App.screenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            App.cameraAccessGranted = true;

            base.OnCreate(bundle);

            #region Resolver Init
            SimpleContainer container = new SimpleContainer();
            container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
            container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
            container.Register<INetwork>(t => t.Resolve<IDevice>().Network);

            Resolver.SetResolver(container.GetResolver());
            #endregion

            global::Xamarin.Forms.Forms.Init(this, bundle);
			global::Xamarin.FormsMaps.Init (this, bundle);
            LoadApplication(new App());
        }
    }
}

