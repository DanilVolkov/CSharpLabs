int size = 1000;
int print_size = 10;

int[] m1 = new int[size * size];
int[] m2 = new int[size * size];
int[] res = new int[size * size];

Random rand = new Random();
for (int i = 0; i < size * size; i++)
{
    m1[i] = rand.Next(10);
    m2[i] = rand.Next(10);
}

for (int i = 0; i < print_size; i++)
{
    for (int j = 0; j < print_size; j++)
    {
        Console.Write($"{m1[i * size + j]} ");
    }
    Console.WriteLine();
}

Console.WriteLine("*");

for (int i = 0; i < print_size; i++)
{
    for (int j = 0; j < print_size; j++)
    {
        Console.Write($"{m2[i * size + j]} ");
    }
    Console.WriteLine();
}

Console.WriteLine("----------");

Parallel.For(0, size, i =>
{
    for (int j = 0; j < size; j++)
    {
        for (int k = 0; k < size; k++)
        {
            res[i * size + j] += m1[i * size + k] * m2[k * size + j];
        }
    }
});


for (int i = 0; i < print_size; i++)
{
    for (int j = 0; j < print_size; j++)
    {
        Console.Write($"{res[i * size + j]} ");
    }
    Console.WriteLine();
}