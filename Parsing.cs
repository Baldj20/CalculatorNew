using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorNew
{
    public class Parsing
    {
        public static string Parse(in string input)
        {
            string output = input;
            if (UserFunction.isFunctionCreating(output))
            {
                UserFunction.functions.Add(UserFunction.CreateUserFunction(output));
                return "Function";
            }
            output = UserFunction.ConvertFunctionsToExpression(output);
            output = Variable.ParseInput(output);
            switch (output)
            {
                case "Incorrect input":
                    return "Incorrect input";
                case "Variable":
                    return output;
                default:
                    if (Validation.IsValidString(ref output))
                    {
                        return ConvertToReversePolandNotation(output);
                    }
                    else
                    {
                        return "Incorrect input";
                    }
            }
        }

        public static int GetOperatorPriority(string operator_symbol)
        {
            if (operator_symbol == "+" || operator_symbol == "-")
            {
                return 1;
            }
            else if (operator_symbol == "*" || operator_symbol == "/")
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        public static string ConvertToReversePolandNotation(string input)
        {
            StringBuilder output = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            string[] tokens = TokenizeInput(input);

            foreach (string token in tokens)
            {
                if (IsNumber(token))
                {
                    output.Append(token).Append(" ");
                }
                else if (Validation.IsOperator(token))
                {
                    while (stack.Count > 0 && Validation.IsOperator(stack.Peek()) && GetOperatorPriority(stack.Peek()) >= GetOperatorPriority(token))
                    {
                        output.Append(stack.Pop()).Append(" ");
                    }
                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        output.Append(stack.Pop()).Append(" ");
                    }
                    if (stack.Count > 0 && stack.Peek() == "(")
                    {
                        stack.Pop();
                    }
                }
            }

            while (stack.Count > 0)
            {
                output.Append(stack.Pop()).Append(" ");
            }

            return output.ToString().TrimEnd();
        }

        private static string[] TokenizeInput(string input)
        {
            input = input.Replace(" ", "");
            input = input.Replace("(-", "(0-");
            input = input.Replace("+-", "+0-"); 
            input = input.Replace("*-", "*0-"); 
            input = input.Replace("/-", "/0-"); 
            if (input[0] == '-')
            {
                input = "0" + input;
            }
            List<string> tokens = new List<string>();
            StringBuilder currentToken = new StringBuilder();

            foreach (char c in input)
            {
                if (Validation.IsOperator(c.ToString()) || c == '(' || c == ')')
                {
                    if (currentToken.Length > 0)
                    {
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }
                    tokens.Add(c.ToString());
                }
                else
                {
                    currentToken.Append(c);
                }
            }

            if (currentToken.Length > 0)
            {
                tokens.Add(currentToken.ToString());
            }

            return tokens.ToArray();
        }
        private static bool IsNumber(string token)
        {
            return double.TryParse(token, out _);
        }
    }
}
