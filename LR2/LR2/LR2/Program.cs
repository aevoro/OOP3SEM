using System;

public partial class  Product
{
    private static int counter = 0;

    private const string DEFAULT_MANUFACTURER = "noname";
    
    private readonly Guid id;

    private string name;
    private string upc;
    private string manufacturer;
    private int price;
    private int shelfLife;
    private int quantity;

    public string Name
    {
        get => name;
        set => name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Имя не может быть использовано");
    }
    
    public string UPC
    {
        get => upc;
        set => upc = value?.Length == 12 ? value : throw new ArgumentException("UPC состоит из 12 цифр");
    }
    
    public string Manufacturer
    {
        get => manufacturer;
        set => manufacturer = !string.IsNullOrWhiteSpace(value) ? value : DEFAULT_MANUFACTURER;
    }
    
    public int Price
    {
        get => price;
        set => price = value >= 0 ? value : throw new ArgumentException("Цена не может быть отрицательной");
    }
    
    public int ShelfLife
    {
        get => shelfLife;
        set => shelfLife = value >= 0 ? value : throw new ArgumentException("Срок хранения не может быть отрицательным");
    }
    
    public int Quantity
    {
        get => quantity;
        set => quantity = value >= 0 ? value : throw new ArgumentException("Количество не может быть отрицательным");
    }
    
    
    //Конструктор с параметрами
    public Product(string name, string upc, string manufacturer, int price, int shelfLife, int quantity, Guid customId) :this(customId)
    {
        this.Name = name;
        this.UPC = upc;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.ShelfLife = shelfLife;
        this.Quantity = quantity;
        counter++;
    }

    //Конструктор с параметрами по умолчанию
    public Product(string name, string upc = "000000000000", string manufacturer = DEFAULT_MANUFACTURER, int price = 0,
        int shelfLife = 0, int quantity = 0)
    {
        this.id = Guid.NewGuid();
        this.Name = name;
        this.UPC = upc;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.ShelfLife = shelfLife;
        this.Quantity = quantity;
        counter++;
    }

    //Конструктор без параметров
    public Product() : this("no", "000000000000", DEFAULT_MANUFACTURER, 0, 0, 0)
    {
        
    }
    
    //Статический конструктор
    static Product()
    {
        counter = 0;
        Console.WriteLine("Статический конструктор");
    }
    
    //Закрытый конструктор
    private Product(Guid customId) 
    {
        id = customId;
        name = "Продукт";
        upc = "ПРОДУКТ000";
        manufacturer = "Кто-то";
        price = 0;
        shelfLife = 0;
        quantity = 0;
        counter++;
    }
    
    //Статическое поле
    public static void ClassInfo()
    {
        Console.WriteLine($"Создано объектов: {counter}");
    }
    
    //Метод с ref и out параметрами
    public bool rePrice(ref int currentPrice, out int oldPrice, int newPrice)
    {
        oldPrice = currentPrice;
        if (newPrice > 0)
        {
            currentPrice = newPrice;
            this.price = newPrice;
            return true;
        }
        return false;
    }

    //Метод для подсчета суммы
    public int GetSum()
    {
        return price*quantity;
    }
    
