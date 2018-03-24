using System;
using NUnit.Framework;
using Task2.StringConverterLibrary;


namespace Task2.Tests
{
    [TestFixture]
    public class StringConverterTests
    {
        [TestCase("-10", -10)]
        [TestCase("11", 11)]
        [TestCase("+1", 1)]
        [TestCase("0", 0)]
        [TestCase("-1134", -1134)]
        [TestCase("1534", 1534)]
        [TestCase("+1234", 1234)]
        [TestCase("+2147483647", int.MaxValue)]
        [TestCase("-2147483648", int.MinValue)]
        [Test]
        public void ValidIntString_ParsedIntResult(string number, int expected)
        {
            int actual = number.ToInt();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [Test]
        public void InvalidArgument_ArgumentExceptionThrown(string number)
        {
            Assert.Throws<ArgumentException>(() => number.ToInt());
        }

        [TestCase("21474836485")]
        [TestCase("-21474836494")]
        [Test]
        public void TooBigNumber_OverflowExceptionThrown(string number)
        {
            Assert.Throws<OverflowException>(() => number.ToInt());
        }

        [TestCase("++111")]
        [TestCase("--111")]
        [TestCase("11.53")]
        [TestCase("1,83")]
        [TestCase("dfsdfsd")]
        [TestCase("15 + 12")]
        [Test]
        public void InvalidNumberFormat_FormatExceptionThrown(string number)
        {
            Assert.Throws<FormatException>(() => number.ToInt());
        }

    }
}
