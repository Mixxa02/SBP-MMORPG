﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG.Mapiranja
{
    public class TimMapiranja : ClassMap<MMORPG.Entiteti.Tim>
    {
        public TimMapiranja()
        {
            Table("TIM");

            Id(x => x.Naziv, "NAZIV").GeneratedBy.Assigned();

            Map(x => x.Plasman, "PLASMAN");
            Map(x => x.BonusPoeni, "BONUS_POENI");
            Map(x => x.Max, "MAX_IGRACI");
            Map(x => x.Min, "MIN_IGRACI");

            HasMany(x => x.Igraci).KeyColumn("NAZIV_TIMA").Cascade.All().Inverse();
            HasOne(x => x.StazaZaTim).PropertyRef(x=>x.Tim);


        }
    }
}
