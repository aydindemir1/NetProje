using System;
using System.Collections.Generic;

 //C# readonly List types:
 //1. ReadOnlyCollection<T>
 //2. ReadOnlyDictionary<TKey, TValue>
 //3. ReadOnlyCollection<T>

public class MyClass
{
    // readonly bir List tanımlanıyor
    private readonly List<int> readOnlyList;

    // Sınıfın yapıcı metodu
    public MyClass()
    {
        // readOnlyList'e başlangıç değeri atanıyor
        readOnlyList = new List<int>() { 1, 2, 3, 4, 5 };
    }

    // readOnlyList'i dışarıya açık bir şekilde okuma
    public List<int> ReadOnlyList => readOnlyList;
}

class Program
{
    static void Main(string[] args)
    {
        // MyClass sınıfından bir örnek oluşturuluyor
        MyClass myObject = new MyClass();

        // readOnlyList'e erişim
        foreach (var item in myObject.ReadOnlyList)
        {
            Console.WriteLine(item);
        }
    }
}

