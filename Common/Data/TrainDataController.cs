using Common.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Common.Data
{
    public class TrainDataController
    {
        static object locker = new object();

        SQLiteConnection database;

        public TrainDataController()
        {

            database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<Train>();
        }

        public List<Train> GetAllTrains()
        {
            lock (locker)
            {
                if (database.Table<Train>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    List<Train> lstAllPlans = new List<Train>();

                    foreach (Train plan in database.Table<Train>())
                    {
                        lstAllPlans.Add(plan);
                    }

                    return lstAllPlans;
                }
            }
        }

        public Train GetTrain(int code)
        {
            lock (locker)
            {
                if (database.Table<Train>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    foreach (Train currPlan in database.Table<Train>())
                    {
                        if (currPlan.TrainingCode == code)
                        {
                            return currPlan;
                        }
                    }
                }

                return null;
            }
        }
        
        public int SaveTrain(Train train)
        {
            lock (locker)
            {
                return database.Insert(train);
            }
        }

        public int DeleteTrain(int trainCode)
        {
            lock (locker)
            {
                return database.Delete<Train>(trainCode );
            }
        }

        public void DeleteAllTrainsInTrainingPlan()
        {
            lock (locker)
            {
                database.DeleteAll<Train>();

                //foreach (var item in GetAllTrains())
                //{
                //    DeleteTrain(item.TrainingCode);
                //}
            }
        }
    }
}
