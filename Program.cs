using System;
using System.IO;
using System.Text;
using System.Threading;

namespace pruebaEquitel
{
    class Prueba
    {
        static void Main(string[] args)
        {
            //Invocación del archivo a analizar
            string texto = @"C:\Users\dz452\source\repos\pruebaEquitel\perfil.txt";
            string contenido = "", s = "";

            //Apertura del archivo para su uso
            using (StreamReader Reader = File.OpenText(texto))
            {
                while ((s = Reader.ReadLine()) != null)
                {
                    contenido += s;
                }
            }

            //Muestra el texto existente en el archivo
            Console.Write(contenido);

            //Creacion de los hilos
            Thread Tarea0 = new Thread(new ThreadStart(Escritura));
            Thread Tarea1 = new Thread(new ThreadStart(Tarea1Solucion));
            Thread Tarea2 = new Thread(new ThreadStart(Tarea2Solucion));
            Thread Tarea3 = new Thread(new ThreadStart(Tarea3Solucion));
            Thread Tarea4 = new Thread(new ThreadStart(Tarea4Solucion));

            //Ejecución de los hilos
            Tarea0.Start();
            Tarea1.Start();
            Tarea2.Start();
            Tarea3.Start();
            Tarea4.Start();
        }
        public static void Escritura()
        {
            //Traer el texto a analizar
            string texto = @"C:\Users\dz452\source\repos\pruebaEquitel\perfil.txt";

            try
            {
                //Comprobación de la existencia del archivo
                if (File.Exists(texto))
                {
                    //En caso de existir añada lo siguiente
                    File.AppendText(texto);
                }

                //Creacipon del archivo
                using (FileStream carga = File.Create(texto))
                {
                    var enco = new UTF8Encoding(true);
                    Byte[] miInfo = enco.GetBytes(texto);
                    carga.Write(miInfo, 0, miInfo.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Tarea1Solucion()
        {
            //Invocación del archivo a analizar
            string texto = @"C:\Users\dz452\source\repos\pruebaEquitel\perfil.txt";
            string contenido = "", s = "";
            int cuenta = 0;

            try
            {
                //Apertura del archivo para su uso
                using (StreamReader Reader = File.OpenText(texto))
                {
                    while ((s = Reader.ReadLine()) != null)
                    {
                        contenido += s;
                    }
                    cuenta = contenido.IndexOf('n');

                    //Cuenta solicitada en el punto 1
                    //Calcular cuantas palabras terminan con la letra N
                    for (int i = 0; i < contenido.Trim().Length - 1; i++)
                    {
                        if (contenido[i] != 'n')
                        {
                            cuenta++;
                            break;
                        }
                    }

                    Console.WriteLine("\n" + "Las palabras que finalizan con la letra N son :" + cuenta);

                    //Append 
                    //Inserta el resultado en el archivo original
                    StreamWriter oSW = new StreamWriter(texto, true);
                    oSW.WriteLine("\n" + "Las palabras que finalizan con la letra N son :" + cuenta);
                    oSW.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Tarea2Solucion()
        {
            string texto = @"C:\Users\dz452\source\repos\pruebaEquitel\perfil.txt";
            string contenido = "";
            string s = "";
            int oracion = 15;
            int linea = 0;

            try
            {
                //Apertura del archivo para su uso
                using (StreamReader Reader = File.OpenText(texto))
                {
                    while ((s = Reader.ReadLine()) != null)
                    {
                        contenido += s;
                    }
                }
                //Cuenta solicitada en el punto 2
                //Calcular cuantas lineas posee el archivo
                for (int i = 0; i < contenido.Trim().Length; i++)
                {
                    if (contenido[i] == '.' || contenido.Length == oracion)
                    {
                        linea++;
                    }
                };

                Console.WriteLine("\n" + "\n" + "Hay " + linea + " frases en el texto");

                //Append 
                //Inserta el resultado en el archivo original
                StreamWriter oSW = new StreamWriter(texto, true);
                oSW.WriteLine("\n" + "Hay " + linea + " frases en el texto");
                oSW.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Tarea3Solucion()
        {
            string texto = @"C:\Users\dz452\source\repos\pruebaEquitel\perfil.txt";
            string contenido = "";
            string s = "";
            int oracion = 15;
            int linea = 0;
            int parrafo = 0;

            try
            {
                //Apertura del archivo para su uso
                using (StreamReader Reader = File.OpenText(texto))
                {
                    while ((s = Reader.ReadLine()) != null)
                    {
                        contenido += s;
                    }
                }
                //Cuenta solicitada en el punto 3
                //Calcular cuantos parrafos posee el archivo
                for (int i = 0; i < contenido.Trim().Length; i++)
                {
                    if (contenido[i] == '.' || contenido.Length == oracion)
                    {
                        linea++;
                        if (linea <= 5)
                        {
                            parrafo = 1;
                        }
                        else
                        {
                            parrafo = linea % 2;
                        }
                    }
                };

                Console.WriteLine("\n" + "Hay " + parrafo + " parrafos en el texto");

                //Append 
                //Inserta el resultado en el archivo original
                StreamWriter oSW = new StreamWriter(texto, true);
                oSW.WriteLine("\n" + "Hay " + parrafo + " parrafos en el texto");
                oSW.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Tarea4Solucion()
        {
            string texto = @"C:\Users\dz452\source\repos\pruebaEquitel\perfil.txt";
            string contenido = "";
            int palabras = 0;
            int caracterestotales = 0;

            try
            {
                //Apertura del archivo para su uso
                using (StreamReader oSR = File.OpenText(texto))
                {
                    string s = "";
                    while ((s = oSR.ReadLine()) != null)
                    {
                        contenido += s;
                    }
                }
                //Cuenta solicitada en el punto 4
                //Calcular cuantos caracteres posee el archivo excluyendo simbolos y la letra N
                for (int i = 0; i < contenido.Trim().Length; i++)
                {
                    if (contenido[i] == ' ' || contenido[i] == '.' || contenido[i] == ',' || contenido[i] == 'n')
                    {
                        palabras++;
                    }
                }
                caracterestotales = contenido.Length - palabras;
                Console.WriteLine("Hay " + caracterestotales + " caracteres excluyendo simbolos y la letra 'n' en el texto");

                //Append 
                //Inserta el resultado en el archivo original
                StreamWriter oSW = new StreamWriter(texto, true);
                oSW.WriteLine("\n" + "Hay " + caracterestotales + " caracteres excluyendo simbolos y la letra 'n' en el texto");
                oSW.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
