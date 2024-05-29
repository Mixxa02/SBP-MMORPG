using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORGP_Web_API.Entiteti
{
    public class Predmet
    {
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual IList<Staza> Staze { get; set; }
        public Predmet()
        {
            Staze = new List<Staza>();
        }
    }
    public class KljucniPredmet : Predmet 
    {
        public virtual string NadimciLikova { get; set; }
    }
    public class PredmetXP : Predmet
    {
        public virtual int BonusUIskustvu { get; set; }
        public virtual string RasePremdet { get; set; }
    }
}