using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class NodeItem
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public Node Node { get => node; set => node = value; }
        public double G { get => g; set => g = value; }
        public double H { get => h; set => h = value; }
        public double F { get => f; set => f = value; }
        public NodeItem Parent { get => parent; set => parent = value; }

        public NodeItem() { }
        public NodeItem(Node node)
        {
            this.node = node;
            this.id = node.Id;
            this.name2 = node.Name;
        }

        private int id;
        private string name2;
        private Node node = new Node();
        private double g;
        private double h;
        private double f;
        private NodeItem parent;

    }
}
