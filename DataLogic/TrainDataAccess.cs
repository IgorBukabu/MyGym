using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Common.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace DataLogic
{
    public class TrainDataAccess
    {
        static TrainDataController trainingDB;

        public static TrainDataController PlanTrainingDataBase
        {
            get
            {
                if (trainingDB == null)
                {
                    trainingDB = new TrainDataController();
                }

                return trainingDB;
            }
        }
    }
}
