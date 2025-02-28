namespace _03.LargestThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
