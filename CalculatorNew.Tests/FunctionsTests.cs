using NUnit.Framework;

namespace CalculatorNew.Tests
{
    public class FunctionsTests
    {
        [Test]
        public void Fx()
        {
            Parsing.Parse("F(x) = x * x");
            string expression = "F(9)";
            double expected = 81;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Fxy()
        {
            Parsing.Parse("F(x,y) = x / y");
            string expression = "F(10,2)";
            double expected = 5;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Fxyz()
        {
            Parsing.Parse("F(x,y,z) = x + y * z");
            string expression = "F(5,2,10)";
            double expected = 25;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

    }
}