Console.Write("Введите текст: ");
var text = Console.ReadLine();

var count = 0;
var index = 0;
var result = true;

for (int i = 0; i < text.Length; i++)
{
    if (text[i] == '(')
    {
        count++;
    }
    else if (text[i] == ')')
    {
        if (count > 0)
        {
            count--;
        }
        else
        {
            if (result)
            {
                index = i + 1;
            }
            result = false;
        }
    }
}


if (!result)
{
    Console.WriteLine("Нет");
    Console.WriteLine($"Позиция 1 закрывающей скобки: {index}");
}
else if (count > 0)
{
    Console.WriteLine("Нет");
    Console.WriteLine($"Количество открывающих скобок: {count}");
}
else
{
    Console.WriteLine("Да");
}