static int[] Сoncatenation(int[] arr1, int[] arr2, int index)
{
    Array.Resize(ref arr1, arr1.Length + arr2.Length);
    // смещаем элементы на длину arr2
    Array.Copy(arr1, index, arr1, index + arr2.Length, arr1.Length - arr2.Length - index);
    // копируем элементы их arr2 в arr1
    Array.Copy(arr2, 0, arr1, index, arr2.Length);
    return arr1;
}

static void UpdateArray(int[] arr)
{
    Random rand = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rand.Next(100);
    }
    foreach (int num in arr)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();
}

Console.Write("Введите размер 1 массива: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите размер 2 массива: ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите позицию вставки элементов: ");
int k = Convert.ToInt32(Console.ReadLine());

int[] array1 = new int[n];
int[] array2 = new int[m];
UpdateArray(array1);
UpdateArray(array2);


if (k < 1)
{
    array1 = Сoncatenation(array1, array2, 0);
}
else if (k > array1.Length)
{
    array1 = Сoncatenation(array1, array2, array1.Length);
}
else
{
    array1 = Сoncatenation(array1, array2, k - 1);
}

foreach (int num in array1)
{
    Console.Write($"{num} ");
}
Console.WriteLine();