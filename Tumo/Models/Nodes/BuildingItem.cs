using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class BuildingItem
    {
        private BuildingItemDB buildingItemDB = new BuildingItemDB();
        private int id;
        private string name2;

        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public BuildingItemDB BuildingItemDB { get => buildingItemDB; }

        public BuildingItem() { }


    }
}
