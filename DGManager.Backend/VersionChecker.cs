using System;
using System.Reflection;
using System.Xml;

namespace DGManager.Backend
{
	public static class VersionChecker
	{
		public static SoftwareVersion CheckForNewVersion(string rssUrl, string moduleTitle)
		{
			SoftwareVersion newVersion = null;

			XmlDocument rssDoc = new XmlDocument();
			rssDoc.Load(rssUrl);

			XmlNodeList itemNodes = rssDoc.SelectNodes("//item");

			foreach (XmlElement item in itemNodes)
			{
				if (item["title"] != null && item["title"].InnerText.StartsWith(moduleTitle))
				{
					newVersion = new SoftwareVersion();

					string[] titleComponents = item["title"].InnerText.Split(new char[] {' '});
					newVersion.VersionNumber = titleComponents[1];

					string[] descriptionComponents = item["description"].InnerText.Split(new string[] {"\""}, StringSplitOptions.None);
					newVersion.DownloadUrl = descriptionComponents[1];
					newVersion.ReleaseNotesUrl = descriptionComponents[3];
					break;
				}
			}

			if (newVersion != null && newVersion > GetCurrentVersion())
			{
				return newVersion;
			}
			else
			{
				return null;
			}
		}

		public static SoftwareVersion GetCurrentVersion()
		{
			SoftwareVersion currentVersion = new SoftwareVersion();
			Version assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
			currentVersion.VersionNumber = String.Format("{0}.{1}.{2}", assemblyVersion.Major, assemblyVersion.Minor, assemblyVersion.Build);
			return currentVersion;
		}
	}
}
