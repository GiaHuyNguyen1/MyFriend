using App1.Models;
using App1.Services;
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
    public partial class FriendView : ContentPage
    {
        public FriendView(UserModel user)
        {
            InitializeComponent();
            this.BindingContext = new FriendViewModel(user);
            
        }

       
    }
}