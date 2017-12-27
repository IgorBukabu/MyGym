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

        public List<TrainingPlan> GetTrainingPlans()
        {
            lock (locker)
            {
                if (database.Table<TrainingPlan>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    List<TrainingPlan> lstAllPlans = new List<TrainingPlan>();

                    foreach (TrainingPlan plan in database.Table<TrainingPlan>())
                    {
                        lstAllPlans.Add(plan);
                    }

                    return lstAllPlans;
                }
            }
        }

        public TrainingPlan GetTrainingPlan(int code)
        {
            lock (locker)
            {
                if (database.Table<TrainingPlan>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    foreach (TrainingPlan currPlan in database.Table<TrainingPlan>())
                    {
                        if (currPlan.TrainingPlanCode == code)
                        {
                            return currPlan;
                        }
                    }
                }

                return null;
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

        public int UpdateTrainingPlan(TrainingPlan trainingPlan)
        {
            lock (locker)
            {
                return database.Update(trainingPlan);
            }
        }



        public int DeleteTrainingPlan(int trainingPlanCode)
        {
            lock (locker)
            {
                return database.Delete<TrainingPlan>(trainingPlanCode);
            }
        }

        public void DeleteAllTrainingPlans()
        {
            lock (locker)
            {               
                foreach (var item in GetTrainingPlans())
                {
                    DeleteTrainingPlan(item.TrainingPlanCode);
                }                
            }
        }
    }
}
