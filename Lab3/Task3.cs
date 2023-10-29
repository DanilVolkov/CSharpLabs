class IntArray
{
    private int[] array;

    public IntArray(in int size)
    {
        array = new int[size];
    }

    public void InputData()
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"Введите элемент {i}: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                array[i] = value;
            }
            else
            {
                Console.WriteLine("Некорректный ввод, введите целое число.");
                i--;
            }
        }
    }

    public void InputDataRandom()
    {
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 101);
        }
    }

    public void Print(in int startIndex, in int endIndex)
    {
        if (startIndex < 0 || endIndex >= array.Length || startIndex > endIndex)
        {
            Console.WriteLine("Некорректные границы индексов.");
            return;
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
    }

    public List<int> FindValue(int value)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                indexes.Add(i);
            }
        }
        return indexes;
    }

    public void DelValue(int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                // Помечаем удаляемый элемент
                array[i] = int.MinValue;
            }
        }

        // Создаем новый массив без помеченных элементов
        int[] newArray = new int[array.Length - FindValue(int.MinValue).Count];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != int.MinValue)
            {
                newArray[index] = array[i];
                index++;
            }
        }

        array = newArray;
    }

    public int FindMax()
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    public void Add(in IntArray otherArray)
    {
        if (array.Length != otherArray.array.Length)
        {
            Console.WriteLine("Массивы должны иметь одинаковую длину.");
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            array[i] += otherArray.array[i];
        }
    }

    public void Sort()
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var arr = new IntArray(5);
        var arr2 = new IntArray(5);
        arr.InputData();
        arr.Print(0, 4);
        var indexes = arr.FindValue(3);
        foreach(var index in indexes)
        {
            Console.Write($"{index} ");
        }
        Console.WriteLine();
        Console.WriteLine($"Максимальное значение: {arr.FindMax()}");
        arr2.InputData();
        arr.Add(arr2);
        arr.Print(0, 4);
        arr.Sort();
        arr.Print(0, 4);
        arr.DelValue(3);
        arr.Print(0, 2);
        arr.InputDataRandom();
        arr.Print(0, 2);
    }
}