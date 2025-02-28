namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            SortedSet<string> chemicals = new();
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var element in input)
                {
                    chemicals.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}
