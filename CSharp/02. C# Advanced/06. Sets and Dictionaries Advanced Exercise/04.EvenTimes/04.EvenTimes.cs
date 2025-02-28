using System.Runtime.CompilerServices;

namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new();
            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if(!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }
                numbers[num]++;
            }
            
            int evenNumber = numbers.First(kvp => kvp.Value % 2 == 0).Key;
            Console.WriteLine(evenNumber);
        }
    }
}
