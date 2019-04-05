namespace ExpresionRegular
{
    partial class SLR0
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
            this.gram = new System.Windows.Forms.RichTextBox();
            this.expandida = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.expand = new System.Windows.Forms.Label();
            this.prim = new System.Windows.Forms.Label();
            this.sig = new System.Windows.Forms.Label();
            this.treePrimero = new System.Windows.Forms.TreeView();
            this.treeSiguiente = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // gram
            // 
            this.gram.Location = new System.Drawing.Point(12, 31);
            this.gram.Name = "gram";
            this.gram.Size = new System.Drawing.Size(121, 272);
            this.gram.TabIndex = 0;
            this.gram.Text = "";
            // 
            // expandida
            // 
            this.expandida.Location = new System.Drawing.Point(139, 31);
            this.expandida.Name = "expandida";
            this.expandida.Size = new System.Drawing.Size(121, 272);
            this.expandida.TabIndex = 1;
            this.expandida.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gramatica";
            // 
            // expand
            // 
            this.expand.AutoSize = true;
            this.expand.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expand.Location = new System.Drawing.Point(139, 15);
            this.expand.Name = "expand";
            this.expand.Size = new System.Drawing.Size(76, 16);
            this.expand.TabIndex = 5;
            this.expand.Text = "Expandida";
            // 
            // prim
            // 
            this.prim.AutoSize = true;
            this.prim.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prim.Location = new System.Drawing.Point(266, 15);
            this.prim.Name = "prim";
            this.prim.Size = new System.Drawing.Size(59, 16);
            this.prim.TabIndex = 6;
            this.prim.Text = "Primero";
            // 
            // sig
            // 
            this.sig.AutoSize = true;
            this.sig.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sig.Location = new System.Drawing.Point(557, 15);
            this.sig.Name = "sig";
            this.sig.Size = new System.Drawing.Size(69, 16);
            this.sig.TabIndex = 7;
            this.sig.Text = "Siguiente";
            // 
            // treePrimero
            // 
            this.treePrimero.Location = new System.Drawing.Point(267, 31);
            this.treePrimero.Name = "treePrimero";
            this.treePrimero.Size = new System.Drawing.Size(284, 272);
            this.treePrimero.TabIndex = 8;
            // 
            // treeSiguiente
            // 
            this.treeSiguiente.Location = new System.Drawing.Point(557, 31);
            this.treeSiguiente.Name = "treeSiguiente";
            this.treeSiguiente.Size = new System.Drawing.Size(284, 272);
            this.treeSiguiente.TabIndex = 9;
            // 
            // SLR0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 318);
            this.Controls.Add(this.treeSiguiente);
            this.Controls.Add(this.treePrimero);
            this.Controls.Add(this.sig);
            this.Controls.Add(this.prim);
            this.Controls.Add(this.expand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expandida);
            this.Controls.Add(this.gram);
            this.Name = "SLR0";
            this.Text = "SLR0";
            this.Load += new System.EventHandler(this.SLR0_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox gram;
        private System.Windows.Forms.RichTextBox expandida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label expand;
        private System.Windows.Forms.Label prim;
        private System.Windows.Forms.Label sig;
        private System.Windows.Forms.TreeView treePrimero;
        private System.Windows.Forms.TreeView treeSiguiente;
    }
}