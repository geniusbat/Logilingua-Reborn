using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logilingua_Reborn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get word to generate
            String wordTo = "";
            if (WordHola.Checked==true)
            {
                wordTo = "hola";
            }
            else if (WordMama.Checked==true)
            {
                wordTo = "mama";
            }
            else if (WordManzana.Checked==true)
            {
                wordTo = "manzana";
            }
            else if (WordPiedra.Checked==true)
            {
                wordTo = "piedra";
            }
            Word palabra = new Word(DataReader.Read("C:\\Users\\Geniusbat\\Documents\\Proyectos\\Programación\\Logilingua Reborn\\Datos\\" + wordTo+".txt"));
            if (Bigrama.Checked==true)
            {
                textoOutput.Text = palabra.WordGenerationUsingBigrams();
            }
            else if (BigramaEst.Checked == true)
            {
                textoOutput.Text = palabra.WordGenerationUsingBigramsBS();
            }
            else if (BigramaSeq.Checked == true)
            {
                textoOutput.Text = palabra.WordGenerationUsingBigramsSequential();
            }
            else if (BigramaSeqEst.Checked == true)
            {
                textoOutput.Text = palabra.WordGenerationUsingBigramsSequentialBS();
            }
        }
    }
}
