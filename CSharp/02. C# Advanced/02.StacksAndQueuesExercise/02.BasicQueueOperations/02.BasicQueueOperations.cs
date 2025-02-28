namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToEnqueue = command[0];
            int elementsToDequeue = command[1];
            int elementToLookUp = command[2];

            Queue<int> queue = new Queue<int>();
            if (elementsToEnqueue <= numbers.Count())
            {
                for (int i = 0; i < elementsToEnqueue; i++)
                {
                    queue.Enqueue(numbers[i]);
                }
            }
            if (elementsToDequeue <= queue.Count())
            {
                for (int i = 0; i < elementsToDequeue; i++)
                {
                    queue.Dequeue();
                }
            }
            if (!queue.Any())
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(elementToLookUp))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
