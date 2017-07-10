using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KalvinSquare_Abbyy.VATProdPostingGroup
{
    public partial class VATProdPostingGroups : Form
    {
        private List<VATProdPostingGroup_Item> _groups;
        int lineCount;

        public VATProdPostingGroups()
        {
            InitializeComponent();
        }

        public void InitForm()
        {
            this.lineCount = 3;
            this._groups = new List<VATProdPostingGroup_Item>();
            //this._groups = Helpers.Extensions.Clone<VATProdPostingGroup_Item>(DBClientVATProdPostingGroups.GetVatProdPostingGroup_Items());

            for (int i = 1; i <= lineCount; i++)
            {
                ComboBox linebox = new ComboBox();
                Label linelabel = new Label();

                linelabel.Text = i.ToString() + ". item:";
                linelabel.Location = new Point(10, i * 30);
                linelabel.Size = new Size(75, 30);

                linebox.Location = new Point(90, i * 30);
                linebox.Size = new Size(300, 30);
                linebox.DataSource = Helpers.Extensions.Clone<VATProdPostingGroup_Item>(this._groups);
                linebox.DisplayMember = "Description";


                this.Controls.Add(linebox);
                this.Controls.Add(linelabel);
            }
            MessageBox.Show("Start");
            
        }
    }
}
