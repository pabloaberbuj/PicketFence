using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnalisisPicketFence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void BT_CargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos dxf(.dxf)|*.dxf|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PicketFence picketFence = PicketFence.Crear(openFileDialog1.FileName);
                int pico = PicketFence.buscarPico(picketFence.matriz, 200, 10);
                MessageBox.Show(pico.ToString());
            }
        }
    }
}

