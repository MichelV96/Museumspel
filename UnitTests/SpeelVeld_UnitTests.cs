using System;
using MuseumSpel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class SpeelVeld_UnitTests
    {
        [TestMethod]
        public void GetGridCordinate_shouldReturnZero()
        {
            //arange
            int a = 50;
            int b = 51;
            int c = 52;
            //act
            SpeelVeld speelveld = new SpeelVeld(10, 10);
            int aGrid = speelveld.GetGridCordinate(a);
            int bGrid = speelveld.GetGridCordinate(b);
            int cGrid = speelveld.GetGridCordinate(c);
            //assert
            Assert.AreEqual(0, aGrid);
            Assert.AreEqual(0, bGrid);
            Assert.AreEqual(1, cGrid); // gaat over marge(2), zou dus 1 moeten terug geven. 
        }

        [TestMethod]
        public void VoegSpelObjectToe_MoetWordenGevuldAlsDeCordinatenVanMuurBinnenHetGridVanSpeelveldIs()
        {
            //arange

            //act
            SpeelVeld speelveld = new SpeelVeld(10, 10);
            speelveld.VoegSpelObjectToe(new Muur(1, 1));
            speelveld.VoegSpelObjectToe(new Muur(2, 2));
            speelveld.VoegSpelObjectToe(new Muur(3, 3));
            speelveld.VoegSpelObjectToe(new Muur(4, 4));
            speelveld.VoegSpelObjectToe(new Muur(5, 5));

            //assert
            Assert.AreEqual(5, speelveld.spelObjecten.Count);
        }

        [TestMethod]
        public void VoegSpelObjectToe_MoetNietWordenGevuldAlsDeCordinatenVanMuurBoutenHetGridVanSpeelveldIs()
        {
            //arange

            //act
            SpeelVeld speelveld = new SpeelVeld(10, 10);
            speelveld.VoegSpelObjectToe(new Muur(10, 9));
            speelveld.VoegSpelObjectToe(new Muur(10, 10));

            //assert
            Assert.AreEqual(0, speelveld.spelObjecten.Count);
        }

        [TestMethod]
        public void VoegSpelObjectToe_ZouNietMoetWordenGevuldAlsDeCordinatenVanMuurNietBinnenHetGridVanSpeelveldIs()
        {
            //arange

            //act
            SpeelVeld speelveld = new SpeelVeld(10, 10);
            speelveld.VoegSpelObjectToe(new Muur(10, 10));

            //assert
            Assert.AreEqual(0, speelveld.muren.Count);
        }

    }
}
