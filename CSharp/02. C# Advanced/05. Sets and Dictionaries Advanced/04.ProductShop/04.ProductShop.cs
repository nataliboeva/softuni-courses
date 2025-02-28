namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productsShops = new();

            string command;
            while ((command = Console.ReadLine()).ToLower() != "revision")
            {
                string[] token = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = token[0];
                string product = token[1];
                double price = double.Parse(token[2]);

                if(!productsShops.ContainsKey(shop))
                {
                    productsShops[shop] = new Dictionary<string, double>();
                }

                productsShops[shop].Add(product, price);
            }

            foreach ((string shop, Dictionary<string, double> products)  in productsShops)
            {
                Console.WriteLine($"{shop}->");
                foreach ((string product, double price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
