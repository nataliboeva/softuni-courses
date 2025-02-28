namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Queue<string> queue = new Queue<string>();
            while (true)
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                else if(command != "Paid")
                {
                    queue.Enqueue(command);
                }
                else if (command == "Paid")
                {
                    foreach (string name in queue)
                    {
                        Console.WriteLine(name);
                    }
                    while (queue.Any())
                    {
                        queue.Dequeue();
                    }
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
