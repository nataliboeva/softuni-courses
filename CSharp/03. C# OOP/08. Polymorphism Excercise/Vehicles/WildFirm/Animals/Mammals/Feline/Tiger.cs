﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFirm.Foods;
using WildFirm.Interfaces;

namespace WildFirm.Animals.Mammals.Feline
{
    public class Tiger : BaseFeline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double GrowthCoefficient => 1;

        public override bool Eat(IFood food) => food is Meat && base.Eat(food);

        public override string AskForFood() => "ROAR!!!";
    }
}
