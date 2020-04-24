using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace RecyclerViewer
{
    public class Photo
    {
        public string EditName { get; set; }
        public string EditTime { get; set; }
        public string EditNote { get; set; }
        public bool CheckBoxReminder { get; set; }
        public int RatingImportance { get; set; }

        public Photo(string EditName, string EditTime,
            string EditNote, bool CheckBoxReminder, 
            int RatingImportance)
        {
            this.EditName = EditName;
            this.EditTime = EditTime;
            this.EditNote = EditNote;
            this.CheckBoxReminder = CheckBoxReminder;
            this.RatingImportance = RatingImportance;
        }
    }

    public class PhotoAlbum
    {

        List<Photo> mBuiltInPhotos = new List<Photo>();
        Random mRandom;

        public PhotoAlbum(List<Photo> mBuiltInPhotos)
        {
            this.mBuiltInPhotos = mBuiltInPhotos;
            mRandom = new Random();
        }

        public int NumPhotos
        {
            get { return mBuiltInPhotos.Count; }
        }
        public Photo this[int i]// для чего ?
        {
            get { return mBuiltInPhotos[i]; }
        }

        public int RandomSwap()
        {
            Photo tmpPhoto = mBuiltInPhotos[0];

            int rnd = mRandom.Next(1, mBuiltInPhotos.Count);

            mBuiltInPhotos[0] = mBuiltInPhotos[rnd];
            mBuiltInPhotos[rnd] = tmpPhoto;
            return rnd;
        }

        public void Shuffle()
        {

            for (int idx = 0; idx < mBuiltInPhotos.Count; ++idx)
            {
                Photo tmpPhoto = mBuiltInPhotos[idx];
                int rnd = mRandom.Next(idx, mBuiltInPhotos.Count);
                mBuiltInPhotos[idx] = mBuiltInPhotos[rnd];
                mBuiltInPhotos[rnd] = tmpPhoto;
            }
        }
    }
}