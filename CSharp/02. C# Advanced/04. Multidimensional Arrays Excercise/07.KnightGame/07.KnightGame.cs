
namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sideOfBoard = int.Parse(Console.ReadLine());
            char[,] board = new char[sideOfBoard, sideOfBoard];

            for (int row = 0; row < sideOfBoard; row++)
            {
                char[] value = Console.ReadLine().ToCharArray();
                for (int col = 0; col < sideOfBoard; col++)
                {
                    board[row, col] = value[col];
                }
            }
            int removedKnights = 0;
            while (true)
            {
                int maxAttacks = 0;
                int knightRow = 0;
                int knightCol = 0;
                for (int row = 0; row < sideOfBoard; row++)
                {
                    for (int col = 0; col < sideOfBoard; col++)
                    {
                        int currentAttacks = 0;
                        if (board[row, col] != 'K')
                        {
                            continue;
                        }
                        if (isInside(board, row - 2, col - 1)
                            && board[row - 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (isInside(board, row - 2, col + 1)
                            && board[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (isInside(board, row + 2, col - 1)
                            && board[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (isInside(board, row + 2, col + 1)
                            && board[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (isInside(board, row - 1, col + 2)
                            && board[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (isInside(board, row + 1, col + 2)
                            && board[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (isInside(board, row - 1, col - 2)
                            && board[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (isInside(board, row + 1, col - 2)
                            && board[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if(currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
                if(maxAttacks > 0)
                {
                    board[knightRow, knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removedKnights);
        }

        public static bool isInside(char[,] board, int row, int column)
        {
            return row >= 0 && row < board.GetLength(0)
                && column >= 0 && column < board.GetLength(1);
        }
    }
}
