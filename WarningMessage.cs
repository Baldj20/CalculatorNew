using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorNew
{
    internal static class WarningMessage
    {
        public static void ThrowErrorMessage()
        {
            MessageBox.Show("Incorrect input!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
