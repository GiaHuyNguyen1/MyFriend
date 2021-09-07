using App1.Models;
using App1.Services;
using App1.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        UserDB db;
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
        string email;
        public string Email 
        {
            get => email;
            
            //using Mvvm helper
            set => SetProperty(ref email, value);

        }
        string result = "";
        public string Result
        {
            get => result;

            //using Mvvm helper
            set => SetProperty(ref result, value);

        }
        public AsyncCommand BackCommand { get; set; }
        public AsyncCommand GetValueCommand { get; }
        public AsyncCommand EditValueCommand { get; }
        async Task GetVaue()
        {
            UserModel account = new UserModel
            {
                Name = this.Name,
                Number = this.Number,
                Address = this.Address,
                Email = this.Email
            };
            Result = JsonConvert.SerializeObject(account, Formatting.Indented);
            await App.Current.MainPage.Navigation.PushAsync(new CreateQRCodeView(Result));
        }
        async Task EditValue()
        {
            var validData = db.updateUser(Name, Number, Address, Email);
            if (validData)
            {
                await App.Current.MainPage.DisplayAlert("Success", "User updated Successfully", "OK");
            }
            await App.Current.MainPage.DisplayAlert("Success", "User updated unSuccessfully", "OK");
        }
        async Task Back()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
        public UserViewModel(UserModel userModel)
        {
            name = userModel.Name;
            address = userModel.Address;
            number = userModel.Number;
            email = userModel.Email;
            Title = "User";
            BackCommand = new AsyncCommand(Back);
            GetValueCommand = new AsyncCommand(GetVaue);
            EditValueCommand = new AsyncCommand(EditValue);
        }
    }
}