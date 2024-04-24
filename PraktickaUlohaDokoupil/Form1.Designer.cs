namespace PraktickaUlohaDokoupil
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            label1 = new Label();
            tlacitkoNacist = new Button();
            tlacitkoProchazet = new Button();
            cestaKSouboru = new TextBox();
            prodaneVozy = new ListBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            vysledky = new TextBox();
            label6 = new Label();
            comboBox1 = new ComboBox();
            groupBox4 = new GroupBox();
            label16 = new Label();
            nazevSouboru = new TextBox();
            label15 = new Label();
            tlacitkoUlozit = new Button();
            tlacitkoProchazet2 = new Button();
            cestaKeSlozce = new TextBox();
            pictureBox1 = new PictureBox();
            tlacitkoReset = new Button();
            pictureBox2 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tlacitkoNacist);
            groupBox1.Controls.Add(tlacitkoProchazet);
            groupBox1.Controls.Add(cestaKSouboru);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(443, 163);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vybrat soubor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 39);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 1;
            label1.Text = "Cesta k souboru";
            // 
            // tlacitkoNacist
            // 
            tlacitkoNacist.Location = new Point(159, 113);
            tlacitkoNacist.Name = "tlacitkoNacist";
            tlacitkoNacist.Size = new Size(94, 29);
            tlacitkoNacist.TabIndex = 1;
            tlacitkoNacist.Text = "Načíst";
            tlacitkoNacist.UseVisualStyleBackColor = true;
            tlacitkoNacist.Click += tlacitkoNacist_Click;
            // 
            // tlacitkoProchazet
            // 
            tlacitkoProchazet.Location = new Point(315, 61);
            tlacitkoProchazet.Name = "tlacitkoProchazet";
            tlacitkoProchazet.Size = new Size(115, 29);
            tlacitkoProchazet.TabIndex = 1;
            tlacitkoProchazet.Text = "Procházet";
            tlacitkoProchazet.UseVisualStyleBackColor = true;
            tlacitkoProchazet.Click += tlacitkoProchazet_Click;
            // 
            // cestaKSouboru
            // 
            cestaKSouboru.BackColor = SystemColors.ButtonHighlight;
            cestaKSouboru.Location = new Point(6, 62);
            cestaKSouboru.Name = "cestaKSouboru";
            cestaKSouboru.ReadOnly = true;
            cestaKSouboru.Size = new Size(284, 27);
            cestaKSouboru.TabIndex = 1;
            // 
            // prodaneVozy
            // 
            prodaneVozy.FormattingEnabled = true;
            prodaneVozy.Location = new Point(6, 73);
            prodaneVozy.Name = "prodaneVozy";
            prodaneVozy.Size = new Size(424, 304);
            prodaneVozy.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 50);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 2;
            label2.Text = "Název modelu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(117, 50);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 3;
            label3.Text = "Datum prodeje";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(284, 50);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 4;
            label4.Text = "Cena";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(391, 50);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 5;
            label5.Text = "DPH";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(prodaneVozy);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 181);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(443, 399);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Seznam prodaných vozů";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pictureBox2);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(vysledky);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Location = new Point(479, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(492, 568);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtry";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(426, 146);
            label14.Name = "label14";
            label14.Size = new Size(13, 20);
            label14.TabIndex = 11;
            label14.Text = " ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(426, 126);
            label13.Name = "label13";
            label13.Size = new Size(13, 20);
            label13.TabIndex = 10;
            label13.Text = " ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(285, 146);
            label12.Name = "label12";
            label12.Size = new Size(13, 20);
            label12.TabIndex = 9;
            label12.Text = " ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(285, 126);
            label11.Name = "label11";
            label11.Size = new Size(13, 20);
            label11.TabIndex = 8;
            label11.Text = " ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(143, 146);
            label10.Name = "label10";
            label10.Size = new Size(13, 20);
            label10.TabIndex = 7;
            label10.Text = " ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(143, 126);
            label9.Name = "label9";
            label9.Size = new Size(13, 20);
            label9.TabIndex = 6;
            label9.Text = " ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 146);
            label8.Name = "label8";
            label8.Size = new Size(13, 20);
            label8.TabIndex = 5;
            label8.Text = " ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 126);
            label7.Name = "label7";
            label7.Size = new Size(13, 20);
            label7.TabIndex = 4;
            label7.Text = " ";
            // 
            // vysledky
            // 
            vysledky.BackColor = SystemColors.ButtonHighlight;
            vysledky.Location = new Point(6, 169);
            vysledky.Multiline = true;
            vysledky.Name = "vysledky";
            vysledky.ReadOnly = true;
            vysledky.Size = new Size(478, 377);
            vysledky.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 38);
            label6.Name = "label6";
            label6.Size = new Size(87, 20);
            label6.TabIndex = 2;
            label6.Text = "Vyberte filtr";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 61);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(325, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(nazevSouboru);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(tlacitkoUlozit);
            groupBox4.Controls.Add(tlacitkoProchazet2);
            groupBox4.Controls.Add(cestaKeSlozce);
            groupBox4.Location = new Point(977, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(353, 163);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Uložit výsledek jako xml";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 99);
            label16.Name = "label16";
            label16.Size = new Size(108, 20);
            label16.TabIndex = 3;
            label16.Text = "Název souboru";
            // 
            // nazevSouboru
            // 
            nazevSouboru.Location = new Point(6, 122);
            nazevSouboru.Name = "nazevSouboru";
            nazevSouboru.Size = new Size(215, 27);
            nazevSouboru.TabIndex = 2;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 39);
            label15.Name = "label15";
            label15.Size = new Size(109, 20);
            label15.TabIndex = 1;
            label15.Text = "Cesta ke složce";
            // 
            // tlacitkoUlozit
            // 
            tlacitkoUlozit.Location = new Point(232, 121);
            tlacitkoUlozit.Name = "tlacitkoUlozit";
            tlacitkoUlozit.Size = new Size(115, 29);
            tlacitkoUlozit.TabIndex = 1;
            tlacitkoUlozit.Text = "Uložit";
            tlacitkoUlozit.UseVisualStyleBackColor = true;
            tlacitkoUlozit.Click += tlacitkoUlozit_Click;
            // 
            // tlacitkoProchazet2
            // 
            tlacitkoProchazet2.Location = new Point(232, 61);
            tlacitkoProchazet2.Name = "tlacitkoProchazet2";
            tlacitkoProchazet2.Size = new Size(115, 29);
            tlacitkoProchazet2.TabIndex = 1;
            tlacitkoProchazet2.Text = "Procházet";
            tlacitkoProchazet2.UseVisualStyleBackColor = true;
            tlacitkoProchazet2.Click += tlacitkoProchazet2_Click;
            // 
            // cestaKeSlozce
            // 
            cestaKeSlozce.BackColor = SystemColors.ButtonHighlight;
            cestaKeSlozce.Location = new Point(6, 62);
            cestaKeSlozce.Name = "cestaKeSlozce";
            cestaKeSlozce.ReadOnly = true;
            cestaKeSlozce.Size = new Size(215, 27);
            cestaKeSlozce.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.tumblr_b0d9384c6cffcfa78fc5753bcf119afd_378a68a8_1280;
            pictureBox1.Location = new Point(1001, 254);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(310, 304);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // tlacitkoReset
            // 
            tlacitkoReset.Location = new Point(1104, 195);
            tlacitkoReset.Name = "tlacitkoReset";
            tlacitkoReset.Size = new Size(94, 29);
            tlacitkoReset.TabIndex = 10;
            tlacitkoReset.Text = "Reset";
            tlacitkoReset.UseVisualStyleBackColor = true;
            tlacitkoReset.Click += tlacitkoReset_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(349, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(114, 93);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1342, 584);
            Controls.Add(tlacitkoReset);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Praktické zadání pro uchazeče - Jan Dokoupil";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button tlacitkoNacist;
        private Button tlacitkoProchazet;
        private TextBox cestaKSouboru;
        private ListBox prodaneVozy;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ComboBox comboBox1;
        private Label label6;
        private TextBox vysledky;
        private Label label7;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        /// <summary>
        /// list labelů pro textbox s výsledky, pro smazání textu u všech
        /// </summary>
        private List<Label> labelyVysledku;
        private GroupBox groupBox4;
        private Label label15;
        private Button tlacitkoUlozit;
        private Button tlacitkoProchazet2;
        private TextBox cestaKeSlozce;
        private Label label16;
        private TextBox nazevSouboru;
        private PictureBox pictureBox1;
        private Button tlacitkoReset;
        /// <summary>
        /// list textboxu aplikace, pro snadne smazaní textu u všech
        /// </summary>
        private List<TextBox> textboxyAplikace;
        /// <summary>
        /// Metoda nastavujici komponenty
        /// </summary>
        private void NastavKomponenty()
        {
            // bohužel některe nastavení komponentů při změne v designeru zmizí,
            // pokud jsou v metode InitializeComponent, takže je vyčleníme do samostatne metody
            comboBox1.Items.AddRange(new object[] { Filtry[0].Nazev, Filtry[1].Nazev });
            labelyVysledku = new List<Label>() { label7, label8, label9, label10, label11, label12, label13, label14 };
            textboxyAplikace = new List<TextBox>() { cestaKSouboru, vysledky, cestaKeSlozce, nazevSouboru };
        }

        private PictureBox pictureBox2;
    }
}
