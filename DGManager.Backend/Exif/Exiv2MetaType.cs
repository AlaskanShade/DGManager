using System;

namespace DGManager.Backend.Exif
{
	public enum GpsAltitudeRef
	{
		AboveSeaLevel = 0,
		BelowSeaLevel = 1
	}

	public enum Exiv2MetaTypeEnum
	{
		ImageDescription,
		XPComment,
		XPKeywords,
		XPSubject,
		UserComment,
		DateTimeOriginal,
		GPSVersionID,
		GPSLatitudeRef,
		GPSLatitude,
		GPSLongitudeRef,
		GPSLongitude,
		GPSAltitudeRef,
		GPSAltitude,
		GPSTimeStamp,
		GPSSatellites,
		GPSStatus,
		GPSMeasureMode,
		GPSDOP,
		GPSSpeedRef,
		GPSSpeed,
		GPSTrackRef,
		GPSTrack,
		GPSImgDirectionRef,
		GPSImgDirection,
		GPSMapDatum,
		GPSDestLatitudeRef,
		GPSDestLatitude,
		GPSDestLongitudeRef,
		GPSDestLongitude,
		GPSDestBearingRef,
		GPSDestBearing,
		GPSDestDistanceRef,
		GPSDestDistance,
		GPSProcessingMethod,
		GPSAreaInformation,
		GPSDateStamp,
		GPSDifferential,
		IptcLocationName,
		IptcLocationCode,
		IptcCountryName,
		IptcCountryCode,
		IptcCity,
		IptcSubLocation,
		IptcProvinceState,
		IptcKeywords,
		IptcCaption
	}

	public struct Exiv2MetaType : IComparable<Exiv2MetaType>
	{
		private string tag;
		private Exiv2MetaTypeEnum metaType;
		private Exiv2DataType dataType;

