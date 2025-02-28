namespace _06.JaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] value = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jaggedArray[row] = value;
            }
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
            while(true)
            {
                string[] token = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = token[0];
                if (action == "End")
                {
                    for (int row = 0; row < jaggedArray.Length; row++)
                    {
                        Console.WriteLine(string.Join(" ", jaggedArray[row]));
                        
                    }
                    return;
                }
                else if(action == "Add")
                {
                    int row = int.Parse(token[1]);
                    int column = int.Parse(token[2]);
                    int value = int.Parse(token[3]);
                    if (row >= 0 && row < jaggedArray.Length && column >= 0 && column < jaggedArray[row].Length)
                    {
                        jaggedArray[row][column] += value;
                    } 
                }
                else if(action == "Subtract")
                {
                    int row = int.Parse(token[1]);
                    int column = int.Parse(token[2]);
                    int value = int.Parse(token[3]);
                    if (row >= 0 && row < jaggedArray.Length && column >= 0 && column < jaggedArray[row].Length)
                    {
                        jaggedArray[row][column] -= value;
                    }
                }
            }
        }
    }
}
