﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG.Entiteti
{
    public class Kupovina
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int Igrac { get; set; }
    }
}
