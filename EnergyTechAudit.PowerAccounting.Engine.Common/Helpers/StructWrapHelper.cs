using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public enum Endianness
    {
        BigEndian,
        LittleEndian
    }

    public static class StructWrapHelper
    {
        public static T ByteArrayToStructure<T>(this byte[] bytes, Endianness endianness = Endianness.BigEndian) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var structData = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            if (endianness == Endianness.BigEndian)
            {
                return ConvertToBigEndian(structData);
            }
            return structData;
        }

        /// <summary>
        /// Превращает Little-endian представление значений в Big-endian
        /// </summary>
        private static T ConvertToBigEndian <T>(T obj)
        {
            object o = obj;
            foreach (var field in typeof(T).GetFields())
            {
                object fieldValue = field.GetValue(o);
                TypeCode typeCode = Type.GetTypeCode(fieldValue.GetType());
                switch (typeCode)
                {
                    case TypeCode.Int16:
                        var int16 = BitConverter.ToInt16(BitConverter.GetBytes((short)fieldValue).Reverse().ToArray(), 0);
                        field.SetValue(o, int16);
                        break;
                    case TypeCode.Single:
                        var single = BitConverter.ToSingle(BitConverter.GetBytes((float)fieldValue).Reverse().ToArray(), 0);
                        field.SetValue(o, single);
                        break;
                    case TypeCode.Int32:
                        var int32 = BitConverter.ToInt32(BitConverter.GetBytes((int)fieldValue).Reverse().ToArray(), 0);
                        field.SetValue(o, int32);
                        break;
                }
            }
            return (T)o;
        }
    }
}
