using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Server
{
    public class WebServer
    {
        private readonly HttpListener _listener;

        public event EventHandler<WebServerEventArgs> ReceiveCompleted;

        private void RaiseReceiveCompleted(WebServerEventArgs args)
        {
            if (ReceiveCompleted != null)
            {
                ReceiveCompleted(null, args);
            }
        }

        public WebServer(string uriPrefix)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(uriPrefix);
        }

        public async void Start()
        {
            _listener.Start();
            while (true)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    await Task.Run(() => ProcessRequestAsync(context));
                }
                catch (HttpListenerException) { break; }
                catch (InvalidOperationException) { break; }
            }
        }

        public void Stop() { _listener.Stop(); }

        async void ProcessRequestAsync(HttpListenerContext context)
        {
            var body = context.Request.InputStream;
            var encoding = context.Request.ContentEncoding;
            using (var reader = new StreamReader(body, encoding))
            {
                string text = reader.ReadToEnd();

                RaiseReceiveCompleted(new WebServerEventArgs(text));

                using (Stream stream = context.Response.OutputStream)
                {
                    byte[] msg = Encoding.UTF8.GetBytes("OK");
                    await stream.WriteAsync(msg, 0, msg.Length);
                }
            }
        }
    }

    public class WebServerEventArgs : EventArgs
    {
        public string ReceivedText { get; set; }

        public WebServerEventArgs(string text)
        {
            ReceivedText = text;
        }
    }
}
