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
    public class FriendViewModel : BaseViewModel
    {
        public ObservableRangeCollection<FriendModel> Friend { get; set; }
        public AsyncCommand RefeshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand ScanQRCommand { get; }
        public AsyncCommand UserCommand { get; }
        public AsyncCommand<FriendModel> RemoveCommand { get; }
        public AsyncCommand<FriendModel> EditCommand { get; }
        public AsyncCommand<FriendModel> GetValueCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public AsyncCommand<object> TappedCommand { get; }
        string result = "";
        public string Result
        {
            get => result;
            
            //using Mvvm helper
            set => SetProperty(ref result, value);

        }
        UserModel userModel;
        public UserModel UserModel
        {
            get => userModel;
            
            //using Mvvm helper
            set => SetProperty(ref userModel, value);

        }
        
        public FriendViewModel(UserModel user)
        {
            UserModel = user;
            showEmployee();
            Title = "My Friend";
            Friend = new ObservableRangeCollection<FriendModel>();
            RefeshCommand = new AsyncCommand(Refresh);
            SelectedCommand = new AsyncCommand<object>(Selected);
            TappedCommand = new AsyncCommand<object>(Tapped);
            AddCommand = new AsyncCommand(Add);
            ScanQRCommand = new AsyncCommand(Scan);
            UserCommand = new AsyncCommand(User);
            RemoveCommand = new AsyncCommand<FriendModel>(Remove);
            EditCommand = new AsyncCommand<FriendModel>(Edit);
            GetValueCommand = new AsyncCommand<FriendModel>(GetVaue);
        }
        FriendModel selectedFriend;
        public FriendModel SelectedFriend
        {
            get => selectedFriend;
            set => SetProperty(ref selectedFriend, value);
        }
        Task Selected(object args)
        {
            var friend = args as FriendModel;
            if (friend == null)
                return Task.CompletedTask;
            SelectedFriend = null;
            return Task.CompletedTask;
        }

        FriendModel tappedFriend;
        public FriendModel TappedFriend
        {
            get => tappedFriend;
            set => SetProperty(ref tappedFriend, value);
        }
        async Task Tapped(object args)
        {
            var friend = args as FriendModel;
            if (friend == null)
                return;

            TappedFriend = null;

            await App.Current.MainPage.Navigation.PushAsync(new InfoFriendView(friend.Name, friend.Number, friend.Address, friend.Email));
        }
        async Task Add()
        {

            await App.Current.MainPage.Navigation.PushAsync(new AddFriendView());
            await Refresh();

        }
        async Task Scan()
        {

            await App.Current.MainPage.Navigation.PushAsync(new ScanQRView());

        }
        async Task User()
        {

            await App.Current.MainPage.Navigation.PushAsync(new UserView(UserModel));

        }
        async Task Remove(FriendModel friend)
        {
            await FriendsService.RemoveFriend(friend.Id);
            await Refresh();

            await FirebaseService.DeleteFriend(friend.Name);
        }
        async Task GetVaue(FriendModel friend)
        {
           
            FriendModel friend1 = await FriendsService.GetFriendByNameAsync(friend.Id);
            FriendModel account = new FriendModel
            {
                Name = friend1.Name,
                Number = friend1.Number,
                Address = friend1.Address,
                Email = friend1.Email,
                SortName = friend1.SortName
            };
            Result = JsonConvert.SerializeObject(account, Formatting.Indented);
          
            await App.Current.MainPage.Navigation.PushAsync(new CreateQRCodeView(Result));
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1000);

            Friend.Clear();
            var friends = await FriendsService.GetFriend();
            Friend.AddRange(friends);
            IsBusy = false;

        }
        private async void showEmployee()
        {
            var friends = await FriendsService.GetFriend();
            Friend.AddRange(friends);
        }
        async Task Edit(FriendModel friend)
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditFriendView(friend));
            await Refresh();
        }
    }
}