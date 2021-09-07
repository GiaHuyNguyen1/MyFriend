using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Views.Widgets
{
    public class CustumButton : Button
    {
        public static readonly BindableProperty ContentKeyProperty = BindableProperty.Create(nameof(ContentKey), typeof(string), typeof(CustumButton));

        public string ContentKey
        {
            get => (string)GetValue(ContentKeyProperty);
            set
            {
                SetValue(ContentKeyProperty, value);
            }
        }
    }
}
