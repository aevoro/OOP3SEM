
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;


class Program
{
    static bool abool = true;
    static byte abyte = 12;
    static sbyte asbyte = 13;
    static char achar = 'a';
    static decimal adecimal = -123.112412412m;
    static double adouble = 12.3;
    static float afloat = 1.22f;
    static int aint = 1;
    static uint auint = 2;
    static nint anint = 3;
    static nuint anuint = 4;
    static long along = 5;
    static ulong aulong = 6;
    static short ashort = 7;
    static ushort aushort = 8;



    static void Main()
    {
        // 1a
        /* Console.WriteLine(abool);
         Console.WriteLine(abyte);
         Console.WriteLine(asbyte);
         Console.WriteLine(achar);
         Console.WriteLine(adecimal);
         Console.WriteLine(adouble);
         Console.WriteLine(afloat);
         Console.WriteLine(aint);
         Console.WriteLine(auint);
         Console.WriteLine(anint);
         Console.WriteLine(anuint);
         Console.WriteLine(along);
         Console.WriteLine(aulong);
         Console.WriteLine(ashort);
         Console.WriteLine(aushort);

         abool = Convert.ToBoolean(Console.ReadLine());
         abyte = Convert.ToByte(Console.ReadLine());
         asbyte = Convert.ToSByte(Console.ReadLine());
         achar = Convert.ToChar(Console.ReadLine());
         adecimal = Convert.ToDecimal(Console.ReadLine());
         adouble = Convert.ToDouble(Console.ReadLine());
         afloat = Convert.ToSingle(Console.ReadLine());
         aint = Convert.ToInt32(Console.ReadLine());
         auint = Convert.ToUInt32(Console.ReadLine());
         anint = Convert.ToInt32(Console.ReadLine());
         anuint = Convert.ToUInt32(Console.ReadLine());
         along = Convert.ToInt32(Console.ReadLine());
         aulong = Convert.ToUInt64(Console.ReadLine());
         ashort = Convert.ToInt16(Console.ReadLine());
         aushort = Convert.ToUInt16(Console.ReadLine());
 */

        // 1b

        /* Console.WriteLine("Неявные");
         int b1 = aint + abyte;
         Console.WriteLine($"int+byte: {b1}");
         int b2 = aint + asbyte;
         Console.WriteLine($"int+sbyte: {b2}");
         int b3 = aint + aushort;
         Console.WriteLine($"int+ushort: {b3}");
         int b4 = aint + ashort;
         Console.WriteLine($"int+short: {b4}");
         int b5 = aint + achar;
         Console.WriteLine($"int+char: {b5}");*/

        //1c

        /*object c1 = abool;
        bool cbool = (bool)c1;
        object c2 = abyte;
        byte cbyte = (byte)c2;
        object c3 = asbyte;
        sbyte csbyte = (sbyte)c3;
        object c4 = achar;
        char cchar = (char)c4;
        object c5 = adecimal;
        decimal cdecimal = (decimal)c5;*/

        //1d

        /*var num1 = 10;
        var num2 = 20;
        var num3 = num1 + num2;
        Console.WriteLine($"Сложение неявно выраженных переменных num1+num2:{num3}");*/

        //1e

        /*int? info = null;
        //info = 1;
        if (info.HasValue)
        {
            Console.WriteLine($"Переменная хранит значение: {info}");
        }
        else { Console.WriteLine($"Переменная не хранит значения"); }

        1f

        var typeInt = 5;
        Console.WriteLine($"Переменная хранит: {typeInt}");
        //typeInt = false;*/

        //2a

        /*string str1 = "Привет";
        string str2 = "Пока";
        string str3 = "Привет";
        if (str1 == str2)
        {
            Console.WriteLine("Строки str1 и str2 равны");
        }
        else { Console.WriteLine("Строки str1 и str2 не равны"); }

        if (str1 == str3)
        {
            Console.WriteLine("Строки str1 и str3 равны");
        }
        else { Console.WriteLine("Строки st1 и str3 не равны"); }*/

        //2b

        /* string str3 = "abc edc";
         string str4 = "cde abc";
         string str5 = "abc cde";

         string concat = str3 + str4;
         Console.WriteLine($"Сцепление строк: {concat}");
         string copy = (string)str3.Clone();
         Console.WriteLine($"Копия str3: {copy}");
         string substring = str4.Substring(0, 3);
         Console.WriteLine($"Выделение подстроки str3: {substring}");
         string[] words = str3.Split(' ');
         Console.WriteLine("Разделение строки str3 на слова");
         foreach (var word in words)
         {
             Console.WriteLine(word);
         }
         string insert = str5.Insert(1, "aaa");
         Console.WriteLine($"Вставка подстроки в строку str5: {insert}");
         string delete = str4.Remove(0, 3);
         Console.WriteLine($"Удаление подстроки в str4: {delete}");
         string inter = $"Fff {str3} hjfj {str4} gfh {str5}";
         Console.WriteLine("Интерполяция: " + inter);*/

        //2c

        /*string nulledstring = null;
        string clearstring = "";
        string str = "hello";
        if (string.IsNullOrEmpty(nulledstring))
        {
            Console.WriteLine("Строка либо пустая либо нулевая");
        }
        else Console.WriteLine("Строка что-то содержит");
        if (string.IsNullOrEmpty(clearstring))
        {
            Console.WriteLine("Строка либо пустая либо нулевая");
        }
        else Console.WriteLine("Строка что-то содержит");
        if (string.IsNullOrEmpty(str))
        {
            Console.WriteLine("Строка либо пустая либо нулевая");
        }
        else Console.WriteLine($"Строка содержит {str}");*/

        //2d

        /*StringBuilder sb = new StringBuilder("Hello", 50);
        sb = sb.Remove(1, 3);
        sb.Append(new char[] { 'a', 'b', 'c' });
        sb.Insert(0, 'd');
        Console.WriteLine($"Строка после изменений: {sb}");*/

        //3a

        /*int[,] array = new int[3, 4] {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12}
        };

        Console.WriteLine("Двумерный массив:");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }*/

        //3b

        /*string[] strarr = { "abngfd", "gihsd", "gasjk", "gjsdhgh" };

        foreach (string str in strarr) {
        Console.WriteLine(str);
        }
        Console.WriteLine("Введите изменяемый элемент массива: ");
        int n;
        n = Convert.ToInt32(Console.ReadLine());
        string strrem;
        Console.WriteLine("Введите строку: ");
        strrem = Convert.ToString(Console.ReadLine());
        strarr[n] = strrem;
        Console.WriteLine($"Значение {strarr[n]} изменено на {strrem}");
        Console.WriteLine("Измененный массив: ");
        foreach (string str in strarr)
        {
            Console.WriteLine(str);
        }*/

        //3c

        /*double[][] jaggedArr = new double[3][];
        jaggedArr[0] = new double[2];
        jaggedArr[1] = new double[3];
        jaggedArr[2] = new double[4];

        for (int i = 0; i < jaggedArr.Length; i++)
        {
            Console.WriteLine($"Введите {jaggedArr[i].Length} значения для строки {i + 1}");
            for (int j = 0; j < jaggedArr[i].Length; j++)
            {
                Console.Write($"Элемент: {jaggedArr[i][j]} = ");
                while (!double.TryParse(Console.ReadLine(), out jaggedArr[i][j]))
                {
                    Console.Write($"Элемент {jaggedArr[i][j]}: ");
                }
            }
        }

        Console.WriteLine("Массив: ");
        for (int i = 0; i < jaggedArr[i].Length; i++)
        {
            Console.WriteLine($"Строка {i + 1}: ");
            for (int j = 0; j < jaggedArr[i].Length; j++)
            {
                Console.Write($"{jaggedArr[i][j]} ");
            }
            Console.WriteLine();
        }*/

        //3d

        /*var arrVar = new[] { 1, 2, 3 };
        var strVar = "Hello";

        Console.WriteLine(strVar);
        foreach (var item in arrVar) {
        Console.Write($"{item} ");
        }*/

        //4

        /*(int, string, char, string, ulong) a4 = (1, "Hello", 'A', "World", 1247891);

        Console.WriteLine("Вывод всего кортежа: ");
        Console.WriteLine(a4);

        Console.WriteLine("Вывод отдельных элементов кортежа: ");
        Console.WriteLine(a4.Item1);
        Console.WriteLine(a4.Item3);
        Console.WriteLine(a4.Item4);

        Console.WriteLine("Распоковка(1-й способ): ");
        var(int4a, string4a, char4a, string4a2,ulong4a) = a4;
        Console.WriteLine(int4a);
        Console.WriteLine(string4a);
        Console.WriteLine(char4a);
        Console.WriteLine(string4a2);
        Console.WriteLine(ulong4a);
        Console.WriteLine("Распоковка(2-й способ): ");

        (int, string, char, string, ulong) a4b = (2, "Good", 'B', "Bye", 41826);
        (int int4ab, string string4ab, char char4ab, string string4a2b,ulong ulong4ab) = a4b;
        Console.WriteLine(int4ab);
        Console.WriteLine(string4ab);
        Console.WriteLine(char4ab);
        Console.WriteLine(string4a2b);
        Console.WriteLine(ulong4ab);

        Console.WriteLine("Игнорирование перменной: ");
        (int, string, char, string, ulong) c4 = (1, "Hello", 'A', "World", 1247891);
        var (intc, stringc,_, _,_) = c4;
        Console.WriteLine(intc);
        Console.WriteLine(stringc);

        Console.WriteLine("Сравнение кортежей: ");
        Console.WriteLine($"Сравнение кортежей a4 и c4: {a4==c4}");
        Console.WriteLine($"Сравнение кортежей a4 и a4b: {a4==a4b}");
        */

        //5

        /*void zad5(int[] a, string str)
        {
            int max = a.Max();
            int min = a.Min();
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }

            char symbol;
            symbol = str.Length > 0 ? str[0] : '\0';

            var tuple = (max, min, sum, symbol);
            Console.WriteLine(tuple);
        }

        Console.WriteLine("Выхов функции с возвращением кортежа: ");
        int[] arr = { 1, 2, 3, 5, 4 };
        string str = "Hello";
        zad5(arr, str);*/

        //6

        /*Console.WriteLine("Работа с checked/unchecked ");

        uint a = uint.MaxValue;
        
        CheckedFunction();
        UncheckedFunction();


        static void UncheckedFunction()
        {
            uint a = uint.MaxValue;
            Console.WriteLine("checked блок");
            Console.WriteLine(a + 3);
        }

        static void CheckedFunction()
        {
            uint a = uint.MaxValue;
            Console.WriteLine("unchecked блок");
            try
            {
                checked
                {
                    Console.WriteLine(a + 2);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);  
            }

        }*/
    }
}