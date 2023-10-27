var stack = new List<int>();

void push(int n, ref List<int> stack)
{
    stack.Add(n);
    Console.WriteLine("ok");
}

void pop(ref List<int> stack)
{
    Console.WriteLine(stack[stack.Count - 1]);
    stack.RemoveAt(stack.Count - 1);
}

void back(ref List<int> stack)
{
    Console.WriteLine(stack[stack.Count - 1]);
}

void size(ref List<int> stack)
{
    Console.WriteLine(stack.Count);
}

void clear(ref List<int> stack)
{
    stack.Clear();
    Console.WriteLine("ok");
}

while (true)
{
    var command = Console.ReadLine();
    if (command.Contains("push"))
    {
        push(int.Parse(command.Split()[1]), ref stack);
    }
    else
    {
        switch (command)
        {
            case "pop":
                pop(ref stack);
                break;

            case "back":
                back(ref stack);
                break;

            case "size":
                size(ref stack);
                break;

            case "clear":
                clear(ref stack);
                break;

            case "exit":
                Console.WriteLine("Bye");
                return 0;
        }
    }
    
}