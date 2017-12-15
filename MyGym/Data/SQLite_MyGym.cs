using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Common.Data;
using MyGym.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_MyGym))]

namespace MyGym.Data
{
    public class SQLite_MyGym : ISQLite
    {
        public SQLite_MyGym()
        {

        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var dbName = "MyGym.db3";
            var path = Path.Combine(System.Environment.
                       GetFolderPath(System.Environment.
                       SpecialFolder.Personal), dbName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}