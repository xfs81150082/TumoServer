using Newtonsoft.Json;
namespace Tumo
{
    public static class TmJson
    {
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
