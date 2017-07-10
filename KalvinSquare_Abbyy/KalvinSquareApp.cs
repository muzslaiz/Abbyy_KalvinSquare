using KalvinSquare_Abbyy.CurrencyFactor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KalvinSquare_Abbyy
{
    public static class KalvinSquareApp
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        public static CurrencyFactorItem LoadCurrencyFactorForm(string _currencyCode)
        {
            CurrencyFactorForm frm = new CurrencyFactorForm();
            frm.InitForm(_currencyCode);
            frm.ShowDialog();
            frm.Enabled = true;
            return frm.selectedCurrency;
        }
    }
}
