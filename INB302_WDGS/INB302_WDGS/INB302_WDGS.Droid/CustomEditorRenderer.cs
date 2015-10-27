using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using INB302_WDGS.Droid;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]

namespace INB302_WDGS.Droid
{
    class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextSize = 16;
            }
        }
    }
}