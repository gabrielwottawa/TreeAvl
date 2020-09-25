using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL_Tree
{
    public static class RequestData
    {
        public static RequestType RequestType()
        {
            RequestType selectedType;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("i - Insert");
                Console.WriteLine("d - Delete");
                Console.WriteLine("b - Search");
                Console.WriteLine("e - Exit");

                var option = convertOption(Console.ReadLine());

                if (!getOptions().ToArray().Contains(option.ToString()))
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }
                selectedType = Enum.Parse<RequestType>(option.ToString());
                break;
            } while (true);
            return selectedType;
        }

        private static IEnumerable<string> getOptions()
        {
            foreach (int value in Enum.GetValues(typeof(RequestType)))
                yield return value.ToString();
        }

        private static int convertOption(string option)
        {
            switch (option)
            {
                case "i":
                    Console.WriteLine("Insert - Enter value:");
                    return 0;
                case "d":
                    Console.WriteLine("Delete - Enter value:");
                    return 1;
                case "b":
                    Console.WriteLine("Search - Enter value:");
                    return 2;
                case "e":
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
