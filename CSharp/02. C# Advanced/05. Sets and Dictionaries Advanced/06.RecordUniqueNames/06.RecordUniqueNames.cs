using System.Reflection;

namespace _06.RecordUniqueNames
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
