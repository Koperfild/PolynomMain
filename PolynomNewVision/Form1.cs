using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolynomNewVision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string polynom = textBox1.Text;
            ExpressionBuilder ebuilder = new ExpressionBuilder(polynom);
            TreeNode TN = ebuilder.build();
            string s=TN.execute().ToString();
            textBox2.Text = s;
        }
    }
}
