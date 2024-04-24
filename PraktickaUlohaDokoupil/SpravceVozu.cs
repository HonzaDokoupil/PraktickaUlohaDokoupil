using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PraktickaUlohaDokoupil
{
    /// <summary>
    /// Třída pro správu prodaných vozů
    /// </summary>
    public class SpravceVozu
    {
        /// <summary>
        /// List prodaných vozů
        /// </summary>
        public List<Vuz> ProdaneVozy { get; private set; }
        /// <summary>
        /// Konstruktor bez parametru
        /// </summary>
        public SpravceVozu()
        {
            ProdaneVozy = new List<Vuz>();
        }
        /// <summary>
        /// Metoda která načíta vozy z XML souboru
        /// </summary>
        /// <param name="cestaKSouboru">Textový řetězec umístění souboru</param>
        public void NactiProdaneVozi(string cestaKSouboru)
        {
            try
            {
                // pro načtení jsem zvolil Linq to XML
                // nejdřív si dokument načteme
                XDocument dokument = XDocument.Load(cestaKSouboru);
                // v cyklu projdeme dokument a uložíme elementy do Listu jako instance třídy Vůz
                foreach (XElement vuz in dokument.Element("prodaneVozy").Elements("vuz"))
                {
                    ProdaneVozy.Add(new Vuz(vuz.Element("nazevModelu").Value,
                                        DateTime.Parse(vuz.Element("datumProdeje").Value),
                                        double.Parse(vuz.Element("cena").Value),
                                        double.Parse(vuz.Element("dph").Value)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání souboru - {ex.Message}", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Metoda ktera se pokusi ulozit vysledek do xml a informuje o úspěchu
        /// </summary>
        /// <param name="dotaz">Generická kolekce</param>
        /// <param name="cestaKeSlozce">řetězec reprezentující cestu ke složce</param>
        /// <param name="nazevSouboru">název souboru</param>
        /// <returns>vrací logickou hodnotu</returns>
        public bool UlozVozyOVikednu(IEnumerable<dynamic> dotaz, string cestaKeSlozce, string nazevSouboru)
        {
            try
            {
                // pro tvorbu nového xml dokumentu sem opět zvolil Linq to XML jako podle mě nejjednoduší variantu
                XDocument dokument = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement("vozyProdaneOVikendu",
                        dotaz.Select(u => new XElement("vuz",
                            new XElement("nazevModelu", u.NazevModelu),
                            new XElement("cenaBezDPH", u.CenaBezDPH),
                            new XElement("cenaSDPH", u.CenaSDPH)))));
                //oveříme jestli uživatel pojmenoval soubor s příponout .xml, jestli ne tak ji připojíme sami a uložíme
                dokument.Save(cestaKeSlozce + @$"\{PripojXML(nazevSouboru)}");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při ukládání souboru - {ex.Message}", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // rozšíření o další filtr, toto už komentovat nebudu jedna se viceméně o to same jen chci ukazat jak
        // by se aplikace dala případně rozšířit
        public bool UlozNejprodavanejsi(IEnumerable<dynamic> dotaz, string cestaKeSlozce, string nazevSouboru)
        {
            try
            {
                XDocument dokument = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement("nejprodavanejsiVozy",
                        dotaz.Select(u => new XElement("vuz",
                            new XElement("nazevModelu", u.NazevModelu),
                            new XElement("cenaBezDPH", u.CenaBezDPH),
                            new XElement("cenaSDPH", u.CenaSDPH),
                            new XElement("pocetProdeju", u.PocetProdeju)))));

                dokument.Save(cestaKeSlozce + @$"\{PripojXML(nazevSouboru)}");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při ukládání souboru - {ex.Message}", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        /// <summary>
        /// Metoda pro připojení .xml za jmeno souboru
        /// </summary>
        /// <param name="nazevSouboru">textový řetězec</param>
        /// <returns>textový řetězec</returns>
        #region pomocne metody
        private string PripojXML(string nazevSouboru)
        {
            // pokud už uživatel příponu xml zadal vrátíme tak jak je
            return nazevSouboru.EndsWith(".xml") ? nazevSouboru : nazevSouboru + ".xml";
        }
        #endregion
    }
}
