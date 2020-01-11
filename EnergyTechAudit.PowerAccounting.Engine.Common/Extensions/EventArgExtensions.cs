using System;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions
{
    public static class EventArgExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e, object sender,
            ref EventHandler<TEventArgs> eventDelegate) where TEventArgs : System.EventArgs
        {
            EventHandler<TEventArgs> temp = Interlocked.CompareExchange(ref eventDelegate, null, null);
            if (temp != null) temp(sender, e);
        }
    }
}
