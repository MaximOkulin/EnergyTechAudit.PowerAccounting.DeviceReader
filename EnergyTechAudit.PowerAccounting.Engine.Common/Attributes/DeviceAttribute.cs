using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeviceAttribute : Attribute
    {
        private readonly string _name;

        public DeviceAttribute(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
