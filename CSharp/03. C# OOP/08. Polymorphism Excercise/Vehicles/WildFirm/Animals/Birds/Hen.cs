using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFirm.Animals.Birds
{
    public class Hen : BaseBird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double GrowthCoefficient => 0.35;

        public override string AskForFood() => "Cluck";
    }
}
