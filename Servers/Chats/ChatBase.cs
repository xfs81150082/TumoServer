using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Chats
{
    public abstract class ChatBase : OnTmTransfer
    {
        public ChatBase()
        {
            TumoChat.Instance.Chats.Add(Code, this);
            Console.WriteLine("Chat:" + this.GetType().Name + "  is register.");
        }

    }
}
