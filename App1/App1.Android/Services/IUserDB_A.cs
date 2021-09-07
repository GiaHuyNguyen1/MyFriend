using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid.Services;
using App1.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(IUserDB_A))]
namespace App1.Droid.Services
{
    public class IUserDB_A : App1.Services.IUserDB
    {
        public SQLiteConnection GetSQLiteConnection()
        {
            var filename = "Team.db3";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}