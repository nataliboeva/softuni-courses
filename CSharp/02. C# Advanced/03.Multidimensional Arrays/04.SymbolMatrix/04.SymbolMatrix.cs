namespace _04.SymbolMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                char[] asci = input.ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = asci[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
