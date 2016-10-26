using System;
using MuseumSpel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Bewaker_UnitTest
    {
        //Geen exception
        [TestMethod]
        public void Bewaker_AanmakenMetEenPathsMetJuisteCordinaten()
        {
            //act
            Bewaker b1 = new Bewaker(0, 0, Direction.Down);

            //assert
            Assert.IsNotNull(b1);
        }

        [TestMethod]
        public void Bewaker_AanmakenMetTweePathsMetJuisteCordinaten()
        {
            //act
            Bewaker b1 = new Bewaker(0, 0, 0, 10, Direction.Down);

            //assert
            Assert.IsNotNull(b1);
        }

        [TestMethod]
        public void Bewaker_AanmakenMetDriePathsMetJuisteCordinaten()
        {
            //act
            Bewaker b1 = new Bewaker(0, 0, 0, 10, 10, 10, Direction.Down);

            //assert
            Assert.IsNotNull(b1);
        }

        [TestMethod]
        public void Bewaker_AanmakenMetVierPathsMetJuisteCordinaten()
        {
            //act
            Bewaker b1 = new Bewaker(0, 0, 0, 10, 10, 10, 10, 0, Direction.Down);

            //assert
            Assert.IsNotNull(b1);
        }

        [TestMethod]
        public void Bewaker_AanmakenMetEenPathsMetJuisteCordinatenJuisteAantalPathsOpgeslagen()
        {
            //act
            Bewaker b1 = new Bewaker(0, 0, Direction.Down);

            //assert
            // twee paths moeten worden opgeslagen omdat de constructor met twee paths wordt gebruik bij het maken van een bewaker met één path
            Assert.AreEqual(2, b1.aantalpaths); 
        }

        [TestMethod]
        public void Bewaker_AanmakenMetTweePathsMetJuisteCordinatenJuisteAantalPathsOpgeslagen()
        {
            //act
            Bewaker b1 = new Bewaker(0, 0, 0, 10, Direction.Down);

            //assert
            Assert.AreEqual(2, b1.aantalpaths);
        }

        [TestMethod]
        public void Bewaker_AanmakenMetDriePathsMetJuisteCordinatenJuisteAantalPathsOpgeslagen()
        {
            //act
            Bewaker b1 = new Bewaker(0, 0, 0, 10, 10, 10, Direction.Down);

            //assert
            // vier paths moeten worden opgeslagen omdat de constructor met vier paths wordt gebruik bij het maken van een bewaker met drie paths
            Assert.AreEqual(4, b1.aantalpaths);
        }

        [TestMethod]
        public void Bewaker_AanmakenMetVierPathsMetJuisteCordinatenJuisteAantalPathsOpgeslagen()
        {
            //act
            Bewaker b1 = new Bewaker(0, 0, 0, 10, 10, 10, 10, 0, Direction.Down);

            //assert
            Assert.AreEqual(4, b1.aantalpaths);
        }

        //Zou exceptions moeten geven
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Bewaker_AanmakenMetTweePathsMetFouteCordinaten()
        {
            Bewaker b1 = new Bewaker(0, 0, 1, 1, Direction.Down);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Bewaker_AanmakenMetDriePathsMetFouteTweedeCordinaten()
        {
            Bewaker b1 = new Bewaker(0, 0, 1, 1, 1, 2, Direction.Down);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Bewaker_AanmakenMetDriePathsMetFouteDerdeCordinaten()
        {
            Bewaker b1 = new Bewaker(0, 0, 0, 1, 2, 2, Direction.Down);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Bewaker_AanmakenMetVierPathsMetFouteTweedeCordinaten()
        {
            Bewaker b1 = new Bewaker(0, 0, 1, 10, 10, 10, 10, 0, Direction.Down);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Bewaker_AanmakenMetVierPathsMetFouteDerdeCordinaten()
        {
            Bewaker b1 = new Bewaker(0, 0, 0, 10, 10, 9, 9, 0, Direction.Down);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Bewaker_AanmakenMetVierPathsMetFouteVierdeCordinaten()
        {
            Bewaker b1 = new Bewaker(0, 0, 0, 10, 10, 10, 10, 1, Direction.Down);
        }
    }
}
