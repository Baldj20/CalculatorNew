using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorNew
{
    public class ButtonHandler
    {
        private TextBox entryField;
        private RichTextBox historyField;
        private VariableHandler variableHandler;

        public ButtonHandler(TextBox entryField, RichTextBox historyField)
        {
            this.entryField = entryField;
            this.historyField = historyField;
            this.variableHandler = new VariableHandler(historyField, entryField);
        }

        public void NumberButton_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor((sender as Button)?.Text);
        }

        public void CommaButton_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor(",");
        }

        public void Dot_Button_Click(object sender, EventArgs e)
        {
            if (!entryField.Text.Contains(".") && entryField.Text != "")
            {
                InsertTextAtCursor(".");
            }
        }

        public void X_Button_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("x");
        }

        public void Y_Button_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("y");
        }

        public void Z_Button_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("z");
        }

        public void FunctionX_Button_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("F(x)");
            entryField.SelectionStart -= 2;
        }

        public void FunctionXY_Button_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("F(x,y)");
            entryField.SelectionStart -= 4;
        }

        public void FunctionXYZ_Button_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("F(x,y,z)");
            entryField.SelectionStart -= 6; 
        }

        public void LeftBrackets_Button_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("(");
        }

        public void RightBrackets_Button_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor(")");
        }


        public void Enter_Button_Click(object sender, EventArgs e)
        {
            string expression = entryField.Text.Trim();
            if (string.IsNullOrEmpty(expression))
            {
                return;
            }

            try
            {
                double answer = 0;               
                string parsedStr = Parsing.Parse(expression);
                switch (parsedStr)
                {
                    case "Variable":
                    case "Function":
                        historyField.AppendText(expression + Environment.NewLine);
                        entryField.Clear();
                        break;
                    case "Incorrect input":
                        WarningMessage.ThrowErrorMessage();
                        break;
                    default:
                        answer = CalcResult.Evaluate(parsedStr);
                        historyField.AppendText(expression + " = " + answer + Environment.NewLine);
                        entryField.Clear();
                        break;
                }                                              
            }
            catch (Exception ex)
            {
                historyField.AppendText("Ошибка. " + ex.Message + Environment.NewLine);
            }
        }

        public void OperationButton_Click(string operation)
        {
            InsertTextAtCursor($" {operation} ");
        }

        public void Equals_Button_Click()
        {
            InsertTextAtCursor(" = ");
        }

        public void Delete_Button_Click()
        {
            if (entryField.SelectionStart > 0)
            {
                int selectionStart = entryField.SelectionStart;
                entryField.Text = entryField.Text.Remove(selectionStart - 1, 1);
                entryField.SelectionStart = selectionStart - 1;
            }
        }

        public void Clear_Button_Click()
        {
            entryField.Clear();
        }

        public void HistoryField_MouseClick(object sender, MouseEventArgs e)
        {
            variableHandler.HandleHistoryFieldClick(e.Location);
        }
        private void InsertTextAtCursor(string text)
        {
            int selectionStart = entryField.SelectionStart;
            entryField.Text = entryField.Text.Insert(selectionStart, text);
            entryField.SelectionStart = selectionStart + text.Length;
        }
    }
}
