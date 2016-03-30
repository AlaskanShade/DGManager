using System;

namespace DGManager.Backend
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public sealed class PointConverterAttribute : Attribute
    {
        public string Description;
        public string DefaultExtension;
        public string Extensions;
    }
}
