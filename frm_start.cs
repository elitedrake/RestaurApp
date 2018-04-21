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
    public partial class frm_start : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        MySqlConnection MyConnection = new MySqlConnection();
        MySqlConnection MyConnection1 = new MySqlConnection();
        MySqlDataAdapter Adaptador = new MySqlDataAdapter();
        DataSet Ds = new DataSet();
        DataSet Ds1 = new DataSet();
        MySqlCommand cmd = new MySqlCommand();
        DataTable TablaMesas = new DataTable();
        double ZoomFact = 1;
        string IDMesero, sqlQ;
        public static string Propietario = "";
        string itbisenprecio, porcientoley;
        Image QueryImage;
        Panel pn = new Panel();

        public frm_start()
        {
            InitializeComponent();
            MyConnection.ConnectionString = ("Server=localhost;Uid=root;Pwd=iLM14PC1191;Database=Restaurant");
            MyConnection1.ConnectionString = ("Server=localhost;Uid=root;Pwd=iLM14PC1191;Database=Restaurant");
        }

        private void frm_start_Load(object sender, EventArgs e)
        {
            Configuracion();
            FillMesas();
            FillMeseros();

        }

       public void Configuracion()
        {
            MyConnection.Open();


           //Itbis en precios
            cmd = new MySqlCommand("SELECT valueint FROM restaurant.configuracion where idconfiguracion=1", MyConnection);
            itbisenprecio = Convert.ToString(cmd.ExecuteScalar());
          

            if (itbisenprecio == "1")
            { lblMensajeItbis.Text = "Los precios del menú incluyen itbis"; }
            else
            { lblMensajeItbis.Text = "Los precios del menú NO incluyen itbis"; }

           //Porciento de ley
            cmd = new MySqlCommand("SELECT valuedouble FROM restaurant.configuracion where idconfiguracion=2", MyConnection);
            porcientoley = Convert.ToString(cmd.ExecuteScalar());

           

            MyConnection.Close();
        }

        private void GetCorrectSizeRow()
        {
            try
            {
                foreach (RowStyle style in tableLayoutPanel1.RowStyles)
                {
                    style.SizeType = SizeType.Absolute;
                    style.Height = 200;
                }

                foreach (DataGridView Dgv in tableLayoutPanel1.Controls)
                {
                    if (Dgv is DataGridView)
                    {
                        Dgv.Columns[0].Width = Convert.ToInt16((Convert.ToDouble(Dgv.Width) * 0.4));
                        Dgv.Columns[1].Width = Convert.ToInt16((Convert.ToDouble(Dgv.Width) * 0.6));
                        Dgv.ClearSelection();
                    }

                }
                simpleButton1.Visible = true;

            }

            catch (Exception ex)
            {
                simpleButton1.Visible = false;
                //MessageBox.Show(this, ex.Message.ToString(), "Se ha encontrado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ForeColorDgv(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView Dgv = new DataGridView();
            Dgv = (dynamic)sender;

            if (Dgv.Rows[e.RowIndex].Cells[2].Value.ToString() == "1")
            {
                Dgv.Rows[e.RowIndex].Cells[1].Style.ForeColor = SystemColors.Highlight;
            }
            if (Dgv.Rows[e.RowIndex].Cells[2].Value.ToString() == "2")
            {
                Dgv.Rows[e.RowIndex].Cells[1].Style.ForeColor = SystemColors.ActiveCaptionText;
                Dgv.Rows[e.RowIndex].Cells[1].Style.Font = new Font("Segoe UI", 15, FontStyle.Italic);
            }
            if (Dgv.Rows[e.RowIndex].Cells[2].Value.ToString() == "3")
            {
                Dgv.Rows[e.RowIndex].Cells[1].Style.ForeColor = SystemColors.HotTrack;
                Dgv.Rows[e.RowIndex].Cells[1].Style.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            }
            if (Dgv.Rows[e.RowIndex].Cells[2].Value.ToString() == "4")
            {
                Dgv.Rows[e.RowIndex].Cells[1].Style.ForeColor = SystemColors.ActiveCaptionText;
            }

        }



        private void FillMeseros()
        {
            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT concat(Nombres,' ',Apellidos),Foto as Nombre FROM restaurant.meseros;", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "Meseros");
            CbxMesero.Properties.Items.Clear();
            MyConnection.Close();

            DataTable dt = Ds1.Tables["Meseros"];

            foreach (DataRow Fila in dt.Rows)
            {
                CbxMesero.Properties.Items.Add(Fila[0].ToString());
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(this, "No se encontraron resultados de meseros.", "No hay meseros");
            }
        }
        private void FillCategorias()
        {
            int XLocation = 10;
            int YLocation = 10;
            int PicWidth = 0;
            int PicHeight = 0;
            Image img;
            int MaxPichHeightSize = 0;

            PanelCategorias.Controls.Clear();

            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT idcategorias,categoria,categoriafoto,ordercategoria,size,grupo FROM restaurant.categorias ORDER BY grupo ASC, ordercategoria ASC, size asc", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "Categoria");
            MyConnection.Close();

            DataTable dt = Ds1.Tables["Categoria"];
         
            foreach (DataRow DRw in dt.Rows)
            {
                DevExpress.XtraEditors.GroupControl CardCategoria = new DevExpress.XtraEditors.GroupControl();
                CardCategoria.Location = new Point(XLocation, YLocation);

                if (DRw[4].ToString() == "1")
                {
                    PicWidth = 280;
                    PicHeight = 120;
                }

                if (DRw[4].ToString() == "2")
                {
                    PicWidth = 340;
                    PicHeight = 160;

                }

                XLocation = XLocation + PicWidth + 10;

                if (PicHeight > MaxPichHeightSize)
                {
                    MaxPichHeightSize = PicHeight;
                }

                if (XLocation + PicWidth >= PanelCategorias.Width)
                {
                    XLocation = 10;
                    YLocation = YLocation + MaxPichHeightSize + 10;
                    MaxPichHeightSize = 0;
                }


                CardCategoria.Text = DRw[1].ToString();
                CardCategoria.Name = DRw[0].ToString();
                CardCategoria.Size = new Size(PicWidth, PicHeight);
                CardCategoria.Tag = DRw[0].ToString();
                CardCategoria.Cursor = Cursors.Hand;

                bool ExistFile = System.IO.File.Exists(DRw[2].ToString());

                if (ExistFile)
                {
                    FileStream Wfile = new FileStream(DRw[2].ToString(), FileMode.Open, FileAccess.Read);
                    img = System.Drawing.Image.FromStream(Wfile);
                }

                else
                {
                    img = Properties.Resources.f752abb3_1b49_4f99_b68a_7c4d77b45b40_1_39d6c524f6033c7c58bd073db1b99786;
                }

                CardCategoria.ContentImage = ResizeImage(img, CardCategoria.Width, CardCategoria.Height);
                CardCategoria.MouseEnter += new System.EventHandler(EnterinPanelCategorias);
                CardCategoria.MouseClick += new MouseEventHandler(ClickInPanelCategorias);

                PanelCategorias.Controls.Add(CardCategoria);

            }

        }

        private void ClickInPanelCategorias(object sender, MouseEventArgs e)
        {
            FillSubCategorias();

        }

        private void ClickInPanelSubCategorias(object sender, MouseEventArgs e)
        {
            FillArticulos();

        }

        private void EnterinPanelCategorias(object sender, System.EventArgs e)
        {

            DevExpress.XtraEditors.GroupControl CardCategoria = new DevExpress.XtraEditors.GroupControl();
            CardCategoria = (dynamic)sender;

            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT idcategorias,categoria,categoriafoto,ordercategoria,size FROM restaurant.categorias where Idcategorias='" + CardCategoria.Tag.ToString() + "'", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "categorias");
            MyConnection.Close();

            DataTable tbl = Ds1.Tables["categorias"];

            lblIDCategoria.Text = "[" + tbl.Rows[0][0].ToString() + "]";
            lblCategoria.Text = tbl.Rows[0][1].ToString();

            tbl.Dispose();
        }

        private void EnterMouse(object sender, System.EventArgs e)
        {
            Button tmpbutton = new Button();
            tmpbutton = (dynamic)sender;

            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("Select IDMesas,NameMesa,Descripcion,Orden,Locacion,LocacionX,LocacionY,Tamaño,TamañoX,TamañoY,Tag,Color,IDMesero,Ocupada,HoraOcupacion from Restaurant.Mesas where IDMesas='" + tmpbutton.Tag.ToString() + "'", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "Mesas");
            MyConnection.Close();

            DataTable tbl = Ds1.Tables["Mesas"];

            foreach (DataRow dt in tbl.Rows)
            {
                lblIDMesa.Text = "[" + dt[0].ToString() + "]";
                lblMesaSeleccionada.Text = dt[2].ToString();

                if (Convert.ToInt16(dt[13].ToString()) == 1)
                {
                    DateTime myDate = DateTime.Parse(dt[14].ToString());
                    lblEstadoMesa.Text = "Ocupado";
                    lblHoraMesa.Text = myDate.ToString();
                    lblEstadoMesa.ForeColor = Color.Red;
                    label4.Visible = true;
                }

                else
                {
                    lblEstadoMesa.Text = "Disponible";
                    lblHoraMesa.Text = "";
                    lblEstadoMesa.ForeColor = Color.Green;
                    label4.Visible = false;
                }

                double num;
                bool isnum = double.TryParse(dt[12].ToString(), out num);
                if (isnum)
                {
                    MyConnection.Open();
                    cmd = new MySqlCommand("SELECT concat(Nombres,' ',Apellidos) FROM restaurant.meseros where IDMeseros='" + dt[12].ToString() + "'", MyConnection);
                    CbxMesero.Text = Convert.ToString(cmd.ExecuteScalar());
                    MyConnection.Close();
                }
            }

            tbl.Dispose();
        }

        private void FillMesas()
        {
            panelMesa.Controls.Clear();
            TablaMesas.Clear();
            zoomTrackBarControl1.Value = 2;

            Ds.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("Select IDMesas,NameMesa,Descripcion,Orden,Locacion,LocacionX,LocacionY,Tamaño,TamañoX,TamañoY,Tag,Color from Restaurant.Mesas", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds, "Mesas");
            MyConnection.Close();

            TablaMesas = Ds.Tables["Mesas"];

            foreach (DataRow dt in TablaMesas.Rows)
            {
                Button NewControl = new Button();

                NewControl.Name = dt[1].ToString();
                NewControl.Tag = dt[0].ToString();
                NewControl.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                NewControl.Size = new Size(Convert.ToInt16(dt[8].ToString()), Convert.ToInt16(dt[9].ToString()));
                NewControl.AutoSize = false;
                NewControl.Text = dt[2].ToString();
                NewControl.BackColor = Color.FromArgb(Convert.ToInt32(dt[11].ToString()));
                NewControl.Top = Convert.ToInt16(dt[6].ToString());
                NewControl.Left = Convert.ToInt16(dt[5].ToString());
                NewControl.Cursor = Cursors.Hand;
                NewControl.BringToFront();
                NewControl.FlatStyle = FlatStyle.Flat;

                NewControl.MouseEnter += new System.EventHandler(EnterMouse);
                NewControl.MouseClick += new MouseEventHandler(ClickButton);
                panelMesa.Controls.Add(NewControl);
            }

        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        private void ClickButton(object sender, MouseEventArgs e)
        {
            Button tmpbutton = new Button();
            tmpbutton = (dynamic)sender;

            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("Select IDMesas,NameMesa,Descripcion,Orden,Locacion,LocacionX,LocacionY,Tamaño,TamañoX,TamañoY,Tag,Color,IDMesero,Ocupada,HoraOcupacion,Mesas.IDClaseMesa,ClaseMesa.ClaseMesa from Restaurant.Mesas inner join restaurant.ClaseMesa on mesas.idclasemesa=clasemesa.idclasemesa where IDMesas='" + tmpbutton.Tag.ToString() + "'", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "Mesas");
            MyConnection.Close();

            DataTable tbl = Ds1.Tables["Mesas"];

            lblIDSelectedTable.Text = "[" + tbl.Rows[0][0].ToString() + "]";
            lblSelectedTable.Text = tbl.Rows[0][2].ToString();
            lblIDTipoMesa.Text = "[" + tbl.Rows[0][15].ToString() + "]";
            lblTipoMesa.Text = tbl.Rows[0][16].ToString();

            ///////////////////////////////////////////////////////////////////////

            tbl.Rows.Clear();
            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT IDCuenta,IDMesa,Fecha,cuentas.Descripcion,Monto FROM restaurant.cuentas inner join restaurant.Mesas on cuentas.IDMesa=Mesas.IDMesas where idmesa='" + tmpbutton.Tag.ToString() + "'", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "Cuentas");
            MyConnection.Close();

            tbl = Ds1.Tables["Cuentas"];

            tableLayoutPanel1.Controls.Clear();

            if (tbl.Rows.Count > 0)
            {

                foreach (DataRow dt in tbl.Rows)
                {

                    DataGridView DgvCuenta = new DataGridView();
                    ////Adding Columns
                    DgvCuenta.Columns.Add("TypeofValue", "");
                    DgvCuenta.Columns.Add("ValueType", "");
                    DgvCuenta.Columns.Add("Format", "Format");

                    //Columns format
                    DgvCuenta.Columns[0].HeaderText = "Cuenta de " + dt[3].ToString();
                    //DgvCuenta.Columns[0].Width = Convert.ToInt32((tableLayoutPanel1.ColumnStyles[0].Width / 100) * (tableLayoutPanel1.Width * 0.4));
                    DgvCuenta.Columns[0].DefaultCellStyle.BackColor = SystemColors.ControlLight;
                    //DgvCuenta.Columns[1].Width = Convert.ToInt32((tableLayoutPanel1.ColumnStyles[0].Width / 100) * (tableLayoutPanel1.Width * 0.6));
                    DgvCuenta.Columns[2].Visible = false;
                    DgvCuenta.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    DgvCuenta.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                    //Dgv Format
                    DgvCuenta.Dock = DockStyle.Fill;
                    DgvCuenta.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
                    DgvCuenta.BackgroundColor = SystemColors.ControlLightLight;
                    DgvCuenta.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    DgvCuenta.ScrollBars = ScrollBars.Vertical;
                    DgvCuenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DgvCuenta.RowHeadersVisible = false;
                    DgvCuenta.AllowUserToAddRows = false;
                    DgvCuenta.AllowUserToDeleteRows = false;
                    DgvCuenta.AllowUserToOrderColumns = false;
                    DgvCuenta.AllowUserToResizeRows = false;
                    DgvCuenta.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    DgvCuenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                    DgvCuenta.ReadOnly = true;
                    DgvCuenta.MultiSelect = false;
                    DgvCuenta.Cursor = Cursors.Hand;
                    DgvCuenta.BackgroundColor = SystemColors.ControlLightLight;

                    //Rows Values
                    DgvCuenta.Rows.Add("ID", dt[0].ToString(), 1);
                    DgvCuenta.Rows.Add("Hora", dt[2].ToString(), 4);
                    DgvCuenta.Rows.Add("", "", 0);

                    DgvCuenta.Rows.Add("Propietario:", dt[3].ToString(), 2);
                    DgvCuenta.Rows.Add("Monto en pesos:", Convert.ToDouble(dt[4].ToString()).ToString("C"), 3);

                    DgvCuenta.RowPostPaint += new DataGridViewRowPostPaintEventHandler(ForeColorDgv);
                    DgvCuenta.CellClick += new DataGridViewCellEventHandler(ClickDgv);
                    DgvCuenta.MouseEnter += new System.EventHandler(OverDgv);

                    int i = 0;
                    int j = 0;

                    for (i = 0; i <= this.tableLayoutPanel1.ColumnCount; i++)
                    {
                        for (j = 0; j <= this.tableLayoutPanel1.RowCount; j++)
                        {
                            Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);

                            if (c != null)
                            {
                                GetCorrectSizeRow();
                            }

                            else
                            {
                                tableLayoutPanel1.Controls.Add(DgvCuenta, i, j);
                                simpleButton1.Visible = true;
                                j = this.tableLayoutPanel1.RowCount;
                                GetCorrectSizeRow();
                                break;

                            }

                        }

                        if (j == this.tableLayoutPanel1.RowCount)
                        {
                            i = this.tableLayoutPanel1.ColumnCount;
                            GetCorrectSizeRow();
                        }
                    }

                }

            }

            else
            {
                Panel PanelNoReg = new Panel();

                PanelNoReg.BackColor = SystemColors.ControlLightLight;
                PanelNoReg.Size = new Size(231, 194);
                PanelNoReg.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);

                Label lblNoReg = new Label();

                PanelNoReg.Controls.Add(lblNoReg);

                lblNoReg.Text = "+ No se han encontrado cuentas en esta mesa.";
                lblNoReg.AutoSize = false;
                lblNoReg.Size = new Size(202, 35);
                lblNoReg.Location = new Point(16, 54);
                lblNoReg.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                DevExpress.XtraEditors.SimpleButton btnAdd = new DevExpress.XtraEditors.SimpleButton();

                PanelNoReg.Controls.Add(btnAdd);

                btnAdd.Size = new Size(42, 35);
                btnAdd.Location = new Point(176, 104);
                btnAdd.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                btnAdd.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png");

                btnAdd.MouseClick += new MouseEventHandler(ClickenMesa);
                tableLayoutPanel1.Controls.Add(PanelNoReg, 0, 0);


            }

            GetCorrectSizeRow();
            tabPane1.SelectedPageIndex = 1;


        }


        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt16(zoomTrackBarControl1.Value.ToString()))
            {
                case 0:
                    ZoomFact = 0.5;
                    break;
                case 1:
                    ZoomFact = 0.75;
                    break;
                case 2:
                    ZoomFact = 1;
                    FillMesas();
                    break;
                case 3:
                    ZoomFact = 1.25;
                    break;
                case 4:
                    ZoomFact = 1.5;
                    break;
            }

            foreach (Control btn in panelMesa.Controls)
            {
                if (btn is Button)
                {
                    btn.Size = new Size(Convert.ToInt32(Convert.ToInt32(GetOriginalWidth(btn.Name)) * ZoomFact), Convert.ToInt32(Convert.ToInt32(GetOriginalHeight(btn.Name)) * ZoomFact));
                    btn.Top = Convert.ToInt16(Convert.ToInt32(GetOriginalY(btn.Name)) * ZoomFact);
                    btn.Left = Convert.ToInt16(Convert.ToInt32(GetOriginalX(btn.Name)) * ZoomFact);
                }

            }
        }

        public string GetOriginalWidth(string ControlName)
        {
            string LocalSiz = "";

            foreach (DataRow dt in TablaMesas.Rows)
            {
                if (ControlName == dt[1].ToString())
                {
                    LocalSiz = dt[8].ToString();
                    break;
                }

            }

            return LocalSiz;
        }

        public string GetOriginalHeight(string ControlName)
        {
            string LocalSiz = "";

            foreach (DataRow dt in TablaMesas.Rows)
            {
                if (ControlName == dt[1].ToString())
                {
                    LocalSiz = dt[9].ToString();
                    break;
                }

            }

            return LocalSiz;
        }

        public string GetOriginalX(string ControlName)
        {
            string LocalSiz = "";

            foreach (DataRow dt in TablaMesas.Rows)
            {
                if (ControlName == dt[1].ToString())
                {
                    LocalSiz = dt[5].ToString();
                    break;
                }

            }

            return LocalSiz;
        }


        public string GetOriginalY(string ControlName)
        {
            string LocalSiz = "";

            foreach (DataRow dt in TablaMesas.Rows)
            {
                if (ControlName == dt[1].ToString())
                {
                    LocalSiz = dt[6].ToString();
                    break;
                }

            }

            return LocalSiz;
        }


        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            FillMesas();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_mesas frm_tmp = new frm_mesas();
            frm_tmp.ShowDialog();
        }

        private void CbxMesero_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MyConnection1.Open();
                cmd = new MySqlCommand("SELECT IDMeseros FROM restaurant.meseros where concat(Nombres,' ',Apellidos)='" + CbxMesero.Text.ToString() + "'", MyConnection1);
                IDMesero = Convert.ToString(cmd.ExecuteScalar());
                MyConnection1.Close();

                string IDMesa = lblIDMesa.Text;
                IDMesa = IDMesa.Replace("[", string.Empty).Replace("]", string.Empty);

                if (Convert.ToInt32(IDMesa) > 0)
                {
                    sqlQ = "UPDATE Restaurant.Mesas SET IDMesero='" + IDMesero + "' WHERE IDMESAS='" + IDMesa + "'";
                    MyConnection1.Open();
                    cmd = new MySqlCommand(sqlQ, MyConnection1);
                    cmd.ExecuteNonQuery();
                    MyConnection1.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Se ha encontrado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPane1_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            if (tabPane1.SelectedPageIndex == 1)
            { GetCorrectSizeRow(); }
            //if (tabPane1.SelectedPageIndex == 2)
            //{ FillCategorias(); }
        }

        private void ClickenMesa(object sender, EventArgs e)
        {

            if (lblIDSelectedTable.Text == "[0]")
            {
                MessageBox.Show(this, "Seleccione una mesa para continuar.", "Seleccione una mesa");
                tabPane1.SelectedPageIndex = 0;
                return;
            }

            frm_propietario_cuenta frm_tmp = new frm_propietario_cuenta();
            frm_tmp.ShowDialog(this);


            tableLayoutPanel1.Controls.Clear();


            DataGridView DgvCuenta = new DataGridView();

            //Adding Columns
            DgvCuenta.Columns.Add("TypeofValue", "");
            DgvCuenta.Columns.Add("ValueType", "");
            DgvCuenta.Columns.Add("Format", "Format");

            //Columns format
            DgvCuenta.Columns[0].HeaderText = "Cuenta de " + Propietario;
            DgvCuenta.Columns[0].Width = Convert.ToInt32((tableLayoutPanel1.ColumnStyles[0].Width / 100) * (tableLayoutPanel1.Width * 0.4));
            DgvCuenta.Columns[0].DefaultCellStyle.BackColor = SystemColors.ControlLight;
            DgvCuenta.Columns[1].Width = Convert.ToInt32((tableLayoutPanel1.ColumnStyles[0].Width / 100) * (tableLayoutPanel1.Width * 0.6));
            DgvCuenta.Columns[2].Visible = false;
            DgvCuenta.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            DgvCuenta.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            //Dgv Format
            DgvCuenta.Dock = DockStyle.Fill;
            DgvCuenta.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
            DgvCuenta.BackgroundColor = SystemColors.ControlLightLight;
            DgvCuenta.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvCuenta.ScrollBars = ScrollBars.Vertical;
            DgvCuenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCuenta.RowHeadersVisible = false;
            DgvCuenta.AllowUserToAddRows = false;
            DgvCuenta.AllowUserToDeleteRows = false;
            DgvCuenta.AllowUserToOrderColumns = false;
            DgvCuenta.AllowUserToResizeRows = false;
            DgvCuenta.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgvCuenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            DgvCuenta.ReadOnly = true;
            DgvCuenta.MultiSelect = false;
            DgvCuenta.Cursor = Cursors.Hand;
            DgvCuenta.BackgroundColor = SystemColors.ControlLightLight;

            //Rows Values
            DgvCuenta.Rows.Add("ID", "(Nuevo)", 1);
            DgvCuenta.Rows.Add("Hora", DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("hh:MM:ss tt"), 4);
            DgvCuenta.Rows.Add("", "", 0);

            DgvCuenta.Rows.Add("Propietario:", Propietario, 2);
            DgvCuenta.Rows.Add("Monto en pesos:", Convert.ToDouble(0).ToString("C"), 3);

            DgvCuenta.RowPostPaint += new DataGridViewRowPostPaintEventHandler(ForeColorDgv);
            DgvCuenta.CellClick += new DataGridViewCellEventHandler(ClickDgv);
            DgvCuenta.MouseEnter += new System.EventHandler(OverDgv);

            int i = 0;
            int j = 0;

            for (i = 0; i <= tableLayoutPanel1.ColumnCount; i++)
            {
                for (j = 0; j <= this.tableLayoutPanel1.RowCount; j++)
                {
                    Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                    //MessageBox.Show(this,i +Environment.NewLine + j,"12");
                    if (c != null)
                    { }

                    else
                    {
                        tableLayoutPanel1.Controls.Add(DgvCuenta, i, j);
                        simpleButton1.Visible = true;
                        GetCorrectSizeRow();
                        return;
                    }
                }
            }


        }

        private void ClickDgv(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tmpdgv = new DataGridView();
            tmpdgv = (dynamic)sender;

            if (tmpdgv.Rows[0].Cells[1].Value.ToString() == "(Nuevo)")
            {
            }

            else
            {
                lblIDCuentaSeleccionada.Text = "[" + tmpdgv.Rows[0].Cells[1].Value.ToString() + "]";
                lblCuentaSeleccionada.Text = "Cuenta de " + tmpdgv.Rows[3].Cells[1].Value.ToString();

                tabPane1.SelectedPageIndex = 2;
            }

        }

        private void OverDgv(object sender, System.EventArgs e)
        {
            DataGridView tmpdgv = new DataGridView();
            tmpdgv = (dynamic)sender;

            if (tmpdgv.Rows[0].Cells[1].Value.ToString() == "(Nuevo)")
            {
                label12.Text = "";
                label11.Text = "Para utilizar esta cuenta por favor guarde el registro.";
                label11.ForeColor = Color.Red;
            }

            else
            {
                label12.Text = "[" + tmpdgv.Rows[0].Cells[1].Value.ToString() + "]";
                label11.Text = "Cuenta de " + tmpdgv.Rows[3].Cells[1].Value.ToString();
                label11.ForeColor = Color.Black;
            }

        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (lblIDSelectedTable.Text == "[0]")
            {
                MessageBox.Show(this, "Seleccione una mesa para continuar.", "Seleccione una mesa");
                tabPane1.SelectedPageIndex = 0;
                return;
            }

            frm_propietario_cuenta frm_tmp = new frm_propietario_cuenta();
            frm_tmp.ShowDialog(this);


            tableLayoutPanel1.Controls.Remove(panel6);


            DataGridView DgvCuenta = new DataGridView();

            //Adding Columns
            DgvCuenta.Columns.Add("TypeofValue", "");
            DgvCuenta.Columns.Add("ValueType", "");
            DgvCuenta.Columns.Add("Format", "Format");

            //Columns format
            DgvCuenta.Columns[0].HeaderText = "Cuenta de " + Propietario;
            DgvCuenta.Columns[0].Width = Convert.ToInt32((tableLayoutPanel1.ColumnStyles[0].Width / 100) * (tableLayoutPanel1.Width * 0.4));
            DgvCuenta.Columns[0].DefaultCellStyle.BackColor = SystemColors.ControlLight;
            DgvCuenta.Columns[1].Width = Convert.ToInt32((tableLayoutPanel1.ColumnStyles[0].Width / 100) * (tableLayoutPanel1.Width * 0.6));
            DgvCuenta.Columns[2].Visible = false;
            DgvCuenta.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            DgvCuenta.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            //Dgv Format
            DgvCuenta.Dock = DockStyle.Fill;
            DgvCuenta.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
            DgvCuenta.BackgroundColor = SystemColors.ControlLightLight;
            DgvCuenta.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvCuenta.ScrollBars = ScrollBars.Vertical;
            DgvCuenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCuenta.RowHeadersVisible = false;
            DgvCuenta.AllowUserToAddRows = false;
            DgvCuenta.AllowUserToDeleteRows = false;
            DgvCuenta.AllowUserToOrderColumns = false;
            DgvCuenta.AllowUserToResizeRows = false;
            DgvCuenta.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgvCuenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            DgvCuenta.ReadOnly = true;
            DgvCuenta.MultiSelect = false;
            DgvCuenta.Cursor = Cursors.Hand;

            //Rows Values
            DgvCuenta.Rows.Add("ID", "(Nuevo)", 1);
            DgvCuenta.Rows.Add("Hora", DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("hh:MM:ss tt"), 4);
            DgvCuenta.Rows.Add("", "", 0);

            DgvCuenta.Rows.Add("Propietario:", Propietario, 2);
            DgvCuenta.Rows.Add("Monto en pesos:", Convert.ToDouble(0).ToString("C"), 3);

            DgvCuenta.RowPostPaint += new DataGridViewRowPostPaintEventHandler(ForeColorDgv);
            DgvCuenta.CellClick += new DataGridViewCellEventHandler(ClickDgv);
            DgvCuenta.MouseEnter += new System.EventHandler(OverDgv);

            int i = 0;
            int j = 0;

            for (i = 0; i <= tableLayoutPanel1.ColumnCount; i++)
            {
                for (j = 0; j <= this.tableLayoutPanel1.RowCount; j++)
                {
                    Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                    if (c != null)
                    { }

                    else
                    {
                        tableLayoutPanel1.Controls.Add(DgvCuenta, i, j);
                        GetCorrectSizeRow();
                        return;
                    }
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridView Dgv in tableLayoutPanel1.Controls)
                {
                    foreach (DataGridViewRow Rw in Dgv.Rows)
                    {
                        if (Rw.Index == 0)
                        {
                            //Aqui guardo la cuenta
                            if (Rw.Cells[1].Value.ToString() == "(Nuevo)")
                            {
                                sqlQ = "INSERT INTO restaurant.cuentas (IDMesa,Fecha,Descripcion,Monto) VALUES ('" + lblIDSelectedTable.Text.Replace("[", string.Empty).Replace("]", string.Empty).ToString() + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "','" + Dgv.Rows[3].Cells[1].Value.ToString() + "','" + Convert.ToString(double.Parse(Dgv.Rows[4].Cells[1].Value.ToString(), System.Globalization.NumberStyles.Currency)) + "')";
                                MyConnection.Open();
                                cmd = new MySqlCommand(sqlQ, MyConnection);
                                cmd.ExecuteNonQuery();


                                cmd = new MySqlCommand("Select IDCuenta from Restaurant.Cuentas where IDCuenta= (Select Max(IDCuenta) from Cuentas)", MyConnection);
                                Rw.Cells[1].Value = Convert.ToString(cmd.ExecuteScalar());
                                MyConnection.Close();

                            }

                            else
                            {
                                MyConnection.Open();
                                sqlQ = "UPDATE restaurant.cuentas SET Fecha='" + DateTime.Parse(Dgv.Rows[1].Cells[1].Value.ToString()).ToString("yyyy-MM-dd HH:MM:ss") + "',Descripcion='" + Dgv.Rows[3].Cells[1].Value.ToString() + "',Monto='" + Convert.ToString(double.Parse(Dgv.Rows[4].Cells[1].Value.ToString(), System.Globalization.NumberStyles.Currency)) + "' Where IDCuenta='" + Dgv.Rows[0].Cells[1].Value.ToString() + "'";
                                cmd = new MySqlCommand(sqlQ, MyConnection);
                                cmd.ExecuteNonQuery();
                                MyConnection.Close();
                            }



                        }

                    }
                }

                MessageBox.Show(this, "Se han guardado las cuentas de la " + lblSelectedTable.Text, "Se ha guardado satisfactoriamente");


            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "No hay mesas para guardar.", "No hay mesas");
            }


        }

        private void btnDeleteCuenta_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (DataGridView dgv in tableLayoutPanel1.Controls)
                {
                    if (dgv is DataGridView)
                    {

                        if (dgv.Rows[0].Cells[1].Value.ToString() == "(Nuevo)")
                        {
                            tableLayoutPanel1.Controls.Remove(dgv);
                            lblCuentaSeleccionada.Text = "";
                            lblIDCuentaSeleccionada.Text = "";
                            label11.Text = "";
                            label12.Text = "";
                            return;
                        }

                        if (dgv.Rows[0].Cells[1].Value.ToString() == lblIDCuentaSeleccionada.Text.Replace("[", string.Empty).Replace("]", string.Empty))
                        {

                            MyConnection.Open();
                            cmd = new MySqlCommand("SELECT count(idCuentasDetalle) FROM restaurant.cuentasdetalle where IDCuenta='" + label12.Text.Replace("[", string.Empty).Replace("]", string.Empty) + "'", MyConnection);
                            int CuentaDetalle = Convert.ToInt16(cmd.ExecuteScalar());
                            MyConnection.Close();

                            if (CuentaDetalle == 0)
                            {
                                DialogResult result = MessageBox.Show("Estás seguro que deseas eliminar la " + lblCuentaSeleccionada.Text + "?", "Confirmación de eliminado", MessageBoxButtons.YesNoCancel);
                                if (result == DialogResult.Yes)
                                {
                                    sqlQ = "Delete from Restaurant.Cuentas Where IDCuenta = (" + lblIDCuentaSeleccionada.Text.Replace("[", string.Empty).Replace("]", string.Empty) + ")";
                                    MyConnection1.Open();
                                    cmd = new MySqlCommand(sqlQ, MyConnection1);
                                    cmd.ExecuteNonQuery();
                                    MyConnection1.Close();

                                    tableLayoutPanel1.Controls.Remove(dgv);
                                    lblCuentaSeleccionada.Text = "";
                                    lblIDCuentaSeleccionada.Text = "";
                                    label11.Text = "";
                                    label12.Text = "";
                                }

                            }

                            else
                            {
                                MessageBox.Show("No se puede eliminar la " + label11.Text + " ya que hay registros guardados en esta cuenta.", "Integridad referencial");
                            }
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show(this, ex.Message.ToString(), "Se ha encontrado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FillSubCategorias()
        {
            int XLocation = 10;
            int YLocation = 10;
            int PicWidth = 280;
            int PicHeight = 120;
            Image img;

            PanelSubCategorias.Controls.Clear();

            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT idSubCategoria,IDCategoria,SubCategoria,FotoSubCategoria,OrderSubCategoria FROM restaurant.subcategoria where idcategoria='" + lblIDCategoria.Text.Replace("[", string.Empty).Replace("]", string.Empty) + "' ORDER BY OrderSubCategoria asc", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "SubCategoria");
            MyConnection.Close();

            DataTable dt = Ds1.Tables["SubCategoria"];

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow DRw in dt.Rows)
                {
                    DevExpress.XtraEditors.GroupControl CardCategoria = new DevExpress.XtraEditors.GroupControl();
                    CardCategoria.Location = new Point(XLocation, YLocation);

                    XLocation = XLocation + PicWidth + 10;

                    if (XLocation + PicWidth >= PanelCategorias.Width)
                    {
                        XLocation = 10;
                        YLocation = YLocation + PicHeight + 10;

                    }

                    CardCategoria.Text = DRw[2].ToString();
                    CardCategoria.Name = DRw[0].ToString();
                    CardCategoria.Size = new Size(PicWidth, PicHeight);
                    CardCategoria.Tag = DRw[0].ToString();

                    CardCategoria.Cursor = Cursors.Hand;

                    bool ExistFile = System.IO.File.Exists(DRw[3].ToString());

                    if (ExistFile)
                    {
                        FileStream Wfile = new FileStream(DRw[3].ToString(), FileMode.Open, FileAccess.Read);
                        img = System.Drawing.Image.FromStream(Wfile);
                    }

                    else
                    {
                        img = Properties.Resources.f752abb3_1b49_4f99_b68a_7c4d77b45b40_1_39d6c524f6033c7c58bd073db1b99786;
                    }

                    CardCategoria.ContentImage = ResizeImage(img, CardCategoria.Width, CardCategoria.Height);
                    CardCategoria.MouseEnter += new System.EventHandler(EnterinPanelSubCategorias);
                    CardCategoria.MouseClick += new MouseEventHandler(ClickInPanelSubCategorias);
                    PanelSubCategorias.Controls.Add(CardCategoria);
                }

                tabPane2.SelectedPageIndex = 1;
                
            }




        }


        private void EnterinPanelSubCategorias(object sender, System.EventArgs e)
        {

            DevExpress.XtraEditors.GroupControl CardCategoria = new DevExpress.XtraEditors.GroupControl();
            CardCategoria = (dynamic)sender;

            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT idSubCategoria,IDCategoria,SubCategoria,FotoSubCategoria,OrderSubCategoria FROM restaurant.subcategoria where idSubcategoria='" + CardCategoria.Tag.ToString() + "'", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "SubCategoria");
            MyConnection.Close();

            DataTable tbl = Ds1.Tables["SubCategoria"];

            lblIDSubCategoria.Text = "[" + tbl.Rows[0][0].ToString() + "]";
            lblSubCategoria.Text = tbl.Rows[0][2].ToString();

            tbl.Dispose();
        }

        private void tabPane2_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            if (tabPane2.SelectedPageIndex == 0)
            {
                lblIDSubCategoria.Text = "";
                lblSubCategoria.Text = "";
            }
            if (tabPane2.SelectedPageIndex != 2)
            {
                lblIDCurrentArticulo.Text= "";
                lblCurrentArticulo.Text ="";
                lblPrecio.Text = "";
                txtBuscar.Text = "";
                btnLimpiarBusqueda.Visible = false;
                DgvConsultaArticulos.Visible = false;
            }

        }

        private void SumArticulos()
        {
            double subtotal = 0;
            double itbis = 0;

            if (DgvArticulos.Rows.Count > 0)
            {
                foreach (DataGridViewRow Rw in DgvArticulos.Rows)
                {
                    subtotal += Convert.ToDouble(Convert.ToString(double.Parse(Rw.Cells[5].Value.ToString(), System.Globalization.NumberStyles.Currency)));
                    itbis += Convert.ToDouble(Convert.ToString(double.Parse(Rw.Cells[6].Value.ToString(), System.Globalization.NumberStyles.Currency)));
                }

                lblSubtotal.Text = subtotal.ToString("C");
                lblItbis.Text = itbis.ToString("C");
            }

            else
            {
                lblSubtotal.Text =Convert.ToDouble(0).ToString("C");
                lblItbis.Text = Convert.ToDouble(0).ToString("C");
            }

            if ((lblIDTipoMesa.Text.Replace("[", string.Empty).Replace("]", string.Empty)) == "1")
            {
                lblPropinaLegal.Text = (subtotal * Convert.ToDouble(porcientoley)).ToString("C");

            }

            else
            {
                lblPropinaLegal.Text = Convert.ToDouble(0).ToString("C");
            }
        }

        private void FillArticulos()
        {
            int XLocation = 10;
            int YLocation = 10;
            int PicWidth = 275;
            int PicHeight = 140;
            Image img;

            PanelArticulos.Controls.Clear();

            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT idarticulos,descripcion,idsubcategoria,precio,imagen from restaurant.articulos where idsubcategoria='" + lblIDSubCategoria.Text.Replace("[", string.Empty).Replace("]", string.Empty) + "' ORDER BY descripcion asc", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "articulos");
            MyConnection.Close();

            DataTable dt = Ds1.Tables["articulos"];

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow DRw in dt.Rows)
                {
                    DevExpress.XtraEditors.GroupControl CardArticulo = new DevExpress.XtraEditors.GroupControl();
                    CardArticulo.Location = new Point(XLocation, YLocation);

                    XLocation = XLocation + PicWidth + 10;

                    if (XLocation + PicWidth >= PanelArticulos.Width)
                    {
                        XLocation = 10;
                        YLocation = YLocation + PicHeight + 10;

                    }

                    CardArticulo.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                    CardArticulo.AppearanceCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    CardArticulo.AllowHtmlText = true;
                    CardArticulo.Text = "<b>" + DRw[1].ToString() + "</b>" + "<br><u>" + Convert.ToDouble(DRw[3].ToString()).ToString("C") + "</u>";
                    CardArticulo.Name = DRw[0].ToString();
                    CardArticulo.Size = new Size(PicWidth, PicHeight);
                    CardArticulo.Tag = DRw[0].ToString();

                    CardArticulo.Cursor = Cursors.Hand;

                    bool ExistFile = System.IO.File.Exists(DRw[4].ToString());

                    if (ExistFile)
                    {
                        FileStream Wfile = new FileStream(DRw[4].ToString(), FileMode.Open, FileAccess.Read);
                        img = System.Drawing.Image.FromStream(Wfile);
                    }

                    else
                    {
                        img = Properties.Resources.f752abb3_1b49_4f99_b68a_7c4d77b45b40_1_39d6c524f6033c7c58bd073db1b99786;
                    }

                    CardArticulo.ContentImage = ResizeImage(img, CardArticulo.Width, CardArticulo.Height);
                    CardArticulo.MouseEnter += new System.EventHandler(EnterinPanelArticulos);
                    CardArticulo.MouseClick += new MouseEventHandler(ClickInPanelArticulos);

                    PanelArticulos.Controls.Add(CardArticulo);
                }

                tabPane2.SelectedPageIndex = 2;
               
            }


    }
        
        private void EnterinPanelArticulos(object sender, System.EventArgs e)
        {

            DevExpress.XtraEditors.GroupControl CardArticulo = new DevExpress.XtraEditors.GroupControl();
            CardArticulo = (dynamic)sender;

            Ds1.Clear();
            MyConnection.Open();
            cmd = new MySqlCommand("SELECT idArticulos,articulos.Descripcion,IDSubCategoria,Precio,Imagen,articulos.IDItbis,Itbis.Descripcion FROM restaurant.articulos inner join restaurant.Itbis on articulos.iditbis=itbis.iditbis where IDArticulos='" + CardArticulo.Tag.ToString() + "'", MyConnection);
            Adaptador = new MySqlDataAdapter(cmd);
            Adaptador.Fill(Ds1, "Articulos");
            MyConnection.Close();

            DataTable tbl = Ds1.Tables["Articulos"];

            lblIDCurrentArticulo.Text = "[" + tbl.Rows[0][0].ToString() + "]";
            lblCurrentArticulo.Text = tbl.Rows[0][1].ToString();
            lblPrecio.Text = Convert.ToDouble(tbl.Rows[0][3].ToString()).ToString("C");
            tbl.Dispose();
        }

        private void ClickInPanelArticulos(object sender, MouseEventArgs e)
        {
            DevExpress.XtraEditors.GroupControl CardArticulo = new DevExpress.XtraEditors.GroupControl();
            CardArticulo = (dynamic)sender;

            lblIDArticulo.Text = lblIDCurrentArticulo.Text;
            lblArticulo.Text = lblCurrentArticulo.Text;
            PanelArticuloSeleccionado.ContentImage = ResizeImage(CardArticulo.ContentImage, PanelArticuloSeleccionado.Width, PanelArticuloSeleccionado.Height);
            txtCant.Focus();
            lblPrecioSeleccionado.Text = lblPrecio.Text;
        }

        private void checkNota_Toggled(object sender, EventArgs e)
        {
            if (checkNota.IsOn)
            {
                label29.Visible = true;
                txtNota.Visible = true;
                txtNota.Focus();
            }

            else
            {
                label29.Visible = false;
                txtNota.Visible = false;
            }
           
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (lblIDArticulo.Text != "")
            {
                double precioestablecido, itbisarticulo;

                /////Establecer precios
                MyConnection.Open();
                cmd = new MySqlCommand("SELECT itbistasa FROM restaurant.articulos inner join restaurant.itbis on articulos.iditbis=itbis.iditbis where articulos.idarticulos='" + lblIDArticulo.Text.Replace("[", string.Empty).Replace("]", string.Empty).ToString() + "'", MyConnection);
                itbisarticulo = Convert.ToDouble(cmd.ExecuteScalar());
                MyConnection.Close();


                if (itbisenprecio == "1")
                {
                    precioestablecido = (Convert.ToDouble(Convert.ToString(double.Parse(lblPrecioSeleccionado.Text, System.Globalization.NumberStyles.Currency))) / (1+itbisarticulo)) * Convert.ToDouble(txtCant.Value);
                    itbisarticulo = (precioestablecido * itbisarticulo);
                }

                else

                {
                    precioestablecido = Convert.ToDouble(Convert.ToString(double.Parse(lblPrecioSeleccionado.Text, System.Globalization.NumberStyles.Currency))) * Convert.ToDouble(txtCant.Value);
                    itbisarticulo = precioestablecido * itbisarticulo;
                }

                DgvArticulos.Rows.Add("", 1, lblIDArticulo.Text.Replace("[", string.Empty).Replace("]", string.Empty).ToString(), txtCant.Value.ToString(), lblArticulo.Text, precioestablecido.ToString("C"), itbisarticulo.ToString("C"),(precioestablecido+itbisarticulo).ToString("C"));

                if (checkNota.IsOn)
                {
                    if (txtNota.Text != "")
                    {
                        DgvArticulos.Rows.Add("", 2, "", "", "+" + txtNota.Text, "");
                    }
                }

                SumArticulos();
                lblIDArticulo.Text = "";
                lblArticulo.Text = "";
                txtCant.Value = 1;
                checkNota.IsOn = false;
                txtNota.Clear();
                txtBuscar.Text = "";
                lblPrecioSeleccionado.Text = "";
                PanelArticuloSeleccionado.ContentImage = null;
                DgvArticulos.ClearSelection();

                if (PanelArticulos.Controls.Count == 0)
                {
                    txtBuscar.Focus();
                }

            }
        }

        private void DgvArticulos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView Dgv = new DataGridView();
            Dgv = (dynamic)sender;

            if (Dgv.Rows[e.RowIndex].Cells[1].Value.ToString() == "2")
            {
                Dgv.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Red;Dgv.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Red;
                Dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            { 
            txtBuscar.Text="Escriba el artículo que desea buscar";
            txtBuscar.ForeColor = Color.Gray;
           
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Escriba el artículo que desea buscar")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void PanelCategorias_Resize(object sender, EventArgs e)
        {
            FillCategorias();
        }

        private void txtBuscar_EditValueChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                DgvConsultaArticulos.Visible = false;
                btnLimpiarBusqueda.Visible = false;
            }

            else
            {
                if (txtBuscar.Text != "Escriba el artículo que desea buscar")
                {
                    DgvConsultaArticulos.Visible = true;
                    btnLimpiarBusqueda.Visible = true;
                    DgvConsultaArticulos.Rows.Clear();
                    MyConnection1.Open();

                    MySqlCommand Consulta = new MySqlCommand("SELECT Imagen,IDArticulos,articulos.Descripcion,Precio FROM restaurant.articulos inner join restaurant.subcategoria on articulos.idsubcategoria=subcategoria.idsubcategoria inner join restaurant.categorias on subcategoria.idcategoria=categorias.idcategorias where articulos.Descripcion like '%" + txtBuscar.Text + "%' or subcategoria.subcategoria like '%" + txtBuscar.Text + "%' or categorias.categoria like '%" + txtBuscar.Text + "%' Order By Descripcion ASC LIMIT 15", MyConnection1);
                    MySqlDataReader Lector = Consulta.ExecuteReader();

                    while (Lector.Read())
                    {
                        bool ExistFile = System.IO.File.Exists(Lector.GetValue(0).ToString());

                        if (ExistFile)
                        {
                            FileStream Wfile = new FileStream(Lector.GetValue(0).ToString(), FileMode.Open, FileAccess.Read);
                            QueryImage = System.Drawing.Image.FromStream(Wfile);
                        }

                        else
                        {
                            QueryImage = Properties.Resources.f752abb3_1b49_4f99_b68a_7c4d77b45b40_1_39d6c524f6033c7c58bd073db1b99786;
                        }

                        DgvConsultaArticulos.Rows.Add(QueryImage, Lector.GetValue(1), Lector.GetValue(2), Convert.ToDouble(Lector.GetValue(3)).ToString("C"), Lector.GetValue(0));

                    }

                    Lector.Close();
                    MyConnection1.Close();
                }
               
            }
            if (DgvConsultaArticulos.Rows.Count < 15)
            {
                DgvConsultaArticulos.Size = new Size(DgvConsultaArticulos.Size.Width, 21 + DgvConsultaArticulos.RowTemplate.Height * DgvConsultaArticulos.Rows.Count);
            }

            else
            {
                DgvConsultaArticulos.Size = new Size(DgvConsultaArticulos.Size.Width, 21 + DgvConsultaArticulos.RowTemplate.Height * 15);
            }
            
        }

          private void DgvConsultaArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                lblIDArticulo.Text = "[" + DgvConsultaArticulos.CurrentRow.Cells[1].Value.ToString() + "]";
                lblArticulo.Text = DgvConsultaArticulos.CurrentRow.Cells[2].Value.ToString();
                lblPrecioSeleccionado.Text = DgvConsultaArticulos.CurrentRow.Cells[3].Value.ToString();

                bool ExistFile = System.IO.File.Exists(DgvConsultaArticulos.CurrentRow.Cells[4].Value.ToString());

                if (ExistFile)
                {
                    FileStream Wfile = new FileStream(DgvConsultaArticulos.CurrentRow.Cells[4].Value.ToString(), FileMode.Open, FileAccess.Read);
                    QueryImage = System.Drawing.Image.FromStream(Wfile);
                }

                else
                {
                    QueryImage = Properties.Resources.f752abb3_1b49_4f99_b68a_7c4d77b45b40_1_39d6c524f6033c7c58bd073db1b99786;
                }

                PanelArticuloSeleccionado.ContentImage = ResizeImage(QueryImage, PanelArticuloSeleccionado.Width, PanelArticuloSeleccionado.Height);
            }
        }

          private void txtLimpiarBusqueda_Click(object sender, EventArgs e)
          {
              txtBuscar.Text = "";
          }

          private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
          {
              frm_setups frm_tmp = new frm_setups();
              frm_tmp.ShowDialog();
          }




   



}
        }
