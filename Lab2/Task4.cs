public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Previous { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

public class Deque<T>
{
    private Node<T> start;
    private Node<T> end;

    public void pushStart(T item)
    {
        var newNode = new Node<T>(item);
        if (isEmpty)
        {
            start = end = newNode;
        }
        else
        {
            newNode.Next = start;
            start.Previous = newNode;
            start = newNode;
        }
    }

    public void pushEnd(T item)
    {
        var newNode = new Node<T>(item);
        if (isEmpty)
        {
            start = end = newNode;
        }
        else
        {
            newNode.Previous = end;
            end.Next = newNode;
            end = newNode;
        }
    }

    public List<int> find(T item)
    {
        var result = new List<int>();
        Node<T> current = start;
        int position = 1;

        while (current != null)
        {
            if (Equals(current.Data, item))
            {
                result.Add(position);
            }
            current = current.Next;
            position++;
        }

        return result;
    }

    public void pop(T item)
    {
        if (isEmpty)
        {
            Console.WriteLine("Дек пуст");
        }
        else
        {
            Node<T> current = start;

            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    if (current == start)
                    {
                        start = current.Next;
                        if (start != null)
                        {
                            start.Previous = null;
                        }
                    }
                    else if (current == end)
                    {
                        end = current.Previous;
                        if (end != null)
                        {
                            end.Next = null;
                        }
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                }
                current = current.Next;
            }
        }
    }

    public void popStart()
    {
        if (isEmpty)
        {
            Console.WriteLine("Дек пуст");
        }
        else
        {
            start = start.Next;
            if (start != null)
            {
                start.Previous = null;
            }
        }
    }

    public void popEnd()
    {
        if (isEmpty)
        {
            Console.WriteLine("Дек пуст");
        }
        else
        {
            end = end.Previous;
            if (end != null)
            {
                end.Next = null;
            }
        }
        
    }

    public void print()
    {
        Node<T> current = start;

        while (current != null)
        {
            Console.Write($"{current.Data} ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public bool isEmpty => start == null;
}

class Program
{
    static void Main()
    {
        Deque<int> deque = new Deque<int>();

        while (true)
        {
            var command = Console.ReadLine();
            if (command.Contains("pushs"))
            {
                deque.pushStart(int.Parse(command.Split()[1]));
            }
            else if (command.Contains("pushe"))
            {
                deque.pushEnd(int.Parse(command.Split()[1]));
            }
            else if (command.Contains("popi"))
            {
                deque.pop(int.Parse(command.Split()[1]));
            }
            else if (command.Contains("find"))
            {
                Console.WriteLine($"Номера позиций: {string.Join(", ", deque.find(int.Parse(command.Split()[1])))}");
            }
            else
            {
                switch (command)
                {
                    case "pops":
                        deque.popStart();
                        break;

                    case "pope":
                        deque.popEnd();
                        break;

                    case "print":
                        deque.print();
                        break;

                    case "exit":
                        Console.WriteLine("Bye");
                        return;
                }
            }

        }
    }
}

