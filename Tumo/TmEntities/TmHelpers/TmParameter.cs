using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class TmParameter : TmDictionaryParameter
    {
        public int Id { get; set; }
        //public string EcsId { get; set; }
        //public string Endpoint { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RolerId { get; set; }
        public TmParameter() { }
    }
}
