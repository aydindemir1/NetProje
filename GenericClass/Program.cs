using System;

// Generic Stack sınıfı tanımı
public class Stack<T>
{
    private T[] items;
    private int top;

    public Stack(int size)
    {
        items = new T[size];
        top = -1;
    }

    public void Push(T item)
    {
        if (top == items.Length - 1)
        {
            throw new StackOverflowException("Stack is full");
        }
        items[++top] = item;
    }

    public T Pop()
    {
        if (top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return items[top--];
    }

    public int Count
    {
        get { return top + 1; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Stack<int> türünde bir nesne oluşturma
        Stack<int> intStack = new Stack<int>(5);

        // Stack'e değerler eklemek
        intStack.Push(10);
        intStack.Push(20);
        intStack.Push(30);

        // Stack'ten değerler çıkarmak ve yazdırmak
        Console.WriteLine("Popped item: " + intStack.Pop());
        Console.WriteLine("Popped item: " + intStack.Pop());

        // Stack<string> türünde bir nesne oluşturma
        Stack<string> stringStack = new Stack<string>(3);

        // Stack'e değerler eklemek
        stringStack.Push("Hello");
        stringStack.Push("World");

        // Stack'ten değerler çıkarmak ve yazdırmak
        Console.WriteLine("Popped item: " + stringStack.Pop());
    }
}
