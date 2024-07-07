using NUnit.Framework;

namespace CalculatorNew.Tests
{
    public class BaseOperationsTests
    {
        //Тест сложения

        [Test]
        public void Sum10and20returned30()
        {
            string expression = "10 + 20";
            double expected = 30;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Sum_5and10returned5()
        {
            string expression = "(0 - 5) + 10";
            double expected = 5;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Sum7and_10returned_3()
        {
            string expression = "7 + (0 - 10)";
            double expected = -3;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Sum_15and_15returned_30()
        {
            string expression = "(0 - 15) + (0 - 15)";
            double expected = -30;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        //Тест вычитания

        [Test]
        public void Diff10and20returned_10()
        {
            string expression = "10 - 20";
            double expected = -10;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Diff_5and10returned_15()
        {
            string expression = "(0 - 5) - 10";
            double expected = -15;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Diff7and_10returned17()
        {
            string expression = "7 - (0 - 10)";
            double expected = 17;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Diff_15and_15returned0()
        {
            string expression = "(0 - 15) - (0 - 15)";
            double expected = 0;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        //Тест умножения

        [Test]
        public void Mult10and20returned200()
        {
            string expression = "10 * 20";
            double expected = 200;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Mult_5and10returned_50()
        {
            string expression = "(0 - 5) * 10";
            double expected = -50;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Mult7and_10returned_70()
        {
            string expression = "7 * (0 - 10)";
            double expected = -70;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Mult_15and_15returned225()
        {
            string expression = "(0 - 15) * (0 - 15)";
            double expected = 225;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        //Тест деления

        [Test]
        public void Div10and20returned0_5()
        {
            string expression = "10 / 20";
            double expected = 0.5;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Div_5and10returned_0_5()
        {
            string expression = "(0 - 5) / 10";
            double expected = -0.5;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Div7and_10returned_0_7()
        {
            string expression = "7 / (0 - 10)";
            double expected = -0.7;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Div_15and_15returned1()
        {
            string expression = "(0 - 15) / (0 - 15)";
            double expected = 1;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        // Тестирование приоритета операций
        [Test]
        public void PriorityOperations()
        {
            string expression = "2 + 2 * 2 + 10 / 2";
            double expected = 11;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        // Тестирование дробных чисел
        [Test]
        public void FractNums()
        {
            string expression = "2,75 / 1,1";
            double expected = 2.5;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

        // Тестирование скобок
        [Test]
        public void Parentheses()
        {
            string expression = "2 * (5 + 10)";
            double expected = 30;

            string parsedStr = Parsing.Parse(expression);
            double answer = CalcResult.Evaluate(parsedStr);

            Assert.AreEqual(expected, answer);
        }

    }
}