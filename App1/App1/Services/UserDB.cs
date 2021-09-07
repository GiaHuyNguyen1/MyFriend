using App1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Services
{
    public class UserDB
    {
        private SQLiteConnection _SQLiteConnection;

        public UserDB()
        {
            _SQLiteConnection = DependencyService.Get<IUserDB>().GetSQLiteConnection();
            _SQLiteConnection.CreateTable<UserModel>();
        }
        public IEnumerable<UserModel> GetUsers()
        {
            return (from u in _SQLiteConnection.Table<UserModel>()
                    select u).ToList();
        }
        
        public UserModel GetSpecificUser(string name)
        {
            return _SQLiteConnection.Table<UserModel>().Where(i => i.Name == name).FirstOrDefault();
        }
        public void DeleteUser(int id)
        {
            _SQLiteConnection.Delete<UserModel>(id);
        }
        public string AddUser(UserModel user)
        {
            var data = _SQLiteConnection.Table<UserModel>();
            var d1 = data.Where(x => x.Name == user.Name).FirstOrDefault();
            if (d1 == null)
            {
                _SQLiteConnection.Insert(user);
                return "Sucessfully Added";
            }
            else
                return "Already Mail id Exist";

        }
        public bool updateUserValidation(string userid)
        {
            var data = _SQLiteConnection.Table<UserModel>();
            var d1 = (from values in data
                      where values.Name == userid
                      select values).Single();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
        public bool updateUser(string username, string number,string address, string email)
        {
            var data = _SQLiteConnection.Table<UserModel>();
            var d1 = (from values in data
                      where values.Name == username
                      select values).Single();
            if (true)
            {
                d1.Number = number;
                d1.Address= address;
                d1.Email = email;

                _SQLiteConnection.Update(d1);
                return true;
            }
            else
                return false;
        }
        public bool LoginValidate(string userName1, string pwd1)
        {
            var data = _SQLiteConnection.Table<UserModel>();
            var d1 = data.Where(x => x.Name == userName1 && x.Password == pwd1).FirstOrDefault();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
