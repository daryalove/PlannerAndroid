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
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RecyclerViewer;

namespace App1.Activity.ListOfTasks
{
    [Activity(Label = "ActivityListTasks")]
    class ActivityListTasks : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAlbumAdapter mAdapter;
        PhotoAlbum mPhotoAlbum;
        FloatingActionButton FabCreateTask;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            List<Photo> mBuiltInPhotos = new List<Photo>();
            mPhotoAlbum = new PhotoAlbum(mBuiltInPhotos);// переход в метод public PhotoAlbum()
            SetContentView(Resource.Layout.activity_list_tasks);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerViewListTask);
            FabCreateTask = FindViewById<FloatingActionButton>(Resource.Id.ListTaskFabCreateTask);
            
            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);
            mRecyclerView.SetAdapter(mAdapter);
            #region Нажатие кнопки
            FabCreateTask.Click += delegate
            {
                LayoutInflater layoutInflater = LayoutInflater.From(this);
                View view = layoutInflater.Inflate(Resource.Layout.activity_create_task, null);
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetView(view);
                #region Объявление переменных в диалоговом окне
                var EditName = view.FindViewById<EditText>(Resource.Id.EditCreateTaskName);
                var EditTime = view.FindViewById<EditText>(Resource.Id.EditCreateTaskTime);
                var EditNote = view.FindViewById<EditText>(Resource.Id.EditCreateTaskNote);
                var RatingImportance = view.FindViewById<RatingBar>(Resource.Id.RatingCreateTaskImportance);
                var CheckBoxkReminder = view.FindViewById<CheckBox>(Resource.Id.CheckBoxCreateTaskReminder);
                var timePicker = view.FindViewById<TimePicker>(Resource.Id.TimePickerCreateTask);
                timePicker.Visibility = ViewStates.Invisible;
                timePicker.SetIs24HourView(Java.Lang.Boolean.True);
                EditTime.Click += delegate
                {
                    timePicker.Visibility = ViewStates.Visible;
                };
                #endregion

                alert.SetCancelable(false)
                .SetPositiveButton("Создать", delegate
                {
                    EditTime.Text = timePicker.CurrentHour.ToString() + ":" + timePicker.CurrentMinute.ToString();

                    Photo b = new Photo(EditName.Text, EditTime.Text,
                        EditNote.Text, CheckBoxkReminder.Checked, 
                        RatingImportance.NumStars);

                    mBuiltInPhotos.Add(b);
                    mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);
                    mRecyclerView.SetAdapter(mAdapter);
                })
                .SetNegativeButton("Отмена", delegate
                {
                    alert.Dispose();
                });
                Dialog dialog = alert.Create();
                dialog.Show();
            };
            #endregion
        }

        //public void FabOnClick(object sender, EventArgs eventArgs)
        //{
        //    //View view = (View)sender;
        //    //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
        //    //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        //    LayoutInflater layoutInflater = LayoutInflater.From(this);
        //    View view = layoutInflater.Inflate(Resource.Layout.activity_create_task, null);
        //    Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
        //    alert.SetView(view);
        //    #region Объявление переменных в диалоговом окне
        //    var EditCreateTaskName = view.FindViewById<EditText>(Resource.Id.EditCreateTaskName);
        //    var EditCreateTaskTime = view.FindViewById<EditText>(Resource.Id.EditCreateTaskTime);
        //    var EditCreateTaskNote = view.FindViewById<EditText>(Resource.Id.EditCreateTaskNote);
        //    var RatingCreateTaskImportance = view.FindViewById<RatingBar>(Resource.Id.RatingCreateTaskImportance);
        //    var CheckBoxCreateTaskReminder = view.FindViewById<CheckBox>(Resource.Id.CheckBoxCreateTaskReminder);
        //    #endregion          

        //    alert.SetCancelable(false)
        //    .SetPositiveButton("Создать", delegate
        //    {
        //        mBuiltInPhotos.Add(6);
        //    })
        //    .SetNegativeButton("Отмена", delegate
        //    {
        //        alert.Dispose();
        //    });
        //    Dialog dialog = alert.Create();
        //    dialog.Show();
        //}
    }
}