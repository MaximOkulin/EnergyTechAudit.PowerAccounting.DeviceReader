using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;

namespace EnergyTechAudit.PowerAccounting.IISInteraction
{
    /// <summary>
    /// Класс обеспечивающий взаимодействие с IIS-сервером сайта
    /// </summary>
    public class ServerCommunicator : IDisposable
    {
        private HttpClient _httpClient;

        protected readonly string UserName;
        private readonly ServerCommunicatorSettings _settings;

        public ServerCommunicatorSettings Settings
        {
            get
            {
                return _settings;
            }
        }

        private readonly string _decryptedPassword;

        public ServerCommunicator(ServerCommunicatorSettings settings)
        {
            _settings = settings;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_settings.NetAddress)
            };

            // расшифровка пароля
            var cryptoProvider = new CryptoMethodsProvider();
            _decryptedPassword = Encoding.Unicode.GetString(cryptoProvider.UnprotectData(settings.User.EncryptedPassword));

            // автоматическое доверие SSL-сертификату
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            InitAuthHeaders();
        }

        public ServerCommunicator(string userName, ServerCommunicatorSettings settings)
            : this(settings)
        {
            UserName = userName;
        }

        private void InitAuthHeaders()
        {
            _httpClient.DefaultRequestHeaders.Add("login", _settings.User.UserName);
            _httpClient.DefaultRequestHeaders.Add("password", _decryptedPassword);
        }

        
        /// <summary>
        /// Посылает новый статус подключения к прибору
        /// </summary>
        /// <param name="statusInfo">Объект статуса</param>
        public void DeviceStatusChange(MeasurementDeviceStatusInfo statusInfo)
        {
            try
            {
                _httpClient.PostAsJsonAsync(string.Format("/{0}/DeviceStatusChange", _settings.Controller), statusInfo);
            }
            catch (Exception ex)
            {
            }
        }

        public void SendCallback(string userName, Dictionary<string, string> result, IEntity entity)
        {
            try
            {
                Thread.Sleep(1000);
                _httpClient.PutAsJsonAsync(string.Format("/{0}/{1}", _settings.Controller, _settings.ReceiveAction), new { userName = userName, result = result, entityInfo = new { EntityId = entity.Id, EntityTypeName = entity.GetType().Name } });
            }
            catch (Exception ex)
            {
            }
        }

        public void SendMnemoschemeParamsForOnlyUpdates(string userName, Dictionary<string, string> result, IEntity entity)
        {
            try
            {
                Thread.Sleep(1000);
                
                var k = _httpClient.PutAsJsonAsync(string.Format("/{0}/{1}", _settings.Controller, _settings.ReceiveAction), new { userName = userName, result = result, entityInfo = new { EntityId = entity.Id, EntityTypeName = entity.GetType().Name }}).Result;
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// Отправляет ответ IIS-серверу
        /// </summary>
        public void SendResponse(Dictionary<string, string> result, IEntity entity)
        {
            SendCallback(UserName, result, entity);
        }
       

        #region Кухня сборки мусора
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_httpClient != null)
                {
                    _httpClient.Dispose();
                    _httpClient = null;
                }
            }
        }

        ~ServerCommunicator()
        {
            Dispose(false);
        }
        #endregion
    }
}
