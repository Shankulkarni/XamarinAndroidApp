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
using Android.Webkit;

namespace FeedReader
{
	[Activity(Label = "Add new Blog", Icon = "@drawable/icon")]
	public class AddFeedActivity : Activity {
		private EditText _urlText;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.addFeed);

			_urlText = FindViewById<EditText>( Resource.Id.textUri );
			var addButton = FindViewById<Button>( Resource.Id.addUrlButton );

			addButton.Click += AddButtonOnClick;
		}

		private void AddButtonOnClick( object sender, EventArgs eventArgs ) {
			var intent = new Intent( this, typeof ( MainActivity ) );
			intent.PutExtra( "url", _urlText.Text );
			SetResult(Result.Ok, intent);

			Finish();
		}
	}
}