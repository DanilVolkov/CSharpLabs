static void PrintArray(int[] arr)
{
    foreach (int num in arr)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();
}

static void RandomFill(int[] arr)
{
    Random rand = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rand.Next(100);
    }
}

static int[] CombineArray(int[] arr1, int[] arr2)
{
    if (arr1.Length != arr2.Length)
    {
        Console.WriteLine("Массивы должны быть одинаковой длины!");
        return new int[0];
    }
    return arr1.Zip(arr2, (el1, el2) => el1 + el2).ToArray();
}

static void MultiplyArray(int[] arr, int num)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] *= num;
    }
}

static int[] IntersectArray(int[] arr1, int[] arr2)
{
    if ((arr1.Length < 1) || (arr2.Length < 1))
    {
        Console.WriteLine("Один или оба массивы пустые!");
        return new int[0];
    }
    return arr1.Intersect(arr2).ToArray();
}

static void SortArray(int[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] < arr[j])
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
    }
}

static int MaxArray(int[] arr)
{
    if (arr.Length < 1)
    {
        Console.WriteLine("Массив пустой!");
        return 0;
    }
    int[] arrCopy = (int[])arr.Clone();
    SortArray(arrCopy);
    return arrCopy[0];
}

static int MinArray(int[] arr)
{
    if (arr.Length < 1)
    {
        Console.WriteLine("Массив пустой!");
        return 0;
    }
    int[] arrCopy = (int[])arr.Clone();
    SortArray(arrCopy);
    return arrCopy[arrCopy.Length - 1];

}


Console.Write("Введите размер массива: ");
int n = Convert.ToInt32(Console.ReadLine());
int[] array = new int[n];
int[] array2 = new int[3] { 1, 2, 3 };

RandomFill(array);
Console.Write("Массив после заполнения случайными числами: ");
PrintArray(array);

Console.Write("Сложили 2 массива: ");
PrintArray(CombineArray(array, array2));

Console.Write("Умножили массив на число: ");
MultiplyArray(array, 2);
PrintArray(array);

Console.Write("Общие элементы массивов: ");
array[0] = 1;
array[1] = 3;
PrintArray(IntersectArray(array, array2));

Console.WriteLine($"Минимальный элемент массива: {MinArray(array)}");

Console.WriteLine($"Максимальный элемент массива: {MaxArray(array)}");

Console.Write("Массив до сортировки: ");
PrintArray(array);

Console.Write("Отсортировали массив по убыванию: ");
SortArray(array);
PrintArray(array);