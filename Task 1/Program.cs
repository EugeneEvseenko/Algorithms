using System.Diagnostics.Metrics;
using System.Reflection;

namespace Task_1
{
    internal class Program
    {
        /// <summary>
        /// Бинарный поиск по массиву
        /// </summary>
        /// <param name="array">Отсортированный массив</param>
        /// <param name="item">Искомый элемент</param>
        /// <returns>Вернет индекс найденного элемента и количество итераций поиска</returns>
        public static (int? Index, int Counter) BinarySearch(int[] array, int item)
        {
            int low = 0;
            int high = array.Length - 1;
            int counter = 0;

            while (low <= high)
            {
                counter++;

                int middle = (low + high) / 2;
                int guess = array[middle];
                if (guess == item)
                    return (middle, counter);
                    
                if (guess > item)
                    high = middle - 1;
                else
                    low = middle + 1;
            }
            
            return (null, counter);
        }
        static void Main(string[] args)
        {
            int from = new Random().Next(1, 500), to = new Random().Next(500, 1000);
            int[] ints = Enumerable.Range(from, to).ToArray();
            int item = new Random().Next(from, to);

            Console.WriteLine($"Сгенерирован массив чисел от {from} до {to}");

            var result = BinarySearch(ints, item);

            if (result.Index != null)
                Console.WriteLine($"Элемент {item}[{result.Index}] найден за {result.Counter} итерации");
            else
                Console.WriteLine($"Элемент {item} не найден [{result.Counter}]");
            Console.ReadKey();
        }
    }
}