using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport
{
    public class HttpDeviceTransport : DeviceTransport
    {
        public HttpDeviceTransport(MeasurementDevice device, AccessPointInfo accessPointInfo, ManualResetEvent autoEvent, LogHelper logHelper) :
            base(device, accessPointInfo, autoEvent, logHelper)
        {

        }

        public override bool InitConnection(TcpClient preparedTcpClient = null)
        {
            return true;
        }

        public string ExecutePostJsonRequest(string uri, string data)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);

            var postdata = Encoding.ASCII.GetBytes(data);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(postdata, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            string responseString = string.Empty;

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                responseString = streamReader.ReadToEnd();
            }

            return responseString;
        }
    }
}
