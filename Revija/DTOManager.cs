using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Revija.Entiteti;
using System.Windows.Forms;

namespace Revija
{
    public class DTOManager
    {
        #region Modna Revija
        public static List<ModnaRevijaPregled> vratiSveRevije()
        {
            List<ModnaRevijaPregled> revije = new List<ModnaRevijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<ModnaRevija> sveRevije = from o in s.Query<ModnaRevija>() select o;

                foreach (ModnaRevija m in sveRevije)
                {
                    revije.Add(new ModnaRevijaPregled(m.RbrRevije, m.Naziv, m.MestoOdrzavanja, m.DatumVreme));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return revije;
        }
        public static List<KreatorPregled> vratiKretoreRevije(int rbr)
        {
            List<KreatorPregled> kreatori = new List<KreatorPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Organizuje> sveRevije = from o in s.Query<Organizuje>()
                                                        where o.OrganizujeRevija.RbrRevije==rbr
                                                        select o;

                foreach (Organizuje or in sveRevije)
                {
                    kreatori.Add(new KreatorPregled(or.KreatorOrganizuje.Id,or.KreatorOrganizuje.Ime,or.KreatorOrganizuje.Prezime,or.KreatorOrganizuje.ZemljaPorekla,or.KreatorOrganizuje.NazivModneKuce));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return kreatori;
        }
        public static List<ModnaRevijaPregled > vratiSveRevijeSaVip(int id)
        {
            List<ModnaRevijaPregled> revije = new List<ModnaRevijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<PojavljujeSeNa> sveRevije = from o in s.Query<PojavljujeSeNa>() where o.VipPojavljujeSeNa.Id==id
                                                        select o;

                foreach (PojavljujeSeNa p in sveRevije)
                {
                    revije.Add(new ModnaRevijaPregled(p.PojavljujuSeNaRevija.RbrRevije, p.PojavljujuSeNaRevija.Naziv, p.PojavljujuSeNaRevija.MestoOdrzavanja, p.PojavljujuSeNaRevija.DatumVreme));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return revije;
        }
        public static void dodajReviju(ModnaRevijaBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModnaRevija m = new Revija.Entiteti.ModnaRevija();
                m.RbrRevije = r.RbrRevije;
                m.Naziv = r.Naziv;
                m.MestoOdrzavanja = r.MestoOdrzavanja;
                m.DatumVreme = r.DatumVremeOdrzavanja;
                m.PrvaZajRevija = r.PrvaZajednickaRevija;

                s.SaveOrUpdate(m);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void obrisiReviju(int rbr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModnaRevija r = s.Load<Revija.Entiteti.ModnaRevija>(rbr);

                s.Delete(r);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static ModnaRevijaBasic vratiReviju(int rbr)
        {
            ModnaRevijaBasic mb = new ModnaRevijaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModnaRevija o = s.Load<Revija.Entiteti.ModnaRevija>(rbr);
                mb = new ModnaRevijaBasic(o.RbrRevije, o.Naziv, o.MestoOdrzavanja, o.DatumVreme, o.PrvaZajRevija);

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return mb;
        }
        public static ModnaRevijaBasic izmeniReviju(ModnaRevijaBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModnaRevija o = s.Load<Revija.Entiteti.ModnaRevija>(m.RbrRevije);
                o.RbrRevije = m.RbrRevije;
                o.Naziv = m.Naziv;
                o.MestoOdrzavanja = m.MestoOdrzavanja;
                o.DatumVreme = m.DatumVremeOdrzavanja;
                o.PrvaZajRevija = m.PrvaZajednickaRevija;

                s.Update(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return m;
        }
        #endregion
        #region Manekeni
        public static List<ManekenPregled> vratiSveManekeneRevije(int rbr)
        {
            List<ManekenPregled> manekeni = new List<ManekenPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.UcestvujeNa> sviManekeni = from o in s.Query<Revija.Entiteti.UcestvujeNa>()
                                                                       where o.UcestvujeNaRevija.RbrRevije == rbr
                                                                       where o.SpecijalniGost=='N'
                                                                       select o;

                foreach (Revija.Entiteti.UcestvujeNa u in sviManekeni)
                {
                    {
                        Revija.Entiteti.ProfesionalniModel p = s.Load<Revija.Entiteti.ProfesionalniModel>(u.OsobaUcestvujeNa.Id);
                        manekeni.Add(new ManekenPregled(p.Id, p.Mbr, p.Ime, p.Prezime, p.Visina, p.Tezina, p.BojaOciju, p.BojaOciju, p.KonfekcijskiBroj));

                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return manekeni;
        }
        public static void dodeliRevijuVipu(int rbr,int id)
        {
           try
            {
                ISession s = DataLayer.GetSession();
                Revija.Entiteti.ModnaRevija o = s.Load<Revija.Entiteti.ModnaRevija>(rbr);
                Revija.Entiteti.Vip v = s.Load<Revija.Entiteti.Vip>(id);
                Revija.Entiteti.PojavljujeSeNa p = new Revija.Entiteti.PojavljujeSeNa();

                p.PojavljujuSeNaRevija = o;
                p.VipPojavljujeSeNa = v;
                s.SaveOrUpdate(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void obrisiManekena(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.Osoba o = s.Load<Revija.Entiteti.Osoba>(id);
                //o.Prodavnice.Clear();
                // r.RadiUProdavnice.Clear(); jedan radnik moze da radi i u vise prodavnica //ovo mozda nece biti potrebno
                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajProfModela(ProfesionalniModelBasic model, ModnaRevijaBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ProfesionalniModel o = new Revija.Entiteti.ProfesionalniModel();
                Revija.Entiteti.UcestvujeNa u = new Revija.Entiteti.UcestvujeNa();
                Revija.Entiteti.ModnaRevija revija = s.Load<Revija.Entiteti.ModnaRevija>(r.RbrRevije);

                o.Mbr = model.Mbr;
                o.Ime = model.Ime;
                o.Prezime = model.Prezime;
                o.DatRodjenja = model.DatRodj;
                o.Pol = model.Pol;
                o.Visina = model.Visina;
                o.Tezina = model.Tezine;
                o.BojaKose = model.BojaKose;
                o.BojaOciju = model.BojaOciju;
                o.KonfekcijskiBroj = model.KonfBroj;
                o.Agencija = s.Load<Revija.Entiteti.ModnaAgencija>(model.AgencijaPIB);

                //o.UcestvujeNaReviji.

                s.SaveOrUpdate(o);
                s.Flush();
                u.OsobaUcestvujeNa = o;
                u.UcestvujeNaRevija = revija;
                u.SpecijalniGost = 'N';
                s.SaveOrUpdate(u);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajVipModela(VIPBasic v, ModnaRevijaBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Revija.Entiteti.UcestvujeNa ucesnik = new Revija.Entiteti.UcestvujeNa();
                Revija.Entiteti.ModnaRevija revija = s.Load<Revija.Entiteti.ModnaRevija>(r.RbrRevije);
                Revija.Entiteti.Vip o = new Revija.Entiteti.Vip();

                o.Mbr = v.Mbr;
                o.Ime = v.Ime;
                o.Prezime = v.Prezime;
                o.DatRodjenja = v.DatRodj;
                o.Pol = v.Pol;
                o.Zanimanje = v.Zanimanje;

                s.SaveOrUpdate(o);
                s.Flush();
                ucesnik.OsobaUcestvujeNa = o;
                ucesnik.UcestvujeNaRevija = revija;
                ucesnik.SpecijalniGost = 'Y';
                s.SaveOrUpdate(ucesnik);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static VIPBasic vratiVip(int id)
        {
            VIPBasic vb = new VIPBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.Vip o = s.Load<Revija.Entiteti.Vip>(id);
                vb = new VIPBasic(o.Id,o.Mbr,o.Ime,o.Prezime,o.DatRodjenja,o.Pol,o.Zanimanje);

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return vb;
        }
        public static VIPBasic IzmeniVipNaReviji(VIPBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.Vip o = s.Load<Revija.Entiteti.Vip>(v.Id);

                o.Mbr = v.Mbr;
                o.Ime = v.Ime;
                o.Prezime = v.Prezime;
                o.DatRodjenja = v.DatRodj;
                o.Pol = v.Pol;
                o.Zanimanje = v.Zanimanje;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return v;
        }
        public static void obrisiVipNaReviji(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.Osoba o = s.Load<Revija.Entiteti.Osoba>(id);
                
                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static List<ProfesionalniModelPregled>vratiSveManekene()
        {
            List<ProfesionalniModelPregled> manekeni = new List<ProfesionalniModelPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.ProfesionalniModel> sviManekeni = from o in s.Query<Revija.Entiteti.ProfesionalniModel>()
                                                                       select o;

                foreach (Revija.Entiteti.ProfesionalniModel p in sviManekeni)
                {
                    {
                        manekeni.Add(new ProfesionalniModelPregled(p.Id, p.Mbr, p.Ime, p.Prezime));
                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return manekeni;
        }
        public static void dodajProfModela(ProfesionalniModelBasic model)
        {
            try { 
            ISession s = DataLayer.GetSession();

            Revija.Entiteti.ProfesionalniModel o = new Revija.Entiteti.ProfesionalniModel();

            o.Mbr = model.Mbr;
            o.Ime = model.Ime;
            o.Prezime = model.Prezime;
            o.DatRodjenja = model.DatRodj;
            o.Pol = model.Pol;
            o.Visina = model.Visina;
            o.Tezina = model.Tezine;
            o.BojaKose = model.BojaKose;
            o.BojaOciju = model.BojaOciju;
            o.KonfekcijskiBroj = model.KonfBroj;
            o.Agencija = s.Load<Revija.Entiteti.ModnaAgencija>(model.AgencijaPIB);

            //o.UcestvujeNaReviji.

            s.SaveOrUpdate(o);
            s.Flush();

            s.Close();
        }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
}
        #endregion
        #region Modna agencija
        public static ModnaAgencijaBasic vratiModnuAgenciju(int pib)
        {
            List<ModnaAgencijaBasic> agencije = new List<ModnaAgencijaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.ModnaAgencija> svi = from o in s.Query<Revija.Entiteti.ModnaAgencija>()
                                                                 where o.PIB==pib

                                                                 select o;

                foreach (Revija.Entiteti.ModnaAgencija u in svi)
                {
                    {
                        if (u is Domaca)
                            agencije.Add(new ModnaAgencijaBasic(u.PIB, u.Naziv, u.Sediste, u.DatumOsnivanja, "DOMACA"));
                        else
                            agencije.Add(new ModnaAgencijaBasic(u.PIB, u.Naziv, u.Sediste, u.DatumOsnivanja, "INTERNACIONALNA"));
                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return agencije.FirstOrDefault();
        }
        public static void obrisiAgenciju(int pib)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModnaAgencija ag = (from o in s.Query<Revija.Entiteti.ModnaAgencija>()
                                                   
                                                   select o).FirstOrDefault();

                s.Delete(ag);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajModnuAgenciju(ModnaAgencijaBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Revija.Entiteti.ModnaAgencija ma;
                if (m.Tip=="DOMACA")
                {
                   ma = new Revija.Entiteti.Domaca();
                }
                else
                {
                   ma = new Revija.Entiteti.Internacionalna();
                }

                ma.PIB = m.PIB;
                ma.Naziv = m.Naziv;
                ma.Sediste = m.Sediste;
                ma.DatumOsnivanja = m.DatumOsnivanja;
                s.Save(ma);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }

        public static List<ModnaAgencijaBasic> vratiSveAgencije()
        {
            List<ModnaAgencijaBasic> agencije = new List<ModnaAgencijaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.ModnaAgencija> svi = from o in s.Query<Revija.Entiteti.ModnaAgencija>()
                                                                  
                                                                   select o;

                foreach (Revija.Entiteti.ModnaAgencija u in svi)
                {
                    {
                        if (u is Domaca)
                            agencije.Add(new ModnaAgencijaBasic(u.PIB, u.Naziv, u.Sediste, u.DatumOsnivanja, "DOMACA"));
                        else
                            agencije.Add(new ModnaAgencijaBasic(u.PIB, u.Naziv, u.Sediste, u.DatumOsnivanja, "INTERNACIONALNA"));
                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return agencije;
        }

        public static ProfesionalniModelBasic vratiManekena(int id)
        {
            ProfesionalniModelBasic pm = new ProfesionalniModelBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ProfesionalniModel o = s.Load<Revija.Entiteti.ProfesionalniModel>(id);
                pm = new ProfesionalniModelBasic(o.Id,o.Mbr,o.Ime,o.Prezime,o.DatRodjenja,o.Pol,o.Visina,o.Tezina,o.BojaOciju,o.BojaKose,o.KonfekcijskiBroj,o.Agencija.PIB);

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return pm;
        }
        public static void izmeniModnuAgenciju(ModnaAgencijaBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModnaAgencija o = s.Load<Revija.Entiteti.ModnaAgencija>(m.PIB);

                o.PIB = m.PIB;
                o.Naziv = m.Naziv;
                o.Sediste = m.Sediste;
                o.DatumOsnivanja = m.DatumOsnivanja;
                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void azurirajProfesionalnogModela(ProfesionalniModelBasic model)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ProfesionalniModel o = s.Load<Revija.Entiteti.ProfesionalniModel>(model.Id);

                o.Mbr = model.Mbr;
                o.Ime = model.Ime;
                o.Prezime = model.Prezime;
                o.DatRodjenja = model.DatRodj;
                o.Pol = model.Pol;
                o.Visina = model.Visina;
                o.Tezina = model.Tezine;
                o.BojaKose = model.BojaKose;
                o.BojaOciju = model.BojaOciju;
                o.KonfekcijskiBroj = model.KonfBroj;
                o.Agencija = s.Load<Revija.Entiteti.ModnaAgencija>(model.AgencijaPIB);

                //o.UcestvujeNaReviji.

                s.Update(o);
                s.Flush();


                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }

        public static List<VipPregled> vratiSveVipRevije( int rbr)
        {
            List<VipPregled> vips = new List<VipPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.UcestvujeNa> sviVips = from o in s.Query<Revija.Entiteti.UcestvujeNa>()
                                                                       where o.UcestvujeNaRevija.RbrRevije == rbr
                                                                       where o.SpecijalniGost == 'Y'
                                                                       select o;

                foreach (Revija.Entiteti.UcestvujeNa u in sviVips)
                {
                    {
                        Revija.Entiteti.Vip v = s.Load<Revija.Entiteti.Vip>(u.OsobaUcestvujeNa.Id);
                        vips.Add(new VipPregled(v.Id, v.Ime, v.Prezime,v.Zanimanje));

                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return vips;
        }
        public static List<string> vratiAktivneZemlje(int pib)
        {
            List<string> zemlje = new List<string>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Revija.Entiteti.PoslujeU> sveZemlje = from o in s.Query<Revija.Entiteti.PoslujeU>()
                                                                   where o.AgencijaPoslujeU.PIB==pib
                                                                   select o;
                foreach (Revija.Entiteti.PoslujeU u in sveZemlje)
                {
                        zemlje.Add(u.NazivZemlje);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return zemlje;
        }

        #endregion
        #region Kreator
        public static void ukloniKreatoraSaRevije(int id, int rbr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.Organizuje spoj = (from o in s.Query<Revija.Entiteti.Organizuje>()
                                                                   where o.KreatorOrganizuje.Id == id
                                                                   where o.OrganizujeRevija.RbrRevije == rbr
                                                                   select o).FirstOrDefault();

                s.Delete(spoj);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajKreatoraReviji(KreatorBasic k,int rbr)

        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModniKreator kr = new Revija.Entiteti.ModniKreator();
                Revija.Entiteti.Organizuje o = new Revija.Entiteti.Organizuje();
                Revija.Entiteti.ModnaRevija r = s.Load<Revija.Entiteti.ModnaRevija>(rbr);

                kr.Mbr = k.mbr;
                kr.Ime = k.ime;
                kr.Prezime = k.prezime;
                kr.DatRodjenja = k.datumRodj;
                kr.Pol = k.Pol;
                kr.ZemljaPorekla = k.zemljaPorekla;
                kr.NazivModneKuce = k.nazivKuce;
                s.Save(kr);
                s.Flush();
                o.KreatorOrganizuje =kr;
                o.OrganizujeRevija = r;
                s.Save(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static List<KreatorBasic> vratiSveKreatore()
        {
            List<KreatorBasic> kreatori = new List<KreatorBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.ModniKreator> sviKreatori = from o in s.Query<Revija.Entiteti.ModniKreator>()
                                                                     select o;

                foreach (Revija.Entiteti.ModniKreator r in sviKreatori)
                {
                    kreatori.Add(new KreatorBasic(r.Id,r.Mbr,r.Ime,r.Prezime,r.DatRodjenja,r.Pol,r.ZemljaPorekla,r.NazivModneKuce));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return kreatori;
        }
        public static void dodajPostojecegKreatora(OrganizujeBasic org)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Organizuje o = new Organizuje();
                o.KreatorOrganizuje = s.Load<Revija.Entiteti.ModniKreator>(org.KreatorOrganizuje.id);
                o.OrganizujeRevija = s.Load<Revija.Entiteti.ModnaRevija>(org.OrganizujeRevija.RbrRevije);

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static KreatorBasic vratiKreatora(int id)
        {
            KreatorBasic kb = new KreatorBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModniKreator o = s.Load<Revija.Entiteti.ModniKreator>(id);
                kb = new KreatorBasic(o.Id,o.Mbr,o.Ime,o.Prezime,o.DatRodjenja,o.Pol,o.ZemljaPorekla,o.NazivModneKuce);

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return kb;
        }
        public static List<ModnaRevijaBasic> vratiSveRevijeKreatora(int id)
        {
            List<ModnaRevijaBasic> revije = new List<ModnaRevijaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.Organizuje> sveRevije = from o in s.Query<Revija.Entiteti.Organizuje>()
                                                                    where o.KreatorOrganizuje.Id==id
                                                                         select o;

                foreach (Revija.Entiteti.Organizuje p in sveRevije)
                {
                    revije.Add(new ModnaRevijaBasic(p.OrganizujeRevija.RbrRevije,p.OrganizujeRevija.Naziv,p.OrganizujeRevija.MestoOdrzavanja,p.OrganizujeRevija.DatumVreme,p.OrganizujeRevija.PrvaZajRevija));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return revije;
        }
        public static void dodajKreatora(KreatorBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModniKreator kr = new Revija.Entiteti.ModniKreator();

                kr.Mbr = k.mbr;
                kr.Ime = k.ime;
                kr.Prezime = k.prezime;
                kr.DatRodjenja = k.datumRodj;
                kr.Pol = k.Pol;
                kr.ZemljaPorekla = k.zemljaPorekla;
                kr.NazivModneKuce = k.nazivKuce;
                s.Save(kr);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static  void izmeniKreatora(KreatorBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.ModniKreator kr = s.Load<Revija.Entiteti.ModniKreator>(k.id);

                kr.Mbr = k.mbr;
                kr.Ime = k.ime;
                kr.Prezime = k.prezime;
                kr.DatRodjenja = k.datumRodj;
                kr.Pol = k.Pol;
                kr.ZemljaPorekla = k.zemljaPorekla;
                kr.NazivModneKuce = k.nazivKuce;
                s.Save(kr);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void obrisiKreatora(int id)
        {
            try {             ISession s = DataLayer.GetSession();

            Revija.Entiteti.ModniKreator o = s.Load<Revija.Entiteti.ModniKreator>(id);

            s.Delete(o);
            s.Flush();

            s.Close();
        }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
}

        #endregion
        #region PoslujeU
        public static List<PoslujeUBasic>vratiPoslujeU(int pib)
        {
            List<PoslujeUBasic> posluje = new List<PoslujeUBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.PoslujeU> svi = from o in s.Query < Revija.Entiteti.PoslujeU>()
                                                                   where o.AgencijaPoslujeU.PIB==pib
                                                                   select o;

                foreach (Revija.Entiteti.PoslujeU u in svi)
                {
                    {
                        
                        posluje.Add(new PoslujeUBasic(u.Id, u.AgencijaPoslujeU.PIB,u.NazivZemlje));

                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return posluje;
        }
        public static PoslujeUBasic vratiPosluje(int id)
        {
            PoslujeUBasic posluje = new PoslujeUBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.PoslujeU svi = (from o in s.Query<Revija.Entiteti.PoslujeU>()
                                                where o.Id == id
                                                select o).FirstOrDefault() ;

                posluje = new PoslujeUBasic(svi.Id, svi.AgencijaPoslujeU.PIB, svi.NazivZemlje);
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return posluje;
        }
        public static void obrisiZemlju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.PoslujeU p = s.Load<Revija.Entiteti.PoslujeU>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajZemlju(string naziv,int pib)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.PoslujeU p = new Revija.Entiteti.PoslujeU();
               
                Revija.Entiteti.Internacionalna a = s.Load<Revija.Entiteti.Internacionalna>(pib);

                p.AgencijaPoslujeU = a;
                p.NazivZemlje = naziv;

                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void izmeniZemlju(PoslujeUBasic pos)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.PoslujeU p = s.Load<Revija.Entiteti.PoslujeU>(pos.Id);

                p.NazivZemlje = pos.NazivZemlje;
                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        #endregion
        #region NaslovnaStrana
        public static List<NaslovnaStranaBasic> vratiSveNaslovneStrane(int id)
        {
            List<NaslovnaStranaBasic> str = new List<NaslovnaStranaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Revija.Entiteti.NaslovnaStrana> svi = from o in s.Query<Revija.Entiteti.NaslovnaStrana>()
                                                            where o.ModelNaNaslovnojStrani.Id == id
                                                            select o;

                foreach (Revija.Entiteti.NaslovnaStrana u in svi)
                {
                    {

                        str.Add(new NaslovnaStranaBasic(u.Id, u.ModelNaNaslovnojStrani.Id,u.NazivCasopisa));

                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return str;
        }
        public static void obrisiStranicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.NaslovnaStrana p = s.Load<Revija.Entiteti.NaslovnaStrana>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajNaslovnuStranu(ProfesionalniModelBasic m,string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.NaslovnaStrana p = new Revija.Entiteti.NaslovnaStrana();

                Revija.Entiteti.ProfesionalniModel a = s.Load<Revija.Entiteti.ProfesionalniModel>(m.Id);

                p.ModelNaNaslovnojStrani = a;
                p.NazivCasopisa = naziv;

                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static NaslovnaStranaBasic vratiNaslovnuStranu(int id)
        {
            NaslovnaStranaBasic str = new NaslovnaStranaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.NaslovnaStrana a = s.Load<Revija.Entiteti.NaslovnaStrana>(id);

                str.Id = a.Id;
                str.modelId = a.ModelNaNaslovnojStrani.Id;
                str.NazivCasopisa = a.NazivCasopisa;

               
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return str;
        }
        public static void IzmeniNaslovnuStranu(NaslovnaStranaBasic n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija.Entiteti.NaslovnaStrana p = s.Load<Revija.Entiteti.NaslovnaStrana>(n.Id);

                p.NazivCasopisa = n.NazivCasopisa;
                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        #endregion
    }
}
