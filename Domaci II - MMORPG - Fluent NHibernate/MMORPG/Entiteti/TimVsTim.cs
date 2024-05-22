using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG.Entiteti
{
    public class TimVsTim
    {
        public virtual string Id { get; set; }
        public virtual string Pobednik { get; set; }
        public virtual string Bonus { get; set; }
        public virtual DateTime Vreme { get; set; }
        public virtual string Tim1 { get; set; }
        public virtual string Tim2 { get; set; }
    }
}