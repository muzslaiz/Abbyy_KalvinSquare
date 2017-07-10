using KalvinSquare_Abbyy.VATProdPostingGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KalvinSquare_Abbyy.CurrencyFactor
{
    public partial class CurrencyFactorForm : Form
    {
        List<CurrencyFactorItem> currencies;
        public CurrencyFactorItem selectedCurrency;

        public CurrencyFactorForm()
        {
            InitializeComponent();
        }

        public void InitForm(string currencyCode)
        {
            try
            {
                this.currencies = new List<CurrencyFactorItem>();
                this.selectedCurrency = new CurrencyFactorItem();
                this.currencies = Helpers.Extensions.Clone<CurrencyFactorItem>(DBClientCurrencyFactor.GetCurrencyFactors(currencyCode));

                this.dgv_main.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgv_main.MultiSelect = false;
                this.dgv_main.ReadOnly = true;
                this.dgv_main.DataSource = currencies;
                //this.dgv_main.AutoGenerateColumns = true;
                this.dgv_main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.dgv_main.Columns[0].HeaderText = "Currency";
                this.dgv_main.Columns[1].HeaderText = "Date";
                this.dgv_main.Columns[2].HeaderText = "Exchange Rate";

                this.dgv_main.Columns[1].DefaultCellStyle.Format = "yyyy.MM.dd.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            this.selectedCurrency.CurrencyCode = this.dgv_main.CurrentRow.Cells[0].FormattedValue.ToString();
            this.selectedCurrency.StartingDate = DateTime.Parse(this.dgv_main.CurrentRow.Cells[1].FormattedValue.ToString());
            this.selectedCurrency.ExchangeRate = double.Parse(this.dgv_main.CurrentRow.Cells[2].FormattedValue.ToString());
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
