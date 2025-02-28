namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] value = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value[col];
                }
            }

            while(true)
            {
                string[] token = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = token[0];
                if(command == "END")
                {
                    return;
                }

                if(command == "swap" && token.Length == 5)
                {
                    int row1 = int.Parse(token[1]);
                    int col1 = int.Parse(token[2]);
                    int row2 = int.Parse(token[3]);
                    int col2 = int.Parse(token[4]);

                    if (IsInside(matrix, row1, col1) && IsInside(matrix, row2, col2))
                    {
                        string temporary = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temporary;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row,col] + " ");
                            }
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static bool IsInside(string[,] matrix, int row1, int col1)
        {
            return row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1);
        }
    }
}
