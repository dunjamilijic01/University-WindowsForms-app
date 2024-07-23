﻿using FluentNHibernate.Mapping;
using Revija.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revija.Mapiranja
{
    class PojavljujeSeNaMapiranja : ClassMap<PojavljujeSeNa>
    {
        public PojavljujeSeNaMapiranja()
        {
            Table("VIP_NA_REVIJI");

            Id(x => x.Id, "ID").GeneratedBy.Assigned();

            References(x => x.VipPojavljujeSeNa).Column("VIP_ID").LazyLoad();
            References(x => x.PojavljujuSeNaRevija).Column("REVIJA_RBR").LazyLoad();


        }
    }
}
