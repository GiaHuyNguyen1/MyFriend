using App1.Models;
using App1.Services;
using App1.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class SigupViewModel : BaseViewModel
    {
        UserModel User = new UserModel();
        UserDB db = new UserDB();
        string name;
        public string Name
        {
            get => name;
           
            //using Mvvm helper
            set => SetProperty(ref name, value);

        }

        string number;
        public string Number
        {
            get => number;
            
            //using Mvvm helper
            set => SetProperty(ref number, value);

        }

        string address;
        public string Address
        {
            get => address;
            
            //using Mvvm helper
            set => SetProperty(ref address, value);

        }
        string contact;
        public string Contact
        {
            get => contact;
            
            //using Mvvm helper
            set => SetProperty(ref contact, value);

        }
        string email;
        public string Email 
        {
            get => email;
            
            //using Mvvm helper
            set => SetProperty(ref email, value);

        }
        string password;
        public string Password
        {
            get => password;
            
            //using Mvvm helper
            set => SetProperty(ref password, value);

        }
        string repassword;
        public string RePassword
        {
            get => repassword;
            
            //using Mvvm helper
            set => SetProperty(ref repassword, value);

        }
        public AsyncCommand RegisterCommand { get; set; }
        public AsyncCommand SignInCommand { get; set; }
        public INavigation Navigation { get; set; }
        async Task Register()
        {

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Address) ||
                string.IsNullOrEmpty(Number) || string.IsNullOrEmpty(Contact) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(RePassword))
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", "Nhập chưa đủ thông tin", "OK");
            }
            else if (!string.Equals(Password, RePassword))
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", "Mật khảu không khớp", "OK");
                Password = string.Empty;
                RePassword = string.Empty;
            }
            else if (Number.Length < 10)
            {
                Number= string.Empty;
                await App.Current.MainPage.DisplayAlert("Thông báo", "Nhập lại điện thoại", "OK");               
            }
            else
            {
                User.Name =Name;
                User.Number=Number;
                User.Address =Address;
                User.Email = Email;
                User.Password = Password;
                User.RePassword = RePassword;
                User.Contact = Contact;
                try
                {
                    var retrunvalue = db.AddUser(User);
                    if (retrunvalue == "Sucessfully Added")
                    {
                        await App.Current.MainPage.DisplayAlert("Thông báo", "Đăng kí thành công", "OK");
                        await App.Current.MainPage.Navigation.PopAsync();

                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Thông báo", "Đăng kí chưa thành công", "OK");                       
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
        
        public SigupViewModel()
        {
            User = new UserModel();
            RegisterCommand = new AsyncCommand(Register);
        }
    }
}