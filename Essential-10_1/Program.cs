namespace Essential_10
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
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine($"Елемент з індексом {i}: {myList.Get(i)}");
            }
            Console.WriteLine("string generic"); 
            // Створюємо екземпляр нашого списку MyList<int>
            MyList<string> myList2 = new MyList<string>();

            // Додаємо елементи до списку
            myList2.Add("one");
            myList2.Add("two");
            myList2.Add("three");
            // Виводимо значення елементів списку

            for (int i = 0; i < myList2.Count; i++)
            {
                Console.WriteLine($"Елемент з індексом {i}: {myList2.Get(i)}");
            }
            Console.ReadLine();
        }
    }
}