using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App1.Activity.Plan
{
    class ActivityWeekPlan : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.activity_week_plan, container, false);

            var cardViewMonday = view.FindViewById<CardView>(Resource.Id.CardWeekPlanMonday);
            var cardViewTuesday = view.FindViewById<CardView>(Resource.Id.CardWeekPlanTuesday);
            var cardViewWednesday = view.FindViewById<CardView>(Resource.Id.CardWeekPlanWednesday);
            var cardViewThursday = view.FindViewById<CardView>(Resource.Id.CardWeekPlanThursday);
            var cardViewFriday = view.FindViewById<CardView>(Resource.Id.CardWeekPlanFriday);
            var cardViewSaturday = view.FindViewById<CardView>(Resource.Id.CardWeekPlanSaturday);
            var cardViewSunday = view.FindViewById<CardView>(Resource.Id.CardWeekPlanSunday);

            #region Обработка нажатий на CardView
            DateTime thisDay = DateTime.Today;

            int daysInFeb = System.DateTime.DaysInMonth(thisDay.Year, thisDay.Month);
            cardViewMonday.Click += CardViewClick;
            cardViewTuesday.Click += CardViewClick;
            cardViewWednesday.Click += CardViewClick;
            cardViewThursday.Click += CardViewClick;
            cardViewFriday.Click += CardViewClick;
            cardViewSaturday.Click += CardViewClick;
            cardViewSunday.Click += CardViewClick;

            #endregion

            return view;
        }

        private void CardViewClick(object sender, System.EventArgs e)
        {

        }
    }
}