using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    public class Node<TKey>
    {
        public TKey Key { get; set; }
        public Node<TKey> Parent { get; set; }
        public Node<TKey> LeftChild { get; set; }
        public Node<TKey> RightChild { get; set; }
        public int Height { get; set; }

        public Node(TKey key)
        {
            this.Key = key;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
            this.Height = 0;
        }
    }
}
