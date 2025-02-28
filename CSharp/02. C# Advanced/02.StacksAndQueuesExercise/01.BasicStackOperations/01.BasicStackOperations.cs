namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToPush = command[0];
            int elementsToPop = command[1];
            int elementToLookUp = command[2];

            Stack<int> stack = new Stack<int>();
            if(elementsToPush <= numbers.Count())
            {
                for (int i = 0; i < elementsToPush; i++)
                {
                    stack.Push(numbers[i]);
                }
            }
            if(elementsToPop <= stack.Count())
            {
                for (int i = 0; i < elementsToPop; i++)
                {
                    stack.Pop();
                }
            }
            if (!stack.Any())
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(elementToLookUp))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
