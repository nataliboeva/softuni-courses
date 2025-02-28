namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> namesVIP = new();
            HashSet<string> namesRegular = new();
            while (true)
            {
                string action = Console.ReadLine();
                if(action == "PARTY")
                {
                    string input;
                    while ((input = Console.ReadLine()) != "END")
                    {
                        
                        if (namesRegular.Contains(input))
                        {
                            namesRegular.Remove(input);
                        }
                        else if (namesVIP.Contains(input))
                        {
                            namesVIP.Remove(input);
                        }
                    }
                    Console.WriteLine(namesVIP.Count + namesRegular.Count);
                    foreach(var name in namesVIP)
                    {
                        Console.WriteLine(name);
                    }
                    foreach (var name in namesRegular)
                    {
                        Console.WriteLine(name);
                    }
                    return;

                }
                else if (action.Length == 8)
                {
                    char firstLetter = action[0];
                    if (char.IsDigit(firstLetter))
                    {
                        namesVIP.Add(action);
                    }
                    else
                    {
                        namesRegular.Add(action);
                    }
                }
            }
        }
    }
}
