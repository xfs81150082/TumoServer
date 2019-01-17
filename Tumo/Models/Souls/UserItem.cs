using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class UserItem
    {
        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Serverid { get => serverid; set => serverid = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Qq { get => qq; set => qq = value; }
        public string RigisterDateTime { get => rigisterDateTime; set => rigisterDateTime = value; }
        public string LoginDateTime { get => loginDateTime; set => loginDateTime = value; }
        public int LoginCount { get => loginCount; set => loginCount = value; }
        public UserItem() { }
        public UserItem(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        private int id;
        private string username;
        private string password;
        private int serverid;
        private string phone;
        private string qq;
        private string rigisterDateTime;
        private string loginDateTime;
        private int loginCount;
    }
}
