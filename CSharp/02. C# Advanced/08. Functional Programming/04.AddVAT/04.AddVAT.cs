namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = 
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n + n * 0.2)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, prices.Select(p => p.ToString("f2"))));

        }
    }
}
