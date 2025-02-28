namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            for (int i = input.Length - 1; i >= 0 ; i--)
            {
                stack.Push(input[i]);
            }
            int result = int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                string command = stack.Pop();
                int number = int.Parse(stack.Pop());
                if (command == "+")
                {
                    result += number;
                }
                else if (command == "-")
                {
                    result -= number;
                }
            }
            Console.WriteLine(result);
        }
    }
}
