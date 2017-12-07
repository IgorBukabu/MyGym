using Android.App;
using Android.Widget;
using Android.OS;

namespace MyGym
{
    [Activity(Label = "MyGym", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // onClick go to training plans
            Button btnTrainingPlans = FindViewById<Button>(Resource.Id.btnTrainingPlans);
            btnTrainingPlans.Click += delegate
            {
                StartActivity(typeof(TrainingPlansActivity));
            };
        }

        
    }
}

