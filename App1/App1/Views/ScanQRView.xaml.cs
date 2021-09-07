using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanQRView : ContentPage
    {
        public ScanQRView()
        {
            InitializeComponent();
            this.BindingContext = new ScanQRViewModel();
        }

    }
}