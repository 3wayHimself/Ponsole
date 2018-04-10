using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponsle_Package_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            openPkg.Filter = "Ponsle Packages | *.ppackage";
            openPkg.ShowDialog();
            textBox1.Text = openPkg.FileName;
        }

        private void inst_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textBox1.Text))
            {
                MessageBox.Show("File does not exist!");
                return;
            }
        }
    }
}
