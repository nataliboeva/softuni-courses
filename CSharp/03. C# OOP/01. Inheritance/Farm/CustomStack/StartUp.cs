namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new();

            Console.WriteLine(stack.isEmpty());

            stack.AddRange(new List<string> { "First", "Second", "Third" });

            Console.WriteLine(stack.isEmpty());
            Console.WriteLine();

            while (!stack.isEmpty())
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
