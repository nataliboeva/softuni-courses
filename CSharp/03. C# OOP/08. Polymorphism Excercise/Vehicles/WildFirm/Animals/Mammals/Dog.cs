using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFirm.Foods;
using WildFirm.Interfaces;

namespace WildFirm.Animals.Mammals
{
    public class Dog : BaseMammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double GrowthCoefficient => 0.4;

        public override bool Eat(IFood food) => food is Meat && base.Eat(food);

        public override string AskForFood() => "Woof!";
    }
}
