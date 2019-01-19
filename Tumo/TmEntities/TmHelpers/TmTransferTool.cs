using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public static class TmTransferTool
    {
        public static TmParameter ToJsonParameter<T>(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            string json = TmJson.ToString<T>(value);
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static TmParameter ToJsonParameter<T>(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            string json = TmJson.ToString<T>(value);
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static TmParameter ToJsonParameter<T>(NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            string json = TmJson.ToString<T>(value);
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static TmParameter ToJsonParameter<T>(NineCode nine, TenCode ten, ElevenCode eleven, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            string json = TmJson.ToString<T>(value);
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static TmParameter ToJsonParameter(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve)
        {
            TmParameter mvc = new TmParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            return mvc;
        }
        public static TmParameter ToJsonParameter(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven)
        {
            TmParameter mvc = new TmParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            return mvc;
        }
        public static TmParameter ToParameter<T>(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            mvc.Parameters.Add(key, value);
            return mvc;
        }
        public static TmParameter ToParameter<T>(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, value);
            return mvc;
        }
        public static TmParameter ToParameter<T>(NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            mvc.Parameters.Add(key, value);
            return mvc;
        }
        public static TmParameter ToParameter<T>(NineCode nine, TenCode ten, ElevenCode eleven, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, value);
            return mvc;
        }
        public static TmParameter ToParameter(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve)
        {
            TmParameter mvc = new TmParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            return mvc;
        }
        public static TmParameter ToParameter(EightCode eight, NineCode nine, TenCode ten, ElevenCode eleven)
        {
            TmParameter mvc = new TmParameter();
            mvc.EightCode = eight;
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            return mvc;
        }
        public static TmParameter ToParameter(NineCode nine, TenCode ten, ElevenCode eleven, TwelveCode twelve)
        {
            TmParameter mvc = new TmParameter();
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.TwelveCode = twelve;
            return mvc;
        }
        public static TmParameter ToParameter(NineCode nine, TenCode ten, ElevenCode eleven)
        {
            TmParameter mvc = new TmParameter();
            mvc.NineCode = nine;
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            return mvc;
        }
        public static void AddJsonParameter<T>(TmParameter mvc, string key, T value)
        {
            string json = TmJson.ToString<T>(value);
            mvc.Parameters.Add(key, json);
        }
        public static void AddParameter<T>(TmParameter mvc, string key, T value)
        {
            mvc.Parameters.Add(key, value);
        }
        public static T GetJsonValue<T>(TmParameter mvc, string key)
        {
            object obj = null;
            mvc.Parameters.TryGetValue(key, out obj);
            string json = (string)obj;
            //Json.NET反序列化
            T t = JsonConvert.DeserializeObject<T>(json);
            return t;
        }
        public static T GetValue<T>(TmParameter mvc, string key)
        {            
            object obj = null;
            mvc.Parameters.TryGetValue(key, out obj);
            T tp = (T)obj;           
            return tp;
        }
    }
}
