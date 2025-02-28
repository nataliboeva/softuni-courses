using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Interfaces;

namespace Telephony.Interfaces
{
    public class StationaryPhone : ICaller
    {
        public string Call(string phoneNumber) => $"Dialing... {phoneNumber}";
    }
}
