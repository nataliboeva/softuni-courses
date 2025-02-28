using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFirm.Interfaces;

namespace WildFirm.Foods
{
    public abstract class BaseFood : IFood
    {
        protected BaseFood(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
