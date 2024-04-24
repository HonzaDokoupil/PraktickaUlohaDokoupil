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
        /// Metoda pro inicializaci na�ich filtru a pridani do Listu
        /// </summary>
        private void NaplnFiltry()
        {
            Filtry.Add(new FiltrVikend("Celkov� cena voz� prodan�ch o v�kendu", SpravceVozu.ProdaneVozy));
            Filtry.Add(new FiltrNejprodavanejsi("T�i nejprod�vanej�� modely", SpravceVozu.ProdaneVozy));
        }
        /// <summary>
        /// Metoda reaguj�c� na stisknut� tla��tka
        /// </summary>
        /// <param name="sender">tla��tko Proch�zet</param>
        /// <param name="e">kliknut�</param>
        private void tlacitkoProchazet_Click(object sender, EventArgs e)
        {
            // otev�eme si dialog s v�b�rem souboru kter� omez�me jenom na XML form�t
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML |*.xml";
            // do textboxu si vypln�me cestu k souboru
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cestaKSouboru.Text = dialog.FileName;
            }
        }
        /// <summary>
        /// Metoda reaguj�c� na stisknut� tla��tka
        /// </summary>
        /// <param name="sender">tla��tko Na��st</param>
        /// <param name="e">kliknut�</param>
        private void tlacitkoNacist_Click(object sender, EventArgs e)
        {
            // pokud u�ivatel nevybral soubor tak ho na to upozorn�me a metodu ukon��me
            if (ZkontrolujUdaj(cestaKSouboru.Text, "Cesta k souboru je pr�zdn�!")) { return; }
            // na�teme si vybran� soubor zavol�n�m na�� metody a p�ed�me ListBoxu data z na�eho Listu voz�, star� data sma�eme
            prodaneVozy.DataSource = null;
            SpravceVozu.ProdaneVozy.Clear();
            SpravceVozu.NactiProdaneVozi(cestaKSouboru.Text);
            prodaneVozy.DataSource = SpravceVozu.ProdaneVozy;
        }
        /// <summary>
        /// Metoda reaguj�c� na v�b�r v comboboxu
        /// </summary>
        /// <param name="sender">tla��tko Prov�st</param>
        /// <param name="e">kliknut�</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // pokud chceme metodu zavolat op�tovn� vyma�eme si p�edchoz� nastaven�
            vysledky.Text = "";
            VymazNastaveni(labelyVysledku);
            // v�sledn� tabulka je zobrazen� v textboxu jako text,
            // p�ijde mi to v�ce flexibiln� a pro takovouto jednoduchou aplikaci dosta�uj�c�
            vysledky.AppendText(Filtry[comboBox1.SelectedIndex].VysledkyNaString());
            // hlavi�ku pomysln� tabulky nastav�me metodou
            NastavHlavicku();
        }
        /// <summary>
        /// Metoda reaguj�c� na stisknut� tla��tka
        /// </summary>
        /// <param name="sender">tla��tko Proch�zet2</param>
        /// <param name="e">kliknut�</param>
        private void tlacitkoProchazet2_Click(object sender, EventArgs e)
        {
            // otev�eme si dialog s v�b�rem slo�ky
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            // do textboxu si vypln�me cestu ke slo�ce
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cestaKeSlozce.Text = dialog.SelectedPath;
            }
        }
        /// <summary>
        /// Metoda reaguj�c� na stisknut� tla��tka
        /// </summary>
        /// <param name="sender">tla��tko Ulo�it</param>
        /// <param name="e">kliknut�</param>
        private void tlacitkoUlozit_Click(object sender, EventArgs e)
        {
            // zkontrolujeme �daje od u�ivatele, pokud chyb� kter�koliv z �daj� metodu ukon��me
            if (ZkontrolujUdaj(vysledky.Text, "��dn� v�sledky k ulo�en�!") ||
               ZkontrolujUdaj(cestaKeSlozce.Text, "Cesta ke slo�ce je pr�zn�!") ||
               ZkontrolujUdaj(nazevSouboru.Text, "Vypl�te n�zev souboru!"))
            { return; }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (SpravceVozu.UlozVozyOVikednu(Filtry[0].VyfiltrovneVozy, cestaKeSlozce.Text, nazevSouboru.Text))
                    {
                        MessageBox.Show("Soubor ulo�en!", "Ozn�men�!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Process.Start("explorer.exe", cestaKeSlozce.Text);
                    break;
                case 1:
                    if (SpravceVozu.UlozNejprodavanejsi(Filtry[1].VyfiltrovneVozy, cestaKeSlozce.Text, nazevSouboru.Text))
                    {
                        MessageBox.Show("Soubor ulo�en!", "Ozn�men�!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Process.Start("explorer.exe", cestaKeSlozce.Text);
                    break;
                case 2:
                    // pro ka�d� dal�� filtr by sme museli napsat novou metodu ulo�en� proto�e anonymn� typy v generick� kolekci
                    // budou m�t pravd�podobn� jine vlastnosti i jejich po�et a tak se ulozene xml dokumenty budou li�it
                    break;
                default:
                    MessageBox.Show("Vyberte pros�m filtr!", "Varov�n�!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        /// <summary>
        /// Metoda reaguj�c� na stisknut� tla��tka
        /// </summary>
        /// <param name="sender">tla��tko Reset</param>
        /// <param name="e">kliknut�</param>
        private void tlacitkoReset_Click(object sender, EventArgs e)
        {
            // nejdrive se uzivatele zeptame jestli chce opravdu aplikaci vyresetovat pokud ano zareagujeme
            DialogResult volba = MessageBox.Show("Opravdu si p�ejete aplikaci resetovat?", "Pozor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (volba == DialogResult.Yes)
            {
                // vymazeme si nastaven� aplikace pomoc� metod
                VymazNastaveni(labelyVysledku);
                VymazNastaveni(textboxyAplikace);
                //vymazeme i n� list voz� a vyresetujeme comboBox
                prodaneVozy.DataSource = null;
                SpravceVozu.ProdaneVozy.Clear();
                comboBox1.ResetText();
            }

        }
        #region pomocne metody
        /// <summary>
        /// Metoda na kontrolu udaj�
        /// </summary>
        /// <param name="udaj">pol��ko s udajem</param>
        /// <param name="hlaska">text MessageBoxu</param>
        /// <returns>vrac� logickou hodnotu</returns>
        private bool ZkontrolujUdaj(string udaj, string hlaska)
        {
            if (udaj == "")
            {
                MessageBox.Show(hlaska, "Varov�n�!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Metoda na vymaz�n� nastaven�
        /// </summary>
        /// <param name="labels">List label�</param>
        private void VymazNastaveni(List<Label> labels)
        {
            // v cyklu projdeme list ktery mame pro tento u�el u� nachystan�
            foreach (var label in labels)
            {
                label.Text = "";
            }
        }
        /// <summary>
        /// P�et�en� metoda na vymaz�n� nastaven�
        /// </summary>
        /// <param name="textBoxy">List textbox�</param>
        private void VymazNastaveni(List<TextBox> textBoxy)
        {
            foreach (var textBox in textBoxy)
            {
                textBox.Text = "";
            }
        }
        /// <summary>
        /// Metoda nastav� hlavi�ku textboxu s v�sledky
        /// </summary>
        private void NastavHlavicku()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    // nastav�me hlavi�ku pomysln� tabulky t�m �e vlo��me text do label� kter� dosud byli pr�zdn�
                    label7.Text = "N�zev modelu";
                    label8.Text = "Cena bez DPH";
                    label12.Text = "Cena s DPH";
                    break;
                case 1:
                    label8.Text = "N�zev modelu";
                    label10.Text = "Celkov� cena";
                    label12.Text = "Celkov� cena s DPH";
                    label14.Text = "Prodej�";
                    break;
                case 2:
                    // dal�� p��padne filtry
                    break;
                default:
                    MessageBox.Show("Vyberte pros�m filtr!", "Varov�n�!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        #endregion
    }
}
