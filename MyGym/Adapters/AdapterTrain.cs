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
using Common.Models;
using MyGym.Adapters;


namespace MyGym.Adapters
{
    class AdapterTrain : BaseAdapter
    {
        private List<Train> _trains;

        public AdapterTrain(List<Train> trains)
        {
            this._trains = trains;
        }


        public override int Count
        {
            get { return this._trains.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            // could wrap a TrainingPlan in a Java.Lang.Object
            // to return it here if needed
            return null;
        }

        public override long GetItemId(int position)
        {
            return this._trains[position].TrainingCode;
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
            holder.TrainingPlanName.Text = this._trains[position].TrainingName;

            return view;
        }
    }
}