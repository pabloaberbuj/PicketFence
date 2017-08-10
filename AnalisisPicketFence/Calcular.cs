using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalisisPicketFence
{
    class Calcular
    {
        public static double interpolar(double x1, double x2, double y1, double y2, double x)
        {
            double y;
            if (x == x1) { y = y1; }
            else if (x == x2) { y = y2; }

            else { y = y1 + (y2 - y1) / (x2 - x1) * (x - x1); }
            return y;
        }

        public static double interpolarLineaIndice(double X, double[] etiquetasX)
        {
            double Indice = Double.NaN;
            double X1 = 0; double i1 = Double.NaN;
            double X2 = 0; double i2 = Double.NaN;
            int iX = Array.IndexOf(etiquetasX, X);
            if (X > etiquetasX.Max())
            {
                MessageBox.Show("El valor es mayor que todos los tabulados. No se puede interpolar");
            }
            else if (X < etiquetasX.Min())
            {
                MessageBox.Show("El valor es menor que todos los tabulados. No se puede interpolar");
            }
            else
            {
                if (iX != -1) //no hace falta interpolar
                {
                    Indice = Array.IndexOf(etiquetasX, X);
                }
                else
                {
                    //   if (Math.Sign(etiquetasX[3] - etiquetasX[0]) == 1) //creciente
                    // {
                    for (int i = 0; i < etiquetasX.Count(); i++)
                    {
                        if (etiquetasX[i] > X)
                        {
                            X1 = etiquetasX[i - 1]; i1 = i - 1;
                            X2 = etiquetasX[i]; i2 = i;
                            break;
                        }
                    }
                    //}
                    /*                else if (Math.Sign(etiquetasX[3] - etiquetasX[0]) == -1) //decreciente
                                    {

                                        for (int i = 0; i < etiquetasX.Count(); i++)
                                        {
                                            if (etiquetasX[i] < X)
                                            {
                                                X1 = etiquetasX[i - 1]; i1 = i - 1;
                                                X2 = etiquetasX[i]; i2 = i;
                                                break;
                                            }
                                        }
                                    }
                                    Indice = interpolar(X1, X2, i1, i2, X);
                                }*/
                }
            }
            return Indice;
        }
    }

}
