using NUnit.Framework;
using System;

namespace NUnitWithDotNetCoreRC2.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(1, 1, 2)]
        [TestCase(-1, -1, -2)]
        [TestCase(100, 5, 105)]
        public void CanAddNumbers(int x, int y, int expected)
        {
            Assert.That(Calculator.Add(x, y), Is.EqualTo(expected));
        }

        [TestCase(1, 1, 0)]
        [TestCase(-1, -1, 0)]
        [TestCase(100, 5, 95)]
        public void CanSubtract(int x, int y, int expected)
        {
            Assert.That(Calculator.Subtract(x, y), Is.EqualTo(expected));
        }

        [TestCase(1, 1, 1)]
        [TestCase(-1, -1, 1)]
        [TestCase(100, 5, 500)]
        public void CanMultiply(int x, int y, int expected)
        {
            Assert.That(Calculator.Multiply(x, y), Is.EqualTo(expected));
        }

        [TestCase(1, 1, 1)]
        [TestCase(-1, -1, 1)]
        [TestCase(100, 5, 20)]
        public void CanDivide(int x, int y, int expected)
        {
            Assert.That(Calculator.Divide(x, y), Is.EqualTo(expected));
        }

        //[Test]
        //public void FailedTest()
        //{
        //    Assert.That(1 + 1, Is.EqualTo(3));
        //}

        //[Test]
        //public void ErrorTest()
        //{
        //    throw new ArgumentException();
        //}

        [Test]
        [Category("One")]
        public void TestWithConsoleOutput()
        {
            Console.WriteLine("Console output");
        }

        [Test]
        [Category("Two")]
        public void TestWithTestContextOutput()
        {
            TestContext.WriteLine("Test context output");
        }

        [Test]
        [Category("One")]
        [Category("Two")]
        public void MultipleCategoryTest()
        {
        }

        [Test]
        [Ignore("Ignored Test")]
        public void IgnoredTest()
        {
        }

        [Test]
        [Explicit("Explicit Test")]
        public void ExplicitTest()
        {
        }
    }
}
