using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktickaUlohaDokoupil.Filtry
{
    /// <summary>
    /// Třída reprezentující filtr, implementuje naše rozhraní
    /// Filtruje vozy na prodané o víkendu a jejich celkovou cenu 
    /// </summary>
    public class FiltrVikend : IFiltr
    {
        public string Nazev { get; }
        public List<Vuz> ProdaneVozy { get; }
        public IEnumerable<dynamic> VyfiltrovneVozy
        { 
            get
            {
                // nejdriv si vybereme jen vozy prodane o vikendu, pote je seskupime podle nazvu
                // nakonec si vybereme anonymni typ s pozadovanymy vlastnostmi
                return ProdaneVozy.Where(vuz => vuz.DatumProdeje.DayOfWeek == DayOfWeek.Sunday || vuz.DatumProdeje.DayOfWeek == DayOfWeek.Saturday)
                                  .GroupBy(vuz => vuz.NazevModelu)
                                  .Select(vuz => new { NazevModelu = vuz.Key, CenaBezDPH = vuz.Sum(x => x.Cena), CenaSDPH = vuz.Sum(x => x.VratCenuSDPH()) });
            }
        }
        public FiltrVikend(string nazev, List<Vuz> prodaneVozy)
        {
            Nazev = nazev;
            ProdaneVozy = prodaneVozy;
        }
        public string VysledkyNaString()
        {
            // Výslednou kolekci projdeme cyklem a každou položku převedeme na string a připojíme do končného stringu 
            string vysledek = "";
            foreach (var vuz in VyfiltrovneVozy)
            {
                vysledek += $"{vuz.NazevModelu}{Environment.NewLine}" +
                            $"{vuz.CenaBezDPH.ToString("N")} Kč\t\t\t{vuz.CenaSDPH.ToString("N")} Kč{Environment.NewLine}" +
                            $"-----------------------------------------------------------------------------{Environment.NewLine}";
            }
            return vysledek;
        }
    }
}
