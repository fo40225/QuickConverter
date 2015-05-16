using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace QuickConverter
{
    public static class Extender
    {
        #region Object

        public static object Box(this object o)
        {
            return o as object;
        }

        public static object CallMethod(this object o, string methodName, params object[] args)
        {
            return Interaction.CallByName(o, methodName, CallType.Method, args);
        }

        public static object DeepClone(this object o)
        {
            return JsonConvert.DeserializeObject(o.SerializeToJsonString(), o.GetType());
        }

        public static object Field(this object o, string fieldName)
        {
            Type t = o.GetType();
            FieldInfo fi = t.GetField(
                fieldName,
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Public);
            return fi.GetValue(o);
        }

        public static T Field<T>(this object o, string fieldName)
        {
            return (T)o.Field(fieldName);
        }

        public static void Field(this object o, string fieldName, string fieldValue)
        {
            Type t = o.GetType();
            FieldInfo fi = t.GetField(
                fieldName,
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Public);
            fi.SetValue(o, fieldValue);
        }

        public static bool IsArray(this object o)
        {
            return Information.IsArray(o);
        }

        public static bool IsDate(this object o)
        {
            return Information.IsDate(o);
        }

        public static bool IsDBNull(this object o)
        {
            return Convert.IsDBNull(o);
        }

        public static bool IsException(this object o)
        {
            return Information.IsError(o);
        }

        public static bool IsNull(this object o)
        {
            return Information.IsNothing(o);
        }

        public static bool IsNumeric(this object o)
        {
            return Information.IsNumeric(o);
        }

        public static bool IsReferenceType(this object o)
        {
            return Information.IsReference(o);
        }

        public static bool IsValueType(this object o)
        {
            return o is ValueType;
        }

        public static object Property(this object o, string propertyName)
        {
            return Interaction.CallByName(o, propertyName, CallType.Get);
        }

        public static T Property<T>(this object o, string propertyName)
        {
            return (T)o.Property(propertyName);
        }

        public static void Property(this object o, string propertyName, object propertyValue)
        {
            Interaction.CallByName(o, propertyName, CallType.Set, propertyValue);
        }

        public static string SerializeToJsonString(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static bool ToBool(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToBoolean(o);
            }
            else
            {
                if (o is string)
                {
                    bool b;
                    bool.TryParse(o as string, out b);
                    return b;
                }
                else
                {
                    bool b;
                    try
                    {
                        b = Convert.ToBoolean(o);
                    }
                    catch (Exception)
                    {
                        b = new Boolean();
                    }
                    return b;
                }
            }
        }

        public static byte ToByte(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToByte(o);
            }
            else
            {
                if (o is string)
                {
                    byte b;
                    byte.TryParse(o as string, out b);
                    return b;
                }
                else
                {
                    byte b;
                    try
                    {
                        b = Convert.ToByte(o);
                    }
                    catch (Exception)
                    {
                        b = new Byte();
                    }
                    return b;
                }
            }
        }

        public static char ToChar(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToChar(o);
            }
            else
            {
                if (o is string)
                {
                    char c;
                    char.TryParse(o as string, out c);
                    return c;
                }
                else
                {
                    char c;
                    try
                    {
                        c = Convert.ToChar(o);
                    }
                    catch (Exception)
                    {
                        c = new Char();
                    }
                    return c;
                }
            }
        }

        public static DateTime ToDateTime(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToDateTime(o);
            }
            else
            {
                if (o is string)
                {
                    DateTime dt;
                    DateTime.TryParse(o as string, out dt);
                    return dt;
                }
                else
                {
                    DateTime dt;
                    try
                    {
                        dt = Convert.ToDateTime(o);
                    }
                    catch (Exception)
                    {
                        dt = new DateTime();
                    }
                    return dt;
                }
            }
        }

        public static decimal ToDecimal(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToDecimal(o);
            }
            else
            {
                if (o is string)
                {
                    decimal d;
                    decimal.TryParse(o as string, out d);
                    return d;
                }
                else
                {
                    decimal d;
                    try
                    {
                        d = Convert.ToDecimal(o);
                    }
                    catch (Exception)
                    {
                        d = new Decimal();
                    }
                    return d;
                }
            }
        }

        public static double ToDouble(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToDouble(o);
            }
            else
            {
                if (o is string)
                {
                    double d;
                    double.TryParse(o as string, out d);
                    return d;
                }
                else
                {
                    double d;
                    try
                    {
                        d = Convert.ToDouble(o);
                    }
                    catch (Exception)
                    {
                        d = new Double();
                    }
                    return d;
                }
            }
        }

        public static T ToEnum<T>(this object o, bool throwEx = true) where T : struct
        {
            if (throwEx)
            {
                if (o is string)
                {
                    return (T)Enum.Parse(typeof(T), o.ToString());
                }
                else
                {
                    return (T)o;
                }
            }
            else
            {
                if (o is string)
                {
                    T e;
                    Enum.TryParse<T>(o as string, out e);
                    return e;
                }
                else
                {
                    T e;
                    try
                    {
                        e = (T)o;
                    }
                    catch (Exception)
                    {
                        e = (T)(object)0;
                    }
                    return e;
                }
            }
        }

        public static float ToFloat(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToSingle(o);
            }
            else
            {
                if (o is string)
                {
                    float f;
                    float.TryParse(o as string, out f);
                    return f;
                }
                else
                {
                    float f;
                    try
                    {
                        f = Convert.ToSingle(o);
                    }
                    catch (Exception)
                    {
                        f = new Single();
                    }
                    return f;
                }
            }
        }

        public static int ToInt(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToInt32(o);
            }
            else
            {
                if (o is string)
                {
                    int i;
                    int.TryParse(o as string, out i);
                    return i;
                }
                else
                {
                    int i;
                    try
                    {
                        i = Convert.ToInt32(o);
                    }
                    catch (Exception)
                    {
                        i = new Int32();
                    }
                    return i;
                }
            }
        }

        public static long ToLong(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToInt64(o);
            }
            else
            {
                if (o is string)
                {
                    long l;
                    long.TryParse(o as string, out l);
                    return l;
                }
                else
                {
                    long l;
                    try
                    {
                        l = Convert.ToInt64(o);
                    }
                    catch (Exception)
                    {
                        l = new Int64();
                    }
                    return l;
                }
            }
        }

        public static sbyte ToSByte(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToSByte(o);
            }
            else
            {
                if (o is string)
                {
                    sbyte sb;
                    sbyte.TryParse(o as string, out sb);
                    return sb;
                }
                else
                {
                    sbyte sb;
                    try
                    {
                        sb = Convert.ToSByte(o);
                    }
                    catch (Exception)
                    {
                        sb = new SByte();
                    }
                    return sb;
                }
            }
        }

        public static short ToShort(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToInt16(o);
            }
            else
            {
                if (o is string)
                {
                    short sh;
                    short.TryParse(o as string, out sh);
                    return sh;
                }
                else
                {
                    short sh;
                    try
                    {
                        sh = Convert.ToInt16(o);
                    }
                    catch (Exception)
                    {
                        sh = new Int16();
                    }
                    return sh;
                }
            }
        }

        public static uint ToUInt(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToUInt32(o);
            }
            else
            {
                if (o is string)
                {
                    uint ui;
                    uint.TryParse(o as string, out ui);
                    return ui;
                }
                else
                {
                    uint ui;
                    try
                    {
                        ui = Convert.ToUInt16(o);
                    }
                    catch (Exception)
                    {
                        ui = new UInt16();
                    }
                    return ui;
                }
            }
        }

        public static ulong ToULong(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToUInt64(o);
            }
            else
            {
                if (o is string)
                {
                    ulong ul;
                    ulong.TryParse(o as string, out ul);
                    return ul;
                }
                else
                {
                    ulong ul;
                    try
                    {
                        ul = Convert.ToUInt64(o);
                    }
                    catch (Exception)
                    {
                        ul = new UInt64();
                    }
                    return ul;
                }
            }
        }

        public static ushort ToUShort(this object o, bool throwEx = true)
        {
            if (throwEx)
            {
                return Convert.ToUInt16(o);
            }
            else
            {
                if (o is string)
                {
                    ushort us;
                    ushort.TryParse(o as string, out us);
                    return us;
                }
                else
                {
                    ushort us;
                    try
                    {
                        us = Convert.ToUInt16(o);
                    }
                    catch (Exception)
                    {
                        us = new UInt16();
                    }
                    return us;
                }
            }
        }

        public static T UnBox<T>(this object o) where T : class
        {
            return o as T;
        }

        #endregion Object

        #region String

        public static byte[] Base64Decode(this string s)
        {
            return Convert.FromBase64String(s);
        }

        public static T DeserializeJsonToObject<T>(this string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }

        public static string HtmlDecode(this string s)
        {
            return WebUtility.HtmlDecode(s);
        }

        public static string HtmlEncode(this string s)
        {
            return WebUtility.HtmlEncode(s);
        }

        public static string StringConvert(this string s, VbStrConv option)
        {
            return Strings.StrConv(s, option);
        }

        public static string UrlDecode(this string s)
        {
            return WebUtility.UrlDecode(s);
        }

        public static string UrlEncode(this string s)
        {
            return WebUtility.UrlEncode(s);
        }

        #endregion String

        #region Byte Array

        public static string Base64Encode(this byte[] b)
        {
            return Convert.ToBase64String(b);
        }

        #endregion Byte Array

        #region Type

        public static object CreateInstance(this Type t, params object[] args)
        {
            return Activator.CreateInstance(t);
        }

        #endregion Type
    }

    public static class TypeFactory
    {
        public static Type GetTypeByName(string typeName)
        {
            var t = Type.GetType(typeName, false);

            if (t == null)
            {
                foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
                {
                    t = item.GetType(typeName, false);
                    if (t != null)
                    {
                        break;
                    }
                }
            }
            return t;
        }
    }
}