namespace _25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете число: ");
            int count = int.Parse(Console.ReadLine());
            Dictionary<int,int> result = new Dictionary<int, int>();
            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result.Add(number, 1);
                }       
            }
            foreach(var value in result) { 
                Console.WriteLine($"число: {value.Key}, брой: {value.Value}");
            }
        }
    }
}
