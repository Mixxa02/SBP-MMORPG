using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORGP_Web_API.Entiteti
{
    public class Sesija
    {
        public virtual int Id { get; set; }
        public virtual DateTime VremePovezivanjaNaServer { get; set; }
        public virtual float VremeUcestvovanja { get; set; }
        public virtual int ZaradjeniGold { get; set; }
        public virtual int ZaradjeniXPpoeni { get; set; }

        public virtual Igrac Igrac { get; set; }
    }
}
