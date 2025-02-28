namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new();
            string command;

            while ((command = Console.ReadLine()).ToLower() != "end")
            {
                string[] token = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = token[0].ToLower();
                string carNumber = token[1];

                if(direction == "in")
                {
                    carNumbers.Add(carNumber);
                }
                else if(direction == "out")
                {
                    if(carNumbers.Any() && carNumbers.Contains(carNumber))
                    {
                        carNumbers.Remove(carNumber);
                    }
                }
            }
            if (!carNumbers.Any())
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            Console.WriteLine(string.Join(Environment.NewLine, carNumbers));
        }
    }
}
