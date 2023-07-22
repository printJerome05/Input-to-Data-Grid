using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDatabase
{
    public partial class Form1 : Form
    {
        public string Id  // property
        { get; set; }

        public string LastName  // property
        { get; set; }

        public string FirstName  // property
        { get; set; }

        public string Position  // property
        { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        }
    }
}
