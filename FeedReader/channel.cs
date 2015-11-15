using System;
using System.Collections.Generic;

namespace FeedReader
{
	public class channel
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public DateTime DateAdded { get; set; }
		public List<items> Allitem { get; set; }

		public channel ()
		{
			Allitem = new List<items> ();
		}
	}
}

