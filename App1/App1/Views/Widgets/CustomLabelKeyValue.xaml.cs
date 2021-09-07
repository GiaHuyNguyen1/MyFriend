using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views.Widgets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomLabelKeyValue : ContentView
    {

        public static readonly BindableProperty IconFontProperty = BindableProperty.Create(nameof(Icon),
            typeof(string),
            typeof(CustomLabelKeyValue),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: IconFontPropertyChanged);

        private static void IconFontPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomLabelKeyValue)bindable;
            control.IconFont.Text = newValue?.ToString();
        }

        public string Icon
        {
            get { return base.GetValue(IconFontProperty)?.ToString(); }
            set
            {
                base.SetValue(IconFontProperty, value);
            }
        }

        public static readonly BindableProperty KeyProperty = BindableProperty.Create(nameof(TextKey),
               typeof(string),
               typeof(CustomLabelKeyValue),
               defaultValue: string.Empty,
               defaultBindingMode: BindingMode.OneWay,
               propertyChanged: KeyPropertyChanged);

        private static void KeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomLabelKeyValue)bindable;
            control.Key.Text = newValue?.ToString();
        }

        public string TextKey
        {
            get { return base.GetValue(KeyProperty)?.ToString(); }
            set
            {
                base.SetValue(KeyProperty, value);
            }
        }
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label),
             typeof(string),
             typeof(CustomLabelKeyValue),
             defaultValue: string.Empty,
             defaultBindingMode: BindingMode.OneWay,
             propertyChanged: TitlePropertyChanged);

        private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomLabelKeyValue)bindable;
            control.Value.Text = newValue?.ToString();
        }

        public string Label
        {
            get { return base.GetValue(LabelProperty)?.ToString(); }
            set
            {
                base.SetValue(LabelProperty, value);
            }
        }
        public CustomLabelKeyValue()
        {
            InitializeComponent();
        }
    }
}