		public static Exiv2MetaType ImageDescription = new Exiv2MetaType(Exiv2MetaTypeEnum.ImageDescription, Exiv2DataType.asciiString, "Exif.Image.ImageDescription");
		public static Exiv2MetaType XPComment = new Exiv2MetaType(Exiv2MetaTypeEnum.XPComment, Exiv2DataType.asciiString, "Exif.Image.XPComment");
		public static Exiv2MetaType XPKeywords = new Exiv2MetaType(Exiv2MetaTypeEnum.XPKeywords, Exiv2DataType.asciiString, "Exif.Image.XPKeywords");
		public static Exiv2MetaType XPSubject = new Exiv2MetaType(Exiv2MetaTypeEnum.XPSubject, Exiv2DataType.asciiString, "Exif.Image.XPSubject");
		public static Exiv2MetaType UserComment = new Exiv2MetaType(Exiv2MetaTypeEnum.UserComment, Exiv2DataType.comment, "Exif.Photo.UserComment");
		public static Exiv2MetaType DateTimeOriginal = new Exiv2MetaType(Exiv2MetaTypeEnum.DateTimeOriginal, Exiv2DataType.asciiString, "Exif.Photo.DateTimeOriginal");
		public static Exiv2MetaType GPSVersionID = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSVersionID, Exiv2DataType.unsignedByte, "Exif.GPSInfo.GPSVersionID");
		public static Exiv2MetaType GPSLatitudeRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSLatitudeRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSLatitudeRef");
		public static Exiv2MetaType GPSLatitude = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSLatitude, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSLatitude");
		public static Exiv2MetaType GPSLongitudeRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSLongitudeRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSLongitudeRef");
		public static Exiv2MetaType GPSLongitude = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSLongitude, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSLongitude");
		public static Exiv2MetaType GPSAltitudeRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSAltitudeRef, Exiv2DataType.unsignedByte, "Exif.GPSInfo.GPSAltitudeRef");
		public static Exiv2MetaType GPSAltitude = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSAltitude, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSAltitude");
		public static Exiv2MetaType GPSTimeStamp = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSTimeStamp, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSTimeStamp");
		public static Exiv2MetaType GPSSatellites = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSSatellites, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSSatellites");
		public static Exiv2MetaType GPSStatus = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSStatus, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSStatus");
		public static Exiv2MetaType GPSMeasureMode = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSMeasureMode, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSMeasureMode");
		public static Exiv2MetaType GPSDOP = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDOP, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSDOP");
		public static Exiv2MetaType GPSSpeedRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSSpeedRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSSpeedRef");
		public static Exiv2MetaType GPSSpeed = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSSpeed, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSSpeed");
		public static Exiv2MetaType GPSTrackRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSTrackRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSTrackRef");
		public static Exiv2MetaType GPSTrack = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSTrack, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSTrack");
		public static Exiv2MetaType GPSImgDirectionRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSImgDirectionRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSImgDirectionRef");
		public static Exiv2MetaType GPSImgDirection = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSImgDirection, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSImgDirection");
		public static Exiv2MetaType GPSMapDatum = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSMapDatum, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSMapDatum");
		public static Exiv2MetaType GPSDestLatitudeRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDestLatitudeRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSDestLatitudeRef");
		public static Exiv2MetaType GPSDestLatitude = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDestLatitude, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSDestLatitude");
		public static Exiv2MetaType GPSDestLongitudeRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDestLongitudeRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSDestLongitudeRef");
		public static Exiv2MetaType GPSDestLongitude = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDestLongitude, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSDestLongitude");
		public static Exiv2MetaType GPSDestBearingRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDestBearingRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSDestBearingRef");
		public static Exiv2MetaType GPSDestBearing = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDestBearing, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSDestBearing");
		public static Exiv2MetaType GPSDestDistanceRef = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDestDistanceRef, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSDestDistanceRef");
		public static Exiv2MetaType GPSDestDistance = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDestDistance, Exiv2DataType.unsignedRational, "Exif.GPSInfo.GPSDestDistance");
		public static Exiv2MetaType GPSProcessingMethod = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSProcessingMethod, Exiv2DataType.undefined, "Exif.GPSInfo.GPSProcessingMethod");
		public static Exiv2MetaType GPSAreaInformation = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSAreaInformation, Exiv2DataType.undefined, "Exif.GPSInfo.GPSAreaInformation");
		public static Exiv2MetaType GPSDateStamp = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDateStamp, Exiv2DataType.asciiString, "Exif.GPSInfo.GPSDateStamp");
		public static Exiv2MetaType GPSDifferential = new Exiv2MetaType(Exiv2MetaTypeEnum.GPSDifferential, Exiv2DataType.unsignedShort, "Exif.GPSInfo.GPSDifferential");
		public static Exiv2MetaType IptcLocationName = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcLocationName, Exiv2DataType.asciiString, "Iptc.Application2.LocationName");
		public static Exiv2MetaType IptcLocationCode = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcLocationCode, Exiv2DataType.asciiString, "Iptc.Application2.LocationCode");
		public static Exiv2MetaType IptcCountryName = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcCountryName, Exiv2DataType.asciiString, "Iptc.Application2.CountryName");
		public static Exiv2MetaType IptcCountryCode = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcCountryCode, Exiv2DataType.asciiString, "Iptc.Application2.CountryCode");
		public static Exiv2MetaType IptcCity = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcCity, Exiv2DataType.asciiString, "Iptc.Application2.City");
		public static Exiv2MetaType IptcSubLocation = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcSubLocation, Exiv2DataType.asciiString, "Iptc.Application2.SubLocation");
		public static Exiv2MetaType IptcProvinceState = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcProvinceState, Exiv2DataType.asciiString, "Iptc.Application2.ProvinceState");
		public static Exiv2MetaType IptcKeywords = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcKeywords, Exiv2DataType.asciiString, "Iptc.Application2.Keywords");
		public static Exiv2MetaType IptcCaption = new Exiv2MetaType(Exiv2MetaTypeEnum.IptcCaption, Exiv2DataType.asciiString, "Iptc.Application2.Caption");

		public string Tag
		{
			get
			{
				return tag;
			}
		}

		public Exiv2MetaTypeEnum MetaType
		{
			get
			{
				return metaType;
			}
		}

		public Exiv2DataType DataType
		{
			get
			{
				return dataType;
			}
		}

		public Exiv2MetaType(Exiv2MetaTypeEnum metaType, Exiv2DataType dataType, string tag)
		{
			this.tag = tag;
			this.metaType = metaType;
			this.dataType = dataType;
		}

		/*public static Exiv2MetaType GetStatus(Exiv2MetaTypeEnum type)
		{
			switch (type)
			{
				case Exiv2MetaTypeEnum.Draft:
					return Draft;
				case ActionStatusEnum.NotStarted:
					return NotStarted;
				case ActionStatusEnum.InProgress:
					return InProgress;
				case ActionStatusEnum.InReview:
					return InReview;
				case ActionStatusEnum.Completed:
					return Completed;
				default:
					return Unknown;
			}
		}*/

		public static bool operator ==(Exiv2MetaType a, Exiv2MetaType b)
		{
			// Return true if the fields match:
			return a.MetaType == b.MetaType;
		}

		public static bool operator !=(Exiv2MetaType a, Exiv2MetaType b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Exiv2MetaType))
			{
				return false;
			}
			Exiv2MetaType exiv2MetaType = (Exiv2MetaType)obj;
			return Equals(MetaType, exiv2MetaType.MetaType);
		}

		public override int GetHashCode()
		{
			return MetaType.GetHashCode();
		}

		public override string ToString()
		{
			return Tag;
		}

		#region IComparable members

		public int CompareTo(Exiv2MetaType other)
		{
			return MetaType.CompareTo(other.MetaType);
		}

		#endregion
	}
}
