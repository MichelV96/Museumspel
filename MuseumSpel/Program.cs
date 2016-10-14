using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

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
            Speler speler = new Speler("Player", 13, 0, 5);
            GameLoop gameloop = new GameLoop();
            SpeelVeld speelVeld = new SpeelVeld(17, 11, speler, gameloop);//Model

            //xml
            XDocument doc = new XDocument();
            doc = XDocument.Load(@"speelveld.xml");
            int countLevels = doc.Descendants("level").Count();

            Menu menu = new Menu(countLevels);
            Application.Run(menu);

            if (menu.startSpel)
            {
                Console.WriteLine();
                //om het goede level te zoeken in de xml file.
                var level = from lvl in doc.Root.Elements("level") where (String)lvl.Element("nummer") == menu.spelLevel.ToString() select lvl;
                //alle gameobjecten
                var muren = level.Descendants("muren").Descendants("muur");
                var schilderijen = level.Descendants("schilderijen").Descendants("schilderij");
                var powerups = level.Descendants("powerups").Descendants("powerup");
                var waterplassen = level.Descendants("waterplassen").Descendants("waterplas");
                var eindpunten = level.Descendants("eindpunten").Descendants("eindpunt");

                //en ze aanmaken + toevoegen aan het speelveld. De trim is ervoor dat er geen spaties of tabs in het element meer zitten.
                foreach (XElement e in muren)
                {
                    int x = Int32.Parse(e.Element("x").Value.Trim());
                    int y = Int32.Parse(e.Element("y").Value.Trim());
                    speelVeld.VoegSpelObjectToe(new Muur(x, y));
                }

                foreach (XElement e in schilderijen)
                {
                    int x = Int32.Parse(e.Element("x").Value.Trim());
                    int y = Int32.Parse(e.Element("y").Value.Trim());
                    speelVeld.VoegSpelObjectToe(new Schilderij(x, y));
                }

                foreach (XElement e in powerups)
                {
                    int x = Int32.Parse(e.Element("x").Value.Trim());
                    int y = Int32.Parse(e.Element("y").Value.Trim());
                    speelVeld.VoegSpelObjectToe(new PowerUp(x, y));
                }

                foreach (XElement e in waterplassen)
                {
                    int x = Int32.Parse(e.Element("x").Value.Trim());
                    int y = Int32.Parse(e.Element("y").Value.Trim());
                    speelVeld.VoegSpelObjectToe(new Waterplas(x, y));
                }

                foreach (XElement e in eindpunten)
                {
                    int x = Int32.Parse(e.Element("x").Value.Trim());
                    int y = Int32.Parse(e.Element("y").Value.Trim());
                    speelVeld.VoegSpelObjectToe(new Eindpunt(x, y));
                }

                //Guard
                #region Guard
                speelVeld.voegBewakerToe(new Bewaker(12, 0, 2, 0, Direction.Left));
                //speelVeld.voegBewakerToe(new Bewaker(3, 10, 12, 10, 5, Direction.Left));
                //speelVeld.voegBewakerToe(new Bewaker(2, 2, 2, 8, 5, Direction.Left));
                speelVeld.voegBewakerToe(new Bewaker(16, 1, 16, 10, Direction.Left));
                speelVeld.voegBewakerToe(new Bewaker(4, 4, 4, 4, Direction.Down));//stilstaand
                speelVeld.voegBewakerToe(new Bewaker(0, 1, 0, 8, Direction.Down));
                speelVeld.voegBewakerToe(new Bewaker(2, 2, 2, 8, 14, 8, 14, 2, Direction.Left));
                speelVeld.voegBewakerToe(new Bewaker(5, 10, 10, 10, Direction.Left));
                    #endregion


                Form1 form1 = new Form1(speelVeld, menu); //Publisher
                SpeelVeldController speelVeldController = new SpeelVeldController(form1, speelVeld);//Controller
                form1.KeyPressed += speelVeldController.OnKeyPressed; //Subscriber
                form1.KeyRealeased += speelVeldController.OnKeyUp; //Subscriber
                gameloop.ModelChanged += form1.OnModelChanged; //Subscriber
                gameloop.BewakerAction += speelVeld.GuardAutomaticMovement; //Subscriber
                gameloop.BewakerAction += speelVeld.GuardDetectPlayer; //Subscriber
                speelVeld.shuttingUp += form1.shuttingUp; //Subscriber

                Application.Run(form1);
            }
            
            
            bool GameOver = true;

            while (!GameOver)
            {

            }
        }
    }
}
