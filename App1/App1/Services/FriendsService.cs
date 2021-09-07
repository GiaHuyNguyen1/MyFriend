using App1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App1.Services
{
    public static class FriendsService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MockDBFriend3.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<FriendModel>();
        }

        public static async Task AddFriend(string name, string number, string address, string contact)
        {
            await Init();
            FriendModel friend = new FriendModel()
            {
                Name = name,
                Number = number,
                Address = address,
                Email = contact
            };
            var id = await db.InsertAsync(friend);

        }
        public static async Task RemoveFriend(int id)
        {
            await Init();
            await db.DeleteAsync<FriendModel>(id);
        }
        public static async Task<IEnumerable<FriendModel>> GetFriend()
        {
            await Init();

            var friend = await db.Table<FriendModel>().ToListAsync();
            return friend;
        }
        public static Task<FriendModel> GetFriendByNameAsync(int id)
        {
            return db.Table<FriendModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }
        public static Task<int> SaveNoteAsync(FriendModel note)
        {
            if (note.Id != 0)
            {
                // Update an existing note.
                return db.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return db.InsertAsync(note);
            }
        }

    }
}
