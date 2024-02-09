using static System.Net.Mime.MediaTypeNames;

namespace TestExamenA
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Camino1()
        {
            Assert.AreEqual(ExamenETSA.funcionMatematica(3, 2), 0.8);
        }
        [TestMethod]
        public void Camino2()
        {
            Assert.AreEqual(ExamenETSA.funcionMatematica(3, -1), 5.6);
        }
        [TestMethod]
        public void Camino3 ()
        {
            Assert.AreEqual(ExamenETSA.funcionMatematica(5, 1), 5.6);
        }
        [TestMethod]
        public void Camino4 ()
        {
            Assert.AreEqual(ExamenETSA.funcionMatematica(1, -1), 2.8);
        }
        [TestMethod]
        public void Camino5 ()
        {
            Assert.AreEqual(ExamenETSA.funcionMatematica(10, -1), 2);
        }
    }
}