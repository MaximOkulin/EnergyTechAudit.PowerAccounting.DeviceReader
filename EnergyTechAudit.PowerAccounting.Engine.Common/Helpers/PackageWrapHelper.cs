using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public class PackageWrapHelper
    {
        private readonly TransportServerModel _transportServerModel;
        private readonly ConnectionInfo _connectionInfo;
        private int _requestId;

        public PackageWrapHelper(TransportServerModel transportServerModel, ConnectionInfo connectionInfo)
        {
            _transportServerModel = transportServerModel;
            _connectionInfo = connectionInfo;             
        }

        public byte[] Wrap(byte[] requestBytes)
        {
            if (_transportServerModel == TransportServerModel.Tbn_KSPD5G_new)
            {
                var wrappedPackage = new List<byte>();
                wrappedPackage.Add(0x01);
                wrappedPackage.Add(0x41);
                // идентификатор 4 байта
                wrappedPackage.AddRange(BitConverter.GetBytes(Convert.ToUInt32(_connectionInfo.Identifier)));
                // длина посылаемого пакета 2 байта
                ushort requestLength = (ushort)requestBytes.Length;
                wrappedPackage.AddRange(BitConverter.GetBytes(requestLength));

                PortType portType = _connectionInfo.PortType;
                int port = portType == PortType.RS232 ? 1 : portType == PortType.RS485_2Wire ? 0 : 2;
                _requestId++;
                port |= (_requestId & 15) << 4;
                wrappedPackage.Add((byte)port);


                wrappedPackage.Add(_kspdBaudRates[_connectionInfo.BaudRate]);
                wrappedPackage.AddRange(requestBytes);

                wrappedPackage.AddRange(wrappedPackage.ToArray().Crc16());

                return wrappedPackage.ToArray();
            }

            return requestBytes;
        }

        public byte[] UnWrap(byte[] wrappedResponseBytes)
        {
            if (_transportServerModel == TransportServerModel.Tbn_KSPD5G_new)
            {
                var responseWithoutTale = wrappedResponseBytes.Take(wrappedResponseBytes.Length - 2).ToArray();
                Array.Reverse(responseWithoutTale);
                var reversedUnwrappedResponse = responseWithoutTale.Take(responseWithoutTale.Length - 10).ToArray();
                Array.Reverse(reversedUnwrappedResponse);

                return reversedUnwrappedResponse;
            }

            return wrappedResponseBytes;
        }

        /// <summary>
        /// Возвращает новую длину ответа с учетом байтов обертки
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public int CalculateNewResponseLength(int totalBytes)
        {
            if (_transportServerModel == TransportServerModel.Tbn_KSPD5G_new)
            {
                return totalBytes + 12;
            }

            return totalBytes;
        }

        /// <summary>
        /// Возвращает длину байтов обертки, стоящих перед телом основного запроса к прибору
        /// </summary>
        /// <returns></returns>
        public int GetPreWrapBytesCount()
        {
            if (_transportServerModel == TransportServerModel.Tbn_KSPD5G_new)
                return 10;

            return 0;
        }

        /// <summary>
        /// Возвращает длина байтов обертки, стоящих после тела основного запроса к прибору
        /// </summary>
        /// <returns></returns>
        public int GetPostWrapBytesCount()
        {
            if (_transportServerModel == TransportServerModel.Tbn_KSPD5G_new)
                return 2;

            return 0;
        }



        private static Dictionary<int, byte> _kspdBaudRates = new Dictionary<int, byte>
        {
            { 2400, 0x00 },
            { 4800, 0x01 },
            { 9600, 0x02 },
            { 19200, 0x03 },
            { 38400, 0x04 },
            { 57600, 0x05 },
            { 115200, 0x06 }
        };
    }
}
