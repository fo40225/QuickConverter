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
                string s = o as string;
                if (s != null)
                {
                    bool b;
                    bool.TryParse(s, out b);
                    return b;
                }
                else
                {
                    bool b;
                    try
                    {
                        b = Convert.ToBoolean(o);
                    }
                    catch
                    {
                        b = default(bool);
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
                string s = o as string;
                if (s != null)
                {
                    byte b;
                    byte.TryParse(s, out b);
                    return b;
                }
                else
                {
                    byte b;
                    try
                    {
                        b = Convert.ToByte(o);
                    }
                    catch
                    {
                        b = default(byte);
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
                string s = o as string;
                if (s != null)
                {
                    char c;
                    char.TryParse(s, out c);
                    return c;
                }
                else
                {
                    char c;
                    try
                    {
                        c = Convert.ToChar(o);
                    }
                    catch
                    {
                        c = default(char);
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
                string s = o as string;
                if (s != null)
                {
                    DateTime dt;
                    DateTime.TryParse(s, out dt);
                    return dt;
                }
                else
                {
                    DateTime dt;
                    try
                    {
                        dt = Convert.ToDateTime(o);
                    }
                    catch
                    {
                        dt = default(DateTime);
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
                string s = o as string;
                if (s != null)
                {
                    decimal d;
                    decimal.TryParse(s, out d);
                    return d;
                }
                else
                {
                    decimal d;
                    try
                    {
                        d = Convert.ToDecimal(o);
                    }
                    catch
                    {
                        d = default(decimal);
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
                string s = o as string;
                if (s != null)
                {
                    double d;
                    double.TryParse(s, out d);
                    return d;
                }
                else
                {
                    double d;
                    try
                    {
                        d = Convert.ToDouble(o);
                    }
                    catch
                    {
                        d = default(double);
                    }
                    return d;
                }
            }
        }

        public static T ToEnum<T>(this object o, bool throwEx = true) where T : struct
        {
            if (throwEx)
            {
                string s = o as string;
                if (s != null)
                {
                    return (T)Enum.Parse(typeof(T), s);
                }
                else
                {
                    return (T)o;
                }
            }
            else
            {
                string s = o as string;
                if (s != null)
                {
                    T e;
                    Enum.TryParse<T>(s, out e);
                    return e;
                }
                else
                {
                    T e;
                    try
                    {
                        e = (T)o;
                    }
                    catch
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
                string s = o as string;
                if (s != null)
                {
                    float f;
                    float.TryParse(s, out f);
                    return f;
                }
                else
                {
                    float f;
                    try
                    {
                        f = Convert.ToSingle(o);
                    }
                    catch
                    {
                        f = default(float);
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
                string s = o as string;
                if (s != null)
                {
                    int i;
                    int.TryParse(s, out i);
                    return i;
                }
                else
                {
                    int i;
                    try
                    {
                        i = Convert.ToInt32(o);
                    }
                    catch
                    {
                        i = default(int);
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
                string s = o as string;
                if (s != null)
                {
                    long l;
                    long.TryParse(s, out l);
                    return l;
                }
                else
                {
                    long l;
                    try
                    {
                        l = Convert.ToInt64(o);
                    }
                    catch
                    {
                        l = default(long);
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
                string s = o as string;
                if (s != null)
                {
                    sbyte sb;
                    sbyte.TryParse(s, out sb);
                    return sb;
                }
                else
                {
                    sbyte sb;
                    try
                    {
                        sb = Convert.ToSByte(o);
                    }
                    catch
                    {
                        sb = default(sbyte);
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
                string s = o as string;
                if (s != null)
                {
                    short sh;
                    short.TryParse(s, out sh);
                    return sh;
                }
                else
                {
                    short sh;
                    try
                    {
                        sh = Convert.ToInt16(o);
                    }
                    catch
                    {
                        sh = default(short);
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
                string s = o as string;
                if (s != null)
                {
                    uint ui;
                    uint.TryParse(s, out ui);
                    return ui;
                }
                else
                {
                    uint ui;
                    try
                    {
                        ui = Convert.ToUInt32(o);
                    }
                    catch
                    {
                        ui = default(uint);
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
                string s = o as string;
                if (s != null)
                {
                    ulong ul;
                    ulong.TryParse(s, out ul);
                    return ul;
                }
                else
                {
                    ulong ul;
                    try
                    {
                        ul = Convert.ToUInt64(o);
                    }
                    catch
                    {
                        ul = default(ulong);
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
                string s = o as string;
                if (s != null)
                {
                    ushort us;
                    ushort.TryParse(s, out us);
                    return us;
                }
                else
                {
                    ushort us;
                    try
                    {
                        us = Convert.ToUInt16(o);
                    }
                    catch
                    {
                        us = default(ushort);
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

        public static object CreateInstance(this Type t)
        {
            return t.CreateInstance(null);
        }

        public static object CreateInstance(this Type t, params object[] args)
        {
            if (t.IsArray)
            {
                Array.CreateInstance(t, args == null ? 0 : (int)args[0]);
            }

            if (args == null)
            {
                return Activator.CreateInstance(t);
            }
            else
            {
                return Activator.CreateInstance(t, args);
            }
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