namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new();
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] clothes = input[1].Split(",");

                if(!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                foreach(string clothe in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clothe))
                    {
                        wardrobe[color].Add(clothe, 0);
                    }
                    wardrobe[color][clothe]++;
                }
            }
            string[] lookFor = Console.ReadLine().Split();

            foreach ((string color, Dictionary<string, int> clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var clothe in clothes)
                {
                    if (color == lookFor[0] && clothe.Key == lookFor[1])
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }
                }
            }
        }
    }
}
