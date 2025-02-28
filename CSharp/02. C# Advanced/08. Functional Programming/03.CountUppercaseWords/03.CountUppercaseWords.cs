namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> checkCapitalized = word => char.IsUpper(word[0]);

            string[] text = 
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(t => checkCapitalized(t))
                .ToArray();

            foreach (string t in text)
            {
                Console.WriteLine(t);
            }
        }
    }
}
