using System;
using VectorTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVectorTask
{
    [TestClass]
    public class VectorUnitTests
    {
        private readonly Vector _vector1 = new Vector(new double[] { 2, 3, 4 });
        private readonly Vector _vector2 = new Vector(new double[] { 5, 6, 7 });

        [TestMethod]
        public void TestAdd()
        {
            _vector1.Add(_vector2);

            var vector3 = new Vector(new double[] { 5, 7, 9 });

            Assert.AreEqual(vector3, _vector1);
        }

        [TestMethod]
        public void TestVectorArguments_ThrowsArgumentException()
        {
            double[] array = { };

            Assert.ThrowsException<ArgumentException>(() => new Vector(0));
            Assert.ThrowsException<ArgumentException>(() => new Vector(array));
        }

        [TestMethod]
        public void TestMultiplyByScalar()
        {
            var result = Vector.GetScalarProduct(_vector1, _vector2);

            Assert.AreEqual(32, result);
        }
    }
}
