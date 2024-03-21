
namespace Essential10_2
{

    public interface ICreature
    {
        string CreatureType { get; }
    }


    public class Gift
    {
        public string Name { get; }

        public Gift(string name)
        {
            Name = name;
        }
    }


    public class MagicalBag<T> where T : ICreature
    {
        private readonly Dictionary<string, Gift> _gifts;

        public MagicalBag()
        {
            _gifts = new Dictionary<string, Gift>();
        }

        // Метод для додавання подарунків у мішок
        public void AddGift(Gift gift)
        {
            _gifts[typeof(T).Name] = gift;
        }

        // Метод для відкриття мішка
        public void OpenBag(T creature)
        {
            if (_gifts.ContainsKey(creature.CreatureType))
            {
                Console.WriteLine($"{creature.CreatureType} отримує подарунок: {_gifts[creature.CreatureType].Name}");
                _gifts.Remove(creature.CreatureType);
            }
            else
            {
                Console.WriteLine($"Для {creature.CreatureType} сьогодні немає подарунка у мішку.");
            }
        }
    }

    // Приклад реалізації конкретних істот
    public class Human : ICreature
    {
        public string CreatureType { get; }

        public Human(string creatureType)
        {
            CreatureType = creatureType;
        }
    }

    public class Elf : ICreature
    {
        public string CreatureType { get; }

        public Elf(string creatureType)
        {
            CreatureType = creatureType;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення мішку
            var magicalBag = new MagicalBag<ICreature>();

            // Додавання подарунків у мішок
            magicalBag.AddGift(new Gift("Книга") { });
            magicalBag.AddGift(new Gift("М'яч") { });

            // Підготовка різних істот, які намагаються отримати подарунок
            var john = new Human("John");
            var jane = new Human("Jane");
            var legolas = new Elf("Legolas");

            // Отримання подарунка з мішка
            magicalBag.OpenBag(john); // John отримує подарунок: Книга
            magicalBag.OpenBag(jane); // Jane отримує подарунок: М'яч
            magicalBag.OpenBag(legolas); // Для Elf сьогодні немає подарунка у мішку.
        }
    }
}
