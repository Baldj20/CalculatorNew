using NUnit.Framework;

namespace CalculatorNew.Tests
{
    public class VariablesTests
    {
        // Переменная и число

        [Test]
        public void SumXandNumber()
        {
            Parsing.Parse("x = 5");
            string expression = "x + 10";
            double expected = 15;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void DiffXandNumber()
        {
            Parsing.Parse("x = 10");
            string expression = "x - 10";
            double expected = 0;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void MultXandNumber()
        {
            Parsing.Parse("x = 15");
            string expression = "x * 10";
            double expected = 150;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void DivXandNumber()
        {
            Parsing.Parse("x = 20");
            string expression = "x / 10";
            double expected = 2;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        // Две переменные

        [Test]
        public void SumXandY()
        {
            Parsing.Parse("x = 5");
            Parsing.Parse("y = 10");
            string expression = "x + y";
            double expected = 15;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void DiffXandY()
        {
            Parsing.Parse("x = 20");
            Parsing.Parse("y = 10");
            string expression = "x - y";
            double expected = 10;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void MultXandY()
        {
            Parsing.Parse("x = 2");
            Parsing.Parse("y = 3");
            string expression = "x * y";
            double expected = 6;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void DivXandY()
        {
            Parsing.Parse("x = 10");
            Parsing.Parse("y = 5");
            string expression = "x / y";
            double expected = 2;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        // Три переменные

        [Test]
        public void XplusYminusZ()
        {
            Parsing.Parse("x = 5");
            Parsing.Parse("y = 10");
            Parsing.Parse("z = 3");
            string expression = "x + y - z";
            double expected = 12;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void XmultYdivZ()
        {
            Parsing.Parse("x = 5");
            Parsing.Parse("y = 5");
            Parsing.Parse("z = 10");
            string expression = "x * y / z";
            double expected = 2.5;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void XplusYmultZ()
        {
            Parsing.Parse("x = 5");
            Parsing.Parse("y = 3");
            Parsing.Parse("z = 10");
            string expression = "x + y * z";
            double expected = 35;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void XminusYdivZ()
        {
            Parsing.Parse("x = 5");
            Parsing.Parse("y = 10");
            Parsing.Parse("z = 2");
            string expression = "x - y / z";
            double expected = 0;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }
    }
}