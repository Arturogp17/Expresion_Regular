namespace ExpresionRegular
{
    partial class Arbol_F
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arbol_F));
            this.pictureArbol = new System.Windows.Forms.PictureBox();
            this.tabArbol = new System.Windows.Forms.TabControl();
            this.tabArbolFloreado = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mueveNodo = new System.Windows.Forms.ToolStripButton();
            this.mueveArbol = new System.Windows.Forms.ToolStripButton();
            this.tabAutomata = new System.Windows.Forms.TabPage();
            this.ZoomMasAut = new System.Windows.Forms.Button();
            this.OriginalAut = new System.Windows.Forms.Button();
            this.ZoomMenosAut = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.mueveNodoAut = new System.Windows.Forms.ToolStripButton();
            this.mueveAut = new System.Windows.Forms.ToolStripButton();
            this.pictureAutomata = new System.Windows.Forms.PictureBox();
            this.Tablas = new System.Windows.Forms.TabControl();
            this.tabPos = new System.Windows.Forms.TabPage();
            this.dataPosiciones = new System.Windows.Forms.DataGridView();
            this.tabSigpos = new System.Windows.Forms.TabPage();
            this.dataSigPos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ExpresionRegular_Postfija = new System.Windows.Forms.Label();
            this.Verificar = new System.Windows.Forms.Label();
            this.TextVer = new System.Windows.Forms.TextBox();
            this.Validar = new System.Windows.Forms.Button();
            this.VerRes = new System.Windows.Forms.Label();
            this.ER_Post = new System.Windows.Forms.TextBox();
            this.ExpReg = new System.Windows.Forms.TextBox();
            this.Simulacion = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureArbol)).BeginInit();
            this.tabArbol.SuspendLayout();
            this.tabArbolFloreado.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabAutomata.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAutomata)).BeginInit();
            this.Tablas.SuspendLayout();
            this.tabPos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPosiciones)).BeginInit();
            this.tabSigpos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSigPos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureArbol
            // 
            this.pictureArbol.Location = new System.Drawing.Point(0, 67);
            this.pictureArbol.Name = "pictureArbol";
            this.pictureArbol.Size = new System.Drawing.Size(100, 50);
            this.pictureArbol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureArbol.TabIndex = 0;
            this.pictureArbol.TabStop = false;
            this.pictureArbol.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureArbol_Paint);
            this.pictureArbol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureArbol_MouseDown);
            this.pictureArbol.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureArbol_MouseMove);
            this.pictureArbol.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureArbol_MouseUp);
            // 
            // tabArbol
            // 
            this.tabArbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabArbol.Controls.Add(this.tabArbolFloreado);
            this.tabArbol.Controls.Add(this.tabAutomata);
            this.tabArbol.Location = new System.Drawing.Point(504, 2);
            this.tabArbol.Name = "tabArbol";
            this.tabArbol.SelectedIndex = 0;
            this.tabArbol.Size = new System.Drawing.Size(751, 556);
            this.tabArbol.TabIndex = 2;
            // 
            // tabArbolFloreado
            // 
            this.tabArbolFloreado.AutoScroll = true;
            this.tabArbolFloreado.Controls.Add(this.button3);
            this.tabArbolFloreado.Controls.Add(this.button2);
            this.tabArbolFloreado.Controls.Add(this.button1);
            this.tabArbolFloreado.Controls.Add(this.toolStrip1);
            this.tabArbolFloreado.Controls.Add(this.pictureArbol);
            this.tabArbolFloreado.Location = new System.Drawing.Point(4, 22);
            this.tabArbolFloreado.Name = "tabArbolFloreado";
            this.tabArbolFloreado.Padding = new System.Windows.Forms.Padding(3);
            this.tabArbolFloreado.Size = new System.Drawing.Size(743, 530);
            this.tabArbolFloreado.TabIndex = 0;
            this.tabArbolFloreado.Text = "Arbol Floreado";
            this.tabArbolFloreado.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(120, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "++ Zoom";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(61, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Original";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "-- Zoom";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mueveNodo,
            this.mueveArbol});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(737, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
            // 
            // mueveNodo
            // 
            this.mueveNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mueveNodo.Image = ((System.Drawing.Image)(resources.GetObject("mueveNodo.Image")));
            this.mueveNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mueveNodo.Name = "mueveNodo";
            this.mueveNodo.Size = new System.Drawing.Size(36, 29);
            this.mueveNodo.Text = "toolStripButton1";
            // 
            // mueveArbol
            // 
            this.mueveArbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mueveArbol.Image = ((System.Drawing.Image)(resources.GetObject("mueveArbol.Image")));
            this.mueveArbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mueveArbol.Name = "mueveArbol";
            this.mueveArbol.Size = new System.Drawing.Size(36, 29);
            this.mueveArbol.Text = "toolStripButton2";
            // 
            // tabAutomata
            // 
            this.tabAutomata.AutoScroll = true;
            this.tabAutomata.Controls.Add(this.ZoomMasAut);
            this.tabAutomata.Controls.Add(this.OriginalAut);
            this.tabAutomata.Controls.Add(this.ZoomMenosAut);
            this.tabAutomata.Controls.Add(this.toolStrip2);
            this.tabAutomata.Controls.Add(this.pictureAutomata);
            this.tabAutomata.Location = new System.Drawing.Point(4, 22);
            this.tabAutomata.Name = "tabAutomata";
            this.tabAutomata.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutomata.Size = new System.Drawing.Size(743, 530);
            this.tabAutomata.TabIndex = 1;
            this.tabAutomata.Text = "Automata";
            this.tabAutomata.UseVisualStyleBackColor = true;
            // 
            // ZoomMasAut
            // 
            this.ZoomMasAut.Location = new System.Drawing.Point(120, 40);
            this.ZoomMasAut.Name = "ZoomMasAut";
            this.ZoomMasAut.Size = new System.Drawing.Size(57, 23);
            this.ZoomMasAut.TabIndex = 7;
            this.ZoomMasAut.Text = "++ Zoom";
            this.ZoomMasAut.UseVisualStyleBackColor = true;
            this.ZoomMasAut.Click += new System.EventHandler(this.ZoomMasAut_Click);
            // 
            // OriginalAut
            // 
            this.OriginalAut.Location = new System.Drawing.Point(61, 40);
            this.OriginalAut.Name = "OriginalAut";
            this.OriginalAut.Size = new System.Drawing.Size(58, 23);
            this.OriginalAut.TabIndex = 6;
            this.OriginalAut.Text = "Original";
            this.OriginalAut.UseVisualStyleBackColor = true;
            this.OriginalAut.Click += new System.EventHandler(this.OriginalAut_Click);
            // 
            // ZoomMenosAut
            // 
            this.ZoomMenosAut.Location = new System.Drawing.Point(3, 40);
            this.ZoomMenosAut.Name = "ZoomMenosAut";
            this.ZoomMenosAut.Size = new System.Drawing.Size(57, 23);
            this.ZoomMenosAut.TabIndex = 5;
            this.ZoomMenosAut.Text = "-- Zoom";
            this.ZoomMenosAut.UseVisualStyleBackColor = true;
            this.ZoomMenosAut.Click += new System.EventHandler(this.ZoomMenosAut_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mueveNodoAut,
            this.mueveAut});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(737, 32);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip2_ItemClicked);
            // 
            // mueveNodoAut
            // 
            this.mueveNodoAut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mueveNodoAut.Image = ((System.Drawing.Image)(resources.GetObject("mueveNodoAut.Image")));
            this.mueveNodoAut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mueveNodoAut.Name = "mueveNodoAut";
            this.mueveNodoAut.Size = new System.Drawing.Size(36, 29);
            this.mueveNodoAut.Text = "toolStripButton1";
            // 
            // mueveAut
            // 
            this.mueveAut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mueveAut.Image = ((System.Drawing.Image)(resources.GetObject("mueveAut.Image")));
            this.mueveAut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mueveAut.Name = "mueveAut";
            this.mueveAut.Size = new System.Drawing.Size(36, 29);
            this.mueveAut.Text = "toolStripButton2";
            // 
            // pictureAutomata
            // 
            this.pictureAutomata.Location = new System.Drawing.Point(0, 67);
            this.pictureAutomata.Name = "pictureAutomata";
            this.pictureAutomata.Size = new System.Drawing.Size(100, 50);
            this.pictureAutomata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureAutomata.TabIndex = 1;
            this.pictureAutomata.TabStop = false;
            this.pictureAutomata.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureAutomata_Paint);
            this.pictureAutomata.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureAutomata_MouseDown);
            this.pictureAutomata.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureAutomata_MouseMove);
            this.pictureAutomata.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureAutomata_MouseUp);
            // 
            // Tablas
            // 
            this.Tablas.Controls.Add(this.tabPos);
            this.Tablas.Controls.Add(this.tabSigpos);
            this.Tablas.Location = new System.Drawing.Point(3, 163);
            this.Tablas.Name = "Tablas";
            this.Tablas.SelectedIndex = 0;
            this.Tablas.Size = new System.Drawing.Size(499, 395);
            this.Tablas.TabIndex = 3;
            // 
            // tabPos
            // 
            this.tabPos.Controls.Add(this.dataPosiciones);
            this.tabPos.Location = new System.Drawing.Point(4, 22);
            this.tabPos.Name = "tabPos";
            this.tabPos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPos.Size = new System.Drawing.Size(491, 369);
            this.tabPos.TabIndex = 0;
            this.tabPos.Text = "Tabla de posiciones";
            this.tabPos.UseVisualStyleBackColor = true;
            // 
            // dataPosiciones
            // 
            this.dataPosiciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataPosiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPosiciones.Location = new System.Drawing.Point(3, 3);
            this.dataPosiciones.Name = "dataPosiciones";
            this.dataPosiciones.Size = new System.Drawing.Size(482, 360);
            this.dataPosiciones.TabIndex = 0;
            // 
            // tabSigpos
            // 
            this.tabSigpos.Controls.Add(this.dataSigPos);
            this.tabSigpos.Location = new System.Drawing.Point(4, 22);
            this.tabSigpos.Name = "tabSigpos";
            this.tabSigpos.Padding = new System.Windows.Forms.Padding(3);
            this.tabSigpos.Size = new System.Drawing.Size(491, 369);
            this.tabSigpos.TabIndex = 1;
            this.tabSigpos.Text = "Tabla de SiguientePos";
            this.tabSigpos.UseVisualStyleBackColor = true;
            // 
            // dataSigPos
            // 
            this.dataSigPos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataSigPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSigPos.Location = new System.Drawing.Point(4, 4);
            this.dataSigPos.Name = "dataSigPos";
            this.dataSigPos.Size = new System.Drawing.Size(482, 360);
            this.dataSigPos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Expresión Regular:";
            // 
            // ExpresionRegular_Postfija
            // 
            this.ExpresionRegular_Postfija.AutoSize = true;
            this.ExpresionRegular_Postfija.Location = new System.Drawing.Point(3, 64);
            this.ExpresionRegular_Postfija.Name = "ExpresionRegular_Postfija";
            this.ExpresionRegular_Postfija.Size = new System.Drawing.Size(130, 13);
            this.ExpresionRegular_Postfija.TabIndex = 6;
            this.ExpresionRegular_Postfija.Text = "Expresion Regular Postfija";
            // 
            // Verificar
            // 
            this.Verificar.AutoSize = true;
            this.Verificar.Location = new System.Drawing.Point(3, 115);
            this.Verificar.Name = "Verificar";
            this.Verificar.Size = new System.Drawing.Size(85, 13);
            this.Verificar.TabIndex = 8;
            this.Verificar.Text = "Verificar Oración";
            // 
            // TextVer
            // 
            this.TextVer.Location = new System.Drawing.Point(3, 132);
            this.TextVer.Name = "TextVer";
            this.TextVer.Size = new System.Drawing.Size(368, 20);
            this.TextVer.TabIndex = 9;
            // 
            // Validar
            // 
            this.Validar.Location = new System.Drawing.Point(377, 131);
            this.Validar.Name = "Validar";
            this.Validar.Size = new System.Drawing.Size(75, 23);
            this.Validar.TabIndex = 10;
            this.Validar.Text = "Validar";
            this.Validar.UseVisualStyleBackColor = true;
            this.Validar.Click += new System.EventHandler(this.Validar_Click);
            // 
            // VerRes
            // 
            this.VerRes.AutoSize = true;
            this.VerRes.Location = new System.Drawing.Point(460, 136);
            this.VerRes.Name = "VerRes";
            this.VerRes.Size = new System.Drawing.Size(0, 13);
            this.VerRes.TabIndex = 11;
            // 
            // ER_Post
            // 
            this.ER_Post.Location = new System.Drawing.Point(3, 80);
            this.ER_Post.Name = "ER_Post";
            this.ER_Post.ReadOnly = true;
            this.ER_Post.Size = new System.Drawing.Size(492, 20);
            this.ER_Post.TabIndex = 12;
            // 
            // ExpReg
            // 
            this.ExpReg.Location = new System.Drawing.Point(3, 30);
            this.ExpReg.Name = "ExpReg";
            this.ExpReg.ReadOnly = true;
            this.ExpReg.Size = new System.Drawing.Size(492, 20);
            this.ExpReg.TabIndex = 13;
            // 
            // Simulacion
            // 
            this.Simulacion.Tick += new System.EventHandler(this.Simulacion_Tick);
            // 
            // Arbol_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 561);
            this.Controls.Add(this.ExpReg);
            this.Controls.Add(this.ER_Post);
            this.Controls.Add(this.VerRes);
            this.Controls.Add(this.Validar);
            this.Controls.Add(this.TextVer);
            this.Controls.Add(this.Verificar);
            this.Controls.Add(this.ExpresionRegular_Postfija);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tablas);
            this.Controls.Add(this.tabArbol);
            this.Name = "Arbol_F";
            this.Text = "Automata Finito Deterministico";
            this.Load += new System.EventHandler(this.Arbol_F_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureArbol)).EndInit();
            this.tabArbol.ResumeLayout(false);
            this.tabArbolFloreado.ResumeLayout(false);
            this.tabArbolFloreado.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabAutomata.ResumeLayout(false);
            this.tabAutomata.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAutomata)).EndInit();
            this.Tablas.ResumeLayout(false);
            this.tabPos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPosiciones)).EndInit();
            this.tabSigpos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSigPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureArbol;
        private System.Windows.Forms.TabControl tabArbol;
        private System.Windows.Forms.TabPage tabArbolFloreado;
        private System.Windows.Forms.TabPage tabAutomata;
        private System.Windows.Forms.TabControl Tablas;
        private System.Windows.Forms.TabPage tabPos;
        private System.Windows.Forms.TabPage tabSigpos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ExpresionRegular_Postfija;
        private System.Windows.Forms.Label Verificar;
        private System.Windows.Forms.TextBox TextVer;
        private System.Windows.Forms.Button Validar;
        private System.Windows.Forms.Label VerRes;
        private System.Windows.Forms.TextBox ER_Post;
        private System.Windows.Forms.TextBox ExpReg;
        private System.Windows.Forms.PictureBox pictureAutomata;
        private System.Windows.Forms.DataGridView dataPosiciones;
        private System.Windows.Forms.DataGridView dataSigPos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mueveNodo;
        private System.Windows.Forms.ToolStripButton mueveArbol;
        private System.Windows.Forms.Timer Simulacion;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ZoomMasAut;
        private System.Windows.Forms.Button OriginalAut;
        private System.Windows.Forms.Button ZoomMenosAut;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton mueveNodoAut;
        private System.Windows.Forms.ToolStripButton mueveAut;
    }
}