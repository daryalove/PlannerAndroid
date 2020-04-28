using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace App1.Activity.Statistic
{
    class ActivityStatistics : Android.App.Fragment
    {
        
        private static TextView TextProgress;
        private static ProgressBar circularbar;
        private static RatingBar ratingBar;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.activity_statistics, container, false);

            circularbar = view.FindViewById<ProgressBar>(Resource.Id.circularProgressbar);
            ratingBar = view.FindViewById<RatingBar>(Resource.Id.RatingBarStatistics);
            TextProgress = view.FindViewById<TextView>(Resource.Id.TextViewProgressStatistics);
            ratingBar.RatingBarChange += RTBStart_Click;
            circularbar.Max = 100;
            circularbar.Progress = 0;
            circularbar.SecondaryProgress = 0;

            return view;
        }
        private void RTBStart_Click(object sender, System.EventArgs e)
        {
            int r = Convert.ToInt32(ratingBar.Rating);
            TextProgress.Text = (100 / r).ToString();
            int progressStatus = 0, progressStatus1 = 100;           
            new System.Threading.Thread(new ThreadStart( delegate
            {
                while (progressStatus < (100/r))
                {
                    progressStatus += 1;
                    progressStatus1 -= 1;
                    circularbar.Progress = progressStatus;                    
                    System.Threading.Thread.Sleep(20);
                }
            })).Start();
        }

    }
}