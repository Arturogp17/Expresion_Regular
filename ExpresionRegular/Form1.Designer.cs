namespace ExpresionRegular
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gramatica = new System.Windows.Forms.RichTextBox();
            this.paso1 = new System.Windows.Forms.RichTextBox();
            this.paso2 = new System.Windows.Forms.RichTextBox();
            this.paso3 = new System.Windows.Forms.RichTextBox();
            this.paso4 = new System.Windows.Forms.RichTextBox();
            this.GramaticaLabel = new System.Windows.Forms.Label();
            this.Paso1Label = new System.Windows.Forms.Label();
            this.Paso2Label = new System.Windows.Forms.Label();
            this.Paso3Label = new System.Windows.Forms.Label();
            this.Paso4Label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.Abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Generar = new System.Windows.Forms.Button();
            this.ExpresionR = new System.Windows.Forms.TextBox();
            this.ErLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.reg = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Open = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.ErpLabel = new System.Windows.Forms.Label();
            this.ER_Postfija = new System.Windows.Forms.TextBox();
            this.Generar_Posfija = new System.Windows.Forms.Button();
            this.Generar_Arbol = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gramatica
            // 
            this.gramatica.AccessibleName = "gramatica";
            this.gramatica.Location = new System.Drawing.Point(12, 84);
            this.gramatica.Name = "gramatica";
            this.gramatica.Size = new System.Drawing.Size(112, 161);
            this.gramatica.TabIndex = 0;
            this.gramatica.Text = "";
            this.gramatica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gramatica_KeyPress);
            // 
            // paso1
            // 
            this.paso1.AccessibleName = "paso1";
            this.paso1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paso1.Location = new System.Drawing.Point(12, 265);
            this.paso1.Name = "paso1";
            this.paso1.ReadOnly = true;
            this.paso1.Size = new System.Drawing.Size(112, 161);
            this.paso1.TabIndex = 1;
            this.paso1.Text = "";
            // 
            // paso2
            // 
            this.paso2.AccessibleName = "paso2";
            this.paso2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paso2.Location = new System.Drawing.Point(130, 84);
            this.paso2.Name = "paso2";
            this.paso2.ReadOnly = true;
            this.paso2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.paso2.Size = new System.Drawing.Size(354, 344);
            this.paso2.TabIndex = 2;
            this.paso2.Text = "";
            this.paso2.WordWrap = false;
            // 
            // paso3
            // 
            this.paso3.AccessibleName = "paso3";
            this.paso3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paso3.Location = new System.Drawing.Point(490, 84);
            this.paso3.Name = "paso3";
            this.paso3.ReadOnly = true;
            this.paso3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.paso3.Size = new System.Drawing.Size(414, 344);
            this.paso3.TabIndex = 3;
            this.paso3.Text = "";
            this.paso3.WordWrap = false;
            // 
            // paso4
            // 
            this.paso4.AccessibleName = "paso4";
            this.paso4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paso4.Location = new System.Drawing.Point(910, 84);
            this.paso4.Name = "paso4";
            this.paso4.ReadOnly = true;
            this.paso4.Size = new System.Drawing.Size(312, 344);
            this.paso4.TabIndex = 4;
            this.paso4.Text = "";
            // 
            // GramaticaLabel
            // 
            this.GramaticaLabel.AutoSize = true;
            this.GramaticaLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GramaticaLabel.Location = new System.Drawing.Point(12, 63);
            this.GramaticaLabel.Name = "GramaticaLabel";
            this.GramaticaLabel.Size = new System.Drawing.Size(92, 18);
            this.GramaticaLabel.TabIndex = 5;
            this.GramaticaLabel.Text = "Gramática";
            // 
            // Paso1Label
            // 
            this.Paso1Label.AutoSize = true;
            this.Paso1Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paso1Label.Location = new System.Drawing.Point(12, 244);
            this.Paso1Label.Name = "Paso1Label";
            this.Paso1Label.Size = new System.Drawing.Size(67, 18);
            this.Paso1Label.TabIndex = 6;
            this.Paso1Label.Text = "Paso 1:";
            // 
            // Paso2Label
            // 
            this.Paso2Label.AutoSize = true;
            this.Paso2Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paso2Label.Location = new System.Drawing.Point(130, 63);
            this.Paso2Label.Name = "Paso2Label";
            this.Paso2Label.Size = new System.Drawing.Size(67, 18);
            this.Paso2Label.TabIndex = 7;
            this.Paso2Label.Text = "Paso 2:";
            // 
            // Paso3Label
            // 
            this.Paso3Label.AutoSize = true;
            this.Paso3Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paso3Label.Location = new System.Drawing.Point(490, 63);
            this.Paso3Label.Name = "Paso3Label";
            this.Paso3Label.Size = new System.Drawing.Size(67, 18);
            this.Paso3Label.TabIndex = 8;
            this.Paso3Label.Text = "Paso 3:";
            // 
            // Paso4Label
            // 
            this.Paso4Label.AutoSize = true;
            this.Paso4Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paso4Label.Location = new System.Drawing.Point(910, 63);
            this.Paso4Label.Name = "Paso4Label";
            this.Paso4Label.Size = new System.Drawing.Size(67, 18);
            this.Paso4Label.TabIndex = 9;
            this.Paso4Label.Text = "Paso 4:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Archivo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Archivo
            // 
            this.Archivo.AccessibleName = "Archivo";
            this.Archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Abrir,
            this.toolStripSeparator1,
            this.Guardar});
            this.Archivo.Name = "Archivo";
            this.Archivo.Size = new System.Drawing.Size(60, 20);
            this.Archivo.Text = "Archivo";
            this.Archivo.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Archivo_DropDownItemClicked);
            // 
            // Abrir
            // 
            this.Abrir.AccessibleName = "Abrir";
            this.Abrir.Name = "Abrir";
            this.Abrir.Size = new System.Drawing.Size(116, 22);
            this.Abrir.Text = "Abrir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // Guardar
            // 
            this.Guardar.AccessibleName = "Guardar";
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(116, 22);
            this.Guardar.Text = "Guardar";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Generar
            // 
            this.Generar.AccessibleName = "Generar";
            this.Generar.Location = new System.Drawing.Point(31, 441);
            this.Generar.Name = "Generar";
            this.Generar.Size = new System.Drawing.Size(75, 23);
            this.Generar.TabIndex = 11;
            this.Generar.Text = "Generar";
            this.Generar.UseVisualStyleBackColor = true;
            this.Generar.Click += new System.EventHandler(this.Generar_Click);
            // 
            // ExpresionR
            // 
            this.ExpresionR.AccessibleDescription = "ExpresionR";
            this.ExpresionR.AccessibleName = "ExpresionR";
            this.ExpresionR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpresionR.Location = new System.Drawing.Point(177, 480);
            this.ExpresionR.Name = "ExpresionR";
            this.ExpresionR.Size = new System.Drawing.Size(1045, 24);
            this.ExpresionR.TabIndex = 12;
            this.ExpresionR.TextChanged += new System.EventHandler(this.ExpresionR_TextChanged);
            // 
            // ErLabel
            // 
            this.ErLabel.AutoSize = true;
            this.ErLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErLabel.Location = new System.Drawing.Point(12, 483);
            this.ErLabel.Name = "ErLabel";
            this.ErLabel.Size = new System.Drawing.Size(159, 18);
            this.ErLabel.TabIndex = 13;
            this.ErLabel.Text = "Expresion Regular:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(130, 443);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(65, 18);
            this.StatusLabel.TabIndex = 14;
            this.StatusLabel.Text = "Status:";
            // 
            // reg
            // 
            this.reg.AutoSize = true;
            this.reg.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg.Location = new System.Drawing.Point(201, 443);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(0, 18);
            this.reg.TabIndex = 16;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Save});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1234, 30);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Open
            // 
            this.Open.AccessibleName = "Abrir";
            this.Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open.Image = ((System.Drawing.Image)(resources.GetObject("Open.Image")));
            this.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(34, 27);
            this.Open.Text = "toolStripButton1";
            // 
            // Save
            // 
            this.Save.AccessibleName = "Save";
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(34, 27);
            this.Save.Text = "toolStripButton2";
            // 
            // ErpLabel
            // 
            this.ErpLabel.AutoSize = true;
            this.ErpLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErpLabel.Location = new System.Drawing.Point(42, 512);
            this.ErpLabel.Name = "ErpLabel";
            this.ErpLabel.Size = new System.Drawing.Size(99, 18);
            this.ErpLabel.TabIndex = 19;
            this.ErpLabel.Text = "ER Postfija:";
            // 
            // ER_Postfija
            // 
            this.ER_Postfija.AccessibleDescription = "ER Postfija";
            this.ER_Postfija.AccessibleName = "ER_Postfija";
            this.ER_Postfija.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ER_Postfija.Location = new System.Drawing.Point(177, 509);
            this.ER_Postfija.Name = "ER_Postfija";
            this.ER_Postfija.Size = new System.Drawing.Size(1045, 24);
            this.ER_Postfija.TabIndex = 18;
            // 
            // Generar_Posfija
            // 
            this.Generar_Posfija.AccessibleName = "Generar_Posfija";
            this.Generar_Posfija.Location = new System.Drawing.Point(259, 443);
            this.Generar_Posfija.Name = "Generar_Posfija";
            this.Generar_Posfija.Size = new System.Drawing.Size(96, 23);
            this.Generar_Posfija.TabIndex = 20;
            this.Generar_Posfija.Text = "Generar Postfija";
            this.Generar_Posfija.UseVisualStyleBackColor = true;
            this.Generar_Posfija.Click += new System.EventHandler(this.Generar_Posfija_Click);
            // 
            // Generar_Arbol
            // 
            this.Generar_Arbol.AccessibleName = "Generar_Arbol";
            this.Generar_Arbol.Location = new System.Drawing.Point(427, 441);
            this.Generar_Arbol.Name = "Generar_Arbol";
            this.Generar_Arbol.Size = new System.Drawing.Size(96, 23);
            this.Generar_Arbol.TabIndex = 21;
            this.Generar_Arbol.Text = "Generar Arbol";
            this.Generar_Arbol.UseVisualStyleBackColor = true;
            this.Generar_Arbol.Click += new System.EventHandler(this.Generar_Arbol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 543);
            this.Controls.Add(this.Generar_Arbol);
            this.Controls.Add(this.Generar_Posfija);
            this.Controls.Add(this.ErpLabel);
            this.Controls.Add(this.ER_Postfija);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.reg);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ErLabel);
            this.Controls.Add(this.ExpresionR);
            this.Controls.Add(this.Generar);
            this.Controls.Add(this.Paso4Label);
            this.Controls.Add(this.Paso3Label);
            this.Controls.Add(this.Paso2Label);
            this.Controls.Add(this.Paso1Label);
            this.Controls.Add(this.GramaticaLabel);
            this.Controls.Add(this.paso4);
            this.Controls.Add(this.paso3);
            this.Controls.Add(this.paso2);
            this.Controls.Add(this.paso1);
            this.Controls.Add(this.gramatica);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox gramatica;
        private System.Windows.Forms.RichTextBox paso1;
        private System.Windows.Forms.RichTextBox paso2;
        private System.Windows.Forms.RichTextBox paso3;
        private System.Windows.Forms.RichTextBox paso4;
        private System.Windows.Forms.Label GramaticaLabel;
        private System.Windows.Forms.Label Paso1Label;
        private System.Windows.Forms.Label Paso2Label;
        private System.Windows.Forms.Label Paso3Label;
        private System.Windows.Forms.Label Paso4Label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Generar;
        private System.Windows.Forms.TextBox ExpresionR;
        private System.Windows.Forms.Label ErLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label reg;
        private System.Windows.Forms.ToolStripMenuItem Archivo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Open;
        private System.Windows.Forms.ToolStripButton Save;
        private System.Windows.Forms.ToolStripMenuItem Abrir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Guardar;
        private System.Windows.Forms.Label ErpLabel;
        private System.Windows.Forms.TextBox ER_Postfija;
        private System.Windows.Forms.Button Generar_Posfija;
        private System.Windows.Forms.Button Generar_Arbol;
    }
}

