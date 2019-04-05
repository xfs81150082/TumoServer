using System;
namespace Tumo
{
    class TmInventorySystem : TmSystem
    {
        public override void TmAwake()
        {
            AddComponent(new TmInventory());
            AddComponent(new TmProperty());
            AddComponent(new TmChangeType());
        }
        public override void TmUpdate()
        {
            foreach (TmEntity tem in GetTmEntities())
            {
                PropertyInit(tem);
            }
        }
        TmInventory  inventory { get; set; }
        TmProperty property { get; set; }
        TmChangeType changeType { get; set; }
        void PropertyInit(TmEntity entity)
        {
            if (entity.GetComponent<TmInventory>() != null && entity.GetComponent<TmProperty>() != null && entity.GetComponent<TmChangeType>() != null)
            {
                TmInventory inventory = entity.GetComponent<TmInventory>();
                TmProperty property = entity.GetComponent<TmProperty>();
                TmChangeType changeType = entity.GetComponent<TmChangeType>();
                if (changeType.Exp != changeType.changeCount)
                {
                    InitProperty(entity);
                    changeType.changeCount = changeType.Exp;
                }
            }
        }
        void InitProperty(TmEntity entity)
        {
            UpdateLevel(entity);
            InitPropertyOne(entity);
            InitPropertyTwo(entity);
            InitPropertyThree(entity);
            UpdateItem(entity);
        }  //更新属性
        void InitPropertyOne(TmEntity soulerItem)
        {
            soulerItem.GetComponent<TmProperty>().Stamina = soulerItem.GetComponent<TmInventory>().Stamina * (soulerItem.GetComponent<TmChangeType>().Level + 1);
            soulerItem.GetComponent<TmProperty>().Brains = soulerItem.GetComponent<TmInventory>().Brains * (soulerItem.GetComponent<TmChangeType>().Level + 1);
            soulerItem.GetComponent<TmProperty>().Power = soulerItem.GetComponent<TmInventory>().Power * (soulerItem.GetComponent<TmChangeType>().Level + 1);
            soulerItem.GetComponent<TmProperty>().Agility = soulerItem.GetComponent<TmInventory>().Agility * (soulerItem.GetComponent<TmChangeType>().Level + 1);
        }
        void InitPropertyTwo(TmEntity soulerItem)
        {
            soulerItem.GetComponent<TmProperty>().MaxHp = soulerItem.GetComponent<TmInventory>().MaxHp;            //Hp与根骨成正比；暂定10倍；
            soulerItem.GetComponent<TmProperty>().Bp = soulerItem.GetComponent<TmInventory>().Bp;                 //Bp与智力成正比；暂定1倍；
            soulerItem.GetComponent<TmProperty>().Ap = soulerItem.GetComponent<TmInventory>().Ap;                   //Ap与力量成正比；暂定1倍；
        }
        void InitPropertyThree(TmEntity soulerItem)
        {
            soulerItem.GetComponent<TmProperty>().Sp = soulerItem.GetComponent<TmInventory>().Sp;   //sp暴击率与敏捷成正比。
            soulerItem.GetComponent<TmProperty>().Hr = soulerItem.GetComponent<TmInventory>().Hr;   //hr命中率与敏捷成正比。
            soulerItem.GetComponent<TmProperty>().Cr = soulerItem.GetComponent<TmInventory>().Cr;   //cr暴击率与敏捷成正比。
        }
        //等级更新
        void UpdateLevel(TmEntity soulerItem)
        {
            if (soulerItem.GetComponent<TmChangeType>().Level == soulerItem.GetComponent<TmInventory>().LevelUpLimit) return;
            int expTem = (int)Math.Round((soulerItem.GetComponent<TmChangeType>().Level + 1.0) * (soulerItem.GetComponent<TmChangeType>().Level + 1.0) + 10.0);
            if (soulerItem.GetComponent<TmChangeType>().Exp >= expTem)
            {
                soulerItem.GetComponent<TmChangeType>().Exp -= expTem;
                soulerItem.GetComponent<TmChangeType>().Level++;
                if (soulerItem.GetComponent<TmChangeType>().Level >= soulerItem.GetComponent<TmInventory>().LevelUpLimit)
                {
                    soulerItem.GetComponent<TmChangeType>().Level = soulerItem.GetComponent<TmInventory>().LevelUpLimit;
                    soulerItem.GetComponent<TmChangeType>().Exp = 0;
                }
            }
        } 

        public void UpdateItem(TmEntity entity)
        {
            TmInventory inventory = entity.GetComponent<TmInventory>();
            TmProperty property = entity.GetComponent<TmProperty>();
            TmChangeType changeType = entity.GetComponent<TmChangeType>();
            switch (inventory.InfoType)
            {
                case (InfoType.Brains):
                    property.Stamina += (int)(inventory.Stamina * (changeType.Level + 1));
                    property.Brains += (int)(inventory.Brains * (changeType.Level + 1));
                    break;
                case (InfoType.Power):
                    property.Stamina += (int)(inventory.Stamina * (changeType.Level + 1));
                    property.Power += (int)(inventory.Power * (changeType.Level + 1));
                    break;
                case (InfoType.Bp):
                    property.Bp += (int)(inventory.Bp * (changeType.Level + 1));
                    break;
                case (InfoType.Ap):
                    property.Ap += (int)(inventory.Ap * (changeType.Level + 1));
                    break;
            }
        }

    }
}
