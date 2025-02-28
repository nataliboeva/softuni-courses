﻿using Raiding.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Interfaces.Factories
{
    public interface IHeroFactory
    {
        IHero Create(string name);
    }
}
