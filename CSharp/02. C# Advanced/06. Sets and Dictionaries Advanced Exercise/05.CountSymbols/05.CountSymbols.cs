using System.Collections;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> occurrences = new();
            foreach (char element in text)
            {
                if (!occurrences.ContainsKey(element))
                {
                    occurrences.Add(element, 0);
                }
                occurrences[element]++;
            }
            foreach (var element in occurrences)
            {
                Console.WriteLine($"{element.Key}: {element.Value} time/s");
            }
        }
    }
}
