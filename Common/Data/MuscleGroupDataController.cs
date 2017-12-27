using Common.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Common.Data
{
    public class MuscleGroupDataController
    {
        static object locker = new object();

        SQLiteConnection database;

        public MuscleGroupDataController()
        {

            database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<MuscleGroup>();
        }

        public List<MuscleGroup> GetAllMuscleGroups()
        {
            lock (locker)
            {
                if (database.Table<MuscleGroup>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    List<MuscleGroup> lstAllMuscleGroup = new List<MuscleGroup>();

                    foreach (MuscleGroup item in database.Table<MuscleGroup>())
                    {
                        lstAllMuscleGroup.Add(item);
                    }

                    return lstAllMuscleGroup;
                }
            }
        }

        public MuscleGroup GetMuscleGroup(int code)
        {
            lock (locker)
            {
                if (database.Table<MuscleGroup>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    foreach (MuscleGroup item in database.Table<MuscleGroup>())
                    {
                        if (item.MuscleGroupCode == code)
                        {
                            return item;
                        }
                    }
                }

                return null;
            }
        }

        // TODO: correct insert
        public int SaveMuscleGroup(MuscleGroup muscleGroup)
        {
            lock (locker)
            {
                return database.Insert(muscleGroup);
            }
        }

        public int UpdateMuscleGroup(MuscleGroup muscleGroup)
        {
            lock (locker)
            {
                return database.Update(muscleGroup);
            }
        }



        public int DeleteMuscleGroup(int trainingPlanCode)
        {
            lock (locker)
            {
                return database.Delete<TrainingPlan>(trainingPlanCode);
            }
        }

        public void DeleteAllMuscleGroup()
        {
            lock (locker)
            {
                foreach (var item in GetAllMuscleGroups())
                {
                    DeleteMuscleGroup(item.MuscleGroupCode);
                }
            }
        }
    }
}
