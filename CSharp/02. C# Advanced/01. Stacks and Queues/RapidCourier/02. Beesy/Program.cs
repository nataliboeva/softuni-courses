namespace _02._Beesy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] field = new char[size][];

            for (int i = 0; i < size; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }
            int row = 0;
            int col = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field[i][j] == 'B')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            int energy = 15;
            int nectarCollected = 0;
            bool energyRestored = false;

            string command;
            while ((command = Console.ReadLine()) != null)
            {
                field[row][col] = '-';
                switch (command)
                {
                    case "up":
                        row = (row - 1 + size) % size;
                        break;
                    case "down":
                        row = (row + 1) % size;
                        break;
                    case "left":
                        col = (col - 1 + size) % size;
                        break;
                    case "right":
                        col = (col + 1) % size;
                        break;
                }

                energy--;

                if (char.IsDigit(field[row][col]))
                {
                    nectarCollected += field[row][col] - '0';
                }

                if (field[row][col] == 'H')
                {
                    if (nectarCollected >= 30)
                    {
                        Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
                    }
                    else
                    {
                        Console.WriteLine("Beesy did not manage to collect enough nectar.");
                    }
                    field[row][col] = 'B';
                    break;
                }
                if (energy == 0)
                {
                    if (nectarCollected >= 30 && !energyRestored)
                    {
                        energy = nectarCollected - 30;
                        nectarCollected = 30;
                        energyRestored = true;
                    }
                    else
                    {
                        Console.WriteLine("This is the end! Beesy ran out of energy.");
                        field[row][col] = 'B';
                        break;
                    }
                }
                field[row][col] = 'B';
            }
            Print(field);
        }
        static void Print(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
