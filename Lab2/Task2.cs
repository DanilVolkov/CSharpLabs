public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class Queue<T>
{
    private Node<T> start; // начало
    private Node<T> end; // конец

    public void push(T item)
    {
        var newNode = new Node<T>(item);
        if (end == null)
        {
            start = end = newNode;
        }
        else
        {
            end.Next = newNode;
            end = newNode;
        }
        Console.WriteLine("ok");
    }

    public bool isEmpty
    {
        get
        {
            return start == null;
        }
    }

    public void pop()
    {
        if (isEmpty)
        {
            Console.WriteLine("error");
        }
        else
        {
            T data = start.Data;
            start = start.Next;

            Console.WriteLine(data);

            if (start == null)
            {
                end = null;
            }
        }
    }

    public void front()
    {
        if (isEmpty)
        {
            Console.WriteLine("error");
        }
        else
        {
            Console.WriteLine(start.Data);
        }
    }

    public void size()
    {

        int count = 0;
        Node<T> current = start;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        Console.WriteLine(count);
    }

    public void clear()
    {
        Console.WriteLine("ok");
        start = end = null;
    }
}

class Program
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();

        while (true)
        {
            var command = Console.ReadLine();
            if (command.Contains("push"))
            {
                queue.push(int.Parse(command.Split()[1]));
            }
            else
            {
                switch (command)
                {
                    case "pop":
                        queue.pop();
                        break;

                    case "front":
                        queue.front();
                        break;

                    case "size":
                        queue.size();
                        break;

                    case "clear":
                        queue.clear();
                        break;

                    case "exit":
                        Console.WriteLine("Bye");
                        return;
                }
            }

        }
    }
}




