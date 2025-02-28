namespace _01._Sum_Matrix_Elements
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

            int sum = 0;

            foreach (int value in matrix)
            {
                sum += value;
            }
            Console.WriteLine(input[0]);
            Console.WriteLine(input[1]);
            Console.WriteLine(sum);
        }
    }
}
