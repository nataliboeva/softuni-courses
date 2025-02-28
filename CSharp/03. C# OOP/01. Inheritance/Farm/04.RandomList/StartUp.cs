namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new();

            list.Add("First");
            list.Add("Second");
            list.Add("Third");
            list.Add("Fourth");

            Console.WriteLine(list.RandomString());
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