    //Переопределение методов Object
    public override bool Equals(object obj)
    {
        if (obj is Product other)
        {
            return id.Equals(other.id);
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
    
    public override string ToString()
    {
        return $"Product [ID: {id}, Name: {name}, UPC: {upc}, Manufacturer: {manufacturer}, " +
               $"Price: {price:C}, Shelf Life: {shelfLife} days, Quantity: {quantity}]";
    }
    
    //Статический метод для вызова закрытого конструктора
    public static Product CreateInternalProduct(string name, string upc, string manufacturer, 
        int price, int shelfLife, int quantity)
    {
        return new Product(name, upc, manufacturer, price, shelfLife, quantity);
    }
}

public partial class Product
{
    //Метод для изменения количества с проверкой
    public bool ChangeQuantity(int delta)
    {
        int newQuantity = quantity + delta;
        if (newQuantity >= 0)
        {
            quantity = newQuantity;
            return true;
        }
        return false;
    }
}

class Program()
{
    static void Main()
    {
        Console.WriteLine("Создание объектов: ");
        var product1 = new Product("Телефон", "123456789123", "Apple", 1000, 10, 5);
        var product2 = new Product("Хлеб", "123123123123", "Минскхлебпром", 3, 1, 1000);
        var product3 = new Product();//Конструктор без параметров
        var product4 = new Product("Сыр", price:12, manufacturer:"СырЗавод", shelfLife:1, quantity:100, upc:"121212121212");
        
        //Вызов закрытого конструктора через статический метод
        var internalProduct = Product.CreateInternalProduct("Телевизор", "999999999999", "Интеграл", 800, 30, 5);
        
        Console.WriteLine("Информация об объектах");
        Console.WriteLine(product1);
        Console.WriteLine(product2);
        Console.WriteLine(product3);
        Console.WriteLine(product4);
        Console.WriteLine(internalProduct);
        
        Console.WriteLine("Свойства");
        product3.Name = "Хлеб";
        product3.Price = 3;
        product3.ChangeQuantity(25); 
        Console.WriteLine($"Обновленный продукт: {product3}");
        Console.WriteLine($"Общая сумма продукта '{product3.Name}': {product3.GetSum()}");
        
        Console.WriteLine("Использование ref и out параметров");
        int price = product2.Price;
        if (product2.rePrice(ref price, out int oldPrice, 2))
        {
            Console.WriteLine($"Цена изменена с {oldPrice:C} на {price:C}");
        }
        
        Console.WriteLine("Сравнение");
        Console.WriteLine($"product1.Equals(product2): {product1.Equals(product2)}");
        Console.WriteLine($"product1 HashCode: {product1.GetHashCode()}");
        Console.WriteLine($"product2 HashCode: {product2.GetHashCode()}");
        
        Console.WriteLine("Проверка типа");
        Console.WriteLine($"Тип product1: {product1.GetType()}");
        Console.WriteLine($"Является ли Product: {product1 is Product}");
        
        Console.WriteLine("Статический метод");
        Product.ClassInfo();
        
        //Создание массива объектов
        Console.WriteLine("Массив объектов");
        Product[] products = {
            new Product("Молоко", "111111111111", "Молочный завод 1", 2, 10, 100),
            new Product("Молоко", "222222222222", "Молочный завод 2", 5, 14, 80),
            new Product("Хлеб", "333333333333", "Хлебзавод 1", 1, 7, 50),
            new Product("Молоко", "444444444444", "Молочный завод 3", 3, 12, 60),
            new Product("Сыр", "555555555555", "Сырный завод", 4, 21, 40)
        };
        
        //Список товаров для заданного наименования
        string searchName = "Молоко";
        Console.WriteLine($"Товары с наименованием '{searchName}':");
        var milkProducts = products.Where(p => p.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        foreach (var product in milkProducts)
        {
            Console.WriteLine(product);
        }
        
        //Список товаров для заданного наименования с ценой не выше заданной
        decimal maxPrice = 1;
        Console.WriteLine($"Товары '{searchName}' с ценой не выше {maxPrice:C}:");
        var filteredProducts = products.Where(p => p.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase) && p.Price <= maxPrice);
        foreach (var product in filteredProducts)
        {
            Console.WriteLine(product);
        }
        
        //Создание анонимного типа
        Console.WriteLine("Анонимный тип");
        var anonymousProduct = new
        {
            Id = Guid.NewGuid(),
            Name = "Молоко",
            UPC = "999999999999",
            Manufacturer = "Молочный завод",
            Price = 1,
            ShelfLife = 10,
            Quantity = 75
        };
        
        Console.WriteLine($"Анонимный тип: {anonymousProduct}");
        Console.WriteLine($"Тип: {anonymousProduct.GetType()}");
        Console.WriteLine($"Название: {anonymousProduct.Name}, Цена: {anonymousProduct.Price:C}");
    }
}