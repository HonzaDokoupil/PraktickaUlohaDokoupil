using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PraktickaUlohaDokoupil.Filtry
{
    /// <summary>
    /// Rozhraní pro filtry
    /// </summary>
    public interface IFiltr
    {
        /// <summary>
        /// Název filtru
        /// </summary>
        public string Nazev { get; }
        /// <summary>
        /// List prodaných Vozů
        /// </summary>
        public List<Vuz> ProdaneVozy { get; }
        /// <summary>
        /// Generická kolekce obsahujicí vysledek filtrování
        /// </summary>
        public IEnumerable<dynamic> VyfiltrovneVozy { get; }
        /// <summary>
        /// Metoda pro převod kolekce na string
        /// </summary>
        /// <returns>textový řetězec/returns>
        public string VysledkyNaString();
    }
}
