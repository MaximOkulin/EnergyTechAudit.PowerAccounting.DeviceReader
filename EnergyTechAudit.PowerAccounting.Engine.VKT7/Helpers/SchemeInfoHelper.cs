using System;
using System.Collections;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Helpers
{
    public class SchemeInfoHelper
    {
        public SchemeInfo ParseSchemeInfo(byte[] buf, int tvNumber = 1)
        {
            var offset = tvNumber - 1;

            BitArray sourceArray = new BitArray(new byte[] { buf[4 + 2 * offset], buf[5 + 2 * offset] });

            BitArray schemeMaskArray = new BitArray(new byte[] { 0x00, 0x1e });
            sourceArray.And(schemeMaskArray);

            byte scheme = new byte();

            scheme |= (byte)(Convert.ToByte(sourceArray.Get(12)) << 3);
            scheme |= (byte)(Convert.ToByte(sourceArray.Get(11)) << 2);
            scheme |= (byte)(Convert.ToByte(sourceArray.Get(10)) << 1);
            scheme |= Convert.ToByte(sourceArray.Get(9));

            sourceArray = new BitArray(new byte[] { buf[4 + 2 * offset], buf[5 + 2 * offset] });
            BitArray pipe3TargetMaskArray = new BitArray(new byte[] { 0x80, 0x01 });
            sourceArray.And(pipe3TargetMaskArray);

            byte pipe3Target = new byte();

            pipe3Target |= (byte)(Convert.ToByte(sourceArray.Get(8)) << 1);
            pipe3Target |= Convert.ToByte(sourceArray.Get(7));


            sourceArray = new BitArray(new byte[] { buf[4 + 2 * offset], buf[5 + 2 * offset] });
            BitArray t5MaskArray = new BitArray(new byte[] { 0x60, 0x00 });
            sourceArray.And(t5MaskArray);

            byte t5 = new byte();
            t5 |= (byte)(Convert.ToByte(sourceArray.Get(6)) << 1);
            t5 |= Convert.ToByte(sourceArray.Get(5));

            return new SchemeInfo
            {
                SchemeNumber = scheme,
                T3 = pipe3Target,
                t5 = t5
            };
        }
    }
}
