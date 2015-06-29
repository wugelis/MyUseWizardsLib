using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyUseWizardsLib.Data;
using Microsoft.VisualStudio.TemplateWizard;

namespace MyUseWizardsLib
{
    public partial class frmSettings : Form
    {
        public static string SelectedTableName = string.Empty;
        public static string SelectedKey = string.Empty;
        public static IEnumerable<DataColumn> SelectedTableColumns = null;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            ClearSelectedTableData();
            CreateRadioButtonList();
        }

        private void ClearSelectedTableData()
        {
            SelectedTableName = string.Empty;
            SelectedKey = string.Empty;
            SelectedTableColumns = null;
        }

        int y = 20;
        private void CreateRadioButtonList()
        {
            groupBox1.Controls.Clear();

            foreach (string node in frmORMappingWindow.SelectedTables)
            {
                RadioButton radio = new RadioButton(){
                    Location = new Point(20, y),
                    Text = string.Format("{0}", node),
                    Size = new Size(85, 16),
                    AutoSize = true
                };
                radio.CheckedChanged += new EventHandler(radio_CheckedChanged);
                groupBox1.Controls.Add(radio);
                
                y += 20;
            }
        }

        void radio_CheckedChanged(object sender, EventArgs e)
        {
            frmSettings.SelectedTableName = (sender as RadioButton).Text;
            GetAndListColumnsByTable();
        }

        private void GetAndListColumnsByTable()
        {
            SQLStore store = new SQLStore();
            DataTable dt = store.GetNoDataDataTableByName(frmSettings.SelectedTableName);
            lbxColumns.ValueMember = "ColumnName";
            lbxColumns.DisplayMember = "ColumnName";
            SelectedTableColumns = dt.Columns.OfType<DataColumn>().AsEnumerable();
            lbxColumns.DataSource = SelectedTableColumns.ToList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedTableName == string.Empty)
            {
                MessageBox.Show("請選擇一個要當作主要資料存取的資料表。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SelectedKey == string.Empty)
            {
                if (lbxColumns.SelectedItem != null)
                {
                    DialogResult dialog = MessageBox.Show(
                        string.Format("是否要使用 \"{0}\" 當作主要條件？。", lbxColumns.SelectedItem.ToString()),
                        this.Text,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);

                    if (dialog == DialogResult.OK)
                    {
                        SelectedKey = lbxColumns.SelectedItem.ToString();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("請選擇一個要當作主要資料存取的資料表。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void lbxColumns_Click(object sender, EventArgs e)
        {
            ListBox lbx = sender as ListBox;
            if (lbx.SelectedItem != null)
                SelectedKey = lbx.SelectedItem.ToString();
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                throw new WizardCancelledException();
        }
    }
}
