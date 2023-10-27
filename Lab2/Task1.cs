
namespace Lab2
{
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

    public class MyStack<T>
    {
        private Node<T> top;

        public void push(T item)
        {
            var newNode = new Node<T>(item);
            newNode.Next = top;
            top = newNode;
            Console.WriteLine("ok");
        }

        public void pop()
        {
            T data = top.Data;
            top = top.Next;
            Console.WriteLine(data);
        }

        public void back()
        {
            Console.WriteLine(top.Data);
        }

        public void size()
        {

            int count = 0;
            Node<T> current = top;
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
            top = null;
        }
    }

    class Program
    {
        static void Main()
        {
            MyStack<int> stack = new MyStack<int>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command.Contains("push"))
                {
                    stack.push(int.Parse(command.Split()[1]));
                }
                else
                {
                    switch (command)
                    {
                        case "pop":
                            stack.pop();
                            break;

                        case "back":
                            stack.back();
                            break;

                        case "size":
                            stack.size();
                            break;

                        case "clear":
                            stack.clear();
                            break;

                        case "exit":
                            Console.WriteLine("Bye");
                            return;
                    }
                }

            }
        }
    }
}

