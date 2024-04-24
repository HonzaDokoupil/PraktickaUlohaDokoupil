using PraktickaUlohaDokoupil.Filtry;
using System.Diagnostics;

namespace PraktickaUlohaDokoupil
{
    public partial class Form1 : Form
    {
        public SpravceVozu SpravceVozu { get; private set; }
        public List<IFiltr> Filtry { get; private set; }
        public Form1()
        {
            SpravceVozu = new SpravceVozu();
            Filtry = new List<IFiltr>();
            NaplnFiltry();
            InitializeComponent();
            NastavKomponenty();
        }
        /// <summary>
        /// Metoda pro inicializaci našich filtru a pridani do Listu
        /// </summary>
        private void NaplnFiltry()
        {
            Filtry.Add(new FiltrVikend("Celková cena vozù prodaných o víkendu", SpravceVozu.ProdaneVozy));
            Filtry.Add(new FiltrNejprodavanejsi("Tøi nejprodávanejší modely", SpravceVozu.ProdaneVozy));
        }
        /// <summary>
        /// Metoda reagující na stisknutí tlaèítka
        /// </summary>
        /// <param name="sender">tlaèítko Procházet</param>
        /// <param name="e">kliknutí</param>
        private void tlacitkoProchazet_Click(object sender, EventArgs e)
        {
            // otevøeme si dialog s výbìrem souboru který omezíme jenom na XML formát
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML |*.xml";
            // do textboxu si vyplníme cestu k souboru
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cestaKSouboru.Text = dialog.FileName;
            }
        }
        /// <summary>
        /// Metoda reagující na stisknutí tlaèítka
        /// </summary>
        /// <param name="sender">tlaèítko Naèíst</param>
        /// <param name="e">kliknutí</param>
        private void tlacitkoNacist_Click(object sender, EventArgs e)
        {
            // pokud uživatel nevybral soubor tak ho na to upozorníme a metodu ukonèíme
            if (ZkontrolujUdaj(cestaKSouboru.Text, "Cesta k souboru je prázdná!")) { return; }
            // naèteme si vybraný soubor zavoláním naší metody a pøedáme ListBoxu data z našeho Listu vozù, stará data smažeme
            prodaneVozy.DataSource = null;
            SpravceVozu.ProdaneVozy.Clear();
            SpravceVozu.NactiProdaneVozi(cestaKSouboru.Text);
            prodaneVozy.DataSource = SpravceVozu.ProdaneVozy;
        }
        /// <summary>
        /// Metoda reagující na výbìr v comboboxu
        /// </summary>
        /// <param name="sender">tlaèítko Provést</param>
        /// <param name="e">kliknutí</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // pokud chceme metodu zavolat opìtovnì vymažeme si pøedchozí nastavení
            vysledky.Text = "";
            VymazNastaveni(labelyVysledku);
            // výsledná tabulka je zobrazená v textboxu jako text,
            // pøijde mi to více flexibilní a pro takovouto jednoduchou aplikaci dostaèující
            vysledky.AppendText(Filtry[comboBox1.SelectedIndex].VysledkyNaString());
            // hlavièku pomyslné tabulky nastavíme metodou
            NastavHlavicku();
        }
        /// <summary>
        /// Metoda reagující na stisknutí tlaèítka
        /// </summary>
        /// <param name="sender">tlaèítko Procházet2</param>
        /// <param name="e">kliknutí</param>
        private void tlacitkoProchazet2_Click(object sender, EventArgs e)
        {
            // otevøeme si dialog s výbìrem složky
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            // do textboxu si vyplníme cestu ke složce
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cestaKeSlozce.Text = dialog.SelectedPath;
            }
        }
        /// <summary>
        /// Metoda reagující na stisknutí tlaèítka
        /// </summary>
        /// <param name="sender">tlaèítko Uložit</param>
        /// <param name="e">kliknutí</param>
        private void tlacitkoUlozit_Click(object sender, EventArgs e)
        {
            // zkontrolujeme údaje od uživatele, pokud chybí kterýkoliv z údajù metodu ukonèíme
            if (ZkontrolujUdaj(vysledky.Text, "Žádné výsledky k uložení!") ||
               ZkontrolujUdaj(cestaKeSlozce.Text, "Cesta ke složce je prázná!") ||
               ZkontrolujUdaj(nazevSouboru.Text, "Vyplòte název souboru!"))
            { return; }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (SpravceVozu.UlozVozyOVikednu(Filtry[0].VyfiltrovneVozy, cestaKeSlozce.Text, nazevSouboru.Text))
                    {
                        MessageBox.Show("Soubor uložen!", "Oznámení!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Process.Start("explorer.exe", cestaKeSlozce.Text);
                    break;
                case 1:
                    if (SpravceVozu.UlozNejprodavanejsi(Filtry[1].VyfiltrovneVozy, cestaKeSlozce.Text, nazevSouboru.Text))
                    {
                        MessageBox.Show("Soubor uložen!", "Oznámení!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Process.Start("explorer.exe", cestaKeSlozce.Text);
                    break;
                case 2:
                    // pro každý další filtr by sme museli napsat novou metodu uložení protože anonymní typy v generické kolekci
                    // budou mít pravdìpodobnì jine vlastnosti i jejich poèet a tak se ulozene xml dokumenty budou lišit
                    break;
                default:
                    MessageBox.Show("Vyberte prosím filtr!", "Varování!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        /// <summary>
        /// Metoda reagující na stisknutí tlaèítka
        /// </summary>
        /// <param name="sender">tlaèítko Reset</param>
        /// <param name="e">kliknutí</param>
        private void tlacitkoReset_Click(object sender, EventArgs e)
        {
            // nejdrive se uzivatele zeptame jestli chce opravdu aplikaci vyresetovat pokud ano zareagujeme
            DialogResult volba = MessageBox.Show("Opravdu si pøejete aplikaci resetovat?", "Pozor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (volba == DialogResult.Yes)
            {
                // vymazeme si nastavení aplikace pomocí metod
                VymazNastaveni(labelyVysledku);
                VymazNastaveni(textboxyAplikace);
                //vymazeme i náš list vozù a vyresetujeme comboBox
                prodaneVozy.DataSource = null;
                SpravceVozu.ProdaneVozy.Clear();
                comboBox1.ResetText();
            }

        }
        #region pomocne metody
        /// <summary>
        /// Metoda na kontrolu udajù
        /// </summary>
        /// <param name="udaj">políèko s udajem</param>
        /// <param name="hlaska">text MessageBoxu</param>
        /// <returns>vrací logickou hodnotu</returns>
        private bool ZkontrolujUdaj(string udaj, string hlaska)
        {
            if (udaj == "")
            {
                MessageBox.Show(hlaska, "Varování!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Metoda na vymazání nastavení
        /// </summary>
        /// <param name="labels">List labelù</param>
        private void VymazNastaveni(List<Label> labels)
        {
            // v cyklu projdeme list ktery mame pro tento uèel už nachystaný
            foreach (var label in labels)
            {
                label.Text = "";
            }
        }
        /// <summary>
        /// Pøetížená metoda na vymazání nastavení
        /// </summary>
        /// <param name="textBoxy">List textboxù</param>
        private void VymazNastaveni(List<TextBox> textBoxy)
        {
            foreach (var textBox in textBoxy)
            {
                textBox.Text = "";
            }
        }
        /// <summary>
        /// Metoda nastaví hlavièku textboxu s výsledky
        /// </summary>
        private void NastavHlavicku()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    // nastavíme hlavièku pomyslné tabulky tím že vložíme text do labelù které dosud byli prázdné
                    label7.Text = "Název modelu";
                    label8.Text = "Cena bez DPH";
                    label12.Text = "Cena s DPH";
                    break;
                case 1:
                    label8.Text = "Název modelu";
                    label10.Text = "Celková cena";
                    label12.Text = "Celková cena s DPH";
                    label14.Text = "Prodejù";
                    break;
                case 2:
                    // další pøípadne filtry
                    break;
                default:
                    MessageBox.Show("Vyberte prosím filtr!", "Varování!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        #endregion
    }
}
