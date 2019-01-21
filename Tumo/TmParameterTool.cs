﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public static class TmParameterTool
    {
        public static TmParameter ToJsonParameter<T>(TenCode ten, ElevenCode eleven, string key, T value)
        {
            TmParameter mvc = new TmParameter();
            string json = TmJson.ToString<T>(value);
            mvc.TenCode = ten;
            mvc.ElevenCode = eleven;
            mvc.Parameters.Add(key, json);
            return mvc;
        }
        public static TmParameter ToJsonParameter(TenCode ten, ElevenCode eleven)
        {
            TmParameter mvc = new TmParameter();
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
