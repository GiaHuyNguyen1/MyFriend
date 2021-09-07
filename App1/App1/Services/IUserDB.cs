using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Services
{
    public interface IUserDB
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
