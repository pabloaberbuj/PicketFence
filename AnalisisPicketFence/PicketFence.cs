using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnalisisPicketFence
{
    class PicketFence
    {
        public double[,] matriz { get; set; }
        public string fecha { get; set; }
        public double gantry { get; set; }
        public double resX { get; set; }
        public double resY { get; set; }
        public int tamX { get; set; }
        public int tamY { get; set; }

        public static string[] Cargar(string archivo)
        {
            return File.ReadAllLines(archivo);
        }

        public static string extraerString(string[] fid, int linea)
        {
            string aux = fid[linea]; string[] aux2 = aux.Split('='); string salida = aux2[1];
            return salida;
        }
        public static double extraerDouble(string[] fid, int linea)
        {
            return Convert.ToDouble(extraerString(fid, linea));
        }

        public static string extraerFecha(string[] fid, int linea)
        {
            string aux = extraerString(fid, linea);
            return aux.Split(',')[0];
        }

        public static double[,] extraerMatriz(string[] fid, int lineaI, int lineaF, int Tam1, int Tam2)
        {
            double[,] M = new double[Tam1, Tam2];
            for (int i = 0; i < Tam2; i++)
            {
                double[] aux1 = Array.ConvertAll(fid[lineaI + i].Split('\t'), new Converter<string, double>(Double.Parse));
                for (int j = 0; j < Tam1; j++)
                {
                    M[j, i] = aux1[j];
                }
            }
            return M;
        }

        public static PicketFence Crear(string archivo)
        {
            string[] aux = Cargar(archivo);
            PicketFence picketFence = new PicketFence
            {
                fecha = extraerFecha(aux, 46),
                gantry = extraerDouble(aux, 38),
                tamX = Convert.ToInt32(extraerDouble(aux, 8)),
                resX = extraerDouble(aux, 9),
                tamY = Convert.ToInt32(extraerDouble(aux, 14)),
                resY = extraerDouble(aux, 15),
            };
            picketFence.matriz = extraerMatriz(aux, 48, 48 + picketFence.tamY - 1, picketFence.tamX, picketFence.tamY);
            return picketFence;
        }
        public static int buscarPico(double[,] matriz, int linea, int colInicio)
        {
            int posicionPico=0;
            for (int i=colInicio;i< matriz.GetLength(0); i++)
            {
                if (matriz[i,linea]>matriz[i-5,linea]*1.2 && matriz[i, linea] > matriz[i + 5, linea])
                {
                    posicionPico = i;
                    break;
                }
                
            }
            return posicionPico;
        }
    }
    
}


