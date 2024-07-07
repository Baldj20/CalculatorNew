﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorNew
{
    internal static class Validation
    {
        static List<string> validCharacters = new List<string>()
        {
            "+","-","*","/","1","2","3","4","5","6","7","8","9","0",")","(", ".", " "
        };
        static bool IsValidSymbol(char symbol)
        {
            foreach (string character in validCharacters)
            {
                if (character == symbol.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsOperator(char symbol)
        {
            return symbol == 42 || symbol == 43 || symbol == 45 || symbol == 47;
        }
        public static bool IsValidString(ref string input)
        {
            input = Regex.Replace(input, @"(\d+)\(", "$1*(");
            input = Regex.Replace(input, @"\)(\d+)", ")*$1");
            input = Regex.Replace(input, @"(\d+)\)\((\d+)", "$1)*($2");

            input = input.Replace(" ", "");
            bool result = true;
            for (int i = 0; i < input.Length; i++)
            {
                result = result && IsValidSymbol(input[i]);
            }

            if (input[0] == 44 || input[0] == 46 || input[0] == 42 || input[0] == 43 || input[0] == 47)
            {
                return false;
            }

            char previous_symbol = '\0';
            foreach (var symbol in input)
            {
                if ((previous_symbol == 44 || previous_symbol == 46 || IsOperator(previous_symbol)) && (symbol == 44 || symbol == 46 || IsOperator(symbol)))
                {
                    return false;
                }

                previous_symbol = symbol;
            }
            return result;
        }
    }
}
