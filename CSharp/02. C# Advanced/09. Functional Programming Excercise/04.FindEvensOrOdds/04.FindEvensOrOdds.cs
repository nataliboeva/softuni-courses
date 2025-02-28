namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = 
                Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string type = Console.ReadLine();
            int start = numbers[0];
            int end = numbers[1];

            List<int> range = Enumerable.Range(start, end - start + 1).ToList();

            Predicate<int> isEven = even => even % 2 == 0;
            Predicate<int> isOdd = odd => odd % 2 != 0;

            Console.WriteLine(string.Join(" ", range.FindAll(type == "even" ? isEven : isOdd)));
        }
    }
}
