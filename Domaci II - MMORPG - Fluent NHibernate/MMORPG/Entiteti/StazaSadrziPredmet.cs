﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG.Entiteti
{
    public class StazaSadrziPredmet
    {
        public virtual int Id { get; set; }
        public virtual string NazivStaze { get; set; }
        public virtual string NazivPredmeta { get; set; }
    }
}
