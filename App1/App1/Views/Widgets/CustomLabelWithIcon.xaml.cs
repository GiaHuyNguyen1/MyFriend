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
    public partial class CustomLabelWithIcon : ContentView
    {
        public CustomLabelWithIcon()
        {
            InitializeComponent();
        }
    }
}