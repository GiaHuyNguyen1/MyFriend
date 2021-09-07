using App1.Models;
using App1.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public class EditFriendViewModel : BaseViewModel
    {
        public AsyncCommand EditCommand { get; }
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

        FriendModel selectedFriend;
        public FriendModel SelectedFriend
        {
            get => selectedFriend;
            set => SetProperty(ref selectedFriend, value);
        }
        async Task Edit()
        {
            selectedFriend.Name = name;
            selectedFriend.Number = number;
            selectedFriend.Address = address;
            selectedFriend.Email = email;
            await FriendsService.SaveNoteAsync(selectedFriend);
            await FirebaseService.UpdateFriend(selectedFriend);
            await App.Current.MainPage.Navigation.PopAsync();
        }
        public EditFriendViewModel(FriendModel friend)
        {
            selectedFriend = friend;
            name = friend.Name;
            number= friend.Number;
            address = friend.Address;
            email = friend.Email;

            EditCommand = new AsyncCommand(Edit);
        }
    }
}
