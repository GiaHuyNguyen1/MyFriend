using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Views.Widgets
{
    public class CustomLabel : Label
    {
        #region ContentKey
        public static readonly BindableProperty ContentKeyProperty = BindableProperty.Create(nameof(ContentKey), typeof(string), typeof(CustomLabel));

        public string ContentKey
        {
            get => (string)GetValue(ContentKeyProperty);
            set
            {
                SetValue(ContentKeyProperty, value);
            }
        }
        #endregion

        public CustomLabel()
        {

        }
    }
}
