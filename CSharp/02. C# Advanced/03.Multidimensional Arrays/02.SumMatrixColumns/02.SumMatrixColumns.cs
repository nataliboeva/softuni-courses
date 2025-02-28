namespace _02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];

            for (int row = 0; row < input[0]; row++)
            {
                int[] value = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = value[col];
                }
            }

            for (int col = 0; col < input[1]; col++)
            {
                int sum = 0;
                for (int row = 0; row < input[0]; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
