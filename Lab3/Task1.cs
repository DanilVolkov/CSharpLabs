void MinRowArray(in double[][] row, in int numberRow, out double result)
{
    result = double.PositiveInfinity;
    foreach(double el in row[numberRow - 1])
    {
        result = Math.Min(el, result);
    }
}

void MaxRowArray(in double[][] row, in int numberRow, out double result)
{
    result = double.NegativeInfinity;
    foreach (double el in row[numberRow - 1])
    {
        result = Math.Max(el, result);
    }
}

void SumRowArray(in double[][] row, in int numberRow, out double result)
{
    result = 0;
    foreach (double el in row[numberRow - 1])
    {
        result += el;
    }

    result = Math.Round(result, 3);
}



Console.Write("Введите количество строк в массиве: ");
int n = Convert.ToInt32(Console.ReadLine());

double[][] arr = new double[n][];

for (int i = 0; i < n; i++)
{
    var items = Console.ReadLine().Split()
    .Where(item => !string.IsNullOrWhiteSpace(item))
    .Select(item => Double.TryParse(item.Trim().Replace(".", ","), out _) ?
        Convert.ToDouble(item.Trim().Replace(".", ",")) : 0.0).ToArray();

    arr[i] = items;

}

foreach (var item in arr)
{
    foreach (object el in item)
    {
        Console.Write($"{el} ");
    }
    Console.WriteLine();
}

double min, max, sum;
for (int i = 0; i < arr.Length; i++)
{
    MinRowArray(arr, i + 1, out min);
    MaxRowArray(arr, i + 1, out max);
    SumRowArray(arr, i + 1, out sum);

    Console.WriteLine($"min: {min}, max: {max}, sum: {sum}");

}







