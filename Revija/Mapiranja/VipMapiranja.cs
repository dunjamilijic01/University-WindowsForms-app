﻿using FluentNHibernate.Mapping;
using Revija.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revija.Mapiranja
{
    class VipMapiranja : SubclassMap<Vip>
    {
        public VipMapiranja()
        {
            Table("VIP");
            KeyColumn("ID");
            Map(x => x.Zanimanje, "ZANIMANJE");

            HasMany(x => x.VipNaRevijama).KeyColumn("VIP_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
