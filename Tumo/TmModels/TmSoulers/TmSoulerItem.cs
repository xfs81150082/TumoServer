using System;
using System.Collections.Generic;
namespace Tumo
{
    [Serializable]
    public class TmSoulerItem : TmEntity
    {
        public override void TmAwake()
        {
            AddComponent(new TmTransform());
            AddComponent(new TmProperty());
            AddComponent(new TmName());
            AddComponent(new TmSouler());
            AddComponent(new TmSoulerDB());
            AddComponent(new TmChangeType());
            AddComponent(new TmCoolDown());
            AddComponent(new TmInventoryAdd());
            AddComponent(new TmBuffAdd());
            AddComponent(new TmAbilityAdd());
            AddComponent(new TmAstarComponent());
        }
        public TmSoulerItem() { }                        ///构造函数 
        public TmSoulerItem(TmSoulerDB itemDB)
        {
            if(this.GetComponent<TmSoulerDB>() != null)
            {
                this.RemoveComponent<TmSoulerDB>();
            }
            this.AddComponent(itemDB);
            this.GetComponent<TmName>().Id = itemDB.Id;
            this.GetComponent<TmName>().Name = itemDB.Name;
            this.GetComponent<TmName>().ParentId = itemDB.UserId;
            this.GetComponent<TmChangeType>().Exp = itemDB.Exp;
            this.GetComponent<TmChangeType>().Level = itemDB.Level;
            this.GetComponent<TmChangeType>().Coin = itemDB.Coin;
            this.GetComponent<TmChangeType>().Diamond = itemDB.Diamond;
            this.GetComponent<TmProperty>().Hp = itemDB.Hp;
            this.GetComponent<TmProperty>().Mp = itemDB.Mp;
            this.GetComponent<TmTransform>().px = itemDB.px;
            this.GetComponent<TmTransform>().py = itemDB.py;
            this.GetComponent<TmTransform>().pz = itemDB.pz;
            this.GetComponent<TmTransform>().ax = itemDB.ax;
            this.GetComponent<TmTransform>().ay = itemDB.ay;
            this.GetComponent<TmTransform>().az = itemDB.az;
        }

    }
}
