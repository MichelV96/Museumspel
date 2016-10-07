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
<<<<<<< HEAD
            SpeelVeld speelVeld = new SpeelVeld(17, 11, speler);//Model
=======
            SpeelVeld speelVeld = new SpeelVeld(17, 11, speler);//Model + publisher
>>>>>>> aa31cb07a8c6ee683827df0866f4e9f590b6f981
            speelVeld.VoegSpelObjectToe(new PowerUp(6, 6));
            speelVeld.VoegSpelObjectToe(new Muur(3, 0));
            speelVeld.VoegSpelObjectToe(new Muur(3, 2));
            speelVeld.VoegSpelObjectToe(new Muur(2, 3));
            speelVeld.VoegSpelObjectToe(new Muur(3, 4));
            speelVeld.VoegSpelObjectToe(new Muur(3, 5));
            speelVeld.VoegSpelObjectToe(new Muur(4, 6));
            speelVeld.VoegSpelObjectToe(new Muur(3, 7));
            speelVeld.VoegSpelObjectToe(new Waterplas(3, 8));
            speelVeld.VoegSpelObjectToe(new Schilderij(5, 5));
            speelVeld.VoegSpelObjectToe(new Schilderij(8, 5));
            Form1 form1 = new Form1(speelVeld); //Publisher
            SpeelVeldController speelVeldController = new SpeelVeldController(form1, speelVeld);//Controller
            form1.KeyPressed += speelVeldController.OnKeyPressed; //Subscriber
            form1.KeyRealeased += speelVeldController.OnKeyUp; //Subscriber
            speelVeld.ModelChanged += form1.OnModelChanged; //Subscriber
            Application.Run(form1);
            bool GameOver = true;

            while (!GameOver)
            {

            }
        }
    }
}
