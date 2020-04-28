using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App1.Activity.ListOfTasks;
using App1.Activity.Statistic;
using Plugin.Settings;

namespace App1.Activity.Plan
{
    [Activity(Label = "@string/app_name")]
    class ActivityMainPlan : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main_plan);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            BottomNavigationView BtnNavigation = FindViewById<BottomNavigationView>(Resource.Id.BottomNavigationCurrentPlan);

            var btn_current_plan = BtnNavigation.Menu.FindItem(Resource.Id.btn_current_plan);
            var btn_statistics = BtnNavigation.Menu.FindItem(Resource.Id.btn_statistics);
            var btn_plan_creation = BtnNavigation.Menu.FindItem(Resource.Id.btn_plan_creation);


            if (CrossSettings.Current.GetValueOrDefault("isEntrance", "") == "1")
            {
                FragmentTransaction fragmentTransaction = this.FragmentManager.BeginTransaction();
                CrossSettings.Current.AddOrUpdateValue("isEntrance", "0");
                activityCurrentPlan(fragmentTransaction);
            }            

            BtnNavigation.NavigationItemSelected += async (sender, e) =>
            {
                FragmentTransaction fragmentTransaction = this.FragmentManager.BeginTransaction();
                switch (e.Item.ItemId)
                {
                    case Resource.Id.btn_current_plan:
                        activityCurrentPlan(fragmentTransaction);
                        break;
                    case Resource.Id.btn_statistics:
                        activityStatistics(fragmentTransaction);
                        break;
                    case Resource.Id.btn_plan_creation:
                        activityPlanCreation(fragmentTransaction);
                        break;                    
                }
            };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.btn_exit)
            {
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetTitle("Внимание!");
                alert.SetMessage("Вы действитеьльно хотите выйти ?");
                alert.SetPositiveButton("Да", (senderAlert, args) =>
                {
                    Intent Exit = new Intent(this, typeof(MainActivity));
                    StartActivity(Exit);
                });
                alert.SetNegativeButton("Нет", (senderAlert, args) =>
                {
                });
                Dialog dialog = alert.Create();
                dialog.Show();
            }

            return base.OnOptionsItemSelected(item);
        }

        public void activityCurrentPlan(FragmentTransaction fragmentTransaction)
        {
            ActivityWeekPlan transitionToactivity1 = new ActivityWeekPlan();
            fragmentTransaction.Replace(Resource.Id.FrameLayout, transitionToactivity1).AddToBackStack(null).Commit();
            Toast.MakeText(this, "Страница: Текущая задача.", ToastLength.Long).Show();
        }

        public void activityPlanCreation(FragmentTransaction fragmentTransaction)
        {
            ActivityCalendar transitionToactivity3 = new ActivityCalendar();
            fragmentTransaction.Replace(Resource.Id.FrameLayout, transitionToactivity3).AddToBackStack(null).Commit();
            Toast.MakeText(this, "Страница: Создать.", ToastLength.Long).Show();
        }

        public void activityStatistics(FragmentTransaction fragmentTransaction)
        {
            ActivityStatistics transitionToactivity2 = new ActivityStatistics();
            fragmentTransaction.Replace(Resource.Id.FrameLayout, transitionToactivity2).AddToBackStack(null).Commit();
            Toast.MakeText(this, "Страница: Статистика.", ToastLength.Long).Show();
        }
    }
}