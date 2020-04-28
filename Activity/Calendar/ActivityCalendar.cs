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

namespace App1.Activity.Plan
{
    class ActivityCalendar : Fragment
    {
        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.activity_calendar, container, false);
            var datePicker = view.FindViewById<DatePicker>(Resource.Id.DatePickerCalendar);
            //for (DateTime i = DateTime.Now; i < DateTime.Now.AddMonths(2); i = i.AddDays(1))
            //{
            //    if ((i.DayOfWeek == DayOfWeek.Saturday) || (i.DayOfWeek == DayOfWeek.Sunday))
            //    {
                    
            //        //SpecDate.Add(new SpecialDate(i)
            //        //{
            //        //    TextColor = Color.Gray,
            //        //    Selectable = false,
            //        //    FontSize = 10,
            //        //    BackgroundPattern = new BackgroundPattern(1)
            //        //    {
            //        //        Pattern = new List
            //        //        {
            //        //        new Pattern{ WidthPercent = 1f, HightPercent = 1f, Color = Color.Transparent,Text = "", TextSize =11, TextAlign=TextAlign.CenterBottom}
            //        //        }
            //        //    }
            //        //});
            //    }
            //}

            return view;
        }
        
        //void DateSelect_OnClick(object sender, EventArgs eventArgs)
        //{
        //    DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
        //    {
        //        _dateDisplay.Text = time.ToLongDateString();
        //    });
        //    frag.Show(FragmentManager, DatePickerFragment.TAG);
        //}
        //public override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //}

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    var view = inflater.Inflate(Resource.Layout.activity_calendar, container, false);

        //    var dateEditText = FindViewById<EditText>(Resource.Id.date_EditText);
        //    dateEditText.Text = DateTime.Now.ToShortDateString();
        //    dateEditText.Click += delegate
        //    {
        //        OnClickDateEditText();
        //    };

        //    return view;
        //}
        //private void OnClickDateEditText()
        //{
        //    var dateTimeNow = DateTime.Now;
        //    DatePickerDialog datePicker = new DatePickerDialog(Context, , dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day);
        //    datePicker.Show();
        //}

        //public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        //{
        //    FindViewById<EditText>(Resource.Id.date_EditText).Text = new DateTime(year, month, dayOfMonth).ToShortDateString();
        //}
    }
}