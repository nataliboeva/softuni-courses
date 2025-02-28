
namespace _04._Border_Control
{
    public static class StartUp
    {
        public static void Main()
        {

            List<IEnter> entersList = new List<IEnter>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] enterInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (enterInfo.Length == 3)
                {
                    string name = enterInfo[0];
                    if (!int.TryParse(enterInfo[1], out int age))
                    {
                        Console.WriteLine("Invalid input format for age.");
                        continue;
                    }
                    string id = enterInfo[2];

                    IEnter citizen = new Citizen(name, age, id);
                    entersList.Add(citizen);
                }
                else if (enterInfo.Length == 2)
                {
                    string model = enterInfo[0];
                    string id = enterInfo[1];

                    IEnter robot = new Robot(model, id);
                    entersList.Add(robot);
                }
                else
                {
                    Console.WriteLine("Invalid input format.");
                }
            }

            string lastDigits = Console.ReadLine();
            if (string.IsNullOrEmpty(lastDigits))
            {
                Console.WriteLine("Invalid input for last digits.");
                return;
            }

            List<string> detainedIds = new List<string>();
            foreach (var entry in entersList)
            {
                if (entry.Id.EndsWith(lastDigits))
                {
                    detainedIds.Add(entry.Id);
                }
            }
            Console.WriteLine(String.Join(Environment.NewLine, detainedIds));
        }
    }
}
