using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MuseumSpel
{
    public partial class Menu : Form
    {
        SoundPlayer backgroundSound = new SoundPlayer("Sound\\sound.wav");
        private bool soundAan = true;
        public bool startSpel { get; private set; }
        public int spelLevel { get; private set; }
        public int levels;

        //controls
        public List<int> controls = new List<int>(new int[] { 87, 83, 65, 68 });

        public SpeelVeld speelVeld;
        public XMLReader reader;
        public XDocument doc;

        public Menu(SpeelVeld speelVeld)
        {
            InitializeComponent();
            this.speelVeld = speelVeld;

            backgroundSound.Play();
            //de balk bovenin is dan weg kruisje, minimaliseren enzo
            this.ControlBox = false;

            //aantal levels uitrekenen
            XDocument doc = new XDocument();
            doc = XDocument.Load(@"speelveld.xml");
            this.levels = doc.Descendants("level").Count();

            Width = 910;
            Height = 380;
            Text = "Hoofdmenu";
            // elementen in de dialog
            Button startSpel = new Button() { Text = "Start spel", Left = 15, Width = 250, Height = 50, Top = 20 };
            Button opties = new Button() { Text = "Opties", Left = 15, Width = 250, Height = 50, Top = 75 };
            Button sluitSpel = new Button() { Text = "Afsluiten", Left = 15, Width = 250, Height = 50, Top = 130 };
            ComboBox kiesLevel = new ComboBox() { Text = "Kies een level", Left = 15, Width = 250, Height = 50, Top = 185 };
            kiesLevel.DisplayMember = "Text";

            for (int i = 0; i < levels; i++)
            {
                kiesLevel.Items.Add(new { Text = "level" + (i + 1) });
            }


            //on click methode
            startSpel.Click += (sender, e) => {
                if((kiesLevel.SelectedIndex + 1) == 0)
                {
                    MessageBox.Show("kies een level");
                }
                else
                {
                    this.startSpel = true;
                    this.spelLevel = kiesLevel.SelectedIndex + 1;
                    this.reader = new XMLReader(this.speelVeld, doc, spelLevel);
                    this.reader.ReadXML();
                    this.Close();
                }
            };
            opties.Click += (sender, e) => { Options(); };
            sluitSpel.Click += (sender, e) => { Application.Exit(); };
            //voeg de elementen toe
            Controls.Add(startSpel);
            Controls.Add(opties);
            Controls.Add(sluitSpel);
            Controls.Add(kiesLevel);
        }

        private void Options()
        {
            Form options = new Form();
            options.KeyPreview = true;
            options.Width = 300;
            options.Height = 350;
            options.Text = "Opties";
            // elementen in de dialog
            Label sound = new Label() { Text = "Geluid: " + this.soundAan, Left = 75, Top = 20 };
            Button soundOn = new Button() { Text = "Aan/uit", Left = 75, Top = 45 };

            Label opties = new Label() { Text = "Opties", Left = 50, Top = 80, AutoSize = true };
            opties.Font = new Font(opties.Font, FontStyle.Bold);

            Label lOmhoog = new Label() { Text = "omhoog: ", Left = 30, Top = 102, AutoSize = true };
            TextBox tOmhoog = new TextBox() { MaxLength = 1, Left = 85, Top = 100, Size = new Size(25, 25) };

            Label lOmlaag = new Label() { Text = "omlaag: ", Left = 30, Top = 132, AutoSize = true };
            TextBox tOmlaag = new TextBox() { MaxLength = 1, Left = 85, Top = 130, Size = new Size(25, 25) };

            Label lLinks = new Label() { Text = "Links: ", Left = 30, Top = 162, AutoSize = true };
            TextBox tLinks = new TextBox() { MaxLength = 1, Left = 85, Top = 160, Size = new Size(25, 25) };

            Label lRechts = new Label() { Text = "Rechts: ", Left = 30, Top = 192, AutoSize = true };
            TextBox tRechts = new TextBox() { MaxLength = 1,  Left = 85, Top = 190, Size = new Size(25, 25) };

            Button bOpslaan = new Button() { Text = "Opslaan", Left = 125, Top = 90 };
            Button bClose = new Button() { Text = "Close", Left = 125, Top = 120 };

            //on click methode
            soundOn.Click += (sender, e) => { this.soundAan = !this.soundAan; sound.Text = "Geluid: " + this.soundAan; if (!soundAan) { backgroundSound.Stop(); } else { backgroundSound.Play(); } };
            bOpslaan.Click += (sender, e) => {
                //kijken of alles is ingevoerd
                if(tOmhoog.Text.Length > 0 || tOmlaag.Text.Length > 0 || tLinks.Text.Length > 0 || tRechts.Text.Length > 0)
                {
                    string[] checkArray = { tOmhoog.Text, tOmlaag.Text, tLinks.Text, tRechts.Text };
                    //checken dat er niet dezelfde toetsen inzitten
                    if(checkArray.Distinct().Count() == checkArray.Count())
                    {
                        int omhoog = (int)((Keys)Enum.Parse(typeof(Keys), tOmhoog.Text.ToUpper()));
                        int omlaag = (int)((Keys)Enum.Parse(typeof(Keys), tOmlaag.Text.ToUpper()));
                        int links = (int)((Keys)Enum.Parse(typeof(Keys), tLinks.Text.ToUpper()));
                        int rechts = (int)((Keys)Enum.Parse(typeof(Keys), tRechts.Text.ToUpper()));

                        this.controls[0] = omhoog;
                        this.controls[1] = omlaag;
                        this.controls[2] = links;
                        this.controls[3] = rechts;
                        MessageBox.Show("Opgeslagen");
                    }
                    else
                    {
                        MessageBox.Show("Elke control moet een aparte toets hebben");
                    }
                }
                else
                {
                    MessageBox.Show("Niet alle invoervelden zijn ingevuld");
                }
            };
            bClose.Click += (sender, e) => { options.Close(); };

            //en alles toevoegen
            options.Controls.Add(sound);
            options.Controls.Add(soundOn);

            options.Controls.Add(opties);

            options.Controls.Add(lOmhoog);
            options.Controls.Add(tOmhoog);

            options.Controls.Add(lOmlaag);
            options.Controls.Add(tOmlaag);

            options.Controls.Add(lLinks);
            options.Controls.Add(tLinks);

            options.Controls.Add(lRechts);
            options.Controls.Add(tRechts);

            options.Controls.Add(bClose);
            options.Controls.Add(bOpslaan);

            options.ShowDialog();

        }

        private void SoundOn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        //Geluid aan en uit zetten
        public void pasGeluidAan()
        {
            //SoundAan false maken als true is en andersom
            this.soundAan = !this.soundAan;

            //Stop muziek als true, play muziek als false
            if (!soundAan)
            {
                backgroundSound.Stop();
            }
            else
            {
                backgroundSound.Play();
            }
        }

        //Getter van soundAan
        public bool getSoundAan()
        {
            return soundAan;
        }
    }
}
