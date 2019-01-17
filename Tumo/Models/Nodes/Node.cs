using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class Node
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public int Idx { get => idx; set => idx = value; }
        public int Idy { get => idy; set => idy = value; }
        public double Px { get => px; set => px = value; }
        public double Py { get => py; set => py = value; }
        public double Pz { get => pz; set => pz = value; }
        public int Lx { get => lx; set => lx = value; }
        public int Ly { get => ly; set => ly = value; }
        public int MoveType { get => moveType; set => moveType = value; }

        public Node() { }

        private int id;
        private string name2;
        private int idx;
        private int idy;
        private double px;
        private double py;
        private double pz;
        private int lx;
        private int ly;
        private int moveType = 1;
    }
}
