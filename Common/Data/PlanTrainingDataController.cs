using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Common.Data
{
    public class PlanTrainingDataController
    {
        static object locker = new object();

        SQLiteConnection database;

        public PlanTrainingDataController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<TrainingPlan>();
        }

        public TrainingPlan GetTrainingPlan()
        {
            lock (locker)
            {
                if (database.Table<TrainingPlan>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<TrainingPlan>().First();
                }
            }
        }

        // TODO: correct insert
        public int SaveTrainingPlan(TrainingPlan trpPlan)
        {
            lock (locker)
            {
                return database.Insert(trpPlan);
            }
        }

        public int DeleteTrainingPlan(int trainingPlanCode)
        {
            lock (locker)
            {
                return database.Delete<TrainingPlan>(trainingPlanCode);
            }
        }




    }
}
