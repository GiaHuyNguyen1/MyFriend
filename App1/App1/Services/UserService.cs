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
    public static class UserService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "user.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<UserModel>();
        }

        public static async Task Register(string name, string number, string address, string contact,string email,string pass,string repass)
        {
            await Init();
            UserModel user = new UserModel()
            {
                Name = name,
                Number = number,
                Address = address,
                Contact = contact,
                Email = email,
                Password = pass,
                RePassword = repass
            };
            var id = await db.InsertAsync(user);
        }
        public static async Task<bool> LoginValidateAsync(string userName1, string pwd1)
        {
            await Init();
            var data = db.Table<UserModel>();
            var d1 = data.Where(x => x.Name == userName1 && x.Password== pwd1).FirstOrDefaultAsync();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
