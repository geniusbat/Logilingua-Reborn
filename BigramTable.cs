using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logilingua_Reborn
{
    class Bigram
    {
        public int position;
        public Char w0;
        public Char w1;
        public Double weight;
        public Bigram(int i, Char i0, Char i1, Double iW)
        {
            position = i;
            w0 = i0;
            w1 = i1;
            weight = iW;
        }
        public void IncreaseWeight()
        {
            weight += 1.0;
        }
        private static bool Compare(Bigram obj0,Bigram obj1)
        {
            return ((obj0.w0 == obj1.w1) & (obj0.w0 == obj1.w0));
        }
        public bool Compare(Bigram obj)
        {
            return ((this.w1 == obj.w1)&(this.w0==obj.w0));
        }
        public override string ToString()
        {
            String cadena = w0+","+w1+" "+"w:"+weight+";";
            return cadena;
        }
        public override bool Equals(object obj)
        {
            bool ret = true;
            if (obj is Bigram)
            {
                ret = this.Compare((Bigram)obj);
            }
            else
            {
                ret = false;
            }
            return ret;
        }
    }
}
