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
    public partial class frmORMappingWindow : Form
    {
        public static ConnectionWindow.SqlConnectionInfo ConnectionInfo; // = new ConnectionWindow.SqlConnectionInfo();

        public frmORMappingWindow()
        {
            InitializeComponent();
        }

        private void frmORMappingWindow_Load(object sender, EventArgs e)
        {
            ConnectionInfo = new ConnectionWindow.SqlConnectionInfo();
        }

        private static List<string> selectedTables = null;
        /// <summary>
        /// 紀錄畫面所選擇的Tables名稱
        /// </summary>
        public static List<string> SelectedTables
        {
            get
            {
                if (selectedTables == null)
                    selectedTables = new List<string>();
                return selectedTables;
            }
            set { selectedTables = value; }
        }

        private void SetLog(string LogText)
        {
            txtLog.Text += string.Format("{0}\r\n", LogText);
        }

        private void btnGetTable_Click(object sender, EventArgs e)
        {
            SchemaData schemaData = new SchemaData();
            var result = schemaData.GetTableData();
            SetLog("讀取 Schema..");
            treeView1.Nodes[0].Text = frmORMappingWindow.ConnectionInfo.Initial_Catalog;
            SetLog(string.Format("讀取資料庫 {0}..", frmORMappingWindow.ConnectionInfo.Initial_Catalog));
            treeView1.Nodes[0].Nodes.Clear();
            foreach (var schema in result)
            {
                TreeNode node = new TreeNode(schema.SCHEMA_Field03);
                treeView1.Nodes[0].Nodes.Add(node);
            }
            SetLog("讀取資料表完成.");
            treeView1.ExpandAll();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "Root")
            {
                foreach (TreeNode n in e.Node.Nodes)
                {
                    n.Checked = e.Node.Checked;
                }
            }
            else
            {
                if (e.Node.Checked)
                {
                    SelectedTables.Add(e.Node.Text);
                }
                else
                    SelectedTables.Remove(e.Node.Text);
            }
        }

        private void frmORMappingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                throw new WizardCancelledException("使用者取消作業！");
        }
    }
}
