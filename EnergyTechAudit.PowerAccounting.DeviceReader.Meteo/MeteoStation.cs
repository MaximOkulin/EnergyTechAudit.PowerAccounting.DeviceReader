using System;
using System.Configuration;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Meteo
{
    public class MeteoStation
    {
        private BaseDispatcher _dispatcher;

        public MeteoStation()
        {
            int deviceReaderId = Convert.ToInt32(ConfigurationManager.AppSettings["DeviceReaderId"]);

            _dispatcher = new BaseDispatcher(deviceReaderId);
        }

        public void Run()
        {
            _dispatcher.Run();
            new Thread(ThreadSleep).Start();
        }

        private static void ThreadSleep()
        {
            while (true)
            {
                Thread.Sleep(60000);
            }
        }
    }
}
