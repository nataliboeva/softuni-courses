namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> vloggerFollowers = new();
            Dictionary<string, SortedSet<string>> vloggerFollowing = new();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] inputInfo = input.Split();

                if (inputInfo[1] == "joined")
                {
                    string username = inputInfo[0];
                    vloggerFollowers.TryAdd(username, new SortedSet<string>());
                    vloggerFollowing.TryAdd(username, new SortedSet<string>());
                }
                else if (inputInfo[1] == "followed")
                {
                    string firstVlogger = inputInfo[0];
                    string secondVlogger = inputInfo[2];
                    if (vloggerFollowers.ContainsKey(firstVlogger)
                        && vloggerFollowers.ContainsKey(secondVlogger)
                        && firstVlogger != secondVlogger)
                    {
                        vloggerFollowers[secondVlogger].Add(firstVlogger);
                        vloggerFollowing[firstVlogger].Add(secondVlogger);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggerFollowers.Count} vloggers in its logs.");

            var sortedVloggers = vloggerFollowers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => vloggerFollowing[x.Key].Count);

            int counter = 0;

            foreach (var item in sortedVloggers)
            {
                Console.WriteLine($"{++counter}. {item.Key} : {item.Value.Count} " +
                    $"followers, {vloggerFollowing[item.Key].Count} following");
                if (counter == 1)
                {
                    foreach (var vlogger in item.Value)
                    {
                        Console.WriteLine($"*  {vlogger}");
                    }
                }
            }
        }
    }
}
