using System;

namespace DGManager.Backend
{
	public class SoftwareVersion : IComparable<SoftwareVersion>, IEquatable<SoftwareVersion>
	{

        public string VersionNumber { get; set; }

        public string DownloadUrl { get; set; }

        public string ReleaseNotesUrl { get; set; }

		public int CompareTo(SoftwareVersion other)
		{
			return VersionNumber.CompareTo(other.VersionNumber);
		}

		public static bool operator ==(SoftwareVersion x, SoftwareVersion y)
		{
			// If both are null, or both are same instance, return true.
			if (ReferenceEquals(x, y))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)x == null) || ((object)y == null))
			{
				return false;
			}

			return x.CompareTo(y) == 0;
		}

		public static bool operator !=(SoftwareVersion x, SoftwareVersion y)
		{
			return !(x == y); 
		}

		public static bool operator >(SoftwareVersion x, SoftwareVersion y)
		{
			return x.CompareTo(y) > 0;
		}

		public static bool operator <(SoftwareVersion x, SoftwareVersion y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <=(SoftwareVersion x, SoftwareVersion y)
		{
			return (x < y) || (x == y);
		} 

		public static bool operator >=(SoftwareVersion x, SoftwareVersion y)
		{
			return (x > y) || (x == y);
		}

        public override bool Equals(object obj)
        {
            SoftwareVersion other = obj as SoftwareVersion;
            return other != null && this == other;
        }

        public override int GetHashCode()
        {
            return VersionNumber.GetHashCode();
        }

        #region IEquatable<SoftwareVersion> Members

        public bool Equals(SoftwareVersion other)
        {
            return this == other;
        }

        #endregion
    }
}
