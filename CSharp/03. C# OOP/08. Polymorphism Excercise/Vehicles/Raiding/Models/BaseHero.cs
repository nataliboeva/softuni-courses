using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models;

using Raiding.Interfaces.Models;

public abstract class BaseHero : IHero
{
    protected BaseHero(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; }
    public int Power { get; }

    public abstract string CastAbility();
}
