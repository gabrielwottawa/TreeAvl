using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    public class Factory
    {
        private static Tree<int> tree = new Tree<int>();
        private static Node<int> node = null;

        public static void Create(RequestType requestType)
        {
            switch (requestType)
            {
                case RequestType.Insert:
                    var keyInsert = Convert.ToInt32(Console.ReadLine());
                    node = tree.Insert(keyInsert, node);
                    tree.ScreenTree(node, "Tree is empty!");
                    break;
                case RequestType.Delete:
                    var keyDelete = Convert.ToInt32(Console.ReadLine());
                    node = tree.Delete(keyDelete);
                    tree.ScreenTree(node, "Tree is empty!");
                    break;
                case RequestType.Search:
                    var keySearch = Convert.ToInt32(Console.ReadLine());
                    var search = tree.Search(node, keySearch);
                    if (search == null)
                        Console.WriteLine("Number not found in the tree.");
                    break;
                case RequestType.Exit:
                    Console.Write("Tree AVL: ");
                    tree.ScreenTree(node, "Tree is empty!");                    
                    Console.Write("Pos order: ");
                    tree.PosOrder(node);
                    Console.Write("\nPre order: ");
                    tree.PreOrder(node);
                    Console.Write("\nIn order: ");
                    tree.InOrder(node);
                    break;
            }
        }
    }
}
