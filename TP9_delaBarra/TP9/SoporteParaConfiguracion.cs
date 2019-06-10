using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helpers
{
    class SoporteParaConfiguracion
    {
        public static void CrearArchivoDeConfiguracion(string archivo)
        {
            string rutaDest = @"E:\BackUp\";
            if (!File.Exists(archivo + ".dat"))
            {
                using (BinaryWriter file = new BinaryWriter(File.Open(archivo + ".dat", FileMode.Create)))
                {
                    file.Write(rutaDest);
                    file.Close();
                }
            }
            else
            {
                Console.WriteLine("Ya existe un archivo con el nombre: {0}", archivo);
            }

            if (!Directory.Exists(rutaDest))//Crea la carpeta BackUp, si no existe
            {
                Directory.CreateDirectory(rutaDest);
                
            }
            else
            {
                Console.WriteLine("Ya existe una carpeta en la ubicacion: {0}", rutaDest);
            }

            if (!Directory.Exists(rutaDest + "Morse"))//Crea la carpeta para los archivos TXT en Morse
            {
                Directory.CreateDirectory(rutaDest + "Morse");
            }

        }

        public static string LeerConfiguracion(string archivo)
        {
            string rutaDest;
            
            if (File.Exists(archivo + ".dat"))
            {
                using (BinaryReader binario = new BinaryReader(File.Open(archivo + ".dat", FileMode.Open)))
                {
                    rutaDest = binario.ReadString();//Leo el contenido del archivo y lo transformo en string
                }
            }
            else
            {
                Console.WriteLine("No se pudo encontrar el archivo.");
                rutaDest = "-";
            }

            return rutaDest;
        }

    }

    class ConversorDeMorse
    {
        public static string MorseATexto(string ruta)
        {
            string textoFinal = "";
            string linea = "";//Para escribir los . y -, para luego separarlos cuando haya un /
            string cadenaMorse;

            FileStream archivoTXT = new FileStream(ruta + "Traduccion_" + DateTime.Today.ToString("dddd, dd MMMM yyyy") + ".txt", FileMode.Create);
            archivoTXT.Close();//Creo el archivo para la traduccion

            StreamReader archivoMorse = new StreamReader(ruta + @"Morse\Morse_" + DateTime.Today.ToString("dddd, dd MMMM yyyy") + ".txt");
            cadenaMorse = archivoMorse.ReadToEnd();
            archivoMorse.Close();//Abro el archivo con el codigo Morse y lo copio en una variable

            for(int i=0; i < cadenaMorse.Length; i++)
            {
                if(cadenaMorse[i] == '/')
                {
                    switch (linea)
                    {
                        case ".-":
                            textoFinal = textoFinal + 'a';
                            break;
                        case "-...":
                            textoFinal = textoFinal + 'b';
                            break;

                        case "-.-.":
                            textoFinal = textoFinal + 'c';
                            break;

                        case "-..":
                            textoFinal = textoFinal + 'd';
                            break;

                        case ".":
                            textoFinal = textoFinal + 'e';
                            break;

                        case "..-.":
                            textoFinal = textoFinal + 'f';
                            break;

                        case "--.":
                            textoFinal = textoFinal + 'g';
                            break;

                        case "....":
                            textoFinal = textoFinal + 'h';
                            break;

                        case "..":
                            textoFinal = textoFinal + 'i';
                            break;

                        case ".---":
                            textoFinal = textoFinal + 'j';
                            break;

                        case "-.-":
                            textoFinal = textoFinal + 'k';
                            break;

                        case ".-..":
                            textoFinal = textoFinal + 'l';
                            break;

                        case "--":
                            textoFinal = textoFinal + 'm';
                            break;

                        case "-.":
                            textoFinal = textoFinal + 'n';
                            break;

                        case "---":
                            textoFinal = textoFinal + 'o';
                            break;

                        case ".--.":
                            textoFinal = textoFinal + 'p';
                            break;

                        case "--.-":
                            textoFinal = textoFinal + 'q';
                            break;

                        case ".-.":
                            textoFinal = textoFinal + 'r';
                            break;

                        case "...":
                            textoFinal = textoFinal + 's';
                            break;

                        case "-":
                            textoFinal = textoFinal + 't';
                            break;

                        case "..-":
                            textoFinal = textoFinal + 'u';
                            break;

                        case "...-":
                            textoFinal = textoFinal + 'v';
                            break;

                        case ".--":
                            textoFinal = textoFinal + 'w';
                            break;

                        case "-..-":
                            textoFinal = textoFinal + 'x';
                            break;

                        case "-.--":
                            textoFinal = textoFinal + 'y';
                            break;

                        case "--..":
                            textoFinal = textoFinal + 'z';
                            break;
                    }
                    linea = "";
                }
                if (cadenaMorse[i] == 6)
                {
                    textoFinal = textoFinal + " ";
                    linea = "";
                }
                else if (cadenaMorse[i] != '/')
                {
                    linea = linea + cadenaMorse[i];//
                }
            }

            
            using(StreamWriter archivoTraduc = new StreamWriter(ruta + "Traduccion_" + DateTime.Today.ToString("dddd, dd MMMM yyyy") + ".txt"))
            {
                archivoTraduc.Write(textoFinal);
                archivoTraduc.Close();
            }

            return textoFinal;
        }

        public static void TextoAMorse(string cadena, string ruta)
        {
            string textoTraduc = "";
            string textoFinal = "";

            FileStream archivoTXT = new FileStream(ruta + @"Morse\Morse_" + DateTime.Today.ToString("dddd, dd MMMM yyyy") + ".txt", FileMode.Create);
            archivoTXT.Close();

            for (int i = 0; i < cadena.Length; i++)
            {
                switch (cadena[i])
                {
                    case 'a':
                        textoTraduc = ".-/";
                        break;
                    case 'b': textoTraduc = "-.../";
                        break;
                    case 'c': textoTraduc = "-.-./";
                        break;
                    case 'd': textoTraduc = "-../";
                        break;
                    case 'e': textoTraduc = "./";
                        break;
                    case 'f': textoTraduc = "..-./";
                        break;
                    case 'g': textoTraduc = "--./";
                        break;
                    case 'h': textoTraduc = "..../";
                        break;
                    case 'i': textoTraduc = "../";
                        break;
                    case 'j': textoTraduc = ".---/";
                        break;
                    case 'k': textoTraduc = "-.-/";
                        break;
                    case 'l': textoTraduc = ".-../";
                        break;
                    case 'm': textoTraduc = "--/";
                        break;
                    case 'n': textoTraduc = "-./";
                        break;
                    case 'o': textoTraduc = "---/";
                        break;
                    case 'p': textoTraduc = ".--./";
                        break;
                    case 'q': textoTraduc = "--.-/";
                        break;
                    case 'r': textoTraduc = ".-./";
                        break;
                    case 's': textoTraduc = ".../";
                        break;
                    case 't': textoTraduc = "-/";
                        break;
                    case 'u': textoTraduc = "..-/";
                        break;
                    case 'v': textoTraduc = "...-/";
                        break;
                    case 'w': textoTraduc = ".--/";
                        break;
                    case 'x': textoTraduc = "-..-/";
                        break;
                    case 'y': textoTraduc = "-.--/";
                        break;
                    case 'z': textoTraduc = "--../";
                        break;
                    case ' ': textoTraduc = "6";//Para los espacios
                        break;
                }
                textoFinal = textoFinal + textoTraduc;
            }

            using (StreamWriter archivo = new StreamWriter(ruta + @"Morse\Morse_" + DateTime.Today.ToString("dddd, dd MMMM yyyy") + ".txt"))
            {
                archivo.Write(textoFinal);
                archivo.Close();
            }
        }

        public static void MorseAAudio(string ruta)
        {
            byte[] puntoMP3, rayaMP3;//Para almacenar los sonidos en bytes
            List<byte> listAux = new List<byte>();//Para almacenar la combinacion de rayas y puntos

            FileStream rutaPunto = new FileStream(ruta + "punto.mp3", FileMode.Open);//Almaceno los bytes del MP3 de punto
            puntoMP3 = LectorCompletoDeBinario(rutaPunto);
            rutaPunto.Close();

            FileStream rutaRaya = new FileStream(ruta + "raya.mp3", FileMode.Open);//Almaceno los bytes del MP3 de raya
            rayaMP3 = LectorCompletoDeBinario(rutaRaya);
            rutaRaya.Close();


            //=========Almaceno el codigo Morse=========
            string codigoMorse;
            using(StreamReader archivo = new StreamReader(ruta + @"Morse\Morse_" + DateTime.Today.ToString("dddd, dd MMMM yyyy") + ".txt"))
            {
                codigoMorse = archivo.ReadToEnd();
                archivo.Close();
            }

            foreach(char caracter in codigoMorse)//Voy almacenando en orden los bytes del sonido para formar el codigo Morse completo
            {
                if(caracter == '.')
                {
                    listAux.AddRange(puntoMP3);//Almaceno los bytes de punto en la lista
                }
                else if (caracter == '-')
                {
                    listAux.AddRange(rayaMP3);//Almaceno los bytes de raya en la lista
                }
            }

            FileStream audioMP3 = new FileStream(ruta + "CodigoMorse.mp3", FileMode.Create);//Creo el archivo MP3 para el MP3
            audioMP3.Write(listAux.ToArray(), 0, listAux.Count());//Carga cada elemento de la lista en el orden correspondiente
            audioMP3.Close();

        }

        public static byte[] LectorCompletoDeBinario(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream()) // creando un memory stream 
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length); // lee desde la última posición hasta el tamaño del buffer
                    if (read <= 0)
                        return ms.ToArray(); // convierte el stream en array 
                    ms.Write(buffer, 0, read); // graba en el stream 
                }
            }
        }
    }
}
