namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int range = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(numbers);
            int box = 1;
            int currentCapacity = 0;
            while (clothes.Any())
            {
                int current = clothes.Pop();
                if(current + currentCapacity <= range)
                {
                    currentCapacity += current;
                }
                else
                {
                    currentCapacity = current;
                    box++;
                }
            }
            Console.WriteLine(box);
        }
    }
}
