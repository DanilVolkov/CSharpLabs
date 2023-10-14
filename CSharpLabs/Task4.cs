int[] line = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));
int n = line[0];
int m = line[1];
byte[,] hall = new byte[n, m];

// заполняем массив значениями
for (int i = 0; i < n; i++)
{
    line = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));
    for (int j = 0; j < m; j++)
    {
        hall[i, j] = Convert.ToByte(line[j]);
    }
}
int k = Convert.ToInt32(Console.ReadLine());
int row = -1;
bool end = false;

for (int i = 0; i < n; i++)
{
    if (end)
    {
        break;
    }
    int place = 0;
    for (int j = 0; j < m; j++)
    {
        if (hall[i, j] == 1)
        {
            if (place != 0)
            {
                place--;
            }
        }
        else
        {
            place++;
        }

        if (place == k)
        {
            end = true;
            row = i;
            break;
        }
    }
}

Console.WriteLine($"{row + 1}");