namespace AnalisisPicketFence
{
    partial class Form1
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
            this.BT_CargarArchivo = new System.Windows.Forms.Button();
            this.TB_Linea = new System.Windows.Forms.TextBox();
            this.TB_ColInicio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_CargarArchivo
            // 
            this.BT_CargarArchivo.Location = new System.Drawing.Point(34, 28);
            this.BT_CargarArchivo.Name = "BT_CargarArchivo";
            this.BT_CargarArchivo.Size = new System.Drawing.Size(106, 23);
            this.BT_CargarArchivo.TabIndex = 0;
            this.BT_CargarArchivo.Text = "Cargar Archivo";
            this.BT_CargarArchivo.UseVisualStyleBackColor = true;
            this.BT_CargarArchivo.Click += new System.EventHandler(this.BT_CargarArchivo_Click);
            // 
            // TB_Linea
            // 
            this.TB_Linea.Location = new System.Drawing.Point(165, 69);
            this.TB_Linea.Name = "TB_Linea";
            this.TB_Linea.Size = new System.Drawing.Size(100, 20);
            this.TB_Linea.TabIndex = 1;
            // 
            // TB_ColInicio
            // 
            this.TB_ColInicio.Location = new System.Drawing.Point(165, 116);
            this.TB_ColInicio.Name = "TB_ColInicio";
            this.TB_ColInicio.Size = new System.Drawing.Size(100, 20);
            this.TB_ColInicio.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cargar Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Linea";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Col Inicio";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 298);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TB_ColInicio);
            this.Controls.Add(this.TB_Linea);
            this.Controls.Add(this.BT_CargarArchivo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_CargarArchivo;
        private System.Windows.Forms.TextBox TB_Linea;
        private System.Windows.Forms.TextBox TB_ColInicio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

