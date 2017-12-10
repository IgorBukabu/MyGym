using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyGym
{
    [Activity(Label = "TrainingPlansActivity")]
    public class TrainingPlansActivity : Activity
    {
        private List<String> lstTrainingPlansList = new List<string>();  

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TraininPlansUI);

            this.lstTrainingPlansList.Add("תן לי בחיטוב");
            this.lstTrainingPlansList.Add("מסה בכל הכוח");

            ListView lstTrainingPlans = FindViewById<ListView>(Resource.Id.llstTrainingPlans);

            ArrayAdapter<string> ListAdapter = new ArrayAdapter<String>
                (this, Android.Resource.Layout.SimpleListItem1, lstTrainingPlansList);

            lstTrainingPlans.Adapter = ListAdapter;




        }
    }
}