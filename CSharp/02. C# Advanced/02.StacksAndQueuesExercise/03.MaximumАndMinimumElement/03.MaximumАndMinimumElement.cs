namespace _03.MaximumАndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> elements = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] token = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                int command = token[0];
                

                if(command == 1) //Push
                {
                    int element = token[1];
                    elements.Push(element);
                }
                else if (command == 2) //Delete
                {
                    if (elements.Any())
                    {
                        elements.Pop();
                    }
                }
                else if (command == 3) //Print max
                {
                    if(elements.Any())
                    {
                        Console.WriteLine(elements.Max());
                    }
                }
                else if (command == 4) //Print min
                {
                    if (elements.Any())
                    {
                        Console.WriteLine(elements.Min());
                    }
                }

            }
            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
