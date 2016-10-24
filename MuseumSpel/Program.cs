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
            SpeelVeld speelVeld = new SpeelVeld(17, 11);//Model
            
            Menu menu = new Menu(speelVeld);
            Application.Run(menu);

            if (menu.startSpel)
            {
                Form1 form1 = new Form1(speelVeld, menu); //Publisher
                SpeelVeldController speelVeldController = new SpeelVeldController(form1, speelVeld, menu.controls);//Controller
                Application.Run(form1);
            }
        }
    }
}
