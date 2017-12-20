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
using Common;
using MyGym.Adapters;

namespace MyGym
{
    class TrainPlanAdapter : BaseAdapter
    {
        private List<TrainingPlan> _trainingPlans;

        public TrainPlanAdapter(List<TrainingPlan> triningPlans)
        {
            this._trainingPlans = triningPlans;
        }


        public override int Count
        {
            get { return this._trainingPlans.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            // could wrap a TrainingPlan in a Java.Lang.Object
            // to return it here if needed
            return null;
        }

        public override long GetItemId(int position)
        {
            return this._trainingPlans[position].TrainingPlanCode;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.trainingPlanRow, parent, false);

                // var photo = view.FindViewById<ImageView>(Resource.Id.);
                var name = view.FindViewById<TextView>(Resource.Id.TrainPlanNameTextView);                

                view.Tag = new TrainingPlanViewHolder() { TrainingPlanName = name };
            }

            var holder = (TrainingPlanViewHolder)view.Tag;

            //holder.Photo.SetImageDrawable(ImageManager.Get(parent.Context, users[position].ImageUrl));
            holder.TrainingPlanName.Text = this._trainingPlans[position].TrainingPlanName; 

            return view;
        }
    }
}