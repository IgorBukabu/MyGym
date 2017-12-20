using Common.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_MyGym))]
namespace Common.Data
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
