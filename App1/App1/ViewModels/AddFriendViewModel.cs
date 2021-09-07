using App1.Models;
using App1.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AddFriendViewModel : BaseViewModel
    {
        public AsyncCommand AddCommand { get; }
        string name ;
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
        public AddFriendViewModel()
        {
            AddCommand = new AsyncCommand(Add);

            Title = "Add a new friend";
        }
        async Task Add()
        {
            await FirebaseService.AddFriend(name, number, address, email);
            await FriendsService.AddFriend(name, number, address, email);     
            List<FriendModel> _data = new List<FriendModel>();
            _data.Add(new FriendModel()
            {
                Name = name,
                Number = number,
                Address = address,
                Email= email
            });

            string json = JsonConvert.SerializeObject(_data.ToArray());

          
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}