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
            GameLoop gameloop = new GameLoop();
            SpeelVeld speelVeld = new SpeelVeld(17, 11, speler, gameloop);//Model
            #region objecten(muur, schilderij, waterplas, powerup)

            //Boven buiten muur
            #region Boven buiten muur
            speelVeld.VoegSpelObjectToe(new Muur(2, 1));
            speelVeld.VoegSpelObjectToe(new Muur(3, 1));
            speelVeld.VoegSpelObjectToe(new Muur(4, 1));
            speelVeld.VoegSpelObjectToe(new Muur(5, 1));
            speelVeld.VoegSpelObjectToe(new Muur(6, 1));
            speelVeld.VoegSpelObjectToe(new Muur(7, 1));
            speelVeld.VoegSpelObjectToe(new Muur(9, 1));
            speelVeld.VoegSpelObjectToe(new Muur(10, 1));
            speelVeld.VoegSpelObjectToe(new Muur(11, 1));
            speelVeld.VoegSpelObjectToe(new Muur(12, 1));
            speelVeld.VoegSpelObjectToe(new Muur(13, 1));
            speelVeld.VoegSpelObjectToe(new Muur(14, 1));
            speelVeld.VoegSpelObjectToe(new Muur(15, 1));
            speelVeld.VoegSpelObjectToe(new Muur(1, 1));

            #endregion 
             
            //Linker buiten muur
            #region Linker Buiten Muur
            speelVeld.VoegSpelObjectToe(new Muur(1, 2));
            speelVeld.VoegSpelObjectToe(new Muur(1, 3));
            speelVeld.VoegSpelObjectToe(new Muur(1, 4));
            speelVeld.VoegSpelObjectToe(new Muur(1, 5));
            speelVeld.VoegSpelObjectToe(new Muur(1, 6));
            speelVeld.VoegSpelObjectToe(new Muur(1, 7));
            speelVeld.VoegSpelObjectToe(new Muur(1, 8));
            #endregion

            //onder buiten muur
            #region onder buiten muur;
            speelVeld.VoegSpelObjectToe(new Muur(1, 9));
            speelVeld.VoegSpelObjectToe(new Muur(2, 9));
            speelVeld.VoegSpelObjectToe(new Muur(3, 9));
            speelVeld.VoegSpelObjectToe(new Muur(4, 9));
            speelVeld.VoegSpelObjectToe(new Muur(5, 9));
            speelVeld.VoegSpelObjectToe(new Muur(6, 9));
            speelVeld.VoegSpelObjectToe(new Muur(7, 9));
            speelVeld.VoegSpelObjectToe(new Muur(9, 9));
            speelVeld.VoegSpelObjectToe(new Muur(10, 9));
            speelVeld.VoegSpelObjectToe(new Muur(11, 9));
            speelVeld.VoegSpelObjectToe(new Muur(12, 9));
            speelVeld.VoegSpelObjectToe(new Muur(13, 9));
            speelVeld.VoegSpelObjectToe(new Muur(14, 9));
            speelVeld.VoegSpelObjectToe(new Muur(15, 9));
            #endregion

            //Rechter buiten muur
            #region Rechter buiten muur
            speelVeld.VoegSpelObjectToe(new Muur(15, 8));
            speelVeld.VoegSpelObjectToe(new Muur(15, 7));
            speelVeld.VoegSpelObjectToe(new Muur(15, 6));
            speelVeld.VoegSpelObjectToe(new Muur(15, 5));
            speelVeld.VoegSpelObjectToe(new Muur(15, 4));
            speelVeld.VoegSpelObjectToe(new Muur(15, 3));
            speelVeld.VoegSpelObjectToe(new Muur(15, 2));
            #endregion

            //Boven binnen muur
            #region Boven binnen muur
            speelVeld.VoegSpelObjectToe(new Muur(4, 3));
            speelVeld.VoegSpelObjectToe(new Muur(5, 3));
            speelVeld.VoegSpelObjectToe(new Muur(6, 3));
            speelVeld.VoegSpelObjectToe(new Muur(7, 3));
            speelVeld.VoegSpelObjectToe(new Muur(8, 3));
            speelVeld.VoegSpelObjectToe(new Muur(9, 3));
            speelVeld.VoegSpelObjectToe(new Muur(10, 3));
            speelVeld.VoegSpelObjectToe(new Muur(11, 3));
            speelVeld.VoegSpelObjectToe(new Muur(12, 3));
            speelVeld.VoegSpelObjectToe(new Muur(13, 3));
            #endregion

            //Linker binnen muur
            #region Linker binnen Muur
            speelVeld.VoegSpelObjectToe(new Muur(3, 3));
            speelVeld.VoegSpelObjectToe(new Muur(3, 4));
            speelVeld.VoegSpelObjectToe(new Muur(3, 6));
            speelVeld.VoegSpelObjectToe(new Muur(3, 7));
            #endregion

            //onder binnen muur
            #region onder binnen muur;
            speelVeld.VoegSpelObjectToe(new Muur(3, 7));
            speelVeld.VoegSpelObjectToe(new Muur(4, 7));
            speelVeld.VoegSpelObjectToe(new Muur(5, 7));
            speelVeld.VoegSpelObjectToe(new Muur(6, 7));
            speelVeld.VoegSpelObjectToe(new Muur(7, 7));
            speelVeld.VoegSpelObjectToe(new Muur(8, 7));
            speelVeld.VoegSpelObjectToe(new Muur(9, 7));
            speelVeld.VoegSpelObjectToe(new Muur(10, 7));
            speelVeld.VoegSpelObjectToe(new Muur(11, 7));
            speelVeld.VoegSpelObjectToe(new Muur(12, 7));
            speelVeld.VoegSpelObjectToe(new Muur(13, 7));
            #endregion

            //Rechter binnen muur
            #region Rechter binnen muur

            speelVeld.VoegSpelObjectToe(new Muur(13, 6));
            speelVeld.VoegSpelObjectToe(new Muur(13, 4));
            #endregion

            //power ups
            #region power ups
            speelVeld.VoegSpelObjectToe(new PowerUp(6, 6));
            #endregion

            //Waterplas
            #region Waterplas
            speelVeld.VoegSpelObjectToe(new Waterplas(3, 8));
            #endregion

            //Schilderij
            #region Schilderij
            speelVeld.VoegSpelObjectToe(new Schilderij(4, 4));
            speelVeld.VoegSpelObjectToe(new Schilderij(12, 4));
            #endregion

            //Guard
            #region Guard
            Bewaker bewaker = new Bewaker(12, 0, 2, 0, 5);
            speelVeld.VoegSpelObjectToe(bewaker);
            

            #endregion


            #endregion

            Form1 form1 = new Form1(speelVeld); //Publisher
            SpeelVeldController speelVeldController = new SpeelVeldController(form1, speelVeld);//Controller
            form1.KeyPressed += speelVeldController.OnKeyPressed; //Subscriber
            form1.KeyRealeased += speelVeldController.OnKeyUp; //Subscriber
            gameloop.ModelChanged += form1.OnModelChanged; //Subscriber
            gameloop.BewakerAction += speelVeld.GuardAutomaticMovement; //Subscriber


            Menu menu = new Menu();
            Application.Run(menu);
            Application.Run(form1);
            bool GameOver = true;

            while (!GameOver)
            {

            }
        }
    }
}
