using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumSpel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Speler speler = new Speler("Dino", 0, 0, 1);
            SpeelVeld speelVeld = new SpeelVeld(17, 11, speler);//Model
            speelVeld.VoegSpelObjectToe(new Muur(2, 2));
            speelVeld.VoegSpelObjectToe(new Muur(2, 3));
            speelVeld.VoegSpelObjectToe(new Muur(3, 3));
            speelVeld.VoegSpelObjectToe(new Muur(4, 3));
            speelVeld.VoegSpelObjectToe(new Muur(4, 2));
            speelVeld.VoegSpelObjectToe(new Muur(6, 4));
            speelVeld.VoegSpelObjectToe(new Muur(5, 7));
            speelVeld.VoegSpelObjectToe(new Schilderij(8, 8));
            speelVeld.VoegSpelObjectToe(new Schilderij(8, 5));
            speelVeld.VoegSpelObjectToe(new PowerUp(3, 8));
            Form1 form1 = new Form1(speelVeld); //Publisher
            SpeelVeldController speelVeldController = new SpeelVeldController(form1, speelVeld);//Controller
            form1.KeyPressed += speelVeldController.OnKeyPressed; //Subscriber
            Application.Run(form1);
            bool GameOver = true;

            while (!GameOver)
            {

            }
        }
    }
}
