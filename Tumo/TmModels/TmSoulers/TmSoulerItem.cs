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
            AddComponent(new TmChangeType());
            AddComponent(new TmProperty());
            AddComponent(new TmInventoryAdd());
            AddComponent(new TmBuffAdd());
            AddComponent(new TmAbilityAdd());
        }
        public TmSoulerItem() { }                        ///构造函数 
        public TmSoulerItem(TmSoulerDB itemDB)
        {
            if (this.GetComponent<TmSoulerDB>() != null)
            {
                RemoveComponent<TmSoulerDB>();
            }
            AddComponent(itemDB);
            (this.GetComponent<TmName>() as TmName).Name = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).Name;
            (this.GetComponent<TmName>() as TmName).Id = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).Id;
            (this.GetComponent<TmName>() as TmName).ParentId = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).UserId;
            (this.GetComponent<TmChangeType>() as TmChangeType).Exp = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).Exp;
            (this.GetComponent<TmChangeType>() as TmChangeType).Level = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).Level;
            (this.GetComponent<TmChangeType>() as TmChangeType).Coin = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).Coin;
            (this.GetComponent<TmChangeType>() as TmChangeType).Diamond = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).Diamond;
            (this.GetComponent<TmProperty>() as TmProperty).Hp = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).Hp;
            (this.GetComponent<TmProperty>() as TmProperty).Mp = (this.GetComponent<TmSoulerDB>() as TmSoulerDB).Mp;
        }

    }
}
