namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API
{
    // Для единиц измерения размер в элементе массива равен 7 байт,
    // для количества знаков после запятой - 1 байт
    internal enum PropertyType
    {
        UnitName = 7,
        Decimals = 1
    }

    internal struct Property
    {
        public int Code;
        public string PropertyName;
        public PropertyType PropertyType;
        public string UnitName;
        public int Decimals;
    }

    internal sealed class Properties
    {
        public static Property[] List =
        {
            new Property {Code = 44, PropertyName = "tTypeM", PropertyType = PropertyType.UnitName},
            new Property {Code = 45, PropertyName = "GTypeM", PropertyType = PropertyType.UnitName},
            new Property {Code = 46, PropertyName = "VTypeM", PropertyType = PropertyType.UnitName},
            new Property {Code = 47, PropertyName = "MTypeM", PropertyType = PropertyType.UnitName},
            new Property {Code = 48, PropertyName = "PTypeM", PropertyType = PropertyType.UnitName},
            new Property {Code = 53, PropertyName = "QoTypeM", PropertyType = PropertyType.UnitName},
            new Property {Code = 55, PropertyName = "QntTypeHIM", PropertyType = PropertyType.UnitName},
            new Property {Code = 56, PropertyName = "QntTypeM", PropertyType = PropertyType.UnitName},
            new Property {Code = 57, PropertyName = "tTypeFractDigNum", PropertyType = PropertyType.Decimals},
            new Property {Code = 58, PropertyName = "GTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 59, PropertyName = "VTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 60, PropertyName = "MTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 61, PropertyName = "PTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 62, PropertyName = "dtTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 63, PropertyName = "tswTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 64, PropertyName = "taTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 65, PropertyName = "MgTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 66, PropertyName = "QoTypeFractDigNum1", PropertyType = PropertyType.Decimals},
            new Property {Code = 67, PropertyName = "tTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 68, PropertyName = "GTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 69, PropertyName = "VTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 70, PropertyName = "MTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 71, PropertyName = "PTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 72, PropertyName = "dtTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 73, PropertyName = "tswTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 74, PropertyName = "taTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 75, PropertyName = "MgTypeFractDigNum2", PropertyType = PropertyType.Decimals},
            new Property {Code = 76, PropertyName = "QoTypeFractDigNum2", PropertyType = PropertyType.Decimals}
        };
    }
}
