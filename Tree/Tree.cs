using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL_Tree
{
    public class Tree<TKey> : IEnumerable<Node<TKey>> where TKey : IComparable<TKey>
    {
        private List<TKey> values;

        public Tree()
        {
            values = new List<TKey>();
        }

        public Node<TKey> Insert(TKey key, Node<TKey> node = null) => insert(key, node);

        public Node<TKey> Delete(TKey key) => delete(key);

        public Node<TKey> Search(Node<TKey> node, TKey key) => search(node, key);

        public void PreOrder(Node<TKey> node) => preOrder(node);

        public void PosOrder(Node<TKey> node) => posOrder(node);

        public void InOrder(Node<TKey> node) => inOrder(node);

        public void ScreenTree(Node<TKey> node, string message)
        {
            if (node == null)
            {
                Console.WriteLine(message);
                return;
            }
            screenTree(node);
            Console.WriteLine();
        }

        private Node<TKey> insert(TKey key, Node<TKey> node = null)
        {
            if (!values.Contains(key))
                values.Add(key);
            if (node == null)
                return new Node<TKey>(key);
            else if (node.Key.CompareTo(key) < 0)
                node.RightChild = insert(key, node.RightChild);
            else if (node.Key.CompareTo(key) > 0)
                node.LeftChild = insert(key, node.LeftChild);
            node.Height = 1 + Math.Max(height(node.LeftChild), height(node.RightChild));
            return balance(node);
        }

        private int height(Node<TKey> node) => node != null ? node.Height : -1;

        private int balanceFactor(Node<TKey> node) => height(node.LeftChild) - height(node.RightChild);

        private Node<TKey> balance(Node<TKey> node)
        {
            if (balanceFactor(node) < -1)
            {
                if (balanceFactor(node.RightChild) > 0)
                    node.RightChild = rightRotation(node.RightChild);
                node = leftRotation(node);
            }
            else if (balanceFactor(node) > 1)
            {
                if (balanceFactor(node.LeftChild) < 0)
                    node.LeftChild = leftRotation(node.LeftChild);
                node = rightRotation(node);
            }
            return node;
        }

        private Node<TKey> rightRotation(Node<TKey> keyTwo)
        {
            Node<TKey> keyOne = keyTwo.LeftChild;
            keyTwo.LeftChild = keyOne.RightChild;
            keyOne.RightChild = keyTwo;
            keyTwo.Height = 1 + Math.Max(height(keyTwo.LeftChild), height(keyTwo.RightChild));
            keyOne.Height = 1 + Math.Max(height(keyOne.LeftChild), height(keyOne.RightChild));
            return keyOne;
        }

        private Node<TKey> leftRotation(Node<TKey> keyOne)
        {
            Node<TKey> keyTwo = keyOne.RightChild;
            keyOne.RightChild = keyTwo.LeftChild;
            keyTwo.LeftChild = keyOne;
            keyOne.Height = 1 + Math.Max(height(keyOne.LeftChild), height(keyOne.RightChild));
            keyTwo.Height = 1 + Math.Max(height(keyTwo.LeftChild), height(keyTwo.RightChild));
            return keyTwo;
        }

        private Node<TKey> search(Node<TKey> node, TKey key)
        {
            if (node == null)
                return null;
            else if (key.CompareTo(node.Key) == 0)
            {
                Console.WriteLine(marker());
                Console.WriteLine("({0})", node.Key);
                Console.WriteLine(marker());
                return node;
            }
            Console.WriteLine(marker());
            Console.WriteLine("({0})", node.Key);
            Console.WriteLine(marker());
            return search(nextNode(key, node), key);
        }

        private string marker() => "----------------";

        private Node<TKey> nextNode(TKey other, Node<TKey> node) => other.CompareTo(node.Key) < 0 ? node.LeftChild : node.RightChild;

        private void screenTree(Node<TKey> current)
        {
            if (current != null)
            {
                screenTree(current.LeftChild);
                Console.Write("({0}) ", current.Key);
                screenTree(current.RightChild);
            }
        }

        private Node<TKey> delete(TKey key)
        {
            Node<TKey> node = null;

            foreach (var value in values)
                if (!key.Equals(value))
                    node = Insert(value, node);
            return node;
        }

        private void posOrder(Node<TKey> node)
        {
            if (node != null)
            {
                posOrder(node.LeftChild);
                posOrder(node.RightChild);
                Console.Write("({0}) ", node.Key);
            }
        }

        private void preOrder(Node<TKey> node)
        {
            if (node != null)
            {
                Console.Write("({0}) ", node.Key);
                preOrder(node.LeftChild);
                preOrder(node.RightChild);
            }
        }

        private void inOrder(Node<TKey> node)
        {
            if (node != null)
            {
                inOrder(node.LeftChild);
                Console.Write("({0}) ", node.Key);
                inOrder(node.RightChild);
            }
        }

        public IEnumerator<Node<TKey>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
