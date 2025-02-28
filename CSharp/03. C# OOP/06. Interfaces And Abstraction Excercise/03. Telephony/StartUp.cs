using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ');
            string[] websites = Console.ReadLine().Split(' ');

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string number in phoneNumbers)
            {
                if (number.All(char.IsDigit))
                {
                    if (number.Length == 10)
                    {
                        smartphone.Call(number);
                    }
                    else if (number.Length == 7)
                    {
                        stationaryPhone.Call(number);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (string site in websites)
            {
                if (site.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone.Browse(site);
                }
            }
        }
    }
}