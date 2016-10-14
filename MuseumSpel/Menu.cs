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

        public Menu()
        {
            InitializeComponent();

            var number = (int)((Keys)Enum.Parse(typeof(Keys), "A"));

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
            ComboBox kiesLevel = new ComboBox() { Text = "Kies level", Left = 15, Width = 250, Height = 50, Top = 185 };

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
            options.Width = 300;
            options.Height = 350;
            options.Text = "Opties";
            // elementen in de dialog
            Label sound = new Label() { Text = "Geluid: " + this.soundAan, Left = 75, Top = 20 };
            Button soundOn = new Button() { Text = "Aan/uit", Left = 75, Top = 45 };

            Label opties = new Label() { Text = "Opties", Left = 50, Top = 80, AutoSize = true };
            opties.Font = new Font(opties.Font, FontStyle.Bold);

            Label lOmhoog = new Label() { Text = "omhoog: ", Left = 30, Top = 102, AutoSize = true };
            TextBox tOmhoog = new TextBox() {Left = 85, Top = 100, Size = new Size(25, 25) };

            Label lOmlaag = new Label() { Text = "omlaag: ", Left = 30, Top = 132, AutoSize = true };
            TextBox tOmlaag = new TextBox() { Left = 85, Top = 130, Size = new Size(25, 25) };

            Label lLinks = new Label() { Text = "Links: ", Left = 30, Top = 162, AutoSize = true };
            TextBox tLinks = new TextBox() { Left = 85, Top = 160, Size = new Size(25, 25) };

            Label lRechts = new Label() { Text = "Rechts: ", Left = 30, Top = 192, AutoSize = true };
            TextBox tRechts = new TextBox() { Left = 85, Top = 190, Size = new Size(25, 25) };

            Button close = new Button() { Text = "Close", Left = 125, Top = 120 };

            //on click methode
            soundOn.Click += (sender, e) => { this.soundAan = !this.soundAan; sound.Text = "Geluid: " + this.soundAan; if (!soundAan) { backgroundSound.Stop(); } else { backgroundSound.Play(); } };
            close.Click += (sender, e) => { options.Close(); };

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

            options.Controls.Add(close);
            options.ShowDialog();

        }

        private void SoundOn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
