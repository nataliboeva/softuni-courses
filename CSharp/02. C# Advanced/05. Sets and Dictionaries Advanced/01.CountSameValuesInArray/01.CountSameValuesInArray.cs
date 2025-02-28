namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> SameValuesCount = new();

            foreach (double number in numbers)
            {
                if (SameValuesCount.ContainsKey(number))
                {
                    SameValuesCount[number]++;
                }
                else
                {
                    SameValuesCount.Add(number, 1);
                }
            }

            foreach (var kvp in SameValuesCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
