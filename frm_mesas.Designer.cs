namespace LearningCSharp
{
    partial class frm_mesas
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button1 = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxTipoMesa = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ColorPickEdit1 = new DevExpress.XtraEditors.ColorPickEdit();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtLocacionY = new System.Windows.Forms.TextBox();
            this.txtLocacionX = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTamañoHeight = new System.Windows.Forms.TextBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtTamañoWidth = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtLocacion = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Button2 = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.TrackBar1 = new System.Windows.Forms.TrackBar();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TrackBar2 = new System.Windows.Forms.TrackBar();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.IDMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocacionX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocacionY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamanox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamanoy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorMuestra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDClaseMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Incluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPickEdit1.Properties)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar1)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar2)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button1.Location = new System.Drawing.Point(910, 720);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(96, 24);
            this.Button1.TabIndex = 32;
            this.Button1.Text = "Guardar";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AllowUserToResizeColumns = false;
            this.DataGridView1.AllowUserToResizeRows = false;
            this.DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMesa,
            this.Nombre,
            this.Descrip,
            this.Orden,
            this.Locacion,
            this.LocacionX,
            this.LocacionY,
            this.Tamaño,
            this.Tamanox,
            this.Tamanoy,
            this.Tag,
            this.Colora,
            this.ColorMuestra,
            this.IDClaseMesa,
            this.Tipo,
            this.Incluir});
            this.DataGridView1.Location = new System.Drawing.Point(15, 545);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 20;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(991, 169);
            this.DataGridView1.TabIndex = 31;
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.DataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            this.DataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellValueChanged);
            this.DataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridView1_CurrentCellDirtyStateChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Location = new System.Drawing.Point(418, 514);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 25;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(120, 525);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(0, 13);
            this.Label7.TabIndex = 30;
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(12, 525);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(102, 13);
            this.Label6.TabIndex = 29;
            this.Label6.Text = "Mesa seleccionada:";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox3.Controls.Add(this.cbxTipoMesa);
            this.GroupBox3.Controls.Add(this.label13);
            this.GroupBox3.Controls.Add(this.ColorPickEdit1);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Controls.Add(this.Label11);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Controls.Add(this.txtLocacionY);
            this.GroupBox3.Controls.Add(this.txtLocacionX);
            this.GroupBox3.Controls.Add(this.Label9);
            this.GroupBox3.Controls.Add(this.txtTag);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Controls.Add(this.txtName);
            this.GroupBox3.Controls.Add(this.txtTamañoHeight);
            this.GroupBox3.Controls.Add(this.Button3);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Controls.Add(this.btnAdd);
            this.GroupBox3.Controls.Add(this.txtDescripcion);
            this.GroupBox3.Controls.Add(this.txtTamañoWidth);
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Controls.Add(this.txtLocacion);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Controls.Add(this.txtOrden);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Location = new System.Drawing.Point(502, 335);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(504, 202);
            this.GroupBox3.TabIndex = 28;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Información";
            // 
            // cbxTipoMesa
            // 
            this.cbxTipoMesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoMesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTipoMesa.FormattingEnabled = true;
            this.cbxTipoMesa.Location = new System.Drawing.Point(313, 168);
            this.cbxTipoMesa.Name = "cbxTipoMesa";
            this.cbxTipoMesa.Size = new System.Drawing.Size(121, 21);
            this.cbxTipoMesa.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Tipo de Mesa";
            // 
            // ColorPickEdit1
            // 
            this.ColorPickEdit1.EditValue = System.Drawing.SystemColors.Control;
            this.ColorPickEdit1.Location = new System.Drawing.Point(81, 169);
            this.ColorPickEdit1.Name = "ColorPickEdit1";
            this.ColorPickEdit1.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.ColorPickEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ColorPickEdit1.Size = new System.Drawing.Size(146, 20);
            this.ColorPickEdit1.TabIndex = 24;
            this.ColorPickEdit1.EditValueChanged += new System.EventHandler(this.ColorPickEdit1_EditValueChanged);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(12, 172);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(31, 13);
            this.Label12.TabIndex = 23;
            this.Label12.Text = "Color";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(366, 93);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(14, 13);
            this.Label11.TabIndex = 21;
            this.Label11.Text = "Y";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(293, 93);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(14, 13);
            this.Label10.TabIndex = 20;
            this.Label10.Text = "X";
            // 
            // txtLocacionY
            // 
            this.txtLocacionY.Location = new System.Drawing.Point(386, 90);
            this.txtLocacionY.Name = "txtLocacionY";
            this.txtLocacionY.Size = new System.Drawing.Size(47, 20);
            this.txtLocacionY.TabIndex = 19;
            this.txtLocacionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLocacionX
            // 
            this.txtLocacionX.Location = new System.Drawing.Point(313, 89);
            this.txtLocacionX.Name = "txtLocacionX";
            this.txtLocacionX.Size = new System.Drawing.Size(47, 20);
            this.txtLocacionX.TabIndex = 18;
            this.txtLocacionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(12, 146);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(26, 13);
            this.Label9.TabIndex = 17;
            this.Label9.Text = "Tag";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(81, 143);
            this.txtTag.Name = "txtTag";
            this.txtTag.ReadOnly = true;
            this.txtTag.Size = new System.Drawing.Size(352, 20);
            this.txtTag.TabIndex = 16;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(12, 16);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(35, 13);
            this.Label8.TabIndex = 15;
            this.Label8.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(81, 13);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(352, 20);
            this.txtName.TabIndex = 14;
            // 
            // txtTamañoHeight
            // 
            this.txtTamañoHeight.Location = new System.Drawing.Point(196, 117);
            this.txtTamañoHeight.Name = "txtTamañoHeight";
            this.txtTamañoHeight.Size = new System.Drawing.Size(109, 20);
            this.txtTamañoHeight.TabIndex = 13;
            this.txtTamañoHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTamañoHeight.TextChanged += new System.EventHandler(this.txtTamañoHeight_TextChanged);
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button3.Location = new System.Drawing.Point(444, 65);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(45, 45);
            this.Button3.TabIndex = 4;
            this.Button3.Text = "-";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 42);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Descripción";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAdd.Location = new System.Drawing.Point(444, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 45);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 39);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(352, 20);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.Text = "Mesa 1";
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // txtTamañoWidth
            // 
            this.txtTamañoWidth.Location = new System.Drawing.Point(81, 117);
            this.txtTamañoWidth.Name = "txtTamañoWidth";
            this.txtTamañoWidth.Size = new System.Drawing.Size(109, 20);
            this.txtTamañoWidth.TabIndex = 11;
            this.txtTamañoWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTamañoWidth.TextChanged += new System.EventHandler(this.txtTamañoWidth_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 68);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(36, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Orden";
            // 
            // txtLocacion
            // 
            this.txtLocacion.Location = new System.Drawing.Point(81, 91);
            this.txtLocacion.Name = "txtLocacion";
            this.txtLocacion.ReadOnly = true;
            this.txtLocacion.Size = new System.Drawing.Size(206, 20);
            this.txtLocacion.TabIndex = 10;
            this.txtLocacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 94);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(51, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Locacion";
            // 
            // txtOrden
            // 
            this.txtOrden.Location = new System.Drawing.Point(81, 65);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(352, 20);
            this.txtOrden.TabIndex = 1;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(12, 120);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Tamaño";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.Panel3);
            this.GroupBox2.Controls.Add(this.Panel2);
            this.GroupBox2.Controls.Add(this.Panel1);
            this.GroupBox2.Location = new System.Drawing.Point(502, 10);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(504, 319);
            this.GroupBox2.TabIndex = 27;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Diseñando";
            // 
            // Panel3
            // 
            this.Panel3.AutoScroll = true;
            this.Panel3.BackColor = System.Drawing.Color.White;
            this.Panel3.Controls.Add(this.Button2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(3, 16);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(446, 251);
            this.Panel3.TabIndex = 2;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(164, 83);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(120, 70);
            this.Button2.TabIndex = 0;
            this.Button2.Text = "Mesa 1";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.TrackBar1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(3, 267);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(446, 49);
            this.Panel2.TabIndex = 1;
            // 
            // TrackBar1
            // 
            this.TrackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrackBar1.Location = new System.Drawing.Point(3, 1);
            this.TrackBar1.Maximum = 900;
            this.TrackBar1.Minimum = 5;
            this.TrackBar1.Name = "TrackBar1";
            this.TrackBar1.Size = new System.Drawing.Size(440, 45);
            this.TrackBar1.TabIndex = 0;
            this.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrackBar1.Value = 120;
            this.TrackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            this.TrackBar1.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TrackBar2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel1.Location = new System.Drawing.Point(449, 16);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(52, 300);
            this.Panel1.TabIndex = 0;
            // 
            // TrackBar2
            // 
            this.TrackBar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrackBar2.Location = new System.Drawing.Point(4, 3);
            this.TrackBar2.Maximum = 450;
            this.TrackBar2.Minimum = 5;
            this.TrackBar2.Name = "TrackBar2";
            this.TrackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar2.Size = new System.Drawing.Size(45, 227);
            this.TrackBar2.TabIndex = 1;
            this.TrackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrackBar2.Value = 70;
            this.TrackBar2.Scroll += new System.EventHandler(this.TrackBar2_Scroll);
            this.TrackBar2.ValueChanged += new System.EventHandler(this.TrackBar2_ValueChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.Panel4);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Location = new System.Drawing.Point(11, 10);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(485, 529);
            this.GroupBox1.TabIndex = 26;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Diseño de grupo de mesas";
            // 
            // Panel4
            // 
            this.Panel4.AutoScroll = true;
            this.Panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 16);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(479, 510);
            this.Panel4.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label5.Location = new System.Drawing.Point(369, 67);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(113, 13);
            this.Label5.TabIndex = 13;
            this.Label5.Text = "Cant. de Mesas:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDMesa
            // 
            this.IDMesa.HeaderText = "ID";
            this.IDMesa.Name = "IDMesa";
            this.IDMesa.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 190;
            // 
            // Descrip
            // 
            this.Descrip.HeaderText = "Descripción";
            this.Descrip.Name = "Descrip";
            this.Descrip.ReadOnly = true;
            this.Descrip.Width = 200;
            // 
            // Orden
            // 
            this.Orden.HeaderText = "Orden";
            this.Orden.Name = "Orden";
            this.Orden.ReadOnly = true;
            this.Orden.Width = 50;
            // 
            // Locacion
            // 
            this.Locacion.HeaderText = "Locacion";
            this.Locacion.Name = "Locacion";
            this.Locacion.ReadOnly = true;
            // 
            // LocacionX
            // 
            this.LocacionX.HeaderText = "Loc X";
            this.LocacionX.Name = "LocacionX";
            this.LocacionX.ReadOnly = true;
            this.LocacionX.Width = 70;
            // 
            // LocacionY
            // 
            this.LocacionY.HeaderText = "Loc Y";
            this.LocacionY.Name = "LocacionY";
            this.LocacionY.ReadOnly = true;
            this.LocacionY.Width = 70;
            // 
            // Tamaño
            // 
            this.Tamaño.HeaderText = "Tamaño";
            this.Tamaño.Name = "Tamaño";
            this.Tamaño.ReadOnly = true;
            this.Tamaño.Width = 140;
            // 
            // Tamanox
            // 
            this.Tamanox.HeaderText = "Tam x";
            this.Tamanox.Name = "Tamanox";
            this.Tamanox.ReadOnly = true;
            this.Tamanox.Width = 70;
            // 
            // Tamanoy
            // 
            this.Tamanoy.HeaderText = "Tam Y";
            this.Tamanoy.Name = "Tamanoy";
            this.Tamanoy.ReadOnly = true;
            this.Tamanoy.Width = 70;
            // 
            // Tag
            // 
            this.Tag.HeaderText = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            this.Tag.Width = 140;
            // 
            // Colora
            // 
            this.Colora.HeaderText = "Color";
            this.Colora.Name = "Colora";
            this.Colora.ReadOnly = true;
            this.Colora.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Colora.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Colora.Width = 65;
            // 
            // ColorMuestra
            // 
            this.ColorMuestra.HeaderText = "Muestra";
            this.ColorMuestra.Name = "ColorMuestra";
            this.ColorMuestra.ReadOnly = true;
            this.ColorMuestra.Width = 50;
            // 
            // IDClaseMesa
            // 
            this.IDClaseMesa.HeaderText = "ID";
            this.IDClaseMesa.Name = "IDClaseMesa";
            this.IDClaseMesa.ReadOnly = true;
            this.IDClaseMesa.Width = 60;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 140;
            // 
            // Incluir
            // 
            this.Incluir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Incluir.HeaderText = "Incluir";
            this.Incluir.Name = "Incluir";
            this.Incluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Incluir.Width = 55;
            // 
            // frm_mesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 753);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "frm_mesas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear Mesa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPickEdit1.Properties)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar2)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Button btnModificar;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtLocacionY;
        internal System.Windows.Forms.TextBox txtLocacionX;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtTag;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtTamañoHeight;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.TextBox txtTamañoWidth;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtLocacion;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtOrden;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TrackBar TrackBar1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TrackBar TrackBar2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label5;
        internal DevExpress.XtraEditors.ColorPickEdit ColorPickEdit1;
        private System.Windows.Forms.ComboBox cbxTipoMesa;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocacionX;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocacionY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamanox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamanoy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorMuestra;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDClaseMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Incluir;
    }
}

