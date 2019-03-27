using System;
using System.Collections.Generic;
namespace Tumo
{
    [Serializable]
    public class TmSoulerItem : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmName());
            AddComponent(new TmSouler());
            AddComponent(new TmSoulerDB());
            AddComponent(new TmCoolDown());
            AddComponent(new TmChangeType());
            AddComponent(new TmProperty());
            AddComponent(new TmInventoryAdd());
            AddComponent(new TmBuffAdd());
            AddComponent(new TmAbilityAdd());
            AddComponent(new TmAstarComponent());
        }
        public TmSoulerItem() { }                        ///构造函数 
        public TmSoulerItem(TmSoulerDB itemDB)
        {
            if (this.GetComponent<TmSoulerDB>() != null)
            {
                RemoveComponent<TmSoulerDB>();
            }
            AddComponent(itemDB);
            this.GetComponent<TmName>().Name = this.GetComponent<TmSoulerDB>().Name;
            this.GetComponent<TmName>().Id = this.GetComponent<TmSoulerDB>().Id;
            this.GetComponent<TmName>().ParentId = this.GetComponent<TmSoulerDB>().UserId;
            this.GetComponent<TmChangeType>().Exp = this.GetComponent<TmSoulerDB>().Exp;
            this.GetComponent<TmChangeType>().Level = this.GetComponent<TmSoulerDB>().Level;
            this.GetComponent<TmChangeType>().Coin = this.GetComponent<TmSoulerDB>().Coin;
            this.GetComponent<TmChangeType>().Diamond = this.GetComponent<TmSoulerDB>().Diamond;
            this.GetComponent<TmProperty>().Hp = this.GetComponent<TmSoulerDB>().Hp;
            this.GetComponent<TmProperty>().Mp = this.GetComponent<TmSoulerDB>().Mp;
        }

    }
}
