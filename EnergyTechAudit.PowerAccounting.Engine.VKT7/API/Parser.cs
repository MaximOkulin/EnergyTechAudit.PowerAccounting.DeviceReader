using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections;
using Param = EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections.Parameter;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API
{
    internal sealed class Parser
    {
        /// <summary>
        /// Получает словарь доступных измеряемых параметров из буфера
        /// </summary>
        public static Dictionary<Param, int> ParseActiveElementsList(byte[] buffer, ParametersCollection parametersCollection)
        {
            var result = new Dictionary<Param, int>();
            int activeElementsCount = Convert.ToInt32(buffer[2]) / 6;

            var currentElementPosition = 3;
            for (var count = 0; count < activeElementsCount; count++)
            {
                // читаем четыре байта параметра
                var param = new List<byte>();
                for (var i = 0; i < 4; i++)
                {
                    param.Add(buffer[currentElementPosition++]);
                }
                // читаем два байта размера параметра
                var size = new List<byte>();
                for (var i = 0; i < 2; i++)
                {
                    size.Add(buffer[currentElementPosition++]);
                }
                var sizeArray = size.ToArray();

                var parameter = parametersCollection.Parameters.FirstOrDefault(p => p.Id == param.GetParamIndex());
                
                if (parameter != null)
                {
                    int parameterSize = BitConverter.ToInt16(sizeArray, 0);
                    result.Add(parameter, parameterSize);
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращает заводской номер устройства для старых версий прошивки
        /// (более ранних, чем 1.9)
        /// </summary>
        /// <param name="buffer">Буфер, содержащий информацию</param>
        public static int ParseDeviceIdentifierOldFirmware(byte[] buffer)
        {
            var identifierList = new List<byte>();

            for(var i = 8; i <= 15; i++)
            {
                identifierList.Add(buffer[i]);
            }

            string identifierStr = Encoding.ASCII.GetString(identifierList.ToArray());

            return Convert.ToInt32(identifierStr);
        }

        /// <summary>
        /// Возвращает заводской номер устройства из буфера
        /// </summary>
        /// <param name="buffer">Буфер, содержащий информацию</param>
        public static int ParseDeviceIdentifier(byte[] buffer)
        {
            int identifierLength = BitConverter.ToInt16(new byte[] {buffer[3], buffer[4]}, 0); 
            
            var identifierList = new List<byte>();
            for (var i = 0; i < identifierLength; i++)
            {
                identifierList.Add(buffer[5 + i]);
            }

            string identifierStr = Encoding.GetEncoding(866).GetString(identifierList.ToArray());

            return Convert.ToInt32(identifierStr);
        }

        public static Tuple<Dictionary<string, string>, Dictionary<string, int>> ParsePropertiesElementsList(
            byte[] buffer, int serverType)
        {
            var unitNames = new Dictionary<string, string>();
            var decimals = new Dictionary<string, int>();


            int currentPosition = 3; // пропускаем первые три байта, содержащие: адрес, код операции и длину данных
            // наименование единиц измерения величин передаются в виде структуры, имеющей два поля
            foreach (var property in Properties.List)
            {
                if (property.PropertyType == PropertyType.UnitName)
                {
                    var unitName = new List<byte>();

                    if (serverType == 1)
                    {
                        var unitLength = new byte[2] { buffer[currentPosition], buffer[currentPosition + 1] };
                        currentPosition += 2;
                        int unitLen = BitConverter.ToInt16(unitLength, 0);
                        
                        // считываем байтовое ОЕМ-представление единицы измерения
                        for (var i = 0; i < unitLen; i++)
                        {
                            unitName.Add(buffer[currentPosition++]);
                        }
                    }
                    else if (serverType == 0)
                    {
                        // считываем 7-байтовое OEM-представление единицы измерения
                        for(var i = 1; i <= 7; i++)
                        {
                            unitName.Add(buffer[currentPosition++]);
                        }
                    }

                    unitNames.Add(property.PropertyName, Encoding.GetEncoding(866).GetString(unitName.ToArray()));

                    // пропускаем байт качества и байт нештатной ситуации
                    currentPosition += 2;
                }
                else if (property.PropertyType == PropertyType.Decimals)
                {
                    decimals.Add(property.PropertyName, buffer[currentPosition]);

                    byte qualityByte = buffer[currentPosition + 1];
                    byte emerByte = buffer[currentPosition + 2];

                    if (serverType == 1)
                    {
                        if (qualityByte != 0xC0 || emerByte != 0x00)
                        {
                            throw new Vkt7WrongDecimalException(property.PropertyName, qualityByte.ToString("X2"),
                                emerByte.ToString("X2"));
                        }
                    }
                    // проходим текущий элемент + пропускам байт качества и байт нештатной ситуации
                    currentPosition += 3;
                }
            }
            return new Tuple<Dictionary<string, string>, Dictionary<string, int>>(unitNames, decimals);
        }

        /// <summary>
        /// Возвращает тип сервера из переданного буфера
        /// </summary>
        /// <param name="buffer">Буфер</param>
        public static int ParseServerType(byte[] buffer)
        {
            return buffer[64];
        }

        /// <summary>
        /// Возвращает номер измерительной схемы
        /// </summary>
        /// <param name="hByte">Старший байт ответа</param>
        public static int GetMeasurementScheme(byte hByte)
        {
            // сдвигаем содержимое на один бит вправо, чтобы прижать 4 значимых бита к правому краю
            // накладываем маску 0х0F (0000 1111)
            return (hByte >> 1) & 0x0F;
        }
        
        /// <summary>
        /// Возвращает назначение ТР3
        /// </summary>
        /// <param name="hByte">Старший байт ответа</param>
        /// <param name="lByte">Младший байт ответа</param>
        public static int GetTr3Purpose(byte hByte, byte lByte)
        {
            // накладываем маску 0x01 и сдвигаем на 1 бит влево для дальнейшей коньюнкции с младшим битом
            int highBit = (hByte & 0x01) << 1;
            int lowBit = (lByte >> 7) & 0x01;
            return highBit | lowBit;
        }

        /// <summary>
        /// Возвращает назначение ТС5 для измерения ТВ1
        /// </summary>
        /// <param name="lByte">Младший байт ответа</param>
        public static int GetTs5Purpose(byte lByte)
        {
            return (lByte >> 5) & 0x03;
        }
    }
}
