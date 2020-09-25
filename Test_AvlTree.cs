using System;

namespace AVL_Tree
{
    public class Test_AvlTree
    {
        public static void Main(string[] args)
        {
            var requestType = RequestType.Exit;

            do
            {
                requestType = RequestData.RequestType();
                Factory.Create(requestType);

            } while (requestType != RequestType.Exit);
        }
    }
}
