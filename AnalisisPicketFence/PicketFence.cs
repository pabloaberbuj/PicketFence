using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace AnalisisPicketFence
{
    class PicketFence
    {
        public double[,] matriz { get; set; }
        public string fecha { get; set; }
        public double gantry { get; set; }
        public double resX { get; set; }
        public double resY { get; set; }
        public int tamMatrizX { get; set; }
        public int tamMatrizY { get; set; }
        public double tamCampoX { get; set; }
        public double tamCampoY { get; set; }

        public static string[] cargar(string archivo)
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
                string[] stringLinea = fid[lineaI + i].Split('\t');
                double[] aux1 = stringLinea.Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
                for (int j = 0; j < Tam1; j++)
                {
                    M[j, i] = aux1[j];
                }
            }
            return M;
        }

        public static PicketFence crear(string archivo)
        {
            string[] aux = cargar(archivo);
            PicketFence picketFence = new PicketFence
            {
                fecha = extraerFecha(aux, 46),
                gantry = extraerDouble(aux, 38),
                tamMatrizX = Convert.ToInt32(extraerDouble(aux, 8)),
                resX = extraerDouble(aux, 9),
                tamMatrizY = Convert.ToInt32(extraerDouble(aux, 14)),
                resY = extraerDouble(aux, 15),
                tamCampoX = -extraerDouble(aux, 40) + extraerDouble(aux, 41),
                tamCampoY = -extraerDouble(aux, 42) + extraerDouble(aux, 43),
            };
            picketFence.matriz = extraerMatriz(aux, 48, 48 + picketFence.tamMatrizY - 1, picketFence.tamMatrizX, picketFence.tamMatrizY);
            return picketFence;
        }
        public static double[] extraerFila(double[,] matriz, int indice)
        {
            double[] fila = new double[matriz.GetLength(0)];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                fila[i] = matriz[i, indice];
            }
            return fila;
        }

        public static double[] extraerColumna(double[,] matriz, int indice)
        {
            double[] columna = new double[matriz.GetLength(1)];
            for (int i = 0; i < matriz.GetLength(1); i++)
            {
                columna[i] = matriz[indice, i];
            }
            return columna;
        }
        public static int aproximarPico(double[] fila, int inicio, int largoSegmento)
        {
            int posicionPico = 0;
            for (int i = inicio + Convert.ToInt32(largoSegmento * 3 / 2); i < fila.Count() - Convert.ToInt32(largoSegmento * 3 / 2); i++)
            {
                double[] auxArrayCentral = new double[largoSegmento];
                double[] auxArrayIzq = new double[largoSegmento];
                double[] auxArrayDer = new double[largoSegmento];
                Array.Copy(fila, i - Convert.ToInt32(largoSegmento / 2), auxArrayCentral, 0, largoSegmento);
                Array.Copy(fila, i - Convert.ToInt32(largoSegmento * 3 / 2), auxArrayIzq, 0, largoSegmento);
                Array.Copy(fila, i + Convert.ToInt32(largoSegmento / 2), auxArrayDer, 0, largoSegmento);
                if (fila[i] >= auxArrayCentral.Max() && fila[i] >= auxArrayDer.Max() && fila[i] >= auxArrayIzq.Max() && fila[i] > fila.Max() * 0.5)
                {
                    posicionPico = i;
                    break;
                }
            }
            return posicionPico;
        }

        public static Pico buscarCentroPico(double[] fila, int posicion, int largoSegmento, int tamMatriz, double resolucion, double factor)
        {

            double[] auxArrayCentrado = new double[largoSegmento];
            double[] auxArrayCentradoInvertido = new double[largoSegmento];
            Array.Copy(fila, posicion - Convert.ToInt32(largoSegmento / 2), auxArrayCentrado, 0, largoSegmento);
            Array.Copy(auxArrayCentrado, auxArrayCentradoInvertido, largoSegmento);
            Array.Reverse(auxArrayCentradoInvertido);
            double inicio = Calcular.interpolarLineaIndice(fila[posicion] * factor, auxArrayCentrado);
            //    int inicioI = Array.FindIndex(auxArrayCentrado, x => x > fila[posicion]*0.8);
            double fin = auxArrayCentrado.Count() - 1 - Calcular.interpolarLineaIndice(fila[posicion] * factor, auxArrayCentradoInvertido);
            //    int finI = Array.FindLastIndex(auxArrayCentrado, x => x > fila[posicion] * 0.8);
            double aux = (inicio + fin) / 2;
            /*    Pico nuevoPico = new Pico
                {
                    posicionPix = posicion - Convert.ToInt32(largoSegmento / 2) + aux,
                    posicionmm = Math.Round((posicion - Convert.ToInt32(largoSegmento / 2) + aux - tamMatriz/2) * resolucion,3),
                    anchoPico = Math.Abs(finI - inicioI), //fuerzo signo por las dudas (innecesario)
                    alturaPico = Math.Round(auxArrayCentrado[aux],5),
                };
                */
            Pico nuevoPico = new Pico
            {
                posicionPix = posicion - largoSegmento / 2 + aux,
                posicionmm = Math.Round((posicion - largoSegmento / 2 + aux - tamMatriz / 2) * resolucion, 3),
                anchoPico = fin - inicio,
                alturaPico = Math.Round(auxArrayCentrado.Max(),5),
                //alturaPico = Math.Round((auxArrayCentrado[Convert.ToInt32(Math.Floor(aux))] + auxArrayCentrado[Convert.ToInt32(Math.Ceiling(aux))]) / 2, 5),
            };
            return nuevoPico;

        }
        public static List<Pico> buscarPicos(double[] fila, int largoSegmento, int tamMatriz, double resolucion, double factor)
        {
            List<Pico> posicionPicos = new List<Pico>();
            int inicio = 0;
            while (inicio < fila.Count() - 3 * largoSegmento / 2)
            {
                int aux = aproximarPico(fila, inicio, largoSegmento);
                if (aux == 0)
                {
                    break;
                }
                else
                {
                    Pico nuevoPico = buscarCentroPico(fila, aux, largoSegmento, tamMatriz, resolucion, factor);
                    posicionPicos.Add(nuevoPico);
                    inicio = aux + Convert.ToInt32(largoSegmento / 2);
                }
            }
            return posicionPicos;
        }


        public static List<Pico> buscarPicoEnMatriz(double[,] matriz, int linea, int largoSegmento, int tamMatriz, double resolucion, double factor)
        {
            List<Pico> posicionPicos = new List<Pico>();
            double[] filaAux = extraerFila(matriz, linea);
            if (filaAux.Max() > 3 * filaAux[0])
            {
                posicionPicos = buscarPicos(filaAux, largoSegmento, tamMatriz, resolucion,factor);
            }
            return posicionPicos;
        }

        public static double[] promediarPerfilEnLamina(double[,] matriz, int centroLamina, int semiAncho)
        {
            double[] filapromedio = new double[matriz.GetLength(0)];
            for (int i = 0; i < 2 * semiAncho; i++)
            {
                double[] fila = extraerFila(matriz, centroLamina - semiAncho + i);
                for (int j = 0; j < filapromedio.Count(); j++)
                {
                    filapromedio[j] = fila[j] / (2 * semiAncho);
                }
            }
            return filapromedio;
        }

        public static int[] buscarPicosAprox(double[,] matriz, double tamCampoY, double resolucion, int largoSegmento, double factor)
        {
            int[] posicionPicos = new int[3];
            int posicionArriba = Convert.ToInt32(matriz.GetLength(1) / 2 - tamCampoY / resolucion / 3);
            int posicionAbajo = Convert.ToInt32(matriz.GetLength(1) / 2 + -tamCampoY / resolucion / 3);
            int posicionCentro = Convert.ToInt32(matriz.GetLength(1) / 2);
            List<Pico> picoArriba = buscarPicoEnMatriz(matriz, posicionArriba, largoSegmento, matriz.GetLength(0), resolucion,factor);
            List<Pico> picoCentro = buscarPicoEnMatriz(matriz, posicionCentro, largoSegmento, matriz.GetLength(0), resolucion,factor);
            List<Pico> picoAbajo = buscarPicoEnMatriz(matriz, posicionAbajo, largoSegmento, matriz.GetLength(0), resolucion,factor);
            int numeroPicos = picoCentro.Count();
            posicionPicos[0] = Convert.ToInt32((picoArriba[0].posicionPix + picoCentro[0].posicionPix + picoAbajo[0].posicionPix) / 3);
            posicionPicos[1] = Convert.ToInt32((picoArriba[Convert.ToInt32(numeroPicos / 2)].posicionPix + picoCentro[Convert.ToInt32(numeroPicos / 2)].posicionPix + picoAbajo[Convert.ToInt32(numeroPicos / 2)].posicionPix) / 3);
            posicionPicos[2] = Convert.ToInt32((picoArriba[numeroPicos - 1].posicionPix + picoCentro[numeroPicos - 1].posicionPix + picoAbajo[numeroPicos - 1].posicionPix) / 3);

            return posicionPicos;
        }

        public static List<int> buscarPosicionLaminas(double[,] matriz, double resolucion, double tamCampoY, int distEntreLaminas,int largoSegmento)
        {
            int[] posicionPicos = buscarPicosAprox(matriz, tamCampoY, resolucion, largoSegmento,0.8);
            List<Pico> picosInterLaminas = buscarPicos(extraerColumna(matriz, posicionPicos[1]), distEntreLaminas, matriz.GetLength(1), resolucion,0.9);
            List<int> posicionLaminas = new List<int>();
            int sumaDistancias = 0;
            double distPromedio = 0;
            posicionLaminas.Add(0); //reservo lugar para primer lámina

            for (int i = 1; i < picosInterLaminas.Count(); i++)
            {
                int distanciaEntrePicos = Convert.ToInt32((picosInterLaminas[i - 1].posicionPix + picosInterLaminas[i].posicionPix));
                sumaDistancias += distanciaEntrePicos / picosInterLaminas.Count();
                posicionLaminas.Add(Convert.ToInt32(distanciaEntrePicos / 2));
            }
            distPromedio = Convert.ToDouble(sumaDistancias) / (picosInterLaminas.Count() - 1);
            posicionLaminas[0] = posicionLaminas[1] - Convert.ToInt32(distPromedio);
            posicionLaminas.Add(posicionLaminas[picosInterLaminas.Count() - 1] + Convert.ToInt32(distPromedio));
            return posicionLaminas;
        }

        public static double analizarRotacion(double[,] matriz, double resolucion, double tamCampoY, int largoSegmento)
        {
            int[] posicionPicos = buscarPicosAprox(matriz, tamCampoY, resolucion, largoSegmento,0.8);
            List<Pico> picosIzquierda = buscarPicos(extraerColumna(matriz, posicionPicos[0]), largoSegmento, matriz.GetLength(1), resolucion,0.8);
            List<Pico> picosDerecha = buscarPicos(extraerColumna(matriz, posicionPicos[2]), largoSegmento, matriz.GetLength(1), resolucion,0.8);
            int numeroDePicos = picosIzquierda.Count();
            //para disminuir el error promedio sobre 3 picos
            double rotacion = 0;
            for (int i = -1; i < 2; i++)
            {
                double PicoDer = picosDerecha[Convert.ToInt32(numeroDePicos / 2) + i].posicionPix;
                double PicoIzq = picosIzquierda[Convert.ToInt32(numeroDePicos / 2) + i].posicionPix;
                rotacion += Math.Round(Convert.ToDouble((PicoDer - PicoIzq)) / 3, 1);
            }
            return rotacion;
        }

        public static List<Pico> buscarPicosEnLamina(double[,] matriz, int centroLamina, int semiAncho, int largoSegmento, int tamMatrizX, double resolucion)
        {
            double[] fila = promediarPerfilEnLamina(matriz, centroLamina, semiAncho);
            return buscarPicos(fila, largoSegmento, tamMatrizX, resolucion,0.8);
        }

        public static string[] buscarPicosEnTodasLasLaminas(double[,] matriz, int semiAncho, int largoSegmento, double resolucion, double tamCampoY, int distEntreLaminas)
        {
            List<int> posicionLaminas = buscarPosicionLaminas(matriz, resolucion, tamCampoY, distEntreLaminas,largoSegmento);
            string[] picosArray = new string[posicionLaminas.Count()];
            for (int i = 0; i < posicionLaminas.Count(); i++)
            {
                List<Pico> aux = buscarPicosEnLamina(matriz, posicionLaminas[i], semiAncho, largoSegmento, matriz.GetLength(0), resolucion);
                picosArray[i] = string.Join("\t", aux.Select(n => n.posicionmm.ToString()).ToArray()) + "\t\t" + string.Join("\t", aux.Select(n => n.alturaPico.ToString()).ToArray()) + "\t\t" + string.Join("\t", aux.Select(n => n.anchoPico.ToString()).ToArray());
            }
            return picosArray;
        }

        public static string[] buscarPicosEnTodasLasLaminasMenosDos(double[,] matriz, int semiAncho, int largoSegmento, double resolucion, double tamCampoY, int distEntreLaminas)
        {
            List<int> posicionLaminas = buscarPosicionLaminas(matriz, resolucion, tamCampoY, distEntreLaminas,largoSegmento);
            posicionLaminas.RemoveAt(0); posicionLaminas.RemoveAt(posicionLaminas.Count() - 1);
            string[] picosArray = new string[posicionLaminas.Count()];
            for (int i = 0; i < posicionLaminas.Count(); i++)
            {
                List<Pico> aux = buscarPicosEnLamina(matriz, posicionLaminas[i], semiAncho, largoSegmento, matriz.GetLength(0), resolucion);
                picosArray[i] = string.Join("\t", aux.Select(n => n.posicionmm.ToString()).ToArray()) + "\t\t" + string.Join("\t", aux.Select(n => n.alturaPico.ToString()).ToArray()) + "\t\t" + string.Join("\t", aux.Select(n => n.anchoPico.ToString()).ToArray());
            }
            return picosArray;
        }

        public static string buscarPicosEnLaminaCentral(double[,] matriz, int semiAncho, int largoSegmento, double resolucion, double tamCampoY, int distEntreLaminas)
        {
            List<int> posicionLaminas = buscarPosicionLaminas(matriz, resolucion, tamCampoY, distEntreLaminas,largoSegmento);
            List<Pico> aux = buscarPicosEnLamina(matriz, posicionLaminas[18], semiAncho, largoSegmento, matriz.GetLength(0), resolucion);
            string picosArray = string.Join("\t", aux.Select(n => n.posicionmm.ToString()).ToArray()) + "\t\t" + string.Join("\t", aux.Select(n => n.alturaPico.ToString()).ToArray()) + "\t\t" + string.Join("\t", aux.Select(n => n.anchoPico.ToString()).ToArray());

            return picosArray;
        }
    }

}


