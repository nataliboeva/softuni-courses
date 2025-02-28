namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int passes = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(input);
            while(names.Count > 1)
            {
                for (int i = 0; i < passes - 1; i++)
                {
                    names.Enqueue(names.Dequeue());
                }
                Console.WriteLine($"Removed {names.Dequeue()}");
            }
            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
