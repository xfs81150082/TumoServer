using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    class NodeItemDB
    {
        public int Id { get => id; set => id = value; }
        public string Name2 { get => name2; set => name2 = value; }
        public Node Node { get => node; set => node = value; }
        public List<int> Engineers { get => engineers; set => engineers = value; }

        public NodeItemDB() { }

        private int id;
        private string name2;
        private Node node;
        private List<int> engineers;
    }
}
