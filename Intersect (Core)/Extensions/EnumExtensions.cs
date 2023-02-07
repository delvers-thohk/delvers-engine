using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using Intersect.Attributes;

namespace Intersect.Extensions
{

    public static partial class EnumExtensions
    {

        public static string GetEnumDescription(this Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value?.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static object GetAmbientValue(this Enum enumVal)
        {
            Type type = enumVal.GetType();
            MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(AmbientValueAttribute), false);

            if (attributes == null || attributes.Length == 0)
                return default;

            return ((AmbientValueAttribute)attributes[0]).Value;
        }

        public static Type GetEntity(this Enum enumVal)
        {
            Type type = enumVal.GetType();
            MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(EntityAttribute), false);

            if (attributes == null || attributes.Length == 0)
                return default;

            return ((EntityAttribute)attributes[0]).type;
        }
        public static Type GetGameObjectInfo(this Enum enumVal)
        {
            Type type = enumVal.GetType();
            MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(GameObjectInfoAttribute), false);

            if (attributes == null || attributes.Length == 0)
                return default;

            return ((GameObjectInfoAttribute) attributes[0]).Type;
        }
    }
}
