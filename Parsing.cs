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
                    //WarningMessage.ThrowErrorMessage();
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
                        //WarningMessage.ThrowErrorMessage();
                        return "Incorrect input";
                    }
            }
        }

        public static string ConvertToReversePolandNotation(string input)
        {
            var output = new StringBuilder();
            Stack<char> stack = new Stack<char>();
            char previous_token = '\0';

            foreach (char token in input)
            {
                if ((previous_token == 44 || previous_token == 46) && !char.IsDigit(token))
                {
                    output.Append('0').Append(' ');
                }
                if (char.IsDigit(token) && char.IsDigit(previous_token))
                {
                    output.Remove(output.Length - 1, 1).Append(token).Append(' ');
                }
                else if ((token == 46 || token == 44) && char.IsDigit(previous_token))
                {
                    output.Remove(output.Length - 1, 1).Append(',');
                }
                else if (char.IsDigit(token))
                {
                    output.Append(token).Append(' ');
                }
                else if (Validation.IsOperator(token))
                {
                    while (stack.Count > 0 && Validation.IsOperator(stack.Peek()) && GetOperatorPriority(stack.Peek()) >= GetOperatorPriority(token))
                    {
                        output.Append(stack.Pop()).Append(' ');
                    }
                    stack.Push(token);
                }
                else if (token == '(')
                {
                    stack.Push(token);
                }
                else if (token == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        output.Append(stack.Pop()).Append(' ');
                    }
                    if (stack.Count > 0 && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                previous_token = token;
            }

            while (stack.Count > 0)
            {
                output.Append(stack.Pop()).Append(' ');
            }

            return output.ToString().Trim();
        }



        public static int GetOperatorPriority(char operator_symbol)
        {
            if (operator_symbol == '+' || operator_symbol == '-')
            {
                return 1;
            }
            else if (operator_symbol == '*' || operator_symbol == '/')
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
