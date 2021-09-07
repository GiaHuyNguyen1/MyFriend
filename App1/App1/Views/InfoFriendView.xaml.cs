using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoFriendView : ContentPage
    {
        public InfoFriendView(string name,string number,string address,string contact)
        {
            InitializeComponent();
            this.BindingContext = new InfoFriendViewModel(name,number,address,contact);
        }
    }
}