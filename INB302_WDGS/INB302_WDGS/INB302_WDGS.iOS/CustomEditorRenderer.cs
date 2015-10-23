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
    /*
     * Custom Renderer for iOS Devices for the Editor Xamarin.Forms element
     * This Renderer is used to change the text colour of all Editor elements
     * on iOS devices to match the appearance of the Android platform
     * 
     * The iOS text colour is default black when on an Editor element,
     * so without this the text colour is black and not visible with a
     * black background.
     */
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
