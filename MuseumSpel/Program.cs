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
            Speler speler = new Speler("Player", 0, 0, 5);
            SpeelVeld speelVeld = new SpeelVeld(17, 11, speler);//Model
            speelVeld.VoegSpelObjectToe(new Muur(3, 0));
            speelVeld.VoegSpelObjectToe(new Muur(3, 2));
            speelVeld.VoegSpelObjectToe(new Muur(2, 3));
            speelVeld.VoegSpelObjectToe(new Muur(3, 4));
            speelVeld.VoegSpelObjectToe(new Muur(3, 5));
            speelVeld.VoegSpelObjectToe(new Muur(4, 6));
            speelVeld.VoegSpelObjectToe(new Muur(3, 7));
            speelVeld.VoegSpelObjectToe(new Schilderij(5, 5));
            speelVeld.VoegSpelObjectToe(new Schilderij(8, 5));
            speelVeld.VoegSpelObjectToe(new PowerUp(3, 6));
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
