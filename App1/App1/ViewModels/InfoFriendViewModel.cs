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
    public class InfoFriendViewModel : BaseViewModel
    {
        public AsyncCommand<FriendModel> RemoveCommand { get; }
        public AsyncCommand<FriendModel> GetValueCommand { get; }
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

        string number;
        public string Number
        {
            get => number;
            //set
            //{
            //    if (value == countDisplay)
            //        return;
            //    countDisplay = value;
            //    OnPropertyChanged();
            //}
            //using Mvvm helper
            set => SetProperty(ref number, value);

        }

        string address;
        public string Address
        {
            get => address;
            //set
            //{
            //    if (value == countDisplay)
            //        return;
            //    countDisplay = value;
            //    OnPropertyChanged();
            //}
            //using Mvvm helper
            set => SetProperty(ref address, value);

        }
        string contact;
        public string Contact
        {
            get => contact;
            //set
            //{
            //    if (value == countDisplay)
            //        return;
            //    countDisplay = value;
            //    OnPropertyChanged();
            //}
            //using Mvvm helper
            set => SetProperty(ref contact, value);

        }
        string result = "";
        public string Result
        {
            get => result;
            //set
            //{
            //    if (value == countDisplay)
            //        return;
            //    countDisplay = value;
            //    OnPropertyChanged();
            //}
            //using Mvvm helper
            set => SetProperty(ref result, value);

        }
        async Task Remove(FriendModel friend)
        {
            await FriendsService.RemoveFriend(friend.Id);
            await App.Current.MainPage.Navigation.PopAsync();
        }
        async Task GetVaue(FriendModel friend)
        {

            FriendModel friend1 = await FriendsService.GetFriendByNameAsync(friend.Id);
            FriendModel account = new FriendModel
            {
                Name = friend1.Name,
                Number = friend1.Number,
                Address = friend1.Address,
                Email= friend1.Email
            };
            Result = JsonConvert.SerializeObject(account, Formatting.Indented);
            await App.Current.MainPage.Navigation.PushAsync(new CreateQRCodeView(Result));
        }
        public InfoFriendViewModel(string nameu,string numberu,string addressu,string contactu)
        {
            name = nameu;
            number = numberu;
            address = addressu;
            contact = contactu; 
            RemoveCommand = new AsyncCommand<FriendModel>(Remove);
            GetValueCommand = new AsyncCommand<FriendModel>(GetVaue);
        }
    }
}