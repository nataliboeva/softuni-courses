namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] quanityOrder = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(quanityOrder);

            Console.WriteLine(orders.Max());

            for (int i = 0; i < quanityOrder.Count(); i++)
            {
                if (quantity - orders.Peek() >= 0)
                {
                    int order = orders.Dequeue();
                    quantity -= order;
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }

    }
}
