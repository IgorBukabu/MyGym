using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DataLogic;

namespace MyGym
{
    [Activity(Theme = "@android:style/Theme.Material.Light",Label = "                                  בחר תוכנית אימונים")]
    public class TrainingPlansActivity : Activity
    {
        private List<String> lstTrainingPlansList = new List<string>();  

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TraininPlansUI);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ////////////////////////////////////////////////////////////////////////////////////////////
            //TrainingPlanDataAccess.PlanTrainingDataBase.SaveTrainingPlan(new TrainingPlan("אני אוהב מסה", 2));
            //TrainingPlanDataAccess.PlanTrainingDataBase.SaveTrainingPlan(new TrainingPlan("אני אוהב בנות", 3));
            //TrainingPlanDataAccess.PlanTrainingDataBase.SaveTrainingPlan(new TrainingPlan("אני אוהב לאכול", 4));            
            ////////////////////////////////////////////////////////////////////////////////////////////

            List<TrainingPlan> lstTrainingPlansListToshow = TrainingPlanDataAccess.PlanTrainingDataBase.GetTrainingPlans();

            ListView lstvTrainingPlans = FindViewById<ListView>(Resource.Id.llstTrainingPlans);

            TrainPlanAdapter adapterTrainPlans = new TrainPlanAdapter(lstTrainingPlansListToshow);

            lstvTrainingPlans.Adapter = adapterTrainPlans;
        }
    }
}