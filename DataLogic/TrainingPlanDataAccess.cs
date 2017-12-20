using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Common.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DataLogic
{
    public class TrainingPlanDataAccess
    {
        static PlanTrainingDataController planTrainingDB;

        public static PlanTrainingDataController PlanTrainingDataBase
        {
            get
            {
                if (planTrainingDB == null)
                {
                    planTrainingDB = new PlanTrainingDataController();
                }

                return planTrainingDB;
            }

        }

        
    }
}
