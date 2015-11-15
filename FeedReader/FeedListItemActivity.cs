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
using Newtonsoft.Json;

namespace FeedReader
{
	[Activity(Label = "View posts" , Icon = "@drawable/icon")]
	public class FeedListItemActivity : Activity {
		private channel _feed;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView( Resource.Layout.showitems );

			_feed = JsonConvert.DeserializeObject<channel>( Intent.GetStringExtra( "feed" ) );

			var feedNameTextView = FindViewById<TextView>( Resource.Id.feedItemName );
			var articleCountTextView = FindViewById<TextView>( Resource.Id.articleCount );
			var feedItemListView = FindViewById<ListView>( Resource.Id.feedItemList );

			feedNameTextView.Text = "Name: " + _feed.Name;
			articleCountTextView.Text = "Articles: " + _feed.Allitem.Count( );
			feedItemListView.ItemClick += FeedItemListViewOnItemClick;

			feedItemListView.Adapter = new FeedItemListAdapter(this, _feed.Allitem.ToArray());
		}

		private void FeedItemListViewOnItemClick( object sender, AdapterView.ItemClickEventArgs itemClickEventArgs ) {
			var item = _feed.Allitem[itemClickEventArgs.Position];

			var intent = new Intent( this, typeof(WebActivity) );
			intent.PutExtra("link", item.Link);
			StartActivity(intent);

		}
	}

	public class FeedItemListAdapter : BaseAdapter<items> {
		private readonly FeedListItemActivity _feedListItemActivity;
		private readonly items[] _rssItems;

		public FeedItemListAdapter( FeedListItemActivity feedListItemActivity, items[] rssItems ) {
			_feedListItemActivity = feedListItemActivity;
			_rssItems = rssItems;
		}

		public override long GetItemId( int position ) {
			return position;
		}

		public override View GetView( int position, View convertView, ViewGroup parent ) {
			var view = convertView;
			if ( view == null ) {
				view = _feedListItemActivity.LayoutInflater.Inflate( Android.Resource.Layout.SimpleListItem2, null );
			}

			view.FindViewById<TextView>( Android.Resource.Id.Text1 ).Text = _rssItems[position].Title;
			view.FindViewById<TextView>( Android.Resource.Id.Text2 ).Text = string.Format( "{0} on {1}", _rssItems[position].Creator, _rssItems[position].PubDate );

			return view;
		}

		public override int Count {
			get { return _rssItems.Count( ); }
		}

		public override items this[ int position ] {
			get { return _rssItems[position]; }
		}
	}
}