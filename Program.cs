using System;

namespace Lesson2
{
    internal class Program
    {
        private static void Main()
        {
            TestsToList();

            Console.ReadKey();

            TestToBinarySearch();
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

        private static void TestToBinarySearch()
        {
            Console.WriteLine(BinarySearch(new int[] {1,2,3,4,5,6},4));
            Console.WriteLine(BinarySearch(new int[] {4,8,7,6,5,4,7,3,7 }, 4));//даже если не упадет, отработает неправильно, ибо массив не отсортирован
            Console.WriteLine(BinarySearch(new int[] {8,7,6, 5, 4, 3, 2, 1}, 4));//отработает тоже неправильно, ибо массив отсортирован не в том порядке, который нужен
        }

        private static int BinarySearch(int[] array, int searchValue) // сложность log2(n)
        {
            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == array[mid])
                {
                    return mid;
                }
                else if (searchValue < array[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return -1;
        }
    }
}
