using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace LearningCSharp
{
    public partial class frm_setups : Form
    {
        MySqlConnection MyConnection = new MySqlConnection();
        MySqlDataAdapter Adaptador = new MySqlDataAdapter();
        DataSet Ds = new DataSet();
        MySqlCommand cmd = new MySqlCommand();
        string SqlQ;

        public frm_setups()
        {
            InitializeComponent();
            MyConnection.ConnectionString = ("Server=localhost;Uid=root;Pwd=iLM14PC1191;Database=Restaurant");
        }

        private void chkIncluirItbis_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncluirItbis.Checked == true)
            { 
                chkIncluirItbis.Tag=1;
            }
            else
            {
                chkIncluirItbis.Tag = 0;
            }
        }

        private void frm_setups_Load(object sender, EventArgs e)
        {
            CargarConfiguracion();
        }

        private void CargarConfiguracion()
        {
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT valueint FROM restaurant.configuracion where idconfiguracion=1", MyConnection);
            chkIncluirItbis.Tag = Convert.ToString(cmd.ExecuteScalar());

            if (chkIncluirItbis.Tag.ToString() == "1")
            { chkIncluirItbis.Checked = true; }
            else { chkIncluirItbis.Checked = false; }
            
            MyConnection.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
              MyConnection.Open();

            // Inlcuir Itbis en Precio
            SqlQ = "UPDATE Configuracion SET valueint='" + Convert.ToInt16(chkIncluirItbis.Tag)+ "' WHERE IDConfiguracion=1";
            guardardatos();

            MyConnection.Close();

            MessageBox.Show(this, "La configuración ha sido guardada satisfactoriamente.", "Guardado exitoso");
        }


        private void guardardatos()
        {
            try 
            
            {
                cmd = new MySqlCommand(SqlQ, MyConnection);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Se ha encontrado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void frm_setups_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frm_start frm_tmp = new frm_start();
            //frm_tmp.Configuracion();
        }

    }
}
