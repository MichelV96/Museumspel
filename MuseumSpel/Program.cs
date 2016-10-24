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
            //XDocument doc = new XDocument();
            //doc = XDocument.Load(@"speelveld.xml");
            Menu menu = new Menu(speelVeld);
            Application.Run(menu);

            if (menu.startSpel)
            {
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
        }
    }
}
