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
using RecyclerViewer;

namespace App1.Activity.ListOfTasks
{
    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        public PhotoAlbum mPhotoAlbum;
        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCardView, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            vh.EditName.Text = mPhotoAlbum[position].EditName;
            vh.EditNote.Text = mPhotoAlbum[position].EditNote;
            vh.EditTime.Text = mPhotoAlbum[position].EditTime;
            vh.RatingImportance.Rating = mPhotoAlbum[position].RatingImportance;
            vh.CheckBoxkReminder.Checked = mPhotoAlbum[position].CheckBoxReminder;
            vh.RatingImportance.Focusable = false;
            vh.RatingImportance.Enabled = false;
            vh.RatingImportance.LongClickable = false;
        }

        public override int ItemCount
        {
            get { return mPhotoAlbum.NumPhotos; }
        }
    }
}