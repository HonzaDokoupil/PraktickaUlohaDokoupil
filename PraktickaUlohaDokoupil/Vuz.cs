using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktickaUlohaDokoupil
{
    /// <summary>
    /// Třída reprezentující jeden prodaný vůz
    /// </summary>
    public class Vuz
    {
        /// <summary>
        /// Název modelu vozu
        /// </summary>
        public string NazevModelu { get; set; }
        /// <summary>
        /// Datum prodeje
        /// </summary>
        public DateTime DatumProdeje { get; set; }
        /// <summary>
        /// Cena bez DPH
        /// </summary>
        public double Cena { get; set; }
        /// <summary>
        /// hodnota DPH
        /// </summary>
        public double DPH { get; set; }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="nazevModelu">Textový řetězec</param>
        /// <param name="datumProdeje">Datum</param>
        /// <param name="cena">Desetiné číslo</param>
        /// <param name="dph">Desetiné číslo</param>
        public Vuz(string nazevModelu, DateTime datumProdeje, double cena, double dph)
        {
            NazevModelu = nazevModelu;
            DatumProdeje = datumProdeje;
            Cena = cena;
            DPH = dph;
        }
        /// <summary>
        /// Přepsaná metoda ToString pro výpis vozu
        /// </summary>
        /// <returns>Vrací textový řetězec</returns>
        public override string ToString()
        {
            return $"{NazevModelu}\t{DatumProdeje.ToShortDateString()}\t{Cena.ToString("N")} Kč\t{DPH}%";
        }
        /// <summary>
        /// Metoda pro spočítaní ceny vozu s DPH
        /// </summary>
        /// <returns>Desetiné číslo</returns>
        public double VratCenuSDPH()
        {
            return Cena + (Cena * (DPH / 100));
        }
    }
}
