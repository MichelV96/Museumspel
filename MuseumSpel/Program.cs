using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

            //xml
            XmlDocument doc = new XmlDocument();
            doc.Load(@"speelveld.xml");

            XmlNodeList muren = doc.DocumentElement.SelectNodes("/levels/level/gameobjecten/muren/muur");
            XmlNodeList schilderijen = doc.DocumentElement.SelectNodes("/levels/level/gameobjecten/schilderijen/schilderij");
            XmlNodeList waterplassen = doc.DocumentElement.SelectNodes("/levels/level/gameobjecten/waterplassen/waterplas");
            XmlNodeList powerups = doc.DocumentElement.SelectNodes("/levels/level/gameobjecten/powerups/powerup");


            //de trim is zodat alle tabs en spaties weg wordengehaald
            foreach (XmlNode muur in muren)
            {
                int x = Int32.Parse(muur.SelectSingleNode("x").InnerText.Trim());
                int y = Int32.Parse(muur.SelectSingleNode("y").InnerText.Trim());
                speelVeld.VoegSpelObjectToe(new Muur(x, y));
            }
            foreach (XmlNode schilderij in schilderijen)
            {
                int x = Int32.Parse(schilderij.SelectSingleNode("x").InnerText.Trim());
                int y = Int32.Parse(schilderij.SelectSingleNode("y").InnerText.Trim());
                speelVeld.VoegSpelObjectToe(new Schilderij(x, y));
            }
            foreach (XmlNode waterplas in waterplassen)
            {
                int x = Int32.Parse(waterplas.SelectSingleNode("x").InnerText.Trim());
                int y = Int32.Parse(waterplas.SelectSingleNode("y").InnerText.Trim());
                speelVeld.VoegSpelObjectToe(new Waterplas(x, y));
            }
            foreach (XmlNode powerup in powerups)
            {
                int x = Int32.Parse(powerup.SelectSingleNode("x").InnerText.Trim());
                int y = Int32.Parse(powerup.SelectSingleNode("y").InnerText.Trim());
                speelVeld.VoegSpelObjectToe(new PowerUp(x, y));
            }


            //Guard
            #region Guard
            speelVeld.voegBewakerToe(new Bewaker(12, 0, 2, 0, 5));
            speelVeld.voegBewakerToe(new Bewaker(3, 10, 12, 10, 5));
            speelVeld.voegBewakerToe(new Bewaker(2, 2, 2, 8, 5));
            speelVeld.voegBewakerToe(new Bewaker(14, 3, 14, 5, 5));
            speelVeld.voegBewakerToe(new Bewaker(4, 4, 4, 4, 5));

            #endregion

            Form1 form1 = new Form1(speelVeld); //Publisher
            SpeelVeldController speelVeldController = new SpeelVeldController(form1, speelVeld);//Controller
            form1.KeyPressed += speelVeldController.OnKeyPressed; //Subscriber
            form1.KeyRealeased += speelVeldController.OnKeyUp; //Subscriber
            gameloop.ModelChanged += form1.OnModelChanged; //Subscriber
            gameloop.BewakerAction += speelVeld.GuardAutomaticMovement; //Subscriber
            gameloop.BewakerAction += speelVeld.GuardDetectPlayer; //Subscriber

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
