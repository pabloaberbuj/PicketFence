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
        PicketFence picketFence = new PicketFence();
        double distancia = 15; //distancia aprox entre picos en mm
        string archivo = "picosTxt.txt";
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
                picketFence = PicketFence.crear(openFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string[] picosArray = new string[768];
            
            for (int i=0;i<768;i++)
            {
                List<double> picos = PicketFence.buscarPicoEnMatriz(picketFence.matriz, i, 0, longSegmento);
                picosArray[i] = string.Join("\t", picos.Select(n => n.ToString()).ToArray());
            }
            File.WriteAllLines(archivo, picosArray);
            MessageBox.Show("");*/
            int longSegmento = Convert.ToInt32(distancia / (3 * picketFence.resX)); //el ancho de medio pico
            int distEntreLaminas = Convert.ToInt32(5 / (3 * picketFence.resX));
            double rotacion = PicketFence.analizarRotacion(picketFence.matriz, picketFence.resX, picketFence.tamCampoY, distEntreLaminas);
            double rotacionEnmm = Math.Round(rotacion * picketFence.resX,3);
            MessageBox.Show("Se observó una rotación de" + rotacion.ToString() + " pixeles" + "\n que corresponde a" +rotacionEnmm.ToString() + " mm" );
            string[] picosArray = PicketFence.buscarPicosEnTodasLasLaminas(picketFence.matriz, 5, longSegmento, picketFence.resX, picketFence.tamCampoY, distEntreLaminas);
            File.WriteAllLines(archivo, picosArray);
            MessageBox.Show("");
            
        }
    }
}

