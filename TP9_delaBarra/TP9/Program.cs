using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Helpers;

namespace TP9
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc = 0;
            string texto;

            //=========== Creacion y lectura del archivo binario ===============
            string ruta = "archivoBinario";
            SoporteParaConfiguracion.CrearArchivoDeConfiguracion(ruta);//Crea el archivo
            string destino = SoporteParaConfiguracion.LeerConfiguracion(ruta);//Lee el archivo binario y extrae la ruta donde se copian los archivos
            Console.WriteLine("La ruta en donde se copian los archivos es en: {0}", destino);//Muestra la ruta


            do
            {
                Console.WriteLine("Escriba una frase corta de texto para transformar a Morse: ");
                texto = Console.ReadLine();

                ConversorDeMorse.TextoAMorse(texto, destino);

                Console.WriteLine("La frase que escribio traducida es la siguiente: ");
                texto = ConversorDeMorse.MorseATexto(destino);
                Console.WriteLine(texto);

                ConversorDeMorse.MorseAAudio(destino);

                Console.WriteLine("¿Desea continuar convirtiendo? (1- Si / 2- No)");
                opc = int.Parse(Console.ReadLine());

            } while(opc != 2);
            //=============== Mover Archivos ================================
            //moverArchivos(destino);//Mueve los archivos desde la carpeta Debug, al destino


            

            Console.ReadKey();
        }

        public static void crearArchivo(string rutaCSV, string cadenaMorse)// Para crear archivo TXT
        {
            using (StreamWriter archivo = File.AppendText(rutaCSV))
            {
                archivo.Write(cadenaMorse);
                archivo.Close();
            }
        }

        public static void moverArchivos(string rutaDest)
        {
            string rutaProy;
            rutaProy = @"C:\Users\mario\Documents\Facultad\Taller de Programacion I\Taller\tp-nro9-mariodelabarra\TP9_delaBarra\TP9\bin\Debug";
            string[] archivosMP3 = Directory.GetFiles(rutaProy, "*.mp3");//Obtengo todos los archivos con extension .mp3
            string[] archivosTXT = Directory.GetFiles(rutaProy, "*.txt");//Obtengo todos los archivos con extension .mp3

            foreach (string archivoAux in archivosMP3)//Muevo todos los archivos MP3
            {
                string nombreArchivo = Path.GetFileName(archivoAux);
                string destino = Path.Combine(rutaDest, nombreArchivo);

                Console.WriteLine(archivoAux);

                File.Copy(archivoAux, destino);
                File.Delete(archivoAux);
            }

            foreach (string archivoAux in archivosTXT)//Muevo los archivos TXT
            {
                string nombreArchivo = Path.GetFileName(archivoAux);
                string destino = Path.Combine(rutaDest, nombreArchivo);

                Console.WriteLine(archivoAux);

                File.Copy(archivoAux, destino);
                File.Delete(archivoAux);
            }
        }
    }
}
