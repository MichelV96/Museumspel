﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MuseumSpel
{
    //Model
    public class XMLReader
    {
        public SpeelVeld speelVeld;
        public XDocument doc;
        public int spelLevel;


        public XMLReader(SpeelVeld speelVeld, XDocument doc, int spelLevel)
        {
            this.speelVeld = speelVeld;
            this.doc = doc;
            this.spelLevel = spelLevel;
        }

        public void ReadXML()
        {
            //om het goede level te zoeken in de xml file.
            var level = from lvl in doc.Root.Elements("level") where (String)lvl.Element("nummer") == spelLevel.ToString() select lvl;
            //alle gameobjecten
            var speler = level.Descendants("speler");
            var muren = level.Descendants("muren").Descendants("muur");
            var schilderijen = level.Descendants("schilderijen").Descendants("schilderij");
            var powerups = level.Descendants("powerups").Descendants("powerup");
            var waterplassen = level.Descendants("waterplassen").Descendants("waterplas");
            var eindpunten = level.Descendants("eindpunten").Descendants("eindpunt");
            var bewakers = level.Descendants("bewakers").Descendants("bewaker");

            foreach (XElement e in speler)
            {
                string naam = e.Element("naam").Value.Trim();
                int x = Int32.Parse(e.Element("startx").Value.Trim());
                int y = Int32.Parse(e.Element("starty").Value.Trim());
                int speed = Int32.Parse(e.Element("snelheid").Value.Trim());

                speelVeld.speler = new Speler(naam, x, y, speed);
            }
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

            foreach (XElement e in bewakers)
            {
                List<int> guardPunten = new List<int>();
                int startx = Int32.Parse(e.Element("startx").Value.Trim());
                int starty = Int32.Parse(e.Element("starty").Value.Trim());
                var punten = e.Descendants("punten").Descendants("punt");
                var aantalPunten = e.Descendants("punten").Descendants("punt").Count();
                //De Richting eruit halen
                String strRichting = e.Element("richting").Value.Trim();
                //ik pak eerste letter in de richting die maak ik hoofdletter en die plak ik weer achter de rest
                Direction enumRichting = (Direction)Enum.Parse(typeof(Direction), strRichting.Substring(0, 1).ToUpper() + (strRichting.Substring(1, strRichting.Length - 1)));
                foreach (int punt in punten)
                {
                    //elk punt die er instaat in de array stoppen
                    guardPunten.Add(punt);
                }
                if (aantalPunten == 0)
                {
                    speelVeld.voegBewakerToe(new Bewaker(startx, starty, enumRichting));
                }
                if (aantalPunten == 2)
                {
                    speelVeld.voegBewakerToe(new Bewaker(startx, starty, guardPunten[0], guardPunten[1], enumRichting));
                }
                if (aantalPunten == 4)
                {
                    speelVeld.voegBewakerToe(new Bewaker(startx, starty, guardPunten[0], guardPunten[1], guardPunten[2], guardPunten[3], enumRichting));
                }
                if (aantalPunten == 6)
                {
                    speelVeld.voegBewakerToe(new Bewaker(startx, starty, guardPunten[0], guardPunten[1], guardPunten[2], guardPunten[3], guardPunten[4], guardPunten[5], enumRichting));
                }
            }
        }
    }
}
