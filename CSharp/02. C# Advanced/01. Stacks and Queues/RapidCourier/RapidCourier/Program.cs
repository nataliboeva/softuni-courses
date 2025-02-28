namespace RapidCourier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] packageWeight = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> packages = new List<int>(packageWeight);

            int[] courierCapacity = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> courier = new Queue<int>(courierCapacity);

            int totalWeight = 0;

            while(packages.Count > 0 && courier.Count > 0)
            {
                int currentPack = packages[packages.Count - 1];
                int currentCourier = courier.Dequeue();

                if(currentCourier >= currentPack)
                {
                    totalWeight+= currentPack;
                    packages.RemoveAt(packages.Count - 1);

                    int remainingCapacity = currentCourier - 2 * currentPack;

                    if(remainingCapacity > 0)
                    {
                        courier.Enqueue(remainingCapacity);
                    }
                }
                else
                {
                    totalWeight += currentCourier;
                    packages[packages.Count - 1] = currentPack - currentCourier;
                }
            }

            Console.WriteLine($"Total weight: {totalWeight} kg");

            if(packages.Count == 0 && courier.Count == 0) 
            {
                Console.WriteLine("Congratulations, all packages were delivered successfully by" +
                    " the couriers today.");
            }
            else if(packages.Count > 0)
            {
                Console.WriteLine("Unfortunately, there are no more available couriers to deliver" +
                    " the following packages: " + string.Join(", ", packages));
            }
            else if(courier.Count > 0)
            {
                Console.WriteLine("Couriers are still on duty: " + string.Join(", ", courier)
                    + " but there are no more packages to deliver.");
            }
        }
    }
}
