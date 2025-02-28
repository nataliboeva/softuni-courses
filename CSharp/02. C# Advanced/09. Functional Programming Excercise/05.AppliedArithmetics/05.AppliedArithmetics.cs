using System.Threading.Channels;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers =
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            
            Func<int[], int[]> add = numbers
               => numbers.Select(x => x + 1).ToArray();

            Func<int[], int[]> subtract = numbers
                => numbers.Select(x => x - 1).ToArray();

            Func<int[], int[]> multiply = numbers
                => numbers.Select(x => x * 1).ToArray();
            while (command != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    numbers = command == "add"
                        ? add(numbers)
                        : command == "multiply"
                            ? multiply(numbers)
                            : subtract(numbers);
                }
                command = Console.ReadLine();
            }
        }
    }
}
