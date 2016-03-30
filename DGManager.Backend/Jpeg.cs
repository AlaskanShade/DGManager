using System;
using System.Collections.Generic;
using DGManager.Backend.Exif;

namespace DGManager.Backend
{
	public class Jpeg
	{
		private Dictionary<Exiv2MetaType, List<string>> stringTags;

        public string FilePath { get; set; }

        public DateTime OriginalDateTime { get; set; }

        public DateTime OffsetDateTime { get; set; }

        public DateTime GpsDateTime { get; set; }

        public Location Location { get; set; }

        public double? Speed { get; set; }

        public string LocationText { get; set; }

		public Dictionary<Exiv2MetaType, List<string>> StringTags
		{
			get
			{
				if (stringTags == null)
				{
					stringTags = new Dictionary<Exiv2MetaType, List<string>>();
				}

				return stringTags;
			}
			set
			{
				stringTags = value;
			}
		}
	}
}
