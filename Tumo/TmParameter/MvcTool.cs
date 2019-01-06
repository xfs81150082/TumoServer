using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class MvcTool
    {
        public static MvcParameter ToJsonParameter<T>(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve, string key, T value)
        {
            MvcParameter mvc = new MvcParameter();
            string json = ToString<T>(value);
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static MvcParameter ToJsonParameter<T>(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, string key, T value)
        {
            MvcParameter mvc = new MvcParameter();
            string json = ToString<T>(value);
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static MvcParameter ToJsonParameter<T>(NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve, string key, T value)
        {
            MvcParameter mvc = new MvcParameter();
            string json = ToString<T>(value);
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static MvcParameter ToJsonParameter<T>(NineCode nine, TenCode ten, ElevenCode eleven, string key, T value)
        {
            MvcParameter mvc = new MvcParameter();
            string json = ToString<T>(value);
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static MvcParameter ToJsonParameter(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            return mvc;
        }
        public static MvcParameter ToJsonParameter(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            return mvc;
        }
        public static MvcParameter ToParameter<T>(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve, string key, T value)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            mvc.Parameters.Add(key, value);
            return mvc;
        }
        public static MvcParameter ToParameter<T>(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, string key, T value)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, value);
            return mvc;
        }
        public static MvcParameter ToParameter<T>(NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve, string key, T value)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            mvc.Parameters.Add(key, value);
            return mvc;
        }
        public static MvcParameter ToParameter<T>(NineCode nine, TenCode ten, ElevenCode eleven, string key, T value)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, value);
            return mvc;
        }
        public static MvcParameter ToParameter(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            return mvc;
        }
        public static MvcParameter ToParameter(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            return mvc;
        }
        public static MvcParameter ToParameter(NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            return mvc;
        }
        public static MvcParameter ToParameter(NineCode nine, TenCode ten, ElevenCode eleven)
        {
            MvcParameter mvc = new MvcParameter();
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            return mvc;
        }
        public static void AddJsonParameter<T>(MvcParameter mvc, string key, T value)
        {
            string json = ToString<T>(value);
            mvc.Parameters.Add(key, json);
        }
        public static void AddParameter<T>(MvcParameter mvc, string key, T value)
        {
            mvc.Parameters.Add(key, value);
        }
        public static T GetJsonValue<T>(MvcParameter mvc, string key)
        {
            object obj = null;
            mvc.Parameters.TryGetValue(key, out obj);
            string json = (string)obj;
            //Json.NET反序列化
            T t = JsonConvert.DeserializeObject<T>(json);
            return t;
        }
        public static T GetValue<T>(MvcParameter mvc, string key)
        {            
            object obj = null;
            mvc.Parameters.TryGetValue(key, out obj);
            T tp = (T)obj;           
            return tp;
        }
        public static T ToObject<T>(string str)
        {
            //Json.NET反序列化
            T t = JsonConvert.DeserializeObject<T>(str);
            return t;
        }
        public static string ToString<T>(T value)
        {
            //Json.NET序列化
            string jsonData = JsonConvert.SerializeObject(value);
            return jsonData;
        }
    }
}
