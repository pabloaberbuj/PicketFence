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
            this.BT_PicketFence = new System.Windows.Forms.Button();
            this.BT_1PicoLargo = new System.Windows.Forms.Button();
            this.BT_1pico1Lam = new System.Windows.Forms.Button();
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
            // BT_PicketFence
            // 
            this.BT_PicketFence.Location = new System.Drawing.Point(34, 165);
            this.BT_PicketFence.Name = "BT_PicketFence";
            this.BT_PicketFence.Size = new System.Drawing.Size(106, 23);
            this.BT_PicketFence.TabIndex = 3;
            this.BT_PicketFence.Text = "PicketFence";
            this.BT_PicketFence.UseVisualStyleBackColor = true;
            this.BT_PicketFence.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT_1PicoLargo
            // 
            this.BT_1PicoLargo.Location = new System.Drawing.Point(159, 165);
            this.BT_1PicoLargo.Name = "BT_1PicoLargo";
            this.BT_1PicoLargo.Size = new System.Drawing.Size(106, 35);
            this.BT_1PicoLargo.TabIndex = 6;
            this.BT_1PicoLargo.Text = "Un Pico en columna";
            this.BT_1PicoLargo.UseVisualStyleBackColor = true;
            this.BT_1PicoLargo.Click += new System.EventHandler(this.BT_1PicoLargo_Click);
            // 
            // BT_1pico1Lam
            // 
            this.BT_1pico1Lam.Location = new System.Drawing.Point(34, 226);
            this.BT_1pico1Lam.Name = "BT_1pico1Lam";
            this.BT_1pico1Lam.Size = new System.Drawing.Size(106, 23);
            this.BT_1pico1Lam.TabIndex = 7;
            this.BT_1pico1Lam.Text = "Un pico una lámina";
            this.BT_1pico1Lam.UseVisualStyleBackColor = true;
            this.BT_1pico1Lam.Click += new System.EventHandler(this.BT_1pico1Lam_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 298);
            this.Controls.Add(this.BT_1pico1Lam);
            this.Controls.Add(this.BT_1PicoLargo);
            this.Controls.Add(this.BT_PicketFence);
            this.Controls.Add(this.BT_CargarArchivo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_CargarArchivo;
        private System.Windows.Forms.Button BT_PicketFence;
        private System.Windows.Forms.Button BT_1PicoLargo;
        private System.Windows.Forms.Button BT_1pico1Lam;
    }
}

