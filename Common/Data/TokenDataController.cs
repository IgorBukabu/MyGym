using Common.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Common.Data
{
    public class TokenDataController
    {
        static object locker = new object();

        SQLiteConnection database;

        public TokenDataController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<TrainingPlan>();
        }

        public Token GetToken()
        {
            lock (locker)
            {
                if (database.Table<Token>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }

        // TODO: correct insert
        public int SaveToken(Token token)
        {
            lock (token)
            {
                if (token.Id != 0)
                {
                    database.Update(token);
                    return token.Id;
                }
                else
                {
                    return database.Insert(token);
                }
            }
        }

        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}
