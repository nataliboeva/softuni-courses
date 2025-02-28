namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];

            for (int row = 0; row < input[0]; row++)
            {
                int[] value = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = value[col];
                }
            }
            int maxSum = 0;
            int maxRowSum = 0;
            int maxColSum = 0;

            for (int row = 0; row < input[0] - 1; row++)
            {
                for (int col = 0; col < input[1] - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] 
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRowSum = row;
                        maxColSum = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxRowSum, maxColSum]} {matrix[maxRowSum, maxColSum + 1]}");
            Console.WriteLine($"{matrix[maxRowSum + 1, maxColSum]} {matrix[maxRowSum + 1, maxColSum + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
