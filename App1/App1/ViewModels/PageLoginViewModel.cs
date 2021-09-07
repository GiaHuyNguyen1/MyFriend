using App1.Models;
using App1.Services;
using App1.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class PageLoginViewModel : BaseViewModel
    {
        UserDB db;
        public UserModel user { get; set; }
        string name;
        public string Name
        {
            get => name;
            //set
            //{
            //    if (value == countDisplay)
            //        return;
            //    countDisplay = value;
            //    OnPropertyChanged();
            //}
            //using Mvvm helper
            set => SetProperty(ref name, value);

        }

        string pass;
        public string Password
        {
            get => pass;
            //set
            //{
            //    if (value == countDisplay)
            //        return;
            //    countDisplay = value;
            //    OnPropertyChanged();
            //}
            //using Mvvm helper
            set => SetProperty(ref pass, value);

        }

        public AsyncCommand LoginCommand { get; set; }
        public AsyncCommand SigupCommand { get; set; }
        async Task Finger()
        {
            var availability = await CrossFingerprint.Current.IsAvailableAsync();
            if (!availability)
            {
                await App.Current.MainPage.DisplayAlert("Warning!", "No biometrics available", "OK");
                return;

            }
            var autnResult = await CrossFingerprint.Current.AuthenticateAsync(new Plugin.Fingerprint.Abstractions.AuthenticationRequestConfiguration("Sercurity","Touch your finger"));
            if (autnResult.Authenticated)
            {
                var infouser = db.GetSpecificUser(Name);
                user = infouser;
                await App.Current.MainPage.Navigation.PushAsync(new FriendView(user));
            }
        }
        async Task Login()
        {
            
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", "Điền đầy đủ thông tin", "OK");
            }
            else
            {   // xu ly logic khi dang nhap
                var validData = db.LoginValidate(Name, Password);
                if (validData)
                {
                    await Finger();

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Thông báo", "Nhập lại tên tài khoản hoặc mặt khẩu", "OK");
                }


            }
           
        }
        
        async Task Sigup()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SigupView());
        }
        public PageLoginViewModel()
        {
            db = new UserDB();
            LoginCommand = new AsyncCommand(Login);
            SigupCommand = new AsyncCommand(Sigup);
            
        }
    }
}