namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] diagonal = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] value = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    diagonal[row, col] = value[col];
                }
            }

            int primarySum = 0;
            for (int i = 0; i < size; i++)
            {
                primarySum += diagonal[i, i];
            }
            int secondarySum = 0;
            int colDiag = diagonal.GetLength(1) - 1;
            for (int i = 0; i < size; i++)
            {
                secondarySum += diagonal[i, colDiag--];
            }
            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
