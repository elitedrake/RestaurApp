using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningCSharp
{
    public partial class frm_propietario_cuenta : Form
    {
        public frm_propietario_cuenta()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_start.Propietario = textBox1.Text;
            this.Close();
        }
    }
}
