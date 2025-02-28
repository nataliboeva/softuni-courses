using System.Runtime.CompilerServices;

namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(input);
            Queue<int> even = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] % 2 == 1)
                {
                    queue.Dequeue();
                }
                else
                {
                    even.Enqueue(input[i]);
                }
            }
            Console.WriteLine(string.Join(", ", even));
        }
    }
}
