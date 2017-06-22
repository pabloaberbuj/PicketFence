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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.BT_CargarArchivo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_CargarArchivo;
    }
}

