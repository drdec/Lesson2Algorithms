using System;

namespace Lesson2
{
    internal class Program
    {
        private static void Main()
        {
            TestsToList();
        }

        private static void TestsToList() //как по узлу искать я понял, но немного не допер как проверить.
        {
            LinkedList<int> list = new LinkedList<int>();

            list.Add(2);
            list.Add(4);
            list.Add(8);
            list.Add(12);
            list.Add(14);
            list.Add(16);
            list.Add(17);

            Console.WriteLine($"Количество элементов в списке - {list.GetCount()}");

            Console.WriteLine($"Элементы списка : ");
            list.OutputAllItems();

            list.RemoveNodeByValue(2);
            list.OutputAllItems();

            list.RemoveNodeByIndex(3);
            list.OutputAllItems();

            try
            {
                list.RemoveNodeByIndex(12);//упадёт
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            var tempValue = list.FindNode(14);

            Console.WriteLine(tempValue.Value);

        }
    }
}
