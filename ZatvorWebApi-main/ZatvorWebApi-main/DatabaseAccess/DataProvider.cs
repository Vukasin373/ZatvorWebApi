using DatabaseAccess.DTOs;
using NHibernate;
using System;
using System.Collections.Generic;
using Zatvor;
using Zatvor.Entiteti;
using System.Linq;

namespace DatabaseAccess
{
    public class DataProvider
    {
        #region Advokat

        public static List<AdvokatView> GetAdvokati()
        {
            List<AdvokatView> AdInfos = new List<AdvokatView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Advokat> advokati = from o in s.Query<Advokat>()
                                                select o;
                if (advokati != null)
                {
                    foreach (Advokat a in advokati)
                    {
                        IEnumerable<Zastupa> zastupas = from z in s.Query<Zastupa>()
                                                        where z.Advokat.Id == a.Id
                                                        select z;

                        //a.Zastupa = new List<Zastupa>();

                        //foreach(Zastupa z in zastupas)
                        //{
                        //    a.Zastupa.Add(z);
                        //}
                        
                        AdInfos.Add(new AdvokatView(a));
                    }
                }
                s.Close();
            }
            catch (Exception )
            {
                //handle exceptions
                throw;
            }
            return AdInfos;
        }

        public static void SacuvajAdvokata(AdvokatView advokat)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Advokat a = new Advokat
                {
                    Jmbg = advokat.Jmbg,
                    Ime = advokat.Ime,
                    Prezime = advokat.Prezime,
                    Pol = advokat.Pol
                };

