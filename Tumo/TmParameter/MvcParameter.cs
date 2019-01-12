using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class MvcParameter : DictionaryParameter
    {
        public int Id { get; set; }
        public string EntityId { get; set; }
        public string Endpoint { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RolerId { get; set; }
        public MvcParameter() { }
    }
}
