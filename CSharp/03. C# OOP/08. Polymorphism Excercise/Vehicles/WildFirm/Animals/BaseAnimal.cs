using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFirm.Interfaces;

namespace WildFirm.Animals
{
    public abstract class BaseAnimal : IAnimal
    {
        protected BaseAnimal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract double GrowthCoefficient { get; }

        public virtual bool Eat(IFood food)
        {
            this.Weight += food.Quantity * this.GrowthCoefficient;
            this.FoodEaten += food.Quantity;
            return true;
        }

        public abstract string AskForFood();
    }
}
