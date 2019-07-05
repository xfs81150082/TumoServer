using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tumo
{
    class TmInventoryAddSystem : TmSystem
    {
        public override void TmAwake()
        {
            AddComponent(new TmProperty());
            AddComponent(new TmInventoryAdd());
        }
        public override void TmUpdate()
        {
            foreach (TmEntity tem in GetTmEntities())
            {
                PropertyInit(tem);
            }
        }
        TmProperty soulerItem { get; set; }
        TmProperty property { get; set; }
        void PropertyInit(TmEntity entity)
        {
            if (entity.GetComponent<TmProperty>() != null && entity.GetComponent<TmInventoryAdd>() != null)
            {
                soulerItem = entity.GetComponent<TmProperty>();
                property = entity.GetComponent<TmInventoryAdd>();

                if (soulerItem.Stamina != entity.GetComponent<TmInventoryAdd>().changeCount)
                {
                    InitAddProperty(entity);
                    entity.GetComponent<TmInventoryAdd>().changeCount = soulerItem.Stamina;
                }

            }
        }
        void InitAddProperty(TmEntity entity)
        {
            soulerItem = entity.GetComponent<TmProperty>();
            property = entity.GetComponent<TmInventoryAdd>();

            property.MaxHp = (int)(soulerItem.MaxHp * property.MaxHpRate + soulerItem.StaminaRate * property.Stamina);
            property.Hp = (int)(soulerItem.Hp * property.HpRate);
            property.Bp = (int)(soulerItem.Bp * property.BpRate + soulerItem.BrainsRate * property.Brains);
            property.Ap = (int)(soulerItem.Ap * property.ApRate + soulerItem.PowerRate * property.Power);
            property.Sp = (int)(soulerItem.Sp * property.SpRate);
        }  //更新属性


    }
}
