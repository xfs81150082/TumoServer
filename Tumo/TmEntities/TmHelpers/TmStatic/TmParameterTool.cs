using Newtonsoft.Json;
using System.Collections.Generic;
namespace Tumo
{
    public static class TmParameterTool
    {
        public static TmParameter ToJsonParameter<T>(TenCode ten, ElevenCode eleven, string key, T value)
        {
            TmParameter parameter = new TmParameter();
            string json = TmJson.ToString<T>(value);
            parameter.TenCode = ten;
            parameter.ElevenCode = eleven;
            parameter.Parameters.Add(key, json);
            return parameter;
        }
        public static void AddJsonParameter<T>(TmParameter parameter, string key, T value)
        {
            object obj;
            bool yes = parameter.Parameters.TryGetValue(key, out obj);
            if (yes) { parameter.Parameters.Remove(key); }
            string json = TmJson.ToString<T>(value);
            parameter.Parameters.Add(key, json);
        }
        public static T GetJsonValue<T>(TmParameter parameter, string key)
        {
            object obj = null;
            parameter.Parameters.TryGetValue(key, out obj);
            string json = (string)obj;
            //Json.NET反序列化
            T t = JsonConvert.DeserializeObject<T>(json);
            return t;
        }
        public static TmParameter ToParameter(TenCode ten, ElevenCode eleven)
        {
            TmParameter parameter = new TmParameter();
            parameter.TenCode = ten;
            parameter.ElevenCode = eleven;
            return parameter;
        }
        public static void AddParameter<T>(TmParameter parameter, string key, T value)
        {
            object obj;
            bool yes = parameter.Parameters.TryGetValue(key, out obj);
            if (yes) { parameter.Parameters.Remove(key); }
            parameter.Parameters.Add(key, value);
        }
        public static T GetValue<T>(TmParameter parameter, string key)
        {
            object obj = null;
            parameter.Parameters.TryGetValue(key, out obj);
            T tp = (T)obj;
            return tp;
        }
        public static T OutOfDictionary<T>(string key, Dictionary<string, T> dictionary)
        {
            T val;
            bool yes = dictionary.TryGetValue(key, out val);
            if (yes)
            {
                return val;
            }
            return default(T);
        }
    }
}