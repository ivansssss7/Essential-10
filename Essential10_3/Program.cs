using System;

namespace Essential_10_3
{
    interface IMyList<T>
    {
        void Add(T item);
        T Get(int id);
        int Count { get; }
    }

    class MyList<T> : IMyList<T>
    {
        private T[] values;
        private int count;

        public MyList()
        {
            values = new T[10];
            count = 0;
        }

        public void Add(T item)
        {
            if (count == values.Length)
            {
                Array.Resize(ref values, values.Length * 2);
            }
            values[count] = item;
            count++;
        }

        public T Get(int id)
        {
            if (id < 0 || id >= count)
            {
                throw new IndexOutOfRangeException("Індекс виходить за межі діапазону");
            }
            return values[id];
        }

        public int Count { get { return count; } }
    }

    static class MyListExtensions
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] array = new T[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list.Get(i);
            }
            return array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо екземпляр нашого списку MyList<int>
            MyList<int> myList = new MyList<int>();

            // Додаємо елементи до списку
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            // Використовуємо розширюючий метод та виводимо значення елементів масиву
            int[] array = myList.GetArray();
            Console.WriteLine("Елементи списку MyList<int>:");
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }

            // Створюємо екземпляр нашого списку MyList<string>
            MyList<string> myList2 = new MyList<string>();

            // Додаємо елементи до списку
            myList2.Add("one");
            myList2.Add("two");
            myList2.Add("three");

            // Використовуємо розширюючий метод та виводимо значення елементів масиву
            string[] array2 = myList2.GetArray();
            Console.WriteLine("Елементи списку MyList<string>:");
            foreach (string item in array2)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
