using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyUseWizardsLib
{
    public partial class UserInputForm : Form
    {
        private string customMessage;

        public UserInputForm()
        {
            InitializeComponent();
        }

        public string get_CustomMessage()
        {
            return customMessage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customMessage = textBox1.Text;

            this.Dispose();
        }
    }
}
