using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid.Renderer;
using App1.Views.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace App1.Droid.Renderer
{

    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawble = new GradientDrawable();
                gradientDrawble.SetCornerRadius(10f);
                gradientDrawble.SetStroke(5,Android.Graphics.Color.DeepSkyBlue);
                gradientDrawble.SetColor(Android.Graphics.Color.Transparent);
                Control.SetBackground(gradientDrawble);

                Control.SetPadding(50,Control.PaddingTop,PaddingRight,Control.PaddingBottom);
            }
        }
    }
}