using Revija.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revija
{
    #region ModnaRevija
    public class ModnaRevijaPregled
    {
        public int RbrRevije;
        public string Naziv;
        public string MestoOdrzavanja;
        public DateTime? DatumVremeOdrzavanja;

        public ModnaRevijaPregled()
        {

        }
        public ModnaRevijaPregled(int rbr,string naziv, string mesto, DateTime? datumvreme)
        {
            this.RbrRevije = rbr;
            this.Naziv = naziv;
            this.MestoOdrzavanja = mesto;
            this.DatumVremeOdrzavanja = datumvreme;
        }
    }
    public class ModnaRevijaBasic
    {
        public int RbrRevije;
        public string Naziv;
        public string MestoOdrzavanja;
        public DateTime? DatumVremeOdrzavanja;
        public char? PrvaZajednickaRevija;

        public virtual IList<PojavljujeSeNaBasic> VipNaReviji { get; set; }
        public virtual IList<OrganizujeBasic> OrganizovanaOdStrane { get; set; }
        public virtual IList<UcestvujeNaBasic> UcesniciRevije { get; set; }

        public ModnaRevijaBasic()
        {
            VipNaReviji = new List<PojavljujeSeNaBasic>();
            OrganizovanaOdStrane = new List<OrganizujeBasic>();
            UcesniciRevije = new List<UcestvujeNaBasic>();
        }
        public ModnaRevijaBasic(int rbr, string naziv, string mesto, DateTime? datumvreme,char? prvazaj)
        {
            this.RbrRevije = rbr;
            this.Naziv = naziv;
            this.MestoOdrzavanja = mesto;
            this.DatumVremeOdrzavanja = datumvreme;
            this.PrvaZajednickaRevija = prvazaj;
        }
    }
    #endregion
    #region Manekeni
    public class ManekenPregled
    {
        public int Id;
        public string Mbr;
        public string Ime;
        public string Prezime;
        public double? Visina;
        public double? Tezine;
        public string BojaOciju;
        public string BojaKose;
        public string KonfBroj;

        public ManekenPregled()
        {

        }
        public ManekenPregled(int id,string mbr, string ime, string prezime, double? visina, double? tezina, string oci, string kosa, string konf)
        {
            this.Id = id;
            this.Mbr = mbr;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Visina = visina;
            this.Tezine = tezina;
            this.BojaKose = kosa;
            this.BojaOciju = oci;
            this.KonfBroj = konf;
        }
    }
    public class ProfesionalniModelBasic
    {
        public int Id;
        public string Mbr;
        public string Ime;
        public string Prezime;
        public DateTime? DatRodj;
        public char Pol;
        public double Visina;
        public double Tezine;
        public string BojaOciju;
        public string BojaKose;
        public string KonfBroj;
        public int AgencijaPIB;
        public virtual IList<NaslovnaStrana> NaslovneStrane { get; set; }

        public ProfesionalniModelBasic()
        {
            NaslovneStrane = new List<NaslovnaStrana>();
        }

        public ProfesionalniModelBasic(int id,string mbr, string ime, string prezime,DateTime? datum, char pol,double visina, double tezina, string oci, string kosa, string konf, int pib)
        {
            this.Id = id;
            this.Mbr = mbr;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatRodj = datum;
            this.Pol = pol;
            this.Visina = visina;
            this.Tezine = tezina;
            this.BojaKose = kosa;
            this.BojaOciju = oci;
            this.KonfBroj = konf;
            this.AgencijaPIB =pib;
           }
    }
    public class VipPregled
    {
        public int Id;
        public string Ime;
        public string Prezime;
        public string Zanimanje;

        public VipPregled()
        {

        }
        public VipPregled(int id,string ime, string prezime,string zanimanje)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Zanimanje = zanimanje;
        }
    }
    public class VIPBasic
    {
        public int Id;
        public string Mbr;
        public string Ime;
        public string Prezime;
        public DateTime? DatRodj;
        public char Pol;
        public string Zanimanje;
        public VIPBasic()
        {

        }
        public VIPBasic(int id,string mbr, string ime, string prezime, DateTime? datum, char pol,string zanimanje)
        {
            this.Id = id;
            this.Mbr = mbr;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatRodj = datum;
            this.Pol = pol;
            this.Zanimanje = zanimanje;
        }
    }

    public class ProfesionalniModelPregled
    {
        public int Id;
        public string Mbr;
        public string Ime;
        public string Prezime;

        public ProfesionalniModelPregled()
        {

        }
        public  ProfesionalniModelPregled(int id,string mbr,string ime,string prezime)
        {
            this.Id = id;
            this.Mbr = mbr;
            this.Ime = ime;
            this.Prezime = prezime;
        }
    }
    #endregion
    #region PojavljujeSeNa
    public class PojavljujeSeNaBasic
    {

    }
    #endregion
    #region Organizuje
    public class OrganizujeBasic
    {
        public int id;
        public  KreatorBasic KreatorOrganizuje { get; set; }
        public  ModnaRevijaBasic OrganizujeRevija { get; set; }

        public OrganizujeBasic()
        {
           
        }
        public OrganizujeBasic(int id,KreatorBasic k,ModnaRevijaBasic r)
        {
            this.id = id;
            this.KreatorOrganizuje = k;
            this.OrganizujeRevija = r;
        }

    }
    #endregion
    #region UcestvujeNa
    public class UcestvujeNaBasic
    {

    }
    #endregion
    #region ModnaAgencija
    public class ModnaAgencijaBasic
    {
        public int PIB;
        public string Naziv;
        public string Sediste;
        public DateTime? DatumOsnivanja;
        public string Tip;

        public virtual IList<ProfesionalniModel> ProfesionalniModeli { get; set; }

        public ModnaAgencijaBasic()
        {
            ProfesionalniModeli = new List<ProfesionalniModel>();
        }
        public ModnaAgencijaBasic(int pib, string naziv,string sediste,DateTime? datum,string tip)
        {
            this.PIB = pib;
            this.Naziv = naziv;
            this.Sediste = sediste;
            this.DatumOsnivanja = datum;
            this.Tip = tip;

        }
    }
    public class DomacaBasic: ModnaAgencijaBasic
    {
        public DomacaBasic()
        {

        }
        public DomacaBasic(int pib, string naziv, string sediste, DateTime? datum): base(pib,naziv,sediste,datum,"DOMACA")
        {
            this.Tip = "DOMACA";
        }
    }
    public class INternacionalnaBasic : ModnaAgencijaBasic
    {
        public virtual IList<PoslujeU> AgencijaPoslujeU { get; set; }
        public INternacionalnaBasic()
        {
            AgencijaPoslujeU = new List<PoslujeU>();
        }
        public INternacionalnaBasic(int pib, string naziv, string sediste, DateTime? datum) : base(pib, naziv, sediste, datum,"INTERNACIONALNA")
        {
            AgencijaPoslujeU = new List<PoslujeU>();
            this.Tip = "INTERNACIONALNA";
        }
    }
    public class ModnaAgencijaPregled
    {
        public int PIB;
        public string Naziv;
        public string Sediste;
        public string Tip;

        public ModnaAgencijaPregled()
        {

        }
        public ModnaAgencijaPregled(int pib,string naziv,string sediste)
        {
            this.PIB = pib;
            this.Naziv = naziv;
            this.Sediste = sediste;
        }
    }
    public class DomacaPregled : ModnaAgencijaPregled
    {
        public DomacaPregled()
        {

        }
        public DomacaPregled(int pib, string naziv, string sediste) : base(pib, naziv, sediste)
        {
            this.Tip = "DOMACA";
        }
    }
    public class INternacionalnaPregled : ModnaAgencijaPregled
    {
        public virtual IList<PoslujeU> AgencijaPoslujeU { get; set; }
        public INternacionalnaPregled()
        {
            AgencijaPoslujeU = new List<PoslujeU>();
        }
        public INternacionalnaPregled(int pib, string naziv, string sediste) : base(pib, naziv, sediste)
        {
            this.Tip = "INTERNACIONALNA";
            AgencijaPoslujeU = new List<PoslujeU>();
        }
    }
    #endregion
    #region Kreator
    public class KreatorPregled
    {
        public int id;
        public string ime;
        public string prezime;
        public string zemljaPorekla;
        public string nazivKuce;

        public KreatorPregled()
        {

        }
        public KreatorPregled(int id, string ime,string przime,string zelja,string naziv)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = przime;
            this.zemljaPorekla = zelja;
            this.nazivKuce = naziv;
        }
    }

    public class KreatorBasic
    {
        public int id;
        public string mbr;
        public string ime;
        public string prezime;
        public DateTime? datumRodj;
        public char Pol;
        public string zemljaPorekla;
        public string nazivKuce;

        public KreatorBasic()
        {

        }
        public KreatorBasic(int id,string mbr, string ime, string przime,DateTime? dat,char pol, string zelja, string naziv)
        {
            this.id = id;
            this.mbr = mbr;
            this.ime = ime;
            this.prezime = przime;
            this.datumRodj = dat;
            this.Pol = pol;
            this.zemljaPorekla = zelja;
            this.nazivKuce = naziv;
        }
    }
    #endregion
    #region POslujeU
    public class PoslujeUBasic
    {
        public int Id;

        public int AgencijaPIB;
        public  string NazivZemlje { get; set; }
        public PoslujeUBasic()
        {

        }
        public PoslujeUBasic(int id, int pib, string zemlje)
        {
            this.Id = id;
            this.AgencijaPIB = pib;
            this.NazivZemlje = zemlje;
        }
    }
    #endregion
    #region NaslovnaStrana
    public class NaslovnaStranaBasic
    {
        public int Id;

        public int modelId;
        public string NazivCasopisa;

        public NaslovnaStranaBasic()
        {

        }
        public NaslovnaStranaBasic(int id, int p,string n)
        {
            this.Id = id;
            this.modelId = p;
            this.NazivCasopisa = n;
        }
    }
    #endregion
}
