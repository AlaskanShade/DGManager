using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using DGManager.Backend.Exif;

namespace DGManager.Backend
{
	public class ReverseGeocoder
	{
		public static string AddLocationTags(Jpeg jpeg)
		{
			RevGeoWithGeoNames(jpeg);
			string addressUnicode = null;

			if (Settings.RevGeoUseGoogleMaps)
			{
				addressUnicode = RevGeoWithGMaps(jpeg);
			}

			string addressAscii;

			if (String.IsNullOrEmpty(addressUnicode))
			{
				addressUnicode = String.Empty;
				
				if (jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcLocationName))
				{
					addressUnicode = jpeg.StringTags[Exiv2MetaType.IptcLocationName][0];
				}

				if (jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcSubLocation))
				{
					addressUnicode += (addressUnicode.Length > 0 ? ", " : "") + jpeg.StringTags[Exiv2MetaType.IptcSubLocation][0];
				}

				if (jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcProvinceState))
				{
					addressUnicode += (addressUnicode.Length > 0 ? ", " : "") + jpeg.StringTags[Exiv2MetaType.IptcProvinceState][0];
				}

				if (jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcCountryName))
				{
					addressUnicode += (addressUnicode.Length > 0 ? ", " : "") + jpeg.StringTags[Exiv2MetaType.IptcCountryName][0];
				}
			}

      //Martin Öbrink-Hansen added this: remove/replace most common danish/swedish/german non-ascii characters
      string cleanedUnicode =
        addressUnicode.Replace("Å", "Aa").Replace("å", "aa").Replace("Ø", "Oe").Replace("ø", "oe").Replace("Æ", "Ae").Replace(
          "æ", "ae").Replace("Ö", "Oe").Replace("ö", "oe").Replace("Ä", "Ae").Replace("ä", "ae").Replace("Ü","Ue").Replace(
          "ü", "ue").Replace("ß", "ss").Replace("é", "e");

      addressAscii = Encoding.Default.GetString(Encoding.Default.GetBytes(cleanedUnicode));

			if (Settings.RevGeoSetImageDescription)
			{
				SetStringTag(jpeg, Exiv2MetaType.ImageDescription, addressAscii);
			}

			if (Settings.RevGeoSetXPComment)
			{
				SetStringTag(jpeg, Exiv2MetaType.XPComment, addressAscii);
			}

			if (Settings.RevGeoSetXPKeywords)
			{
				SetStringTag(jpeg, Exiv2MetaType.XPKeywords, addressAscii);
			}

			if (Settings.RevGeoSetXPSubject)
			{
				SetStringTag(jpeg, Exiv2MetaType.XPSubject, addressAscii);
			}

			if (Settings.RevGeoSetUserComment)
			{
				SetStringTag(jpeg, Exiv2MetaType.UserComment, addressUnicode);
			}
			
			if (Settings.RevGeoSetIptcCaption)
			{
				SetStringTag(jpeg, Exiv2MetaType.IptcCaption, addressAscii);
			}

			if (Settings.RevGeoSetIptcKeywords)
			{
				if (!jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcKeywords))
				{
					jpeg.StringTags[Exiv2MetaType.IptcKeywords] = new List<string>();
				}

				string[] addressParts = addressAscii.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
				List<string> nonexistingAddressParts = new List<string>();

                Array.ForEach(addressParts, addressPart =>
                {
                    if (!jpeg.StringTags[Exiv2MetaType.IptcKeywords].Contains(addressPart))
                        nonexistingAddressParts.Add(addressPart);
                });

				//add province / state to keywords
				if (jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcProvinceState) &&
					!jpeg.StringTags[Exiv2MetaType.IptcKeywords].Contains(jpeg.StringTags[Exiv2MetaType.IptcProvinceState][0]) &&
					!nonexistingAddressParts.Contains(jpeg.StringTags[Exiv2MetaType.IptcProvinceState][0]))
				{
					nonexistingAddressParts.Add(jpeg.StringTags[Exiv2MetaType.IptcProvinceState][0]);
				}

				jpeg.StringTags[Exiv2MetaType.IptcKeywords].Clear();
				jpeg.StringTags[Exiv2MetaType.IptcKeywords].AddRange(nonexistingAddressParts);
			}

			jpeg.LocationText = addressUnicode;
			return addressUnicode;
		}

		private static void SetStringTag(Jpeg jpeg, Exiv2MetaType metaType, string value)
		{
			if (!jpeg.StringTags.ContainsKey(metaType))
			{
				jpeg.StringTags[metaType] = new List<string>();
				jpeg.StringTags[metaType].Add(String.Empty);
			}

			string currentValue = jpeg.StringTags[metaType][0];

			if (!currentValue.Contains(value))
			{
                jpeg.StringTags[metaType][0] = currentValue.Length > 0 ? String.Format("{0} ({1})", currentValue, value) : value;
			}
		}

		private static string RevGeoWithGMaps(Jpeg jpeg)
		{
			XmlDocument responseXml = new XmlDocument();
			string queryString = String.Format("?q=from%20{0},{1}%20to%20{0},{1}&output=kml",
												 jpeg.Location.Latitude.ToString(CultureInfo.InvariantCulture),
												 jpeg.Location.Longitude.ToString(CultureInfo.InvariantCulture));

			WebRequest req = WebRequest.Create(Constants.GMAPS_SERVICE_URL + queryString);
			WebResponse resp = req.GetResponse();

			Stream s = resp.GetResponseStream();
			StreamReader sr = new StreamReader(s, Encoding.UTF8);
			string responseText = sr.ReadToEnd();

			if (String.IsNullOrEmpty(responseText))
			{
				return null;
			}

			responseXml.LoadXml(responseText);

			if (String.IsNullOrEmpty(responseXml.OuterXml) || responseXml.SelectSingleNode("//*[local-name()='address']") == null)
			{
				return null;
			}

			string streetName = responseXml.SelectSingleNode("//*[local-name()='address']").InnerText;

			if (String.IsNullOrEmpty(streetName))
			{
				return null;
			}

            queryString = String.Format("?output=xml&key={0}&q=", Settings.GMapsApiKey);

			queryString += streetName;

			if (jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcProvinceState))
			{
                queryString += String.Format(",{0}", jpeg.StringTags[Exiv2MetaType.IptcProvinceState][0]);
			}

			if (jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcCountryName))
			{
                queryString += String.Format(",{0}", jpeg.StringTags[Exiv2MetaType.IptcCountryName][0]);
			}

		  queryString += "&oe=utf-8"; //Martin Öbrink-Hansen added this: Make sure gmaps geocoding service returns UTF-8 encoded data, otherwise
                                  //the assumption when creating a StreamReader below doesn't hold and unicode characters are represented by '?'

			req = WebRequest.Create(Constants.GMAPS_GEOCODING_SERVICE_URL + queryString);
			resp = req.GetResponse();

			s = resp.GetResponseStream();
			sr = new StreamReader(s, Encoding.UTF8);
			responseText = sr.ReadToEnd();

			responseXml.LoadXml(responseText);

			XmlNodeList addressCandidates = responseXml.SelectNodes("//*[local-name()='Placemark']");
			XmlNode bestMatch = null;
			double closestDistance = -1;

			foreach (XmlNode candidate in addressCandidates)
			{
				string[] coords = candidate.SelectSingleNode(".//*[local-name()='coordinates']").InnerText.Split(',');
				double lat = Double.Parse(coords[1], CultureInfo.InvariantCulture);
				double lon = Double.Parse(coords[0], CultureInfo.InvariantCulture);
				double distance = Support.DistanceBetweenPoints(jpeg.Location.Latitude, jpeg.Location.Longitude, lat, lon);

				if (bestMatch == null || distance < closestDistance)
				{
					bestMatch = candidate;
					closestDistance = distance;
				}
			}

			//Max distance from photo to street is 20 km
			if (bestMatch == null || closestDistance > 20000)
			{
				return null;
			}

			XmlNode primaryLocationNameNode = bestMatch.SelectSingleNode(".//*[local-name()='LocalityName']");
			XmlNode postalCodeNumberNode = bestMatch.SelectSingleNode(".//*[local-name()='PostalCodeNumber']");
			XmlNode administrativeAreaNameNode = bestMatch.SelectSingleNode(".//*[local-name()='AdministrativeAreaName']");

			if (primaryLocationNameNode != null && !String.IsNullOrEmpty(primaryLocationNameNode.InnerText))
			{
				jpeg.StringTags[Exiv2MetaType.IptcLocationName] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcLocationName].Add(primaryLocationNameNode.InnerText);
				jpeg.StringTags[Exiv2MetaType.IptcCity] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcCity].Add(primaryLocationNameNode.InnerText);
			}

			if (!jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcSubLocation) &&
				postalCodeNumberNode != null && !String.IsNullOrEmpty(postalCodeNumberNode.InnerText))
			{
				jpeg.StringTags[Exiv2MetaType.IptcSubLocation] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcSubLocation].Add(postalCodeNumberNode.InnerText);
			}

			if (!jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcProvinceState) &&
				administrativeAreaNameNode != null && !String.IsNullOrEmpty(administrativeAreaNameNode.InnerText))
			{
				jpeg.StringTags[Exiv2MetaType.IptcProvinceState] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcProvinceState].Add(administrativeAreaNameNode.InnerText);
			}

			string address = bestMatch.SelectSingleNode(".//*[local-name()='address']").InnerText;

			//insert the city/suburb/town if it isn't in the address
			if ((primaryLocationNameNode == null || !String.IsNullOrEmpty(primaryLocationNameNode.InnerText))
				&& jpeg.StringTags.ContainsKey(Exiv2MetaType.IptcLocationName)
				&& !address.Contains(jpeg.StringTags[Exiv2MetaType.IptcLocationName][0]))
			{
                address = address.Replace(streetName, String.Format("{0}, {1}", streetName, jpeg.StringTags[Exiv2MetaType.IptcLocationName][0]));
			}

			return String.IsNullOrEmpty(address) ? null : address;
		}

		private static void RevGeoWithGeoNames(Jpeg jpeg)
		{
			XmlDocument responseXml = new XmlDocument();
			string queryString = String.Format("?lat={0}&lng={1}&style=FULL",
												 jpeg.Location.Latitude.ToString(CultureInfo.InvariantCulture),
												 jpeg.Location.Longitude.ToString(CultureInfo.InvariantCulture));

			responseXml.Load(Constants.GEONAMES_SERVICE_URL + queryString);

			XmlNode primaryLocationNameNode = responseXml.SelectSingleNode("//name");
			XmlNode countryCodeNode = responseXml.SelectSingleNode("//countryCode");
			XmlNode countryNameNode = responseXml.SelectSingleNode("//countryName");
			XmlNode secondaryLocationNameNode = responseXml.SelectSingleNode("//adminName1");
			XmlNode tertiaryLocationNameNode = responseXml.SelectSingleNode("//adminName2");

			if (primaryLocationNameNode != null && !String.IsNullOrEmpty(primaryLocationNameNode.InnerText))
			{
				jpeg.StringTags[Exiv2MetaType.IptcLocationName] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcLocationName].Add(primaryLocationNameNode.InnerText);
				jpeg.StringTags[Exiv2MetaType.IptcCity] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcCity].Add(primaryLocationNameNode.InnerText);
			}

			if (countryCodeNode != null && !String.IsNullOrEmpty(countryCodeNode.InnerText))
			{
				jpeg.StringTags[Exiv2MetaType.IptcCountryCode] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcCountryCode].Add(countryCodeNode.InnerText);
				jpeg.StringTags[Exiv2MetaType.IptcLocationCode] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcLocationCode].Add(countryCodeNode.InnerText);
			}

			if (countryNameNode != null && !String.IsNullOrEmpty(countryNameNode.InnerText))
			{
				jpeg.StringTags[Exiv2MetaType.IptcCountryName] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcCountryName].Add(countryNameNode.InnerText);
			}

			if (secondaryLocationNameNode != null && !String.IsNullOrEmpty(secondaryLocationNameNode.InnerText))
			{
				jpeg.StringTags[Exiv2MetaType.IptcProvinceState] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcProvinceState].Add(secondaryLocationNameNode.InnerText);
			}

			if (tertiaryLocationNameNode != null && !String.IsNullOrEmpty(tertiaryLocationNameNode.InnerText))
			{
				jpeg.StringTags[Exiv2MetaType.IptcSubLocation] = new List<string>();
				jpeg.StringTags[Exiv2MetaType.IptcSubLocation].Add(tertiaryLocationNameNode.InnerText);
			}
		}
	}
}
