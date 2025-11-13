using System;
using System.Collections.Generic;

interface ICloneableDocument
{
    bool DoClone();
}

abstract class BaseDocument
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public Organization Organization { get; set; }

    public abstract bool DoClone();
    public abstract override string ToString();
    
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Документ №{Number} от {Date.ToShortDateString()}");
    }
}

class Date
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public Date(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Day:00}.{Month:00}.{Year}";
    }
}

class Organization
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string INN { get; set; }

    public Organization(string name, string address, string inn)
    {
        Name = name;
        Address = address;
        INN = inn;
    }

    public override string ToString()
    {
        return $"{Name} (ИНН: {INN}), адрес: {Address}";
    }
}

class Document : BaseDocument, ICloneableDocument
{
    public string Type { get; set; }
    public decimal Amount { get; set; }

    public Document(string number, DateTime date, Organization organization, string type, decimal amount)
    {
        Number = number;
        Date = date;
        Organization = organization;
        Type = type;
        Amount = amount;
    }

    public override bool DoClone()
    {
        Console.WriteLine("Абстрактный метод DoClone: Создана копия документа");
        return true;
    }

    bool ICloneableDocument.DoClone()
    {
        Console.WriteLine("Интерфейсный метод DoClone: Документ клонирован через интерфейс");
        return false;
    }

    public override string ToString()
    {
        return $"Документ [№{Number}, {Date.ToShortDateString()}, {Type}, Сумма: {Amount:C}, Организация: {Organization.Name}]";
    }

    public override bool Equals(object obj)
    {
        if (obj is Document other)
        {
            return Number == other.Number && Date == other.Date;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Number, Date);
    }
}

class Receipt : Document
{
    public string Payer { get; set; }
    public string PaymentPurpose { get; set; }

    public Receipt(string number, DateTime date, Organization organization, decimal amount, string payer, string paymentPurpose)
        : base(number, date, organization, "Квитанция", amount)
    {
        Payer = payer;
        PaymentPurpose = paymentPurpose;
    }

    public override string ToString()
    {
        return $"Квитанция [№{Number}, {Date.ToShortDateString()}, Плательщик: {Payer}, Назначение: {PaymentPurpose}, Сумма: {Amount:C}]";
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Квитанция №{Number} - {PaymentPurpose}");
    }
}

class Invoice : Document
{
    public string Product { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; }

    public Invoice(string number, DateTime date, Organization organization, decimal amount, string product, int quantity, string unit)
        : base(number, date, organization, "Накладная", amount)
    {
        Product = product;
        Quantity = quantity;
        Unit = unit;
    }

    public override string ToString()
    {
        return $"Накладная [№{Number}, {Date.ToShortDateString()}, Товар: {Product}, Количество: {Quantity} {Unit}, Сумма: {Amount:C}]";
    }
}

sealed class Check : Document
{
    public string Cashier { get; set; }
    public int CheckNumber { get; set; }

    public Check(string number, DateTime date, Organization organization, decimal amount, string cashier, int checkNumber)
        : base(number, date, organization, "Чек", amount)
    {
        Cashier = cashier;
        CheckNumber = checkNumber;
    }

    public override string ToString()
    {
        return $"Чек [№{Number}, {Date.ToShortDateString()}, Кассир: {Cashier}, Номер чека: {CheckNumber}, Сумма: {Amount:C}]";
    }
}

class Printer
{
    public void IAmPrinting(BaseDocument doc)
    {
        if (doc is Receipt receipt)
        {
            Console.WriteLine($"Печать квитанции: {receipt}");
        }
        else if (doc is Invoice invoice)
        {
            Console.WriteLine($"Печать накладной: {invoice}");
        }
        else if (doc is Check check)
        {
            Console.WriteLine($"Печать чека: {check}");
        }
        else if (doc is Document document)
        {
            Console.WriteLine($"Печать документа: {document}");
        }
        else
        {
            Console.WriteLine($"Печать неизвестного документа: {doc}");
        }
    }
}

class Program
{
    static void Main()
    {
        Organization org1 = new Organization("ООО БББ", "г. Минск, ул. ААА, 1", "1234567890");
        Organization org2 = new Organization("ИП ААА", "г. Москва, ул. БББ, 1", "0987654321");

        Document doc1 = new Document("DOC-001", new DateTime(2024, 1, 15), org1, "ААА", 15000.50m);
        Receipt receipt1 = new Receipt("REC-001", new DateTime(2024, 1, 16), org2, 5000.75m, "Петров П.П.", "Оплата услуг");
        Invoice invoice1 = new Invoice("INV-001", new DateTime(2024, 1, 17), org1, 25000.00m, "Ноутбук", 2, "шт.");
        Check check1 = new Check("CHK-001", new DateTime(2024, 1, 18), org2, 1500.25m, "Петров П.П.", 12345);

        BaseDocument[] documents = { doc1, receipt1, invoice1, check1 };
        
        Console.WriteLine("=== Работа через ссылки на абстрактный класс ===");
        foreach (var doc in documents)
        {
            if (doc is Receipt receipt)
            {
                Console.WriteLine($"Это квитанция: {receipt.Payer}");
            }
            else if (doc is Invoice invoice)
            {
                Console.WriteLine($"Это накладная: {invoice.Product}");
            }
            else if (doc is Check)
            {
                Console.WriteLine("Это чек (sealed класс)");
            }
            
            doc.PrintInfo();
            Console.WriteLine(doc.ToString());
            Console.WriteLine();
        }

        Console.WriteLine("Одноименные методы");
        Document testDoc = new Document("TEST-001", DateTime.Now, org1, "Тестовый", 1000m);
        
        testDoc.DoClone();
        
        ICloneableDocument cloneable = testDoc;
        cloneable.DoClone();
        Console.WriteLine();

        Console.WriteLine("Работа класса Printer");
        Printer printer = new Printer();
        
        foreach (var doc in documents)
        {
            printer.IAmPrinting(doc);
        }
        Console.WriteLine();

        Console.WriteLine("Дополнительная демонстрация");
        
        ICloneableDocument[] cloneableDocs = { doc1, receipt1, invoice1, check1 };
        foreach (var cloneDoc in cloneableDocs)
        {
            if (cloneDoc is Document concreteDoc)
            {
                Console.WriteLine($"Документ №{concreteDoc.Number} готов к клонированию");
            }
        }

        Console.WriteLine("\nПроверка переопределения методов Object");
        Document doc2 = new Document("DOC-001", new DateTime(2024, 1, 15), org1, "ААА", 15000.50m);
        Console.WriteLine($"doc1.Equals(doc2): {doc1.Equals(doc2)}");
        Console.WriteLine($"HashCode doc1: {doc1.GetHashCode()}");
        Console.WriteLine($"HashCode doc2: {doc2.GetHashCode()}");

        Console.WriteLine("\nSealed класс Check");
        Check check2 = new Check("CHK-002", DateTime.Now, org1, 2000m, "Иванов И.И.", 54321);
        Console.WriteLine(check2.ToString());
    }
}