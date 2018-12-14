using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class RequestMvcParameter : DictionaryParameter
    {
        public string Endpoint { get; set; }
        public int Id { get; set; }
        public string RolerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RequestMvcParameter() { }
    }
}
