using System;
using System.Collections.Generic;
using System.Linq;

public class MyList
{
    private List<int> items;

    public class Production
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public Production(int id, string name)
        {
            Id = id;
            OrganizationName = name;
        }
        public override string ToString() => $"Производство: Id={Id}, Организация={OrganizationName}";
    }

    public class Developer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public Developer(int id, string fullName, string department)
        {
            Id = id;
            FullName = fullName;
            Department = department;
        }
        public override string ToString() => $"Производитель: {FullName}, ID={Id}, Департамент={Department}";
    }

    public Production production;
    public Developer developer;

    public MyList()
    {
        items = new List<int>();
        production = new Production(1, "Ааааа");
        developer = new Developer(101, "Бббб", "Фффф");
    }

    public MyList(IEnumerable<int> collection)
        : this()
    {
        items = new List<int>(collection);
    }

    public int this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public static MyList operator +(int item, MyList list)
    {
        var newList = new MyList(list.items);
        newList.items.Insert(0, item);
        return newList;
    }

    public static MyList operator --(MyList list)
    {
        var newList = new MyList(list.items);
        if (newList.items.Count > 0)
            newList.items.RemoveAt(0);
        return newList;
    }
    
    public static bool operator ==(MyList? a, MyList? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.items.SequenceEqual(b.items);
    }

    public static bool operator !=(MyList? a, MyList? b) => !(a == b);

    public static MyList operator *(MyList a, MyList b)
    {
        var combined = a.items.Concat(b.items).ToList();
        return new MyList(combined);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MyList other) return false;
        return this == other;
    }

    public override int GetHashCode() => items.GetHashCode();

    public void Add(int item) => items.Add(item);
    public void RemoveAt(int index) => items.RemoveAt(index);
    public override string ToString() => $"[{string.Join(", ", items)}]";

    public IEnumerable<int> AsEnumerable()
    {
        for (int i = 0; i < items.Count; i++)
            yield return items[i];
    }
}

public static class StatisticOperation
{
    public static int DiffMaxMin(this MyList list)
    {
        if (list == null || !list.AsEnumerable().Any()) return 0;
        return list.AsEnumerable().Max() - list.AsEnumerable().Min();
    }

    public static int Count(this MyList list) => list.AsEnumerable().Count();
    public static int Sum(this MyList list) => list.AsEnumerable().Sum();

    public static int CountCapitalizedWords(this string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return 0;
        string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return words.Count(w => char.IsUpper(w[0]));
    }

    public static bool HasDuplicates(this MyList list)
    {
        var distinctCount = list.AsEnumerable().Distinct().Count();
        return distinctCount != list.Count();
    }
}

public class Program
{
    public static void Main()
    {
        var list1 = new MyList(new[] { 1, 2, 3 });
        var list2 = new MyList(new[] { 4, 5, 6 });

        Console.WriteLine("list1 = " + list1);
        Console.WriteLine("list2 = " + list2);

        var list3 = 10 + list1;
        Console.WriteLine("10 + list1 = " + list3);

        var list4 = --list1;
        Console.WriteLine("--list1 = " + list4);

        var list5 = list1 * list2;
        Console.WriteLine("list1 * list2 = " + list5);

        Console.WriteLine("list1 != list2 ? " + (list1 != list2));
        
        var listA = new MyList(new[] { 1, 2, 3, 4, 5 });
        
        Console.WriteLine($"Сумма(listA) = {listA.Sum()}");
        Console.WriteLine($"Разница минимального и максимального элемента(listA) = {listA.DiffMaxMin()}");
        Console.WriteLine($"Количесвтво элементов(listA) = {listA.Count()}");

        string text = "Привет как Дела";
        Console.WriteLine($"Слова начинающиеся с заглавной буквы: {text.CountCapitalizedWords()}");

        var listWithDup = new MyList(new[] { 1, 2, 2, 3 });
        Console.WriteLine($"Есть ли дупликакты в ListWithDup? {listWithDup.HasDuplicates()}");

        Console.WriteLine(list1.production);
        Console.WriteLine(list1.developer);
    }
}
