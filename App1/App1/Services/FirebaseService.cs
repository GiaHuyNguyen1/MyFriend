using App1.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public static class FirebaseService
    {
        static FirebaseClient firebase = new FirebaseClient("https://myfriend-84d5a-default-rtdb.firebaseio.com/");

        //public async Task<List<FriendModel>> GetAllFriends()
        //{
        //    return (await firebase
        //      .Child("Friends")
        //      .OnceAsync<FriendModel>()).Select(item => new FriendModel
        //      {
        //          Name = item.Object.Name,
        //          Address = item.Object.Address,
        //          Email = item.Object.Email,
        //          Number = item.Object.Number
        //      }).ToList();
        //}
        public static async Task AddFriend(string name, string number, string address,string email)
        {

            await firebase
              .Child("Friends")
              .PostAsync(new FriendModel() 
              { Name = name, Number = number, Address = address,Email = email });
        }
        //public async Task<FriendModel> GetFriend(int id)
        //{
        //    var allPersons = await GetAllFriends();
        //    await firebase
        //      .Child("Friends")
        //      .OnceAsync<FriendModel>();
        //    return allPersons.Where(a => a.Id== id).FirstOrDefault();
        //}
        public static async Task UpdateFriend(FriendModel friend)
        {
            var toUpdateFriend = (await firebase
              .Child("Friends")
              .OnceAsync<FriendModel>()).Where(a => a.Object.Name == friend.Name).FirstOrDefault();

            await firebase
              .Child("Friends")
              .Child(toUpdateFriend.Key)
              .PutAsync(new FriendModel() { Name = friend.Name, Address = friend.Address, Email = friend.Email, Number = friend.Number });
        }
        public static async Task DeleteFriend(string name)
        {
            var toDeleteFriend = (await firebase
              .Child("Friends")
              .OnceAsync<FriendModel>()).Where(a => a.Object.Name == name).FirstOrDefault();
            await firebase.Child("Friends").Child(toDeleteFriend.Key).DeleteAsync();

        }
    }
}
