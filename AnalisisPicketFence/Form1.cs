﻿using System;
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
            int longSegmento = Convert.ToInt32(distancia / (2.5 * picketFence.resX)); //el ancho de medio pico
            int distEntreLaminas = Convert.ToInt32(5 / (2.5 * picketFence.resX));
            double rotacion = PicketFence.analizarRotacion(picketFence.matriz, picketFence.resX, picketFence.tamCampoY, distEntreLaminas);
            double rotacionEnmm = Math.Round(rotacion * picketFence.resX,3);
            MessageBox.Show("Se observó una rotación de" + rotacion.ToString() + " pixeles" + "\n que corresponde a" +rotacionEnmm.ToString() + " mm" );
            string[] picosArray = PicketFence.buscarPicosEnTodasLasLaminas(picketFence.matriz, 5, longSegmento, picketFence.resX, picketFence.tamCampoY, distEntreLaminas);
            File.WriteAllLines(archivo, picosArray);
            MessageBox.Show("Listo");
        }

        private void BT_1PicoLargo_Click(object sender, EventArgs e)
        {
            int longSegmento = Convert.ToInt32(distancia / (3 * picketFence.resX)); //el ancho de medio pico
            int distEntreLaminas = Convert.ToInt32(5 / (3 * picketFence.resX));
            string[] picosArray = PicketFence.buscarPicosEnTodasLasLaminasMenosDos(picketFence.matriz, 5, longSegmento, picketFence.resX, picketFence.tamCampoY, distEntreLaminas);
            File.WriteAllLines(archivo, picosArray);
            MessageBox.Show("Listo");
        }

        private void BT_1pico1Lam_Click(object sender, EventArgs e)
        {
            int longSegmento = Convert.ToInt32(distancia / (3 * picketFence.resX)); //el ancho de medio pico
            int distEntreLaminas = Convert.ToInt32(5 / (3 * picketFence.resX));
            string picosArray = PicketFence.buscarPicosEnLaminaCentral(picketFence.matriz, 5, longSegmento, picketFence.resX, picketFence.tamCampoY, distEntreLaminas);
            File.WriteAllText(archivo, picosArray);
            MessageBox.Show("Listo");
        }
    }
}

