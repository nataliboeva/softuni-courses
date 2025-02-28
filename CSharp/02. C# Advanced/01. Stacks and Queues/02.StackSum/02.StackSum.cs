namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input);

            string command = null;
            
            while(command != "end")
            {
                command = Console.ReadLine().ToLower();
                string[] token = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (token[0] == "add")
                {
                    stack.Push(int.Parse(token[1]));
                    stack.Push(int.Parse(token[2]));
                }
                else if (token[0] == "remove")
                {
                    if(stack.Count >= int.Parse(token[1]))
                    {
                        for (int i = 0; i < int.Parse(token[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
