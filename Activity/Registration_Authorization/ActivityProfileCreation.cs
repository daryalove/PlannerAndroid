using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App1.Activity.Registration_Authorization
{
    [Activity(Label = "ActivityProfileCreation")]
    class ActivityProfileCreation : AppCompatActivity
    {
        #region Объявление переменных

        private EditText EditProfileCreationLastName;

        private EditText EditProfileCreationName;

        private EditText EditProfileCreationPasswordRepeat;

        private EditText EditProfileCreationLogin;

        private EditText EditProfileCreationPassword;

        private EditText EditProfileCreationDateOfBirth;

        private Button ButtonProfileCreation;

        private ProgressBar loader;

        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_profile_creation);

            #region Инициализация переменных
            EditProfileCreationLastName = FindViewById<EditText>(Resource.Id.EditProfileCreationLastName);
            EditProfileCreationName = FindViewById<EditText>(Resource.Id.EditProfileCreationName);
            EditProfileCreationPasswordRepeat = FindViewById<EditText>(Resource.Id.EditProfileCreationPasswordRepeat);
            EditProfileCreationLogin = FindViewById<EditText>(Resource.Id.EditProfileCreationLogin);
            EditProfileCreationPassword = FindViewById<EditText>(Resource.Id.EditProfileCreationPassword);
            EditProfileCreationDateOfBirth = FindViewById<EditText>(Resource.Id.EditProfileCreationDateOfBirth);
            ButtonProfileCreation = FindViewById<Button>(Resource.Id.ButtonProfileCreation);
            loader = FindViewById<ProgressBar>(Resource.Id.loader);
            EditProfileCreationDateOfBirth.Focusable = false;
            EditProfileCreationDateOfBirth.Clickable = false;
            #endregion

            EditProfileCreationDateOfBirth.Click += DateSelect_OnClick;

            ButtonProfileCreation.Click += delegate
            {
                loader.Visibility = Android.Views.ViewStates.Visible;

                if (EditProfileCreationPassword.Text == EditProfileCreationPasswordRepeat.Text)
                {
                    loader.Visibility = ViewStates.Invisible;
                }
                else
                {
                    Toast.MakeText(this,"Пароли не совпадают", ToastLength.Long).Show();
                    loader.Visibility = ViewStates.Invisible;
                }
            };

            //Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
            //alert.SetTitle("Внимание!");
            //alert.SetMessage("Чтобы установить дату рождения, нажмите 2 раза на соответствующее поле !");
            //alert.SetPositiveButton("Закрыть", (senderAlert, args) =>
            //{                
            //});
            //Dialog dialog = alert.Create();
            //dialog.Show();

        }
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time) {
                EditProfileCreationDateOfBirth.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        public class DatePickerFragment : DialogFragment,
    DatePickerDialog.IOnDateSetListener
        {
            // TAG can be any string of your choice.  
            public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();
            // Initialize this value to prevent NullReferenceExceptions.  
            Action<DateTime> _dateSelectedHandler = delegate { };
            public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
            {
                DatePickerFragment frag = new DatePickerFragment();
                frag._dateSelectedHandler = onDateSelected;
                return frag;
            }
            public override Dialog OnCreateDialog(Bundle savedInstanceState)
            {
                DateTime currently = DateTime.Now;
                DatePickerDialog dialog = new DatePickerDialog(Activity, this, currently.Year, currently.Month, currently.Day);
                return dialog;
            }
            public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
            {
                // Note: monthOfYear is a value between 0 and 11, not 1 and 12!  
                DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
                Log.Debug(TAG, selectedDate.ToLongDateString());
                _dateSelectedHandler(selectedDate);
            }
        }
        //private void OnClickDateEditText()
        //{
        //    var dateTimeNow = DateTime.Now;
        //    DatePickerDialog datePicker = new DatePickerDialog(this, OnDateSet, dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day);
        //    datePicker.Show();
        //}

        //public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        //{
        //    FindViewById<EditText>(Resource.Id.EditProfileCreationDateOfBirth).Text = new DateTime(year, month, dayOfMonth).ToShortDateString();
        //}

    }
}