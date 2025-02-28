namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] value = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = value[col][0];
                }
            }
            int count = 0;
            for (int row = 0; row < input[0] - 1; row++)
            {
                for (int col = 0; col < input[1] - 1; col++)
                {
                    
                    if (matrix[row, col] == matrix[row + 1, col] 
                        && matrix[row, col + 1] == matrix[row + 1, col + 1]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
