using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktickaUlohaDokoupil.Filtry
{
    /// <summary>
    /// Třída reprezentující filtr, implementuje naše rozhraní
    /// filtruje na tři nejprodávanejší a počet jejich prodejů
    /// </summary>
    /// 
    public class FiltrNejprodavanejsi : IFiltr
    {
        // rozšíření o další filtr, toto už komentovat nebudu jedna se viceméně o to same jen chci ukazat jak
        // by se aplikace dala případně rozšířit
        public string Nazev { get; }
        public List<Vuz> ProdaneVozy { get; }

        public IEnumerable<dynamic> VyfiltrovneVozy
        {
            get
            {
                return ProdaneVozy.GroupBy(Vuz => Vuz.NazevModelu)
                                  .Select(vuz => new { NazevModelu = vuz.Key, CenaBezDPH = vuz.Sum(x => x.Cena), CenaSDPH = vuz.Sum(x => x.VratCenuSDPH()), PocetProdeju = vuz.Count() })
                                  .OrderByDescending(vuz => vuz.PocetProdeju)
                                  .OrderByDescending(vuz => vuz.CenaSDPH)
                                  .Take(3);
            }
        }

        public FiltrNejprodavanejsi(string nazev, List<Vuz> prodaneVozy)
        {
            Nazev = nazev;
            ProdaneVozy = prodaneVozy;
        }

        public string VysledkyNaString()
        {
            string vysledek = "";
            foreach (var vuz in VyfiltrovneVozy)
            {
                vysledek += $"{vuz.NazevModelu}\t{vuz.CenaBezDPH.ToString("N")} Kč\t\t{vuz.CenaSDPH.ToString("N")} Kč\t{vuz.PocetProdeju}{Environment.NewLine}" +
                            $"-----------------------------------------------------------------------------{Environment.NewLine}";
            }
            return vysledek;
        }
    }
}
