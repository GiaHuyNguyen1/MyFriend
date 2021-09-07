using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid.Renderer;
using App1.Resources;
using App1.Views.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustumButton), typeof(CustomButtonRenderer))]
namespace App1.Droid.Renderer
{
    public class CustomButtonRenderer : ButtonRenderer
    {

        protected virtual void OnContentKeyChanged()
        {
            var key = ((CustumButton)Element).ContentKey;

            if (string.IsNullOrEmpty(key))
                return;

            try
            {
                var res = typeof(TranslateKey).GetField(key)?.GetValue(null);

                Element.Text = res == null ? key : (string)res;
            }
            catch
            {
                Element.Text = key;
            }
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                OnContentKeyChanged();
            }
        }
    }
}