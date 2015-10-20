using INB302_WDGS.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]

namespace INB302_WDGS.iOS
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.Black;
                Control.TextColor = UIColor.LightGray;
            }
        }
    }
}
