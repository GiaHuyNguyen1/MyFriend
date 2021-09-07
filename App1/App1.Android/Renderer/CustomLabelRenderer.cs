using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid.Renderer;
using App1.Resources;
using App1.Views.Widgets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace App1.Droid.Renderer
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer(Context context) : base(context)
        {
            //do nothing
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Control?.SetIncludeFontPadding(false);

            OnLanguageChanged();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(CustomLabel.ContentKeyProperty.PropertyName))
            {
                OnLanguageChanged();
            }
        }

        public void OnLanguageChanged()
        {
            if (Element == null)
                return;

            var label = (CustomLabel)Element;
            if (!string.IsNullOrEmpty(label.ContentKey))
            {
                var newValue = typeof(TranslateKey).GetField(label.ContentKey)?.GetValue(null) as string;

                if (!string.IsNullOrEmpty(newValue))
                {
                    label.Text = newValue;
                }
                else
                {
                    label.Text = label.ContentKey;
                }
            }
        }
    }
}