                s.Save(a);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiAdvokata(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Advokat advokat = s.Load<Advokat>(id);

                s.Delete(advokat);
                s.Flush();

                s.Close();
            }
            catch(Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniAdvokata(AdvokatView advokat)
        {
            try { 
            ISession s = DataLayer.GetSession();

            Advokat a = s.Load<Advokat>(advokat.Id);

            a.Jmbg = advokat.Jmbg;
            a.Ime = advokat.Ime;
            a.Prezime = advokat.Prezime;
            a.Pol = advokat.Pol;

            s.SaveOrUpdate(a);
            s.Flush();
            s.Close();
            }
            catch(Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion Advokat

        #region DozvolaZaOruzje

        public static DozvolaZaOruzjeView VratiDozvoluZaOruzje(int id)
        {
           
            try
            {
                ISession s = DataLayer.GetSession();
                DozvolaZaOruzje dozvola = s.Load<DozvolaZaOruzje>(id);
                DozvolaZaOruzjeView d = new DozvolaZaOruzjeView(dozvola);

                //d.Datum = dozvola.Datum;
                //d.SifraDozvole = dozvola.SifraDozvole;
                //d.PolicijskaUprava = d.PolicijskaUprava;

                s.Close();
                return d;
            }
            catch(Exception)
            {
                //handle exceptions
                throw;
            }
     
        }

        public static void DodajDozvoluZaOruzje(DozvolaZaOruzjeView dozvola, int zaposleniId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni zaposleni = s.Load<Zaposleni>(zaposleniId);
                if (zaposleni.NazivRadnogMesta != "Obezbedjenje")
                    throw new Exception("Ovaj tip zaposlenog ne moze da izvadi dozvolu za oruzje !");

                DozvolaZaOruzje l = new DozvolaZaOruzje
                {
                    SifraDozvole = dozvola.SifraDozvole,
                    Datum = dozvola.Datum,
                    PolicijskaUprava = dozvola.PolicijskaUprava,
                    Zaposleni = zaposleni
                };



                s.SaveOrUpdate(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
       
        public static void IzmeniDozvoluZaOruzje(DozvolaZaOruzjeView dozvola)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                DozvolaZaOruzje d = s.Load<DozvolaZaOruzje>(dozvola.Id);

                d.Datum = dozvola.Datum;
                d.SifraDozvole = dozvola.SifraDozvole;
                d.PolicijskaUprava = dozvola.PolicijskaUprava;

                s.SaveOrUpdate(d);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiDozvoluZaOruzje(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DozvolaZaOruzje dozvola = s.Load<DozvolaZaOruzje>(id);

                s.Delete(dozvola);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion DozvolaZaOruzje

        #region Firma

        public static List<FirmaView> GetFirme()
        {
            List<FirmaView> FiInfos = new List<FirmaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Firma> firme = from o in s.Query<Firma>()
                                                select o;
                if (firme != null)
                {
                    foreach (Firma f in firme)
                        FiInfos.Add(new FirmaView(f));
                }
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return FiInfos;
        }

        public static void SacuvajFirmu(FirmaView firma)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma f = new Firma
                {
                    Pib = firma.Pib,
                    ImeFirme = firma.ImeFirme
                };

                s.Save(f);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniFirmu(int id, FirmaView firma)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Firma f = s.Load<Firma>(id);

                f.Pib = firma.Pib;
                f.ImeFirme = firma.ImeFirme;

                s.SaveOrUpdate(f);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiFirmu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma firma = s.Load<Firma>(id);

                s.Delete(firma);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion Firma

        #region FirmaKontakt

        public static List<FirmaKontaktView> GetKontaktiFirme(int firmaId)
        {
            List<FirmaKontaktView> fiInfos = new List<FirmaKontaktView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<FirmaKontakt> firmaKontakts = from f in s.Query<FirmaKontakt>()
                                                   where f.Firma.Id == firmaId
                                                   select f;

                foreach (FirmaKontakt f in firmaKontakts)
                {
                    fiInfos.Add(new FirmaKontaktView(f));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return fiInfos;
        }

        public static void SacuvajFirmaKontakt(FirmaKontaktView firmaKontakt, int idFirme)
        {
            try
            {
                ISession s = DataLayer.GetSession();

 
                IQuery q = s.CreateQuery("from FirmaKontakt as o where o.Firma.Id = ? and o.KontaktTelefon = ?");
                q.SetInt32(0, idFirme);
                q.SetParameter(1, firmaKontakt.KontaktTelefon);

                IList<FirmaKontakt> kont = q.List<FirmaKontakt>();

                if (kont.Count != 0)
                {
                    throw new Exception("Ovaj kontakt je vec memorisan !");
                }

                Firma firma = s.Load<Firma>(idFirme);

                FirmaKontakt f = new FirmaKontakt
                {
                    KontaktTelefon = firmaKontakt.KontaktTelefon,
                    Firma = firma
                };

                s.Save(f);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        

        public static void IzmeniFirmaKontakt(FirmaKontaktView firmaKontakt)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from FirmaKontakt as o where o.KontaktTelefon = ?");
                q.SetParameter(0, firmaKontakt.KontaktTelefon);

                IList<FirmaKontakt> kont = q.List<FirmaKontakt>();

                if (kont.Count != 0)
                {
                    throw new Exception("Ovaj kontakt je vec memorisan, greska !");
                }

                FirmaKontakt f = s.Load<FirmaKontakt>(firmaKontakt.Id);

                f.KontaktTelefon = firmaKontakt.KontaktTelefon;

                s.SaveOrUpdate(f);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiFirmaKontakt(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FirmaKontakt firmaKontakt = s.Load<FirmaKontakt>(id);

                s.Delete(firmaKontakt);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion FirmaKontakt

        #region FirmaOdgovornaLica

        public static List<FirmaOdgovornaLicaView> GetOdgovornaLicaFirme(int firmaId)
        {
            List<FirmaOdgovornaLicaView> fiInfos = new List<FirmaOdgovornaLicaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<FirmaOdgovornaLica> firmaOdgovornaLica = from f in s.Query<FirmaOdgovornaLica>()
                                                                     where f.Firma.Id == firmaId
                                                                     select f;

                foreach (FirmaOdgovornaLica f in firmaOdgovornaLica)
                {
                    fiInfos.Add(new FirmaOdgovornaLicaView(f));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return fiInfos;
        }

        public static void SacuvajFirmaOdgovornoLice(FirmaOdgovornaLicaView firmaOdgovornoLice, int idFirme)
        {
            try
            {
                ISession s = DataLayer.GetSession();

               
                IQuery q = s.CreateQuery("from FirmaOdgovornaLica as o where o.Firma.Id = ? and o.OdgovornoLice = ?");
                q.SetInt32(0, idFirme);
                q.SetParameter(1, firmaOdgovornoLice.OdgovornoLice);

                IList<FirmaOdgovornaLica> kont = q.List<FirmaOdgovornaLica>();

                if (kont.Count != 0)
                {
                    throw new Exception("Ovo odgovorno lice je vec memorisano !");
                }

                Firma firma = s.Load<Firma>(idFirme);

                FirmaOdgovornaLica f = new FirmaOdgovornaLica
                {
                    OdgovornoLice = firmaOdgovornoLice.OdgovornoLice,
                    Firma = firma
                };

                s.Save(f);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniFirmaOdgovornoLice(FirmaOdgovornaLicaView firmaOdgovornoLice)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                FirmaOdgovornaLica f = s.Load<FirmaOdgovornaLica>(firmaOdgovornoLice.Id);

                f.OdgovornoLice = firmaOdgovornoLice.OdgovornoLice;

                s.SaveOrUpdate(f);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiFirmaOdgovornoLice(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FirmaOdgovornaLica firmaOdgovornoLice = s.Load<FirmaOdgovornaLica>(id);

                s.Delete(firmaOdgovornoLice);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion FirmaOdgovornaLica

        #region LekarskiPregled

        public static LekarskiPregledView GetLekarskiPregled(int id)
        {
            

            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled lekarskiPregled = s.Load<LekarskiPregled>(id);

                LekarskiPregledView l = new LekarskiPregledView(lekarskiPregled);

                //l.NazivUstanove = lekarskiPregled.NazivUstanove;
                //l.Datum = lekarskiPregled.Datum;
                //l.AdresaUstanove = lekarskiPregled.AdresaUstanove;
                //l.Lekar = lekarskiPregled.Lekar;
              
                s.Close();
                return l;
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
         
        }

        public static void DodajLekarskiPregled(LekarskiPregledView pregled, int zaposleniId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni zaposleni = s.Load<Zaposleni>(zaposleniId);
                if(zaposleni.NazivRadnogMesta=="Administracija" || zaposleni.NazivRadnogMesta== "Upravnik")
                    throw new Exception("Ovaj tip zaposlenog ne moze da izvadi lekarski pregled !");

                LekarskiPregled l = new LekarskiPregled
                {               
                    NazivUstanove = pregled.NazivUstanove,
                    Datum = pregled.Datum,
                    AdresaUstanove = pregled.AdresaUstanove,
                    Lekar = pregled.Lekar,
                    Zaposleni = zaposleni
                };


              
                s.SaveOrUpdate(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniLekarskiPregled(LekarskiPregledView pregled)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                LekarskiPregled l = s.Load<LekarskiPregled>(pregled.Id);

                l.NazivUstanove = pregled.NazivUstanove;
                l.Datum = pregled.Datum;
                l.AdresaUstanove = pregled.AdresaUstanove;
                l.Lekar = pregled.Lekar;

                s.SaveOrUpdate(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiLekarskiPregled(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled pregled = s.Load<LekarskiPregled>(id);

                s.Delete(pregled);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion LekarskiPregled

        #region Pocinio

       
        public static List<PocinioView> GetZatvorenikPocinio(int ZatvorenikId)
        {
            List<PocinioView> prInfos = new List<PocinioView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Pocinio> prestupi = from p in s.Query<Pocinio>()
                                                where p.Zatvorenik.Id == ZatvorenikId
                                                select p;

                foreach (Pocinio p in prestupi)
                {
                    prInfos.Add(new PocinioView(p));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return prInfos;
        }

        public static void SacuvajPocinio(PocinioView pocinio)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pocinio f = new Pocinio
                {
                    Datum = pocinio.Datum,
                    MestoPrestupa = pocinio.MestoPrestupa,
                    Zatvorenik = s.Load<Zatvorenik>(pocinio.Zatvorenik.Id),
                    Prestup = s.Load<Prestup>(pocinio.Prestup.Id)
                };

                s.Save(f);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DeletePocinio(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Pocinio pocinio = s.Load<Pocinio>(Id);

                s.Delete(pocinio);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion Pocinio

        #region Posecuje
        public static void SacuvajPosecuje(PosecujeView pos)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Zastupa as o where o.Advokat.Id = ? and o.Zatvorenik.Id = ?");
                q.SetInt32(0, pos.Advokat.Id);
                q.SetInt32(1, pos.Zatvorenik.Id);
              
                Zastupa zast = q.UniqueResult<Zastupa>();
                if (zast == null)
                {
                    throw new Exception("Poseta nije moguca jer ovaj advokat ne zastupa ovog zatvorenika !");
                }

                Posecuje p = new Posecuje
                {
                    VremePocetka = pos.VremePocetka,
                    VremeKraja = pos.VremeKraja,
                    Zatvorenik = s.Load<Zatvorenik>(pos.Zatvorenik.Id),
                    Advokat = s.Load<Advokat>(pos.Advokat.Id)
                };

                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static List<PosecujeView> GetZatvorenikPosecuje(int ZatvorenikId)
        {
            List<PosecujeView> prInfos = new List<PosecujeView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Posecuje> posete = from p in s.Query<Posecuje>()
                                                where p.Zatvorenik.Id == ZatvorenikId
                                                select p;

                foreach (Posecuje p in posete)
                {
                    prInfos.Add(new PosecujeView(p));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return prInfos;
        }
        public static void DeletePosecuje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Posecuje posecuje = s.Load<Posecuje>(Id);

                s.Delete(posecuje);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion Posecuje

        #region Prestup

        public static List<PrestupView> GetPrestupi()
        {
            List<PrestupView> PrInfos = new List<PrestupView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Prestup> prestupi = from p in s.Query<Prestup>()
                                                select p;
                if (prestupi != null)
                {
                    foreach (Prestup p in prestupi)
                        PrInfos.Add(new PrestupView(p));
                }
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return PrInfos;
        }

        public static void SacuvajPrestup(PrestupView prestup)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup p = new Prestup
                {
                    Naziv = prestup.Naziv,
                    Opis = prestup.Opis,
                    MinimalnaKazna = prestup.MinimalnaKazna,
                    MaximalnaKazna = prestup.MaximalnaKazna,
                    Kategorija = prestup.Kategorija
                };

                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniPrestup(PrestupView prestup)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup p = s.Load<Prestup>(prestup.Id);

                p.Naziv = prestup.Naziv;
                p.Opis = prestup.Opis;
                p.MinimalnaKazna = prestup.MinimalnaKazna;
                p.MaximalnaKazna = prestup.MaximalnaKazna;
                p.Kategorija = prestup.Kategorija;

                s.SaveOrUpdate(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiPrestup(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup prestup = s.Load<Prestup>(id);

                s.Delete(prestup);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion Prestup

        #region Saradjuje
        public static void SacuvajSaradjuje(SaradjujeView saradjuje, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma f = s.Load<Firma>(id);
                ZatvorskaJedinica z= s.Load<ZatvorskaJedinica>(saradjuje.ZatvorskaJedinica.Id);

                if (z.OtvoreniF == 'N')
                    throw new Exception("Zatvor mora da bude otvorenog tipa da bi mogao da saradjuje sa firmama !");

                IQuery q = s.CreateQuery("from Saradjuje as o where o.Firma.Id = ? and o.ZatvorskaJedinica.Id = ?");
                q.SetInt32(0, f.Id);
                q.SetInt32(1, z.Id);

                IList<Saradjuje> saradj = q.List<Saradjuje>();

                if (saradj.Count != 0)
                {
                    throw new Exception("Ovaj zatvor i ova firma vec saradjuju !");
                }

                Saradjuje sar = new Saradjuje
                {
                    Firma = f,
                    ZatvorskaJedinica = z
                };

                s.Save(sar);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DeleteSaradjuje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Saradjuje saradjuje = s.Load<Saradjuje>(Id);

                s.Delete(saradjuje);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static List<SaradjujeView> GetFirmaSaradjuje(int ZatvorId)
        {
            List<SaradjujeView> prInfos = new List<SaradjujeView>();

            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(ZatvorId);
                if (zatvor.OtvoreniF != 'Y')
                    throw new Exception("Samo otvorena zatvorska jedinica ima saradnju sa firmama!");

                IEnumerable < Saradjuje > firme = from f in s.Query<Saradjuje>()
                                                  where f.ZatvorskaJedinica.Id == ZatvorId
                                                  select f;

                foreach (Saradjuje f in firme)
                {
                    prInfos.Add(new SaradjujeView(f));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return prInfos;
        }

        #endregion Saradjuje

        #region StrogTerminPosete
        public static List<StrogTerminView> GetTerminPoseteZatvora(int ZatvorId)
        {
            List<StrogTerminView> prInfos = new List<StrogTerminView>();

            try
            {
                ISession s = DataLayer.GetSession();

                if (s.Load<ZatvorskaJedinica>(ZatvorId).StrogiF != 'Y')
                    throw new Exception("Zatvor mora biti strogog tipa");

                IEnumerable<StrogTerminPosete> termini = from p in s.Query<StrogTerminPosete>()
                                                where p.Zatvor.Id == ZatvorId
                                                select p;

                foreach (StrogTerminPosete p in termini)
                {
                    prInfos.Add(new StrogTerminView(p));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return prInfos;
        }

        public static void SacuvajTerminPosete(StrogTerminView termin)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(termin.Zatvor.Id);
                if (zatvor.OtvoreniF != 'N')
                    throw new Exception("Mora biti zatvor otvorenog tipa");

                StrogTerminPosete f = new StrogTerminPosete
                {
                    TerminPosete = termin.TerminPosete,
                    Zatvor = zatvor
                };

                s.Save(f);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DeleteTerminPosete(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                StrogTerminPosete termin = s.Load<StrogTerminPosete>(Id);

                s.Delete(termin);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion StrogTerminPosete

        #region Zaposleni
        #region ZaposleniGeneralneFunkcije
        public static List<ZaposleniView> VratiSveZaposlene()
        {
            List<ZaposleniView> zaposleni = new List<ZaposleniView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zaposleni> sviUpravnici = from o in s.Query<Upravnik>()
                                                      select o;
                IEnumerable<Zaposleni> sviAdministratori = from o in s.Query<ZaposlenUAdministraciji>()
                                                           select o;
                IEnumerable<Zaposleni> sviObezbedjenje = from o in s.Query<Radnik_obezbedjenja>()
                                                         select o;
                IEnumerable<Zaposleni> sviPsiholozi = from o in s.Query<Psiholog>()
                                                      select o;

                foreach (Zaposleni p in sviAdministratori)
                {
                    zaposleni.Add(new ZaposlenUAdministracijaView(p));
                }
                foreach (Zaposleni p in sviObezbedjenje)
                {
                    zaposleni.Add(new ZaposleniRadnikObezbedjenjaView(p));
                }
                foreach (Zaposleni p in sviPsiholozi)
                {
                    zaposleni.Add(new ZaposleniPsihologView(p));
                }
                foreach (Zaposleni p in sviUpravnici)
                {
                    zaposleni.Add(new ZaposleniUpravnikView(p));
                }


                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleni;
        }

        public static ZaposleniView AzurirajZaposleni(ZaposleniView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni o = s.Load<Zaposleni>(p.Id);
                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(o.ZatvorskaJedinica.Id);
                o.Id = p.Id;
                o.Ime = p.Ime;
                o.Prezime = p.Prezime;
                o.Jmbg = p.Jmbg;
                o.Pol = p.Pol;
                o.NazivRadnogMesta = p.NazivRadnogMesta;
                o.DatumPPZ = p.DatumPPZ;
                o.DatumPocetkaRada = p.DatumPocetkaRada;
                o.APozicija = p.APozicija;
                o.AStrucnaSprema = p.AStrucnaSprema;
                o.AZanimanje = p.AZanimanje;
                o.ZatvorskaJedinica = zatvor;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZaposleniView VratiZaposleni(int id)
        {
            ZaposleniView zaposleniView;

            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni o = s.Load<Zaposleni>(id);
                zaposleniView = new ZaposleniView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleniView;
        }
        public static void ObrisiZaposleni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni o = s.Load<Zaposleni>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region Psiholog
        public static List<ZaposleniPsihologView> VratiSvePsiholog()
        {
            List<ZaposleniPsihologView> zaposleni = new List<ZaposleniPsihologView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Psiholog> sviPsiholog = from o in s.Query<Psiholog>()
                                                      select o;

                foreach (Psiholog p in sviPsiholog)
                {
                    zaposleni.Add(new ZaposleniPsihologView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleni;
        }
        public static void DodajPsiholog(ZaposleniPsihologView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(p.ZatvorskaJedinica.Id);
                Psiholog o = new Psiholog
                {
                    Id = p.Id,
                    Jmbg = p.Jmbg,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Pol = p.Pol,
                    DatumPPZ = p.DatumPPZ,
                    DatumPocetkaRada = p.DatumPocetkaRada,
                    APozicija = null,
                    AStrucnaSprema = null,
                    AZanimanje = null,
                    NazivRadnogMesta = p.NazivRadnogMesta,
                    ZatvorskaJedinica = zatvor
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZaposleniPsihologView AzurirajPsiholog(ZaposleniPsihologView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Psiholog o = s.Load<Psiholog>(p.Id);
                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(o.ZatvorskaJedinica.Id);
                o.Id = p.Id;
                o.Ime = p.Ime;
                o.Prezime = p.Prezime;
                o.Jmbg = p.Jmbg;
                o.Pol = p.Pol;
                o.NazivRadnogMesta = p.NazivRadnogMesta;
                o.DatumPPZ = p.DatumPPZ;
                o.DatumPocetkaRada = p.DatumPocetkaRada;
                o.APozicija = p.APozicija;
                o.AStrucnaSprema = p.AStrucnaSprema;
                o.AZanimanje = p.AZanimanje;
                o.ZatvorskaJedinica = zatvor;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZaposleniPsihologView VratiPsiholog(int id)
        {
            ZaposleniPsihologView zaposleniView;

            try
            {
                ISession s = DataLayer.GetSession();

                Psiholog o = s.Load<Psiholog>(id);
                zaposleniView = new ZaposleniPsihologView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleniView;
        }
        public static void ObrisiPsiholog(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Psiholog o = s.Load<Psiholog>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region RadnikObezbedjenja
        public static List<ZaposleniRadnikObezbedjenjaView> VratiSveRadnikObezbedjenja()
        {
            List<ZaposleniRadnikObezbedjenjaView> zaposleni = new List<ZaposleniRadnikObezbedjenjaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Radnik_obezbedjenja> sviRadnikObezbedjenja = from o in s.Query<Radnik_obezbedjenja>()
                                                    select o;

                foreach (Radnik_obezbedjenja p in sviRadnikObezbedjenja)
                {
                    zaposleni.Add(new ZaposleniRadnikObezbedjenjaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleni;
        }
        public static void DodajRadnikObezbedjenja(ZaposleniRadnikObezbedjenjaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(p.ZatvorskaJedinica.Id);
                Radnik_obezbedjenja o = new Radnik_obezbedjenja
                {
                    Id = p.Id,
                    Jmbg = p.Jmbg,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Pol = p.Pol,
                    DatumPPZ = p.DatumPPZ,
                    DatumPocetkaRada = p.DatumPocetkaRada,
                    APozicija = null,
                    AStrucnaSprema = null,
                    AZanimanje = null,
                    NazivRadnogMesta = p.NazivRadnogMesta,
                    ZatvorskaJedinica = zatvor
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZaposleniRadnikObezbedjenjaView AzurirajRadnikObezbedjenja(ZaposleniRadnikObezbedjenjaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Radnik_obezbedjenja o = s.Load<Radnik_obezbedjenja>(p.Id);
                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(o.ZatvorskaJedinica.Id);
                o.Id = p.Id;
                o.Ime = p.Ime;
                o.Prezime = p.Prezime;
                o.Jmbg = p.Jmbg;
                o.Pol = p.Pol;
                o.NazivRadnogMesta = p.NazivRadnogMesta;
                o.DatumPPZ = p.DatumPPZ;
                o.DatumPocetkaRada = p.DatumPocetkaRada;
                o.APozicija = p.APozicija;
                o.AStrucnaSprema = p.AStrucnaSprema;
                o.AZanimanje = p.AZanimanje;
                o.ZatvorskaJedinica = zatvor;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZaposleniRadnikObezbedjenjaView VratiRadnikObezbedjenja(int id)
        {
            ZaposleniRadnikObezbedjenjaView zaposleniView;

            try
            {
                ISession s = DataLayer.GetSession();

                Radnik_obezbedjenja o = s.Load<Radnik_obezbedjenja>(id);
                zaposleniView = new ZaposleniRadnikObezbedjenjaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleniView;
        }
        public static void ObrisiRadnikObezbedjenja(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Radnik_obezbedjenja o = s.Load<Radnik_obezbedjenja>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region Upravnik
        public static List<ZaposleniUpravnikView> VratiSveUpravnik()
        {
            List<ZaposleniUpravnikView> zaposleni = new List<ZaposleniUpravnikView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Upravnik> sviUpravnik = from o in s.Query<Upravnik>()
                                                    select o;

                foreach (Upravnik p in sviUpravnik)
                {
                    zaposleni.Add(new ZaposleniUpravnikView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleni;
        }
        public static void DodajUpravnik(ZaposleniUpravnikView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(p.ZatvorskaJedinica.Id);
                Upravnik o = new Upravnik
                {
                    Id = p.Id,
                    Jmbg = p.Jmbg,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Pol = p.Pol,
                    DatumPPZ = p.DatumPPZ,
                    DatumPocetkaRada = p.DatumPocetkaRada,
                    APozicija = null,
                    AStrucnaSprema = null,
                    AZanimanje = null,
                    NazivRadnogMesta = p.NazivRadnogMesta,
                    ZatvorskaJedinica = zatvor
                };
                zatvor.Upravnik = o;
                
                s.Update(zatvor);
                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZaposleniUpravnikView AzurirajUpravnik(ZaposleniUpravnikView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Upravnik o = s.Load<Upravnik>(p.Id);
                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(o.ZatvorskaJedinica.Id);
                o.Id = p.Id;
                o.Ime = p.Ime;
                o.Prezime = p.Prezime;
                o.Jmbg = p.Jmbg;
                o.Pol = p.Pol;
                o.NazivRadnogMesta = p.NazivRadnogMesta;
                o.DatumPPZ = p.DatumPPZ;
                o.DatumPocetkaRada = p.DatumPocetkaRada;
                o.APozicija = p.APozicija;
                o.AStrucnaSprema = p.AStrucnaSprema;
                o.AZanimanje = p.AZanimanje;
                o.ZatvorskaJedinica = zatvor;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZaposleniUpravnikView VratiUpravnik(int id)
        {
            ZaposleniUpravnikView zaposleniView;

            try
            {
                ISession s = DataLayer.GetSession();

                Upravnik o = s.Load<Upravnik>(id);
                zaposleniView = new ZaposleniUpravnikView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleniView;
        }
        public static void ObrisiUpravnik(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Upravnik o = s.Load<Upravnik>(id);
                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(o.ZatvorskaJedinica.Id);
                zatvor.Upravnik = null;

                s.Update(zatvor);
                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region UAdministracija
        public static List<ZaposlenUAdministracijaView> VratiSveUAdministracija()
        {
            List<ZaposlenUAdministracijaView> zaposleni = new List<ZaposlenUAdministracijaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZaposlenUAdministraciji> sviUAdministracija = from o in s.Query<ZaposlenUAdministraciji>()
                                                    select o;

                foreach (ZaposlenUAdministraciji p in sviUAdministracija)
                {
                    zaposleni.Add(new ZaposlenUAdministracijaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleni;
        }
        public static void DodajUAdministracija(ZaposlenUAdministracijaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(p.ZatvorskaJedinica.Id);
                ZaposlenUAdministraciji o = new ZaposlenUAdministraciji
                {
                    Id = p.Id,
                    Jmbg = p.Jmbg,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Pol = p.Pol,
                    DatumPPZ = p.DatumPPZ,
                    DatumPocetkaRada = p.DatumPocetkaRada,
                    APozicija = p.APozicija,
                    AStrucnaSprema = p.AStrucnaSprema,
                    AZanimanje = p.AZanimanje,
                    NazivRadnogMesta = p.NazivRadnogMesta,
                    ZatvorskaJedinica = zatvor
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZaposlenUAdministracijaView AzurirajUAdministracija(ZaposlenUAdministracijaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZaposlenUAdministraciji o = s.Load<ZaposlenUAdministraciji>(p.Id);
                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(o.ZatvorskaJedinica.Id);
                o.Id = p.Id;
                o.Ime = p.Ime;
                o.Prezime = p.Prezime;
                o.Jmbg = p.Jmbg;
                o.Pol = p.Pol;
                o.NazivRadnogMesta = p.NazivRadnogMesta;
                o.DatumPPZ = p.DatumPPZ;
                o.DatumPocetkaRada = p.DatumPocetkaRada;
                o.APozicija = p.APozicija;
                o.AStrucnaSprema = p.AStrucnaSprema;
                o.AZanimanje = p.AZanimanje;
                o.ZatvorskaJedinica = zatvor;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZaposlenUAdministracijaView VratiUAdministracija(int id)
        {
            ZaposlenUAdministracijaView zaposleniView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZaposlenUAdministraciji o = s.Load<ZaposlenUAdministraciji>(id);
                zaposleniView = new ZaposlenUAdministracijaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zaposleniView;
        }
        public static void ObrisiUAdministracija(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZaposlenUAdministraciji o = s.Load<ZaposlenUAdministraciji>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion
        #endregion

        #region Zastupa

        public static void SacuvajZastupa(ZastupaView zas)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik z = s.Load<Zatvorenik>(zas.Zatvorenik.Id);


                Advokat a = s.Load<Advokat>(zas.Advokat.Id);


                IQuery q = s.CreateQuery("from Zastupa as o where o.Advokat.Id = ? and o.Zatvorenik.Id = ?");
                q.SetInt32(0, a.Id);
                q.SetInt32(1, z.Id);

                IList<Zastupa> zastupa = q.List<Zastupa>();

                if (zastupa.Count != 0)
                {
                    throw new Exception("Advokat je vec angazovan !");
                }

                Zastupa zastupaa = new Zastupa
                {
                    ZastupaOd = zas.ZastupaOd,
                    DatumPoslednjegKontakta = zas.DatumPoslednjegKontakta,
                    Zatvorenik = z,
                    Advokat = a
                };

                s.Save(zastupaa);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static List<ZastupaView> GetZastupa(int ZatvorenikId)
        {
            List<ZastupaView> prInfos = new List<ZastupaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zastupa> zastupa = from z in s.Query<Zastupa>()
                                               where z.Zatvorenik.Id == ZatvorenikId
                                               select z;

                foreach (Zastupa z in zastupa)
                {
                    Advokat a = s.Load<Advokat>(z.Advokat.Id);
                    z.Advokat = a;
                    
                    Zatvorenik zat = s.Load<Zatvorenik>(z.Zatvorenik.Id);
                    z.Zatvorenik = zat;

                    prInfos.Add(new ZastupaView(z));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return prInfos;
        }

        public static void DeleteZastupa(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zastupa zastupa = s.Load<Zastupa>(Id);

                s.Delete(zastupa);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion Zastupa

        #region Zatvorenik
        public static void ObrisiZatvorenika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik zatvorenik = s.Load<Zatvorenik>(id);

                s.Delete(zatvorenik);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static ZatvorenikView VratiZatvorenika(int id)
        {
            ZatvorenikView o = new ZatvorenikView(new Zatvorenik());

            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik zatvorenik = s.Load<Zatvorenik>(id);
                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(zatvorenik.ZatvorskaJedinica.Id);

                o.Id = zatvorenik.Id;
                o.Jmbg = zatvorenik.Jmbg;
                o.Ime = zatvorenik.Ime;
                o.Prezime = zatvorenik.Prezime;
                o.Adresa = zatvorenik.Adresa;
                o.Pol = zatvorenik.Pol;
                o.Broj = zatvorenik.Broj;
                o.DatumSaslusanja = zatvorenik.DatumSaslusanja;
                o.StatusUslovnogOtpusta = zatvorenik.StatusUslovnogOtpusta;
                o.ZatvorskaJedinica = new ZatvorskaJedinicaView(zatvor);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return o;
        }

        public static List<ZatvorenikView> VratiZatvorenikeZatvora(int zatvorId)
        {
            List<ZatvorenikView> zatvorenici = new List<ZatvorenikView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zatvorenik> zatvorenik = from o in s.Query<Zatvorenik>()
                                                          where o.ZatvorskaJedinica.Id == zatvorId
                                                          select o;


                foreach (Zatvorenik o in zatvorenik)
                {
                    zatvorenici.Add(new ZatvorenikView(o));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorenici;
        }
        public static void IzmeniZatvorenika(ZatvorenikView zatvorenik)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik o = s.Load<Zatvorenik>(zatvorenik.Id);
                ZatvorskaJedinica zatvor = s.Load<ZatvorskaJedinica>(zatvorenik.ZatvorskaJedinica.Id);

                o.Jmbg = zatvorenik.Jmbg;
                o.Ime = zatvorenik.Ime;
                o.Prezime = zatvorenik.Prezime;
                o.Adresa = zatvorenik.Adresa;
                o.Pol = zatvorenik.Pol;
                o.Broj = zatvorenik.Broj;
                o.DatumSaslusanja = zatvorenik.DatumSaslusanja;
                o.StatusUslovnogOtpusta = zatvorenik.StatusUslovnogOtpusta;
                o.ZatvorskaJedinica = zatvor;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static void SacuvajZatvorenika(ZatvorenikView zatvorenik)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik o = new Zatvorenik();
                ZatvorskaJedinica z = s.Load<ZatvorskaJedinica>(zatvorenik.ZatvorskaJedinica.Id);

                o.Jmbg = zatvorenik.Jmbg;
                o.Ime = zatvorenik.Ime;
                o.Prezime = zatvorenik.Prezime;
                o.Adresa = zatvorenik.Adresa;
                o.Pol = zatvorenik.Pol;
                o.Broj = zatvorenik.Broj;
                o.DatumSaslusanja = zatvorenik.DatumSaslusanja;
                o.StatusUslovnogOtpusta = zatvorenik.StatusUslovnogOtpusta;
                o.ZatvorskaJedinica = z;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

      
        #endregion Zatvorenik

        #region ZatvorskaJedinica
        #region ZatvorksaJedinicaGeneralneFunkcije
        public static List<ZatvorskaJedinicaView> VratiSveZatvorskeJedinice()
        {
            List<ZatvorskaJedinicaView> zatvori = new List<ZatvorskaJedinicaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZatvorskaJedinica> sveZatvorskaJedinica = from o in s.Query<ZatvorskaJedinica>()
                                                    select o;

                foreach (ZatvorskaJedinica p in sveZatvorskaJedinica)
                {
                    zatvori.Add(new ZatvorskaJedinicaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvori;
        }

        public static List<ZaposleniView> VratiSveZaposleneZatvora(int id)
        {
            List<ZaposleniView> sviZaposleni = new List<ZaposleniView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zaposleni> zaposleni = from o in s.Query<Zaposleni>()
                                                     where o.ZatvorskaJedinica.Id == id
                                                     select o;


                foreach (Zaposleni o in zaposleni)
                {
                    sviZaposleni.Add(new ZaposleniView(o));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return sviZaposleni;
        }
        public static void DodajZatvorskaJedinica(ZatvorskaJedinicaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica o = new ZatvorskaJedinica
                {
                    Id = p.Id,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Kapacitet = p.Kapacitet,
                    OtvoreniF = p.OtvoreniF,
                    PoluOtvoreniF = p.PoluOtvoreniF,
                    PeriodZakljucavanja = p.PeriodZakljucavanja,
                    StrogiF = p.StrogiF,
                    Setnja = p.Setnja
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZatvorskaJedinicaView AzurirajZatvorskaJedinica(ZatvorskaJedinicaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica o = s.Load<ZatvorskaJedinica>(p.Id);

                o.Id = p.Id;
                o.Sifra = p.Sifra;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Kapacitet = p.Kapacitet;
                o.OtvoreniF = p.OtvoreniF;
                o.PoluOtvoreniF = p.PoluOtvoreniF;
                o.PeriodZakljucavanja = p.PeriodZakljucavanja;
                o.StrogiF = p.StrogiF;
                o.Setnja = p.Setnja;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZatvorskaJedinicaView VratiZatvorskaJedinica(int id)
        {
            ZatvorskaJedinicaView zatvorskaJedinicaView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica o = s.Load<ZatvorskaJedinica>(id);
                zatvorskaJedinicaView = new ZatvorskaJedinicaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorskaJedinicaView;
        }
        public static void ObrisiZatvorskaJedinica(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica o = s.Load<ZatvorskaJedinica>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region ZOTipa
        public static List<ZOTipaView> VratiSveZOTipa()
        {
            List<ZOTipaView> zatvori = new List<ZOTipaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZOTipa> sveZatvorskaJedinica = from o in s.Query<ZOTipa>()
                                                            select o;

                foreach (ZOTipa p in sveZatvorskaJedinica)
                {
                    zatvori.Add(new ZOTipaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvori;
        }
        public static void DodajZOTipa(ZOTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOTipa o = new ZOTipa
                {
                    Id = p.Id,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Kapacitet = p.Kapacitet,
                    PeriodZakljucavanja = p.PeriodZakljucavanja,
                    Setnja = p.Setnja
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZOTipaView AzurirajZOTipa(ZOTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOTipa o = s.Load<ZOTipa>(p.Id);
                o.Id = p.Id;
                o.Sifra = p.Sifra;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Kapacitet = p.Kapacitet;
                o.OtvoreniF = p.OtvoreniF;
                o.PoluOtvoreniF = p.PoluOtvoreniF;
                o.PeriodZakljucavanja = p.PeriodZakljucavanja;
                o.StrogiF = p.StrogiF;
                o.Setnja = p.Setnja;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZOTipaView VratiZOTipa(int id)
        {
            ZOTipaView zatvorskaJedinicaView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZOTipa o = s.Load<ZOTipa>(id);
                zatvorskaJedinicaView = new ZOTipaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorskaJedinicaView;
        }
        public static void ObrisiZOTipa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOTipa o = s.Load<ZOTipa>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region ZPOTipa
        public static List<ZPOTipaView> VratiSveZPOTipa()
        {
            List<ZPOTipaView> zatvori = new List<ZPOTipaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZPOTipa> sveZatvorskaJedinica = from o in s.Query<ZPOTipa>()
                                                           select o;

                foreach (ZPOTipa p in sveZatvorskaJedinica)
                {
                    zatvori.Add(new ZPOTipaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvori;
        }
        public static void DodajZPOTipa(ZPOTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZPOTipa o = new ZPOTipa
                {
                    Id = p.Id,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Kapacitet = p.Kapacitet,
                    PeriodZakljucavanja = p.PeriodZakljucavanja,
                    Setnja = p.Setnja
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZPOTipaView AzurirajZPOTipa(ZPOTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZPOTipa o = s.Load<ZPOTipa>(p.Id);
                o.Id = p.Id;
                o.Sifra = p.Sifra;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Kapacitet = p.Kapacitet;
                o.OtvoreniF = p.OtvoreniF;
                o.PoluOtvoreniF = p.PoluOtvoreniF;
                o.PeriodZakljucavanja = p.PeriodZakljucavanja;
                o.StrogiF = p.StrogiF;
                o.Setnja = p.Setnja;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZPOTipaView VratiZPOTipa(int id)
        {
            ZPOTipaView zatvorskaJedinicaView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZPOTipa o = s.Load<ZPOTipa>(id);
                zatvorskaJedinicaView = new ZPOTipaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorskaJedinicaView;
        }
        public static void ObrisiZPOTipa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZPOTipa o = s.Load<ZPOTipa>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region ZSTipa
        public static List<ZSTipaView> VratiSveZSTipa()
        {
            List<ZSTipaView> zatvori = new List<ZSTipaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZSTipa> sveZatvorskaJedinica = from o in s.Query<ZSTipa>()
                                                           select o;

                foreach (ZSTipa p in sveZatvorskaJedinica)
                {
                    zatvori.Add(new ZSTipaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvori;
        }
        public static void DodajZSTipa(ZSTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZSTipa o = new ZSTipa
                {
                    Id = p.Id,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Kapacitet = p.Kapacitet,
                    PeriodZakljucavanja = p.PeriodZakljucavanja,
                    Setnja = p.Setnja
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZSTipaView AzurirajZSTipa(ZSTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZSTipa o = s.Load<ZSTipa>(p.Id);
                o.Id = p.Id;
                o.Sifra = p.Sifra;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Kapacitet = p.Kapacitet;
                o.OtvoreniF = p.OtvoreniF;
                o.PoluOtvoreniF = p.PoluOtvoreniF;
                o.PeriodZakljucavanja = p.PeriodZakljucavanja;
                o.StrogiF = p.StrogiF;
                o.Setnja = p.Setnja;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZSTipaView VratiZSTipa(int id)
        {
            ZSTipaView zatvorskaJedinicaView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZSTipa o = s.Load<ZSTipa>(id);
                zatvorskaJedinicaView = new ZSTipaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorskaJedinicaView;
        }
        public static void ObrisiZSTipa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZSTipa o = s.Load<ZSTipa>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region ZOPOTipa
        public static List<ZOPOTipaView> VratiSveZOPOTipa()
        {
            List<ZOPOTipaView> zatvori = new List<ZOPOTipaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZOPOTipa> sveZatvorskaJedinica = from o in s.Query<ZOPOTipa>()
                                                           select o;

                foreach (ZOPOTipa p in sveZatvorskaJedinica)
                {
                    zatvori.Add(new ZOPOTipaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvori;
        }
        public static void DodajZOPOTipa(ZOPOTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOPOTipa o = new ZOPOTipa
                {
                    Id = p.Id,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Kapacitet = p.Kapacitet,
                    PeriodZakljucavanja = p.PeriodZakljucavanja,
                    Setnja = p.Setnja
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZOPOTipaView AzurirajZOPOTipa(ZOPOTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOPOTipa o = s.Load<ZOPOTipa>(p.Id);
                o.Id = p.Id;
                o.Sifra = p.Sifra;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Kapacitet = p.Kapacitet;
                o.OtvoreniF = p.OtvoreniF;
                o.PoluOtvoreniF = p.PoluOtvoreniF;
                o.PeriodZakljucavanja = p.PeriodZakljucavanja;
                o.StrogiF = p.StrogiF;
                o.Setnja = p.Setnja;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZOPOTipaView VratiZOPOTipa(int id)
        {
            ZOPOTipaView zatvorskaJedinicaView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZOPOTipa o = s.Load<ZOPOTipa>(id);
                zatvorskaJedinicaView = new ZOPOTipaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorskaJedinicaView;
        }
        public static void ObrisiZOPOTipa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOPOTipa o = s.Load<ZOPOTipa>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region ZOSTipa
        public static List<ZOSTipaView> VratiSveZOSTipa()
        {
            List<ZOSTipaView> zatvori = new List<ZOSTipaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZOSTipa> sveZatvorskaJedinica = from o in s.Query<ZOSTipa>()
                                                           select o;

                foreach (ZOSTipa p in sveZatvorskaJedinica)
                {
                    zatvori.Add(new ZOSTipaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvori;
        }
        public static void DodajZOSTipa(ZOSTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOSTipa o = new ZOSTipa
                {
                    Id = p.Id,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Kapacitet = p.Kapacitet,
                    PeriodZakljucavanja = p.PeriodZakljucavanja,
                    Setnja = p.Setnja
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZOSTipaView AzurirajZOSTipa(ZOSTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOSTipa o = s.Load<ZOSTipa>(p.Id);
                o.Id = p.Id;
                o.Sifra = p.Sifra;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Kapacitet = p.Kapacitet;
                o.OtvoreniF = p.OtvoreniF;
                o.PoluOtvoreniF = p.PoluOtvoreniF;
                o.PeriodZakljucavanja = p.PeriodZakljucavanja;
                o.StrogiF = p.StrogiF;
                o.Setnja = p.Setnja;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZOSTipaView VratiZOSTipa(int id)
        {
            ZOSTipaView zatvorskaJedinicaView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZOSTipa o = s.Load<ZOSTipa>(id);
                zatvorskaJedinicaView = new ZOSTipaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorskaJedinicaView;
        }
        public static void ObrisiZOSTipa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOSTipa o = s.Load<ZOSTipa>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region ZPOSTipa
        public static List<ZPOSTipaView> VratiSveZPOSTipa()
        {
            List<ZPOSTipaView> zatvori = new List<ZPOSTipaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZPOSTipa> sveZatvorskaJedinica = from o in s.Query<ZPOSTipa>()
                                                            select o;

                foreach (ZPOSTipa p in sveZatvorskaJedinica)
                {
                    zatvori.Add(new ZPOSTipaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvori;
        }
        public static void DodajZPOSTipa(ZPOSTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZPOSTipa o = new ZPOSTipa
                {
                    Id = p.Id,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Kapacitet = p.Kapacitet,
                    PeriodZakljucavanja = p.PeriodZakljucavanja,
                    Setnja = p.Setnja
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZPOSTipaView AzurirajZPOSTipa(ZPOSTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZPOSTipa o = s.Load<ZPOSTipa>(p.Id);
                o.Id = p.Id;
                o.Sifra = p.Sifra;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Kapacitet = p.Kapacitet;
                o.OtvoreniF = p.OtvoreniF;
                o.PoluOtvoreniF = p.PoluOtvoreniF;
                o.PeriodZakljucavanja = p.PeriodZakljucavanja;
                o.StrogiF = p.StrogiF;
                o.Setnja = p.Setnja;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZPOSTipaView VratiZPOSTipa(int id)
        {
            ZPOSTipaView zatvorskaJedinicaView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZPOSTipa o = s.Load<ZPOSTipa>(id);
                zatvorskaJedinicaView = new ZPOSTipaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorskaJedinicaView;
        }
        public static void ObrisiZPOSTipa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZPOSTipa o = s.Load<ZPOSTipa>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region ZOPOSTipa
        public static List<ZOPOSTipaView> VratiSveZOPOSTipa()
        {
            List<ZOPOSTipaView> zatvori = new List<ZOPOSTipaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZOPOSTipa> sveZatvorskaJedinica = from o in s.Query<ZOPOSTipa>()
                                                            select o;

                foreach (ZOPOSTipa p in sveZatvorskaJedinica)
                {
                    zatvori.Add(new ZOPOSTipaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvori;
        }
        public static void DodajZOPOSTipa(ZOPOSTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOPOSTipa o = new ZOPOSTipa
                {
                    Id = p.Id,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Kapacitet = p.Kapacitet,
                    PeriodZakljucavanja = p.PeriodZakljucavanja,
                    Setnja = p.Setnja
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static ZOPOSTipaView AzurirajZOPOSTipa(ZOPOSTipaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOPOSTipa o = s.Load<ZOPOSTipa>(p.Id);
                o.Id = p.Id;
                o.Sifra = p.Sifra;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Kapacitet = p.Kapacitet;
                o.OtvoreniF = p.OtvoreniF;
                o.PoluOtvoreniF = p.PoluOtvoreniF;
                o.PeriodZakljucavanja = p.PeriodZakljucavanja;
                o.StrogiF = p.StrogiF;
                o.Setnja = p.Setnja;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }
        public static ZOPOSTipaView VratiZOPOSTipa(int id)
        {
            ZOPOSTipaView zatvorskaJedinicaView;

            try
            {
                ISession s = DataLayer.GetSession();

                ZOPOSTipa o = s.Load<ZOPOSTipa>(id);
                zatvorskaJedinicaView = new ZOPOSTipaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zatvorskaJedinicaView;
        }
        public static void ObrisiZOPOSTipa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZOPOSTipa o = s.Load<ZOPOSTipa>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion
        #endregion ZatvorskaJedinica

    }
}
