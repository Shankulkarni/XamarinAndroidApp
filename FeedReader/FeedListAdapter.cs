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

namespace FeedReader
{
	public class FeedListAdapter : BaseAdapter<channel> {
		private channel[] _feeds;
		private Activity _context;

		public FeedListAdapter( channel[] feeds, Activity context ) : base() {
			_feeds = feeds;
			_context = context;
		}

		public override long GetItemId( int position ) {
			return position;
		}

		public override View GetView( int position, View convertView, ViewGroup parent ) {
			var view = convertView;
			if ( view == null ) {
				view = _context.LayoutInflater.Inflate( Android.Resource.Layout.SimpleListItem2, null );
			}

			view.FindViewById<TextView>( Android.Resource.Id.Text1 ).Text = _feeds[position].Name;
			view.FindViewById<TextView>( Android.Resource.Id.Text2 ).Text = string.Format( "Added On: {0} - {1} items", _feeds[position].DateAdded, _feeds[position].Allitem.Count );

			return view;
		}

		public override int Count {
			get { return _feeds.Count( ); }
		}

		public override channel this[ int position ] {
			get { return _feeds[position]; }
		}
	}
}