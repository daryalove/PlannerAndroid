using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App1.Activity.Registration_Authorization;

namespace App1
{
    [Activity(Label = "Planer", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private Button ButtonEntranceMain;

        private Button ButtonRegistrationMain;

        Toolbar toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
           
            ButtonEntranceMain = FindViewById<Button>(Resource.Id.ButtonEntranceMain);
            ButtonRegistrationMain = FindViewById<Button>(Resource.Id.ButtonRegistrationMain);
            
            ButtonEntranceMain.Click += delegate
            {
                Intent Entrance = new Intent(this, typeof(ActivityEntrance));
                StartActivity(Entrance);
            };

            ButtonRegistrationMain.Click += delegate
            {
                Intent ProfileCreation = new Intent(this, typeof(ActivityProfileCreation));
                StartActivity(ProfileCreation);
            };
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.menu_main, menu);
        //    return true;
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    int id = item.ItemId;
        //    if (id == Resource.Id.action_settings)
        //    {
        //        return true;
        //    }

        //    return base.OnOptionsItemSelected(item);
        //}
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

