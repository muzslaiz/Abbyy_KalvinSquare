using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using KalvinSquare_Abbyy.CurrencyFactor;

namespace KalvinSquare_Abbyy_Test
{
    [TestClass]
    public class KalvinSquare_Test
    {
        //[TestMethod]
        //public void TestVATProdPostGroups_Form()
        //{
        //    KalvinSquare_Abbyy.VATProdPostingGroup.VATProdPostingGroups frm = new KalvinSquare_Abbyy.VATProdPostingGroup.VATProdPostingGroups();
        //    frm.InitForm();
        //    frm.ShowDialog();
        //}

        [TestMethod]
        public void TestCurrencyCode_Form()
        {
            CurrencyFactorForm frm = new CurrencyFactorForm();
            MessageBox.Show("Start");
            frm.InitForm("EUR");
            frm.ShowDialog();
            
        }
    }
}
