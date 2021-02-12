using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logilingua_Reborn
{
    class DataReader
    {
        public static List<String> Read(String direction)
        {
            List<String> lista = new List<string>();
            String[] cadena= (System.IO.File.ReadAllText(direction)).Split(',');
            foreach (var el in cadena)
            {
                lista.Add(el.Trim());
            }
            return lista;
        }
    }
}
