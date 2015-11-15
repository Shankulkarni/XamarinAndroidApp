
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
using System.Net.Http;
using Android.Util;
using System.Net;
using System.IO;

namespace FeedReader
{
	[Activity (Label = "Blog Page", Icon = "@drawable/icon")]
	public class WebActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);
//			String url = Intent.GetStringExtra ("link");
//			try
//			{
//				WebRequest req = HttpWebRequest.Create(url);
//				req.Method = "GET";
//
//				string source;
//				using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
//				{
//					source = reader.ReadToEnd();
//				}
//				
//				Log.Info("Debugging1", source);
//
//			}
//			catch ( Exception ex)
//			{
//				Log.Error( "Debugging1", "Encountered an error attempting to deserialize feed data: {0}", ex.Message );
//
//			}
			SetContentView(Resource.Layout.WebActivity);

			WebView view = FindViewById<WebView>(Resource.Id.DetailView);

			view.LoadUrl(Intent.GetStringExtra("link"));
		}
	}
}

