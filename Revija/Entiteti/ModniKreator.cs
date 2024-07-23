using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revija.Entiteti
{
    public class ModniKreator:Osoba
    {
        public virtual string ZemljaPorekla { get; set; }
        public virtual string NazivModneKuce { get; set; }

        public virtual IList<Organizuje> OrganizujeReviju { get; set; }

        public ModniKreator()
        {
            OrganizujeReviju = new List<Organizuje>();
        }
    }
}
