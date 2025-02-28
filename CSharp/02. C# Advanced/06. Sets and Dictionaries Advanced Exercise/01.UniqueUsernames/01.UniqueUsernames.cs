namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> names = new();

            for (int i = 0; i < count; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
