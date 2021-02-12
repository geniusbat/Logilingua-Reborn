using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logilingua_Reborn
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            /*
            Stopwatch reloj = new Stopwatch();
            //Mama
            System.Console.WriteLine("Mama: ");
            Word mama = new Word(DataReader.Read("C:/Users/Tytan/source/repos/Logilingua Reborn/Datos/mama.txt"));
            System.Console.WriteLine("Estructura Binaria: "+mama.ShowBS());
            reloj.Start();
            System.Console.WriteLine("Bigramas");
            System.Console.WriteLine(mama.WordGenerationUsingBigrams());
            System.Console.WriteLine(mama.WordGenerationUsingBigramsBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: "+reloj.ElapsedTicks);
            reloj.Start();
            System.Console.WriteLine("Bigramas, sequencial");
            System.Console.WriteLine(mama.WordGenerationUsingBigramsSequential());
            System.Console.WriteLine(mama.WordGenerationUsingBigramsSequentialBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: "+reloj.ElapsedTicks);
            System.Console.WriteLine("");
            //Hola
            System.Console.WriteLine("Hola: ");
            Word hola = new Word(DataReader.Read("C:/Users/Tytan/source/repos/Logilingua Reborn/Datos/hola.txt"));
            System.Console.WriteLine("Estructura Binaria: " + hola.ShowBS());
            reloj.Start();
            System.Console.WriteLine("Bigramas");
            System.Console.WriteLine(hola.WordGenerationUsingBigrams());
            System.Console.WriteLine(hola.WordGenerationUsingBigramsBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: " + reloj.ElapsedTicks);
            reloj.Start();
            System.Console.WriteLine("Bigramas, sequencial");
            System.Console.WriteLine(hola.WordGenerationUsingBigramsSequential());
            System.Console.WriteLine(hola.WordGenerationUsingBigramsSequentialBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: " + reloj.ElapsedTicks);
            System.Console.WriteLine("");
            //Manzana
            System.Console.WriteLine("Manzana: ");
            Word manzana = new Word(DataReader.Read("C:/Users/Tytan/source/repos/Logilingua Reborn/Datos/manzana.txt"));
            System.Console.WriteLine("Estructura Binaria: " + manzana.ShowBS());
            reloj.Start();
            System.Console.WriteLine("Bigramas");
            System.Console.WriteLine(manzana.WordGenerationUsingBigrams());
            System.Console.WriteLine(manzana.WordGenerationUsingBigramsBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: " + reloj.ElapsedTicks);
            reloj.Start();
            System.Console.WriteLine("Bigramas, sequencial");
            System.Console.WriteLine(manzana.WordGenerationUsingBigramsSequential());
            System.Console.WriteLine(manzana.WordGenerationUsingBigramsSequentialBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: " + reloj.ElapsedTicks);
            System.Console.WriteLine("");
            //Malo
            System.Console.WriteLine("Malo: ");
            Word malo = new Word(DataReader.Read("C:/Users/Tytan/source/repos/Logilingua Reborn/Datos/malo.txt"));
            System.Console.WriteLine("Estructura Binaria: " + malo.ShowBS());
            reloj.Start();
            System.Console.WriteLine("Bigramas");
            System.Console.WriteLine(malo.WordGenerationUsingBigrams());
            System.Console.WriteLine(malo.WordGenerationUsingBigramsBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: " + reloj.ElapsedTicks);
            reloj.Start();
            System.Console.WriteLine("Bigramas, sequencial");
            System.Console.WriteLine(malo.WordGenerationUsingBigramsSequential());
            System.Console.WriteLine(malo.WordGenerationUsingBigramsSequentialBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: " + reloj.ElapsedTicks);
            System.Console.WriteLine("");
            //Piedra
            System.Console.WriteLine("Piedra: ");
            Word piedra = new Word(DataReader.Read("C:/Users/Tytan/source/repos/Logilingua Reborn/Datos/piedra.txt"));
            System.Console.WriteLine("Estructura Binaria: " + piedra.ShowBS());
            reloj.Start();
            System.Console.WriteLine("Bigramas");
            System.Console.WriteLine(piedra.WordGenerationUsingBigrams());
            System.Console.WriteLine(piedra.WordGenerationUsingBigramsBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: " + reloj.ElapsedTicks);
            reloj.Start();
            System.Console.WriteLine("Bigramas, sequencial");
            System.Console.WriteLine(piedra.WordGenerationUsingBigramsSequential());
            System.Console.WriteLine(piedra.WordGenerationUsingBigramsSequentialBS());
            reloj.Stop();
            System.Console.WriteLine("Tiempo: " + reloj.ElapsedTicks);
            */
        }
    }
}
