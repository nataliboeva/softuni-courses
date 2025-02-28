using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFirm.Foods;
using WildFirm.Interfaces;

namespace WildFirm.Animals.Mammals
{
    public class Mouse : BaseMammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double GrowthCoefficient => 0.1;

        public override bool Eat(IFood food) => food is Vegetable or Fruit && base.Eat(food);

        public override string AskForFood() => "Squeak";
    }
}
