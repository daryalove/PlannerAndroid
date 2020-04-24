using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App1.Activity.Plan;
using Plugin.Settings;

namespace App1.Activity.Registration_Authorization
{
    [Activity(Label = "ActivityEntrance")]
    class ActivityEntrance : AppCompatActivity
    {

        #region Объявление переменных

        private EditText EditEntranceLogin;

        private EditText EditEntrancePassword;

        private CheckBox CheckBoxEntranceRemember;

        private Button ButtonEntranceRegistration;

        private Button ButtonEntrance;

        private ProgressBar loader;

        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_entrance);

            #region Инициализация переменных
            EditEntranceLogin = FindViewById<EditText>(Resource.Id.EditEntranceLogin);
            EditEntrancePassword = FindViewById<EditText>(Resource.Id.EditEntrancePassword);
            CheckBoxEntranceRemember = FindViewById<CheckBox>(Resource.Id.CheckBoxEntranceRemember);
            ButtonEntranceRegistration = FindViewById<Button>(Resource.Id.ButtonEntranceRegistration);
            ButtonEntrance = FindViewById<Button>(Resource.Id.ButtonEntrance);
            loader = FindViewById<ProgressBar>(Resource.Id.loader);
            #endregion

            ButtonEntranceRegistration.Click += delegate
            {
                loader.Visibility = Android.Views.ViewStates.Visible;
                Intent ProfileCreation = new Intent(this, typeof(ActivityProfileCreation));
                StartActivity(ProfileCreation);
            };

            ButtonEntrance.Click += delegate
            {
                CrossSettings.Current.AddOrUpdateValue("isEntrance", "1");
                Intent MainPlan = new Intent(this, typeof(ActivityMainPlan));
                StartActivity(MainPlan);
            };

        }

    }
}