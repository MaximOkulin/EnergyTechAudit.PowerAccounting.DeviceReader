using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using System;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types
{
    public class Tv7Events
    {
        public List<Tv7Event> Events = new List<Tv7Event>
        {
            // архив изменений базы данных
            {
                new Tv7Event
                {
                    /* Исп. БД2 */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 1,
                    EventNumber = 0,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "нет";
                            case 0x01:
                                return "да";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;

                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
               new Tv7Event
               {
                   /* БД1 <> БД2 */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 2,
                   EventNumber = 1,
                   ValueParser = buffer =>
                   {
                       switch (buffer[1])
                       {
                           case 0x00:
                               return "вручную";
                           case 0x01:
                               return "авто по дате";
                           default:
                               return DeviceMessages.Tv7AibdUnknownValue;
                       }
                   },
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
               }
            },
            {
               new Tv7Event
               {
                   /* С клав. */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 3,
                   EventNumber = 2,
                   ValueParser = buffer =>
                   {
                       switch (buffer[1])
                       {
                           case 0x00:
                               return "запрет";
                           case 0x01:
                               return "с паролем";
                           case 0x02:
                               return "с доступом";
                           default:
                               return DeviceMessages.Tv7AibdUnknownValue;
                       }
                   },
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
               }
            },
            {
              new Tv7Event
              {
                  /* С ПК */
                  AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                  InternalDeviceEventId = 4,
                  EventNumber = 3,
                  ValueParser = buffer =>
                  {
                      switch (buffer[1])
                      {
                          case 0x00:
                              return "запрет";
                          case 0x01:
                              return "с паролем";
                          default:
                              return DeviceMessages.Tv7AibdUnknownValue;
                      }
                  },
                  CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
              }
            },
            {
               new Tv7Event
               {
                   /* БД1 с */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 5,
                   EventNumber = 4,
                   ValueParser = buffer =>
                   {
                       var day = BitConverter.ToInt16(new byte[] {buffer[1], 0x00}, 0);
                       var month = BitConverter.ToInt16(new byte[] {buffer[0], 0x00}, 0);
                       var year = BitConverter.ToInt16(new byte[] {buffer[3], 0x00}, 0);
                       var hour = BitConverter.ToInt16(new byte[] {buffer[2], 0x00}, 0);
                       return string.Format("{0:00}.{1:00}.{2:00} {3:00}", day, month, year, hour);
                   },
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
               }
            },
            {
               new Tv7Event
               {
                   /* БД2 с */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 6,
                   EventNumber = 5,
                   ValueParser = buffer =>
                   {
                       var day = BitConverter.ToInt16(new byte[] {buffer[1], 0x00}, 0);
                       var month = BitConverter.ToInt16(new byte[] {buffer[0], 0x00}, 0);
                       var year = BitConverter.ToInt16(new byte[] {buffer[3], 0x00}, 0);
                       var hour = BitConverter.ToInt16(new byte[] {buffer[2], 0x00}, 0);
                       return string.Format("{0:00}.{1:00}.{2:00} {3:00}", day, month, year, hour);
                   },
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
               }
            },
            {
                new Tv7Event
                {
                    /* Час отчета */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 7,
                    EventNumber = 16,
                    ValueParser = buffer => string.Format("{0}", buffer[1]),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Дата отчета */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 8,
                    EventNumber = 17,
                    ValueParser = buffer => string.Format("{0}", buffer[1]),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Сет. адрес */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 9,
                    EventNumber = 18,
                    ValueParser = buffer => string.Format("{0}", buffer[1]),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Код. орг. */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 10,
                    EventNumber = 19,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Договор */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 11,
                    EventNumber = 20,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Сист. единиц */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 12,
                    EventNumber = 21,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "СИ";
                            case 0x01:
                                return "МКС";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;
                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Термопреобр. */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 13,
                    EventNumber = 22,
                    ValueParser = buffer =>
                        {
                            switch(buffer[1])
                            {
                                case 0x00 : return "100П";
                                case 0x01: return "500П";
                                case 0x02: return "Pt100";
                                case 0x03: return "Pt500";
                                default: return DeviceMessages.Tv7AibdUnknownValue;
                            }
                        },
                        CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Перев. часов */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 14,
                    EventNumber = 23,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "Выкл";
                            case 0x01:
                                return "Вкл";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;
                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Время */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 15,
                    EventNumber = 24,
                    ValueParser = buffer =>
                        {
                            var minute = BitConverter.ToInt16(new byte[] { buffer[0], 0x00 }, 0);
                            var hour = BitConverter.ToInt16(new byte[] { buffer[1], 0x00 }, 0);
                            var second = BitConverter.ToInt16(new byte[] { buffer[3], 0x00 }, 0);

                            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
                        },
                        CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
             {
                new Tv7Event
                {
                    /* Пароль */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 16,
                    EventNumber = 25,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Дата */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 17,
                    EventNumber = 26,
                    ValueParser = buffer =>
                    {
                        var month = BitConverter.ToInt16(new byte[] {buffer[0], 0x00}, 0);
                        var day = BitConverter.ToInt16(new byte[] {buffer[1], 0x00}, 0);
                        var year = 2000 + BitConverter.ToInt16(new byte[] {buffer[3], 0x00 }, 0);

                        return string.Format("{0:00}.{1:00}.{2:0000}", day, month, year);
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
               new Tv7Event
               {
                   /* Контр. V */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 18,
                   EventNumber = 37,
                   ValueParser = buffer =>
                   {
                       switch (buffer[1])
                       {
                           case 0x00:
                               return "нет";
                           case 0x01:
                               return "без подст.";
                           case 0x02:
                               return "подст.";
                           case 0x03:
                               return "подст и контр U";
                           case 0x04:
                               return "счет отменен";
                           default:
                               return DeviceMessages.Tv7AibdUnknownValue;
                       }
                   },
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
               }
               },
            {
                new Tv7Event
                {
                    /* Контр. ВС */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 19,
                    EventNumber = 38,
                    ValueParser = buffer =>
                        {
                            switch(buffer[1])
                            {
                                case 0x00: return "нет";
                                case 0x01: return "сеть (общ.)";
                                case 0x02: return "Резерв";
                                default: return DeviceMessages.Tv7AibdUnknownValue;
                            }
                        },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Датчик P */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 20,
                    EventNumber = 39,
                    ValueParser = buffer =>
                        {
                            switch(buffer[1])
                            {
                                case 0x00: return "нет";
                                case 0x01: return "да";
                                default: return DeviceMessages.Tv7AibdUnknownValue;
                            }
                        },
                        CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
               new Tv7Event
               {
                   /* Тип ВС */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 21,
                   EventNumber = 40,
                   ValueParser = buffer =>
                   {
                       switch (buffer[1])
                       {
                           case 0x00:
                               return "Механич.";
                           case 0x01:
                               return "Электрон.";
                           default:
                               return DeviceMessages.Tv7AibdUnknownValue;
                       }
                   },
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
               }
            },
            {
                new Tv7Event
                {
                    /* Pдог */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 22,
                    EventNumber = 41,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* tдог */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 23,
                    EventNumber = 42,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Pп */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 24,
                    EventNumber = 43,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Pв */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 25,
                    EventNumber = 44,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Вес импульса */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 26,
                    EventNumber = 45,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Vmin */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 27,
                    EventNumber = 46,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Vmax */    
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 28,
                    EventNumber = 47,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Vдог */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 29,
                    EventNumber = 48,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2} {3})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputNameByPipeNumber(pipeOrInputNumber), GetPipeName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* СИ */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 30,
                    EventNumber = 59,
                    ValueParser = buffer =>  string.Format("{0}", buffer[1]),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
                }
            },
            {
               new Tv7Event
               {
                   /* dMmax */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 31,
                   EventNumber = 60,
                   ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
               }
            },
            {
                new Tv7Event
                {
                    /* tхд */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 32,
                    EventNumber = 61,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
                }
            },
            {
               new Tv7Event
               {
                   /* Pхд */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 33,
                   EventNumber = 62,
                   ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
               }
            },
            {
               new Tv7Event
               {
                   /* КТ3 */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 34,
                   EventNumber = 63,
                   ValueParser = buffer => string.Format("{0}", buffer[1]),
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
               }
            },
            {
               new Tv7Event
               {
                   /* ФРТ */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 35,
                   EventNumber = 64,
                   ValueParser = buffer => string.Format("{0}", buffer[1]),
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
               }
            },
            {
                new Tv7Event
                {
                    /* Контр.t */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 36,
                    EventNumber = 65,
                    ValueParser = buffer => string.Format("{0}", buffer[1] == 0x00 ? "с подст." : buffer[1] == 0x01 ? "счет отмен." : DeviceMessages.Tv7AibdUnknownValue),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
                }
            },
            {
               new Tv7Event
               {
                   /* Контр.dM */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 37,
                   EventNumber = 66,
                   ValueParser = buffer =>
                   {
                       switch (buffer[1])
                       {
                           case 0x00:
                               return "Нет";
                           case 0x01:
                               return "Без подст.1";
                           case 0x02:
                               return "Без подст.2";
                           case 0x03:
                               return "С подст.1";
                           case 0x04:
                               return "С подст.2";
                           default:
                               return DeviceMessages.Tv7AibdUnknownValue;
                       }
                   },
                   CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
               }
            },
            {
                new Tv7Event
                {
                    /* Контр.Q */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 38,
                    EventNumber = 67,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "Нет";
                            case 0x01:
                                return "Без подст.";
                            case 0x02:
                                return "С подст.";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;
                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Контр.dt */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 39,
                    EventNumber = 68,
                    ValueParser = buffer => 
                        {
                            switch(buffer[1])
                            {
                                case 0x00: return "без подст.";
                                case 0x01: return "с подст.";
                                case 0x02: return "счет отмен.";
                                default: return DeviceMessages.Tv7AibdUnknownValue;
                            }
                        },
                        CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
                }
           },
            {
                new Tv7Event
                {
                    /* dtmin */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 40,
                    EventNumber = 69,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "2°С";
                            case 0x01:
                                return "3°С";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;
                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
                }
            },
           {
               new Tv7Event
               {
                   /* Исп.tx */
                   AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                   InternalDeviceEventId = 41,
                   EventNumber = 70,
                   ValueParser = buffer =>
                       {
                           switch(buffer[1])
                           {
                               case 0x00: return "Не исп.";
                               case 0x01: return "догов.";
                               case 0x02: return "изм.в данном ТВ";
                               case 0x03: return "изм. в другом ТВ";
                               default: return DeviceMessages.Tv7AibdUnknownValue;
                           }
                       },
                  CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
               }
            },
            {
                new Tv7Event
                {
                    /* Исп.Px */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 42,
                    EventNumber = 71,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "Не изм.";
                            case 0x01:
                                return "Изм.";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;
                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => 
                           string.Format("{0} ({1} {2})", internalDeviceEvent.Description, GetDatabaseName(databaseNumber), GetHeatInputName(pipeOrInputNumber))
                }
            },
            {
                new Tv7Event
                {
                    /* Назнач. ДП */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 43,
                    EventNumber = 82,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "нет";
                            case 0x01:
                                return "контр.сети";
                            case 0x02:
                                return "счет имп.";
                            case 0x03:
                                return "сигн-ия";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;
                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уровень */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 44,
                    EventNumber = 83,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "НР";
                            case 0x01:
                                return "НЗ";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;
                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Ед.изм. */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 45,
                    EventNumber = 84,
                    ValueParser = buffer =>
                    {
                        switch (buffer[1])
                        {
                            case 0x00:
                                return "м3";
                            case 0x01:
                                return "кВт*ч";
                            default:
                                return DeviceMessages.Tv7AibdUnknownValue;
                        }
                    },
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Вес имп. */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 46,
                    EventNumber = 85,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description  
                }
            },
            {
                new Tv7Event
                {
                    /* ДПmin */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 47,
                    EventNumber = 86,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description  
                }
            },
            {
                new Tv7Event
                {
                    /* ДПmax */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 48,
                    EventNumber = 87,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description  
                }
            },
            {
                new Tv7Event
                {
                    /* T подт. */
                    AsyncArchiveType = AsyncArchiveType.DatabaseChanges,
                    InternalDeviceEventId = 49,
                    EventNumber = 88,
                    ValueParser = buffer => string.Format("{0:0.000000}", BitConverter.ToSingle(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description  
                }
            },

            // архив событий
            {
                new Tv7Event
                {
                    /* Запрет калибр. (ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 50,
                    EventNumber = 0,
                    ValueParser = buffer => string.Format("{0}", BitConverter.ToInt32(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Запись настроек (ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 51,
                    EventNumber = 1,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уст. COMов на умолч. */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 52,
                    EventNumber = 2,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Сброс архива */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 53,
                    EventNumber = 3,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Резерв */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 54,
                    EventNumber = 4,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Калибр.t(ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 55,
                    EventNumber = 5,
                    ValueParser = buffer => string.Format("{0}", BitConverter.ToInt32(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Калибр.P(ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 56,
                    EventNumber = 6,
                    ValueParser = buffer => string.Format("{0}", BitConverter.ToInt32(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Калибр.t */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 57,
                    EventNumber = 7,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Калибр.P */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 58,
                    EventNumber = 8,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Поверка (Старт, ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 59,
                    EventNumber = 9,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Поверка (Стоп, ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 60,
                    EventNumber = 10,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Поверка (Старт) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 61,
                    EventNumber = 11,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Поверка (Стоп) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 62,
                    EventNumber = 12,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уск. режим (старт) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 63,
                    EventNumber = 13,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уск. режим (стоп) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 64,
                    EventNumber = 14,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Доступ запр. */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 65,
                    EventNumber = 15,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Доступ разр. */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 66,
                    EventNumber = 16,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Калибр запр. */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 67,
                    EventNumber = 17,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Калибр разр. */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 68,
                    EventNumber = 18,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уст. акт. БД1 */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 69,
                    EventNumber = 19,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уст. акт. БД2 */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 70,
                    EventNumber = 20,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уст. акт. БД1 (авто) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 71,
                    EventNumber = 21,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уст. акт. БД2 (авто) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 72,
                    EventNumber = 22,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уст. акт. БД1 (ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 73,
                    EventNumber = 23,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Уст. акт. БД2 (ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 74,
                    EventNumber = 24,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Запись незащ. настр. (ПК) */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 75,
                    EventNumber = 25,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Запись дан. производит. */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 76,
                    EventNumber = 26,
                    ValueParser = buffer => string.Format("{0}", BitConverter.ToInt32(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Запись дан. серв.-центра */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 77,
                    EventNumber = 27,
                    ValueParser = buffer => string.Format("{0}", BitConverter.ToInt32(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Авто перевод часов */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 78,
                    EventNumber = 28,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Очистка архивов */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 79,
                    EventNumber = 29,
                    ValueParser = buffer => string.Format("{0}", BitConverter.ToInt32(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Замена батареи */
                    AsyncArchiveType = AsyncArchiveType.Events,
                    InternalDeviceEventId = 80,
                    EventNumber = 30,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },

            // диагностический архив
            {
                new Tv7Event
                {
                    /* Рестарт */
                    AsyncArchiveType = AsyncArchiveType.Diagnostic,
                    InternalDeviceEventId = 81,
                    EventNumber = 0,
                    ValueParser = buffer => string.Format("{0}", BitConverter.ToInt32(new [] { buffer[1], buffer[0], buffer[3], buffer[2]}, 0)),
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Инициализация */
                    AsyncArchiveType = AsyncArchiveType.Diagnostic,
                    InternalDeviceEventId = 82,
                    EventNumber = 1,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Вкл. 220В */
                    AsyncArchiveType = AsyncArchiveType.Diagnostic,
                    InternalDeviceEventId = 83,
                    EventNumber = 2,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* Откл. 220В */
                    AsyncArchiveType = AsyncArchiveType.Diagnostic,
                    InternalDeviceEventId = 84,
                    EventNumber = 3,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* LB */
                    AsyncArchiveType = AsyncArchiveType.Diagnostic,
                    InternalDeviceEventId = 85,
                    EventNumber = 4,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            },
            {
                new Tv7Event
                {
                    /* BR */
                    AsyncArchiveType = AsyncArchiveType.Diagnostic,
                    InternalDeviceEventId = 86,
                    EventNumber = 5,
                    ValueParser = buffer => null,
                    CreateDescription = (internalDeviceEvent, pipeOrInputNumber, databaseNumber) => internalDeviceEvent.Description
                }
            }
        };

        private static string GetDatabaseName(int databaseNumber)
        {
            return string.Format("{0}{1}", DeviceMessages.DatabaseAbbreviation, databaseNumber + 1);
        }

        private static string GetHeatInputName(int inputNumber)
        {
            return string.Format("{0}{1}", DeviceMessages.HeatInputAbbreviation, inputNumber + 1);
        }

        private static string GetHeatInputNameByPipeNumber(int pipeNumber)
        {
            return string.Format("{0}{1}", DeviceMessages.HeatInputAbbreviation, pipeNumber <= 2 ? "1" : "2");
        }        

        private static string GetPipeName(int pipeNumber)
        {
            var pipeNumberStr = string.Empty;
            switch(pipeNumber)
            {
                case 0: pipeNumberStr = "1"; break;
                case 1: pipeNumberStr = "2"; break;
                case 2: pipeNumberStr = "3"; break;
                case 3: pipeNumberStr = "1"; break;
                case 4: pipeNumberStr = "2"; break;
                case 5: pipeNumberStr = "3"; break;
            }
            return string.Format("{0}{1}", DeviceMessages.PipeAbbreviation, pipeNumberStr);
        }
     }
}
