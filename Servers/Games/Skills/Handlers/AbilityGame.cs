using Tumo;
using Tumo.Models;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Handlers
{
    class AbilityGame : GameHandlerBase
    {
        public override string Code => TenCode.Ability.ToString();
        public override void OnTransferParameter(TmRequest mvc)
        {
            ElevenCode ElevenCode = mvc.ElevenCode;
            switch (ElevenCode)
            {              
                case (ElevenCode.None):
                    break;
                case (ElevenCode.Test):
                    break;
                default:
                    break;
            }
        }

        public AbilityGame()  {  }

        void Test(TmRequest mvc)
        {
            Console.WriteLine("GameAbilityTest:" + mvc.NineCode);
            //object obj1 = null;
            //mvc.Parameters.TryGetValue("TPeer", out obj1);
            //TPeer peer = (TPeer)obj1;
            //mvc.Parameters.Remove("TPeer");
            //mvc.Parameters.Add("Test", "成功收到GameTest信息");
            //peer.SendMsg(mvc);
        }


        void SpawnItemdb(TmRequest sp)
        {
            object json;
            sp.Parameters.TryGetValue("SkillItemDB", out json);
            SkillItemDB item = TmTransferTool.ToObject<SkillItemDB>(json.ToString());
            //manager.InsertItemdb(item.Name, item.SkillId, item.RolerId);
        }
        void RemoveItemdb(TmRequest sp)
        {
            object json;
            sp.Parameters.TryGetValue("SkillItemDB", out json);
            SkillItemDB item = TmTransferTool.ToObject<SkillItemDB>(json.ToString());
            //manager.RemoveItemdb(item.Id);
        }
        void UpdateItemdbName(TmRequest sp)
        {
            object json;
            sp.Parameters.TryGetValue("SkillItemDB", out json);
            SkillItemDB item = TmTransferTool.ToObject<SkillItemDB>(json.ToString());
            //manager.UpdateItemdb(item.Id, item.Name);
        }
        void UpdateItemdbHpMp(TmRequest sp)
        {
            object json;
            sp.Parameters.TryGetValue("SkillItemDB", out json);
            SoulItemDB item = TmTransferTool.ToObject<SoulItemDB>(json.ToString());
            //manager.UpdateItemdb(item.Id, item.Exp, item.Level, item.Hp, item.Mp, item.Coin, item.Diamond);
        }
        void UpdateItemdbPxPyPz(TmRequest sp)
        {
            Console.WriteLine("sp:" + sp.Parameters.Count);
            object json;
            sp.Parameters.TryGetValue("SkillItemDB", out json);
            SoulItemDB item = TmTransferTool.ToObject<SoulItemDB>(json.ToString());
            Console.WriteLine("SkillItemDB:" + item.py);

            //manager.UpdateItemdb(item.Id, item.SenceId, item.px, item.py, item.pz, item.ax, item.ay, item.az);
        }
        void GetItems(TmRequest mvc)
        {
            //向mysql取得玩家数据列表
            //List<SkillItem> list1 = manager.ReaderItems();
            //Console.WriteLine("SkillItems:" + list1.Count + "\t\n");

            //string jsondict1 = SocketTool.ToString(list1);
            //mvc.Parameters.Add("GetItems", jsondict1);

            //用json序列化参数，然后发送给客户端
            object obj1 = null;
            mvc.Parameters.TryGetValue("TPeer", out obj1);
            TPeer peer = (TPeer)obj1;
            //Console.WriteLine(peer.Socket.RemoteEndPoint.ToString());
            mvc.Parameters.Remove("TPeer");
            //peer.SendMsg(mvc);
        }

    }
}
