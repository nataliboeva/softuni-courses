namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstSet = sets[0];
            int secondSet = sets[1];
            HashSet<int> firstSetNum = new();
            HashSet<int> secondSetNum = new();
            for (int i = 0; i < firstSet; i++)
            {
                firstSetNum.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < secondSet; i++)
            {
                secondSetNum.Add(int.Parse(Console.ReadLine()));
            }
            
            foreach (int num in firstSetNum)
            {
                if (secondSetNum.Contains(num))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
