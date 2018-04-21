using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace LearningCSharp
{
    public partial class frm_mesas : Form
    {
        Boolean _isMoved, MultipleMove, ChangeColorDirext, IsIncluded;
        int _x, _y;
        string IDMesaM, sqlQ;
        MySqlConnection MyConnection = new MySqlConnection();
        MySqlDataAdapter Adaptador = new MySqlDataAdapter();
        DataSet Ds = new DataSet();
        MySqlCommand Cmd = new MySqlCommand();
                
        public frm_mesas()
        {
            InitializeComponent();
            MyConnection.ConnectionString = ("Server=localhost;Uid=root;Pwd=iLM14PC1191;Database=Restaurant");
            EnableDoubleBuffering();
                    }

        public void EnableDoubleBuffering()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterButton();
            BuscarMesas();
            FillClaseMesas();
        }

        private void FillClaseMesas()
        {
            cbxTipoMesa.Items.Clear();
            Ds.Clear();
            MyConnection.Open();
            Cmd = new MySqlCommand("SELECT idclasemesa,clasemesa FROM restaurant.clasemesa ORDER BY idclasemesa ASC", MyConnection);
            Adaptador = new MySqlDataAdapter(Cmd);
            Adaptador.Fill(Ds, "Clases");
            cbxTipoMesa.DisplayMember = "clasemesa";
            cbxTipoMesa.ValueMember = "idclasemesa";

            cbxTipoMesa.DataSource=Ds.Tables["Clases"];
            MyConnection.Close();
            
        }

        
        private void BuscarMesas()
        {
            DataGridView1.Rows.Clear();
            MyConnection.Open();

            MySqlCommand Consulta = new MySqlCommand("Select IDMesas,NameMesa,Descripcion,Orden,Locacion,LocacionX,LocacionY,Tamaño,TamañoX,TamañoY,Tag,Color,Mesas.IDClaseMesa,ClaseMesa.ClaseMesa from Restaurant.Mesas inner join restaurant.ClaseMesa on mesas.idclasemesa=clasemesa.idclasemesa", MyConnection);
            MySqlDataReader Lector = Consulta.ExecuteReader();
            
            while (Lector.Read())
            {
                DataGridView1.Rows.Add(Lector.GetValue(0), Lector.GetValue(1), Lector.GetValue(2), Lector.GetValue(3), Lector.GetValue(4), Lector.GetValue(5), Lector.GetValue(6), Lector.GetValue(7), Lector.GetValue(8), Lector.GetValue(9), Lector.GetValue(10), Lector.GetValue(11),"",Lector.GetValue(12),Lector.GetValue(13),false);

            }

            Lector.Close();
            MyConnection.Close();

            foreach (DataGridViewRow Row in DataGridView1.Rows)
            {
                Button NewControl = new Button();

                NewControl.Name = Row.Cells[1].Value.ToString();
                NewControl.Tag = Row.Cells[2].Value.ToString();
                NewControl.Size = new Size(Convert.ToInt16(Row.Cells[8].Value), Convert.ToInt16(Row.Cells[9].Value));
                NewControl.AutoSize = false;
                NewControl.Text = Row.Cells[2].Value.ToString();
                NewControl.BackColor = Color.FromArgb(Convert.ToInt32(Row.Cells[11].Value));
                NewControl.Top = Convert.ToInt16(Row.Cells[6].Value);
                NewControl.Left = Convert.ToInt16(Row.Cells[5].Value);
                NewControl.Cursor = Cursors.Hand;
                NewControl.BringToFront();

                NewControl.MouseMove += new MouseEventHandler(MovingButton);
                NewControl.MouseDown += new MouseEventHandler(DowningButton);
                NewControl.MouseUp += new MouseEventHandler(UppingButton);
                NewControl.MouseClick += new MouseEventHandler(ClickButton);

                Panel4.Controls.Add(NewControl);
                Row.Cells[12].Style.BackColor=Color.FromArgb(Convert.ToInt32(Row.Cells[11].Value));
            }

            Label5.Text = "Cant. de Mesas: " + NumControlsInteger();
            txtDescripcion.Text = "Mesa " + (NumControlsInteger() + 1);
        }


        
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            Button2.Width = TrackBar1.Value;
            CenterButton();
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            Button2.Height = TrackBar2.Value;
            CenterButton();
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            Button2.Width = TrackBar1.Value;
            CenterButton();
        }

        public void CenterButton()
        {
            Button2.Top = (Panel3.Height / 2) - (Button2.Height / 2);
            Button2.Left = (Panel3.Width / 2) - (Button2.Width / 2);
            txtTamañoWidth.Text = Button2.Size.Width.ToString();
            txtTamañoHeight.Text = Button2.Size.Height.ToString();
        }


        private void TrackBar2_ValueChanged(object sender, EventArgs e)
        {
            Button2.Height = TrackBar2.Value;
            CenterButton();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Control Ctrl in Panel4.Controls)
            {
                Ctrl.SendToBack();

            }

            Button NewControl = new Button();
            NewControl.Name = "Table" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHMMssfff");
            NewControl.Tag = "Table" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHMMssfff");
            NewControl.Size = Button2.Size;
            NewControl.AutoSize = false;
            NewControl.Text = Button2.Text;
            NewControl.BackColor = ColorPickEdit1.Color;

            if (string.IsNullOrEmpty(txtLocacion.Text))
            {
                NewControl.Top = ((Panel4.Height / 2) - (NewControl.Height / 2)) + (5 * NumControlsInteger());
                NewControl.Left = ((Panel4.Width / 2) - (NewControl.Width / 2)) + (5 * NumControlsInteger());
            }

            else
            {

                NewControl.Top = Convert.ToInt16(txtLocacionY.Text);
                NewControl.Left = Convert.ToInt16(txtLocacionX.Text);
            }

            NewControl.Cursor = Cursors.Hand;
            NewControl.Tag = Button2.Text;
            NewControl.BringToFront();

            NewControl.MouseMove += new MouseEventHandler(MovingButton);
            NewControl.MouseDown += new MouseEventHandler(DowningButton);
            NewControl.MouseUp += new MouseEventHandler(UppingButton);
            NewControl.MouseClick  += new MouseEventHandler(ClickButton);

            Panel4.Controls.Add(NewControl);
            DataGridView1.Rows.Add(IDMesaM, NewControl.Name, NewControl.Text, txtOrden.Text, NewControl.Location.ToString(), NewControl.Location.X.ToString(), NewControl.Location.Y.ToString(), NewControl.Size.ToString(), NewControl.Size.Width.ToString(), NewControl.Size.Height.ToString(), NewControl.Tag, ColorPickEdit1.Color.ToArgb(), "",cbxTipoMesa.SelectedValue.ToString(), cbxTipoMesa.Text,false);


            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                row.Cells[12].Style.BackColor = Color.FromArgb(Convert.ToInt32(row.Cells[11].Value));
            }

            NumControlsInteger();
            Label5.Text = "Cant. de Mesas: " + NumControlsInteger();
            IDMesaM = "";
            ChangeColorDirext = false;
            txtDescripcion.Text = "Mesa " + (NumControlsInteger() + 1);
            ColorPickEdit1.Color = SystemColors.Control;
            txtLocacion.Clear();
            txtLocacionY.Clear();
            txtLocacionX.Clear();
            txtDescripcion.Focus();
            txtDescripcion.SelectAll();
            txtTag.Clear();
            txtTamañoHeight.Text = "70";
            txtTamañoWidth.Text = "120";
            txtName.Clear();
            DataGridView1.ClearSelection();



        }


        //Declare Function
        public int NumControlsInteger()
        {
            int Total = 0;
            foreach (Button ctrl in Panel4.Controls)
            {
                Total = ++Total;
            }

            return Total;
        }






        public void MovingButton(object sender, MouseEventArgs e)
        {
            if (MultipleMove == false)
            {
                Button TmpButton = new Button();
                TmpButton = (dynamic)sender;

                if (_isMoved)
                {
                    TmpButton.Location = new Point(TmpButton.Location.X + (e.Location.X - _x), TmpButton.Location.Y + (e.Location.Y - _y));

                    foreach (DataGridViewRow Row in DataGridView1.Rows)
                    {
                        if (TmpButton.Name.ToString() == Row.Cells[1].Value.ToString())
                        {
                            Row.Cells[4].Value = TmpButton.Location;
                            Row.Cells[5].Value = TmpButton.Location.X;
                            Row.Cells[6].Value = TmpButton.Location.Y;
                        }
                    }  
                }
            }

                else
                {
                    foreach (DataGridViewRow Rw in DataGridView1.Rows)
                    {

                        if (Convert.ToBoolean(Rw.Cells[15].Value) == true)
                        {
                            this.Controls.Find(Rw.Cells[1].Value.ToString(), true)[0].Location = new Point((Convert.ToInt32(this.Controls.Find(Rw.Cells[1].Value.ToString(), true)[0].Location.X)) + (e.Location.X - _x), (Convert.ToInt32(this.Controls.Find(Rw.Cells[1].Value.ToString(), true)[0].Location.Y)) + (e.Location.Y - _y));
                            Rw.Cells[4].Value = this.Controls.Find(Rw.Cells[1].Value.ToString(), true)[0].Location;
                            Rw.Cells[5].Value = this.Controls.Find(Rw.Cells[1].Value.ToString(), true)[0].Location.X;
                            Rw.Cells[6].Value = this.Controls.Find(Rw.Cells[1].Value.ToString(), true)[0].Location.Y;
                        }
                    }


                }

        }

        
        private void DowningButton(object sender, MouseEventArgs e)
        {
            Button TmpButton = new Button();
            TmpButton = (dynamic)sender;

            foreach (DataGridViewRow Row in DataGridView1.Rows)
            {
                if (TmpButton.Name.ToString() == Row.Cells[1].Value.ToString())
                {
                    if (Convert.ToBoolean(Row.Cells[15].Value) == false)
                    {
                        MultipleMove = false;
                        _isMoved = true;
                        _x = e.Location.X;
                        _y = e.Location.Y;

                    }

                    else

                    {

                        int Counted = 0;
                        foreach (DataGridViewRow Rw in DataGridView1.Rows)
                        {
                            if (Convert.ToBoolean(Rw.Cells[15].Value) == true)
                            {
                                Counted = ++Counted;
                            }
                        }

                        if (Counted <= 1)
                        {
                            MultipleMove = false;
                            _isMoved = true;
                            _x = e.Location.X;
                            _y = e.Location.Y;
                        }

                        else

                        {
                            MultipleMove = true;
                        }
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////

        private void UppingButton(object sender, MouseEventArgs e)
        {
            _isMoved = false;
            MultipleMove = false;
        }


        private void ClickButton(object sender, MouseEventArgs e)
        {
            Button TmpButton = new Button();
            TmpButton = (dynamic)sender;

            Label7.Text = TmpButton.Name;

            foreach (DataGridViewRow Row in DataGridView1.Rows)
            {
                if (Row.Cells[1].Value.ToString() == TmpButton.Name)
                {
                    DataGridView1.ClearSelection();
                    DataGridView1.Rows[Row.Index].Selected = true;
                    DataGridView1.FirstDisplayedScrollingRowIndex = Row.Index;
                }
                
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(Label7.Text)))
            {
                if (Panel4.Controls.Count > 0)
                {
                    foreach (DataGridViewRow Row in DataGridView1.Rows)
                    {
                        if (Row.Cells[1].Value.ToString() == Label7.Text)
                        {
                            if (Convert.ToBoolean(Row.Cells[15].Value) == true)
                            {
                                MessageBox.Show(this, "La " + Convert.ToString(Row.Cells[2].Value) + " está incluído para mover en grupos." + Environment.NewLine + Environment.NewLine + "Por favor deseleccione esta opción para modificarla.", "Mesa incluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            else

                            {

                                if (Row.Cells[0].Value == null)
                                {
                                    IDMesaM = "";
                                    DataGridView1.Rows.Remove(Row);
                                }

                                else
                                {
                                    IDMesaM = Convert.ToString(Row.Cells[0].Value.ToString());
                                    cbxTipoMesa.Text = Row.Cells[14].Value.ToString();
                                    DataGridView1.Rows.Remove(Row);
                                }
                 
                            }
                        }
                    }

                    txtDescripcion.Text = this.Controls.Find(Label7.Text, true)[0].Text;
                    txtLocacion.Text = this.Controls.Find(Label7.Text, true)[0].Location.ToString();
                    txtLocacionX.Text = this.Controls.Find(Label7.Text, true)[0].Location.X.ToString();
                    txtLocacionY.Text = this.Controls.Find(Label7.Text, true)[0].Location.Y.ToString();
                    txtTamañoHeight.Text = this.Controls.Find(Label7.Text, true)[0].Size.Height.ToString();
                    txtTamañoWidth.Text = this.Controls.Find(Label7.Text, true)[0].Size.Width.ToString();
                    TrackBar1.Value = this.Controls.Find(Label7.Text, true)[0].Size.Width;
                    TrackBar2.Value = this.Controls.Find(Label7.Text, true)[0].Size.Height;
                    ColorPickEdit1.Color = this.Controls.Find(Label7.Text, true)[0].BackColor;
                    txtName.Text = this.Controls.Find(Label7.Text, true)[0].Name;
                    txtTag.Text = Convert.ToString(this.Controls.Find(Label7.Text, true)[0].Tag);
                    Button2.BackColor = this.Controls.Find(Label7.Text, true)[0].BackColor;
                 
                    Panel4.Controls.Remove(this.Controls.Find(Label7.Text, true)[0]);
                    Label7.Text = "";
                    Label5.Text = "Cant. de Mesas: " + NumControlsInteger();
                    DataGridView1.ClearSelection();
                }
            }


        }

        private void txtTamañoWidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsNumeric(txtTamañoWidth.Text))
                {
                    TrackBar1.Value = Convert.ToInt16(txtTamañoWidth.Text);

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show(this, ex.Message.ToString(),"Se ha encontrado un error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtTamañoHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsNumeric(txtTamañoHeight.Text))
                {
                    TrackBar2.Value = Convert.ToInt16(txtTamañoHeight.Text);

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message.ToString(), "Se ha encontrado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        static bool IsNumeric(string input)
        {
            bool result = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsNumber(input[i]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private void ColorPickEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (ChangeColorDirext == false)
            {
                Button2.BackColor = ColorPickEdit1.Color;
            }

            else
            {
                if (DataGridView1.Rows.Count > 0)
                {
                    DataGridView1.CurrentRow.Cells[11].Value = ColorPickEdit1.Color.ToArgb().ToString();
                    DataGridView1.CurrentRow.Cells[12].Style.BackColor = ColorPickEdit1.Color;
                    Panel4.Controls.Find(DataGridView1.CurrentRow.Cells[1].Value.ToString(),true)[0].BackColor = ColorPickEdit1.Color;
                    ChangeColorDirext = false;
                    DataGridView1.ClearSelection();

                    txtDescripcion.Text = "Mesa " + (NumControlsInteger() + 1);
                    ColorPickEdit1.Color = SystemColors.Control;
                    txtLocacion.Clear();
                    txtLocacionY.Clear();
                    txtLocacionX.Clear();
                    txtDescripcion.Focus();
                    txtDescripcion.SelectAll();
                    txtTag.Clear();
                    txtTamañoHeight.Text = "70";
                    txtTamañoWidth.Text = "120";
                    txtName.Clear();
                    DataGridView1.ClearSelection();
                }
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.Rows.Count > 0)
            {

                if (Panel4.Controls.Count > 0)
                {

                    if (e.ColumnIndex == 15)
                    {
                        bool IsTicked = Convert.ToBoolean(DataGridView1.CurrentRow.Cells[15].Value);

                        if (IsTicked)
                        {

                            Panel4.Controls.Find(DataGridView1.CurrentRow.Cells[1].Value.ToString(), true)[0].Text = DataGridView1.CurrentRow.Cells[2].Value.ToString() + Environment.NewLine + "Incluído";
                            Panel4.Controls.Find(DataGridView1.CurrentRow.Cells[1].Value.ToString(), true)[0].Font = new Font("Segoe UI", 8, FontStyle.Bold);
                            Panel4.Controls.Find(DataGridView1.CurrentRow.Cells[1].Value.ToString(), true)[0].ForeColor = SystemColors.Highlight;

                        }

                        else
                        {
                            Panel4.Controls.Find(DataGridView1.CurrentRow.Cells[1].Value.ToString(), true)[0].Text = DataGridView1.CurrentRow.Cells[2].Value.ToString() ;
                            Panel4.Controls.Find(DataGridView1.CurrentRow.Cells[1].Value.ToString(), true)[0].Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
                            Panel4.Controls.Find(DataGridView1.CurrentRow.Cells[1].Value.ToString(), true)[0].ForeColor = Color.Black;
                        }
                    }
                }
            
            }
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DataGridView1.IsCurrentCellDirty)
            {
                DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                if (e.ColumnIndex != 15)
                {
                    Label7.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
                    btnModificar.PerformClick();

                }
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Label7.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();

                if (e.ColumnIndex == 15)
                {
                    DataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;


                }

                if (e.ColumnIndex == 12)
                {
                    ColorPickEdit1.Color = DataGridView1.CurrentRow.Cells[12].Style.BackColor;
                    ChangeColorDirext = true;
                    ColorPickEdit1.ShowPopup();
                }
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            Button2.Text = txtDescripcion.Text;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (IsNumeric(IDMesaM))
            {
                MyConnection.Open();
                sqlQ = "Delete from Mesas Where IDMesas= '" + IDMesaM + "'";
                Cmd = new MySqlCommand(sqlQ, MyConnection);
                Cmd.ExecuteNonQuery();
                MyConnection.Close();
            }

            IDMesaM = "";
            NumControlsInteger();
            Label5.Text = "Cant. de Mesas: " + NumControlsInteger();
            txtDescripcion.Text = "Mesa " + (NumControlsInteger() + 1);
            txtLocacion.Clear();
            txtLocacionX.Clear();
            txtLocacionY.Clear();
            txtDescripcion.Focus();
            txtDescripcion.SelectAll();
            txtTag.Clear();
            txtTamañoHeight.Text = "70";
            txtTamañoWidth.Text = "120";
            txtName.Clear();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count > 0)
            {
                MyConnection.Open();

                foreach (DataGridViewRow Rw in DataGridView1.Rows)
                {
                    if (Convert.ToString(Rw.Cells[0].Value) == string.Empty)
                        
                    {
                        sqlQ = "INSERT INTO Mesas (NameMesa,Descripcion,Orden,Locacion,LocacionX,LocacionY,Tamaño,TamañoX,TamañoY,Tag,Color,idclasemesa) VALUES ('" + Rw.Cells[1].Value.ToString() + "', '" + Rw.Cells[2].Value.ToString() + "','" + Rw.Cells[3].Value.ToString() + "','" + Rw.Cells[4].Value.ToString() + "','" + Rw.Cells[5].Value.ToString() + "','" + Rw.Cells[6].Value.ToString() + "','" + Rw.Cells[7].Value.ToString() + "','" + Rw.Cells[8].Value.ToString() + "','" + Rw.Cells[9].Value.ToString() + "','" + Rw.Cells[10].Value.ToString() + "','" + Rw.Cells[11].Value.ToString() + "','" + Rw.Cells[13].Value.ToString() + "') ";
                        Cmd = new MySqlCommand(sqlQ, MyConnection);
                        Cmd.ExecuteNonQuery();

                        Cmd = new MySqlCommand("Select IDMesas from Mesas where IDMesas= (Select Max(IDMesas) from Mesas)", MyConnection);
                        Rw.Cells[0].Value = Convert.ToString(Cmd.ExecuteScalar());
                    }

                    else
                    {
                        //String IDM = Rw.Cells[0].Value.ToString();
                        sqlQ = "UPDATE Mesas SET NameMesa='" + Rw.Cells[1].Value.ToString() + "',Descripcion='" + Rw.Cells[2].Value.ToString() + "',Orden='" + Rw.Cells[3].Value.ToString() + "',Locacion='" + Rw.Cells[4].Value.ToString() + "',LocacionX='" + Rw.Cells[5].Value.ToString() + "',LocacionY='" + Rw.Cells[6].Value.ToString() + "',Tamaño='" + Rw.Cells[7].Value.ToString() + "',TamañoX='" + Rw.Cells[8].Value.ToString() + "',TamañoY='" + Rw.Cells[9].Value.ToString() + "',Tag='" + Rw.Cells[10].Value.ToString() + "',Color='" + Rw.Cells[11].Value.ToString() + "',IDClaseMesa='" + Rw.Cells[13].Value.ToString() + "' Where IDMesas='" + Rw.Cells[0].Value.ToString() + "'";
                        Cmd = new MySqlCommand(sqlQ, MyConnection);
                        Cmd.ExecuteNonQuery();
                    }
                }

                MyConnection.Close();
            }
        }

    
      

             


    }
}