static void PrintArray(int[] arr)
{

    foreach (int num in arr)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();
}

Console.Write("Введите размер массива: ");
int n = Convert.ToInt32(Console.ReadLine());
int[] array = new int[n];

Random rand = new Random();
for (int i = 0; i < n; i++)
{
    array[i] = rand.Next(100);
}

PrintArray(array);
for (int i = 0; i < array.Length / 2; i++)
{
    (array[i], array[array.Length / 2 + i + (array.Length % 2)]) = (array[array.Length / 2 + i + (array.Length % 2)], array[i]);
}
PrintArray(array);