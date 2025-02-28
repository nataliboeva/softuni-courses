namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine()); 
            string command = string.Empty;
            Queue<string> cars = new Queue<string>();
            int passes = 0;
            while(true)
            {
                command = Console.ReadLine();
                if(command == "end")
                {
                    Console.WriteLine($"{passes} cars passed the crossroads.");
                    break;
                }
                else if(command == "green")
                {
                    for(int i = 0; i < count; i++)
                    {
                        if (cars.Any())
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passes++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }
        }
    }
}
