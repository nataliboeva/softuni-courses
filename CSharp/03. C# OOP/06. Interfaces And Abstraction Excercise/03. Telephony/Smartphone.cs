using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._Telephony
{
    public class Smartphone : ICallable,IBrowsable
    {
        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }
        public void Browse(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}
