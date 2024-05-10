using System;
using System.Collections.Immutable;

// C# immutable List types:
   //1.ImmutableList < T >
   //2.ImmutableStack < T >
   //3.ImmutableQueue < T >
   //4. ImmutableDictionary<TKey, TValue>
class Program
{
    static void Main(string[] args)
    {
        // Immutable koleksiyon oluşturmak
        ImmutableList<int> immutableList = ImmutableList.Create<int>(1, 2, 3, 4, 5);

        // Immutable koleksiyona erişim
        Console.WriteLine("Immutable List:");
        foreach (var item in immutableList)
        {
            Console.WriteLine(item);
        }

        // Immutable koleksiyona eleman eklemek
        ImmutableList<int> newImmutableList = immutableList.Add(6);

        // Eklenmiş elemanlarla birlikte orijinal koleksiyonu yazdırma
        Console.WriteLine("\nUpdated Immutable List:");
        foreach (var item in newImmutableList)
        {
            Console.WriteLine(item);
        }

        // Orijinal koleksiyonun değişmediğini doğrulama
        Console.WriteLine("\nOriginal Immutable List:");
        foreach (var item in immutableList)
        {
            Console.WriteLine(item);
        }


        ImmutableStack<int> immutableStack = ImmutableStack<int>.Empty;
        immutableStack = immutableStack.Push(1);
        immutableStack = immutableStack.Push(2);

        Console.WriteLine("\nOriginal Immutable Stack:");
        foreach (var item in immutableStack)
        {
            Console.WriteLine(item);
        }

        ImmutableQueue<int> immutableQueue = ImmutableQueue<int>.Empty;
        immutableQueue = immutableQueue.Enqueue(1);
        immutableQueue = immutableQueue.Enqueue(2);

        Console.WriteLine("\nOriginal Immutable Queue:");
        foreach (var item in immutableQueue)
        {
            Console.WriteLine(item);
        }


        ImmutableDictionary<string, int> immutableDictionary = ImmutableDictionary<string, int>.Empty;
        immutableDictionary = immutableDictionary.Add("one", 1);
        immutableDictionary = immutableDictionary.Add("two", 2);

        Console.WriteLine("\nOriginal Immutable Dictionary:");
        foreach (var item in immutableDictionary)
        {
            Console.WriteLine(item);
        }





    }
}

