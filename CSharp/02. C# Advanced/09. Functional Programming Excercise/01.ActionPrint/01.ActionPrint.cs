using System.Threading.Channels;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = p => Console.WriteLine(string.Join(Environment.NewLine, p));

            print(names);
        }
    }
}
