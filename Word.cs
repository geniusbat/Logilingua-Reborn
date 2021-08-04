using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logilingua_Reborn
{
    class Word
    {
        private Dictionary<int,List<Char>> lettersByPosition;
        private List<String> words;
        private Dictionary<int,List<Bigram>> bigramTable = new Dictionary<int,List<Bigram>>();
        private List<String> binaryStructure;
        private int averageLength=0;
        //Constructor
        public Word(List<String> input)
        {
            words = input;
            lettersByPosition = new Dictionary <int,List<Char>>();
            //Get positions table and average
            foreach (var word in words)
            {
                int i = 0;
                while (i < word.Length)
                {
                    if (lettersByPosition.ContainsKey(i)) { 
                        lettersByPosition[i].Add(word[i]);
                    }
                    else
                    {
                        List<Char> a = new List<Char>();
                        a.Add(word[i]);
                        lettersByPosition[i] = a;
                    }
                    i++;
                }
                averageLength += word.Length;
            }
            averageLength = averageLength / words.Count;
            //System.Console.WriteLine("avg:" + averageLength);
            Dictionary<int, List<Bigram>> auxTable = new Dictionary<int, List<Bigram>>();
            //Set bigram table
            //Asign pairs
            for (int i = 0; i < words.Count; i++)
            {
                String word = words[i];
                for (int j = 0; j < word.Length; j++)
                {
                    if (auxTable.ContainsKey(j))
                    {
                        if (j==0)
                        {
                            auxTable[j].Add(new Bigram(j, ' ', word[j], 1.0));
                        }
                        else {
                            auxTable[j].Add(new Bigram(j,word[j-1],word[j],1.0));
                        }
                    }
                    else
                        if (j == 0)
                        {
                        List<Bigram> a = new List<Bigram>();
                        a.Add(new Bigram(j, ' ', word[j], 1.0));
                        auxTable[j] =a;
                        }
                    else
                    {
                        List<Bigram> a = new List<Bigram>();
                        a.Add(new Bigram(j, word[j - 1], word[j], 1.0));
                        auxTable[j] = a;
                    }
                }
            }
            //Assign weights
            foreach (var item in auxTable)
            {
                List<Bigram> bigramas = item.Value;
                List<Bigram> bgSet = new List<Bigram>();
                foreach (var elemento in bigramas)
                {
                    if (!bgSet.Contains(elemento)) {
                        int cuenta = 0;
                        foreach (var aux in bigramas)
                        {
                            if (elemento.Equals(aux))
                            {
                                cuenta++;
                            }
                        }
                        elemento.weight = cuenta;
                        bgSet.Add(elemento);
                    }
                }
                bigramTable[item.Key] = bgSet;
            }
            //Generate binaryStructure, c is consontant and v is vowel
            binaryStructure = new List<string>();
            foreach (var item in lettersByPosition)
            {
                if (item.Key+1<=averageLength) {
                    List<Char> letras = item.Value;
                    int consonantes = 0; int vocales = 0;
                    foreach (Char elemento in letras)
                    {
                        if (EsVocal(elemento)) {
                            vocales += 1;
                        }
                        else
                        {
                            consonantes += 1;
                        }
                    }
                    if (vocales>consonantes)
                    {
                        binaryStructure.Add("v");
                    }
                    else
                    {
                        if (vocales==consonantes)
                        {
                            if (binaryStructure.Count>0)
                            {
                                if (binaryStructure[-1]=="v")
                                {
                                    binaryStructure.Add("c");
                                }
                                else
                                {
                                    binaryStructure.Add("v");
                                }
                            }
                            else
                            {
                                binaryStructure.Add("c");
                            }
                        }
                        else
                        {
                            binaryStructure.Add("c");
                        }
                    }
                }
            }
            /*
            System.Console.WriteLine("Table");
            //Print table
            foreach (var item in bigramTable)
            {
                System.Console.WriteLine(item.Key);
                foreach (var el in item.Value)
                {
                    System.Console.Write(el);
                    System.Console.Write(", ");
                }
                System.Console.WriteLine();
            }*/
        }
        //Get montecarlo method word
        public String MontecarloWord()
        {
            Random rng = new Random();
            String cadena = "";
            for (int i = 0; i <= averageLength; i++)
            {
                List<Char> letras = lettersByPosition[i];
                int generatedIndex = rng.Next(letras.Count);
                cadena += letras[generatedIndex];
            }
            return cadena;
        }
        public String MontecarloWordWithStructure()
        {
            Random rng = new Random();
            String cadena = "";
            for (int i = 0; i <= averageLength; i++)
            {
                List<Char> aux = lettersByPosition[i];
                List<Char> letras = new List<char>();
                if (binaryStructure[i]=="c")
                {
                    foreach (var item in aux)
                    {
                        if (!EsVocal(item))
                        {
                            letras.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in aux)
                    {
                        if (EsVocal(item))
                        {
                            letras.Add(item);
                        }
                    }
                }
                int generatedIndex = rng.Next(letras.Count);
                cadena += letras[generatedIndex];
            }
            return cadena;
        }
        public String WordGenerationUsingBigrams()
        {
            String palabra = "";
            List<Object[]> possibleSolutions = new List<object[]>();
            foreach (var item in bigramTable)
            {
                if (item.Key<=averageLength)
                {
                    //Initial case
                    List<Bigram> bigramas = item.Value;
                    /*
                    Object[] result = GetHighestWeightBigram(bigramas);
                    AuxWordGeneration(((Bigram)result[0]).w1.ToString(), 1,(int)result[1],possibleSolutions);*/
                    foreach (var possibleBigram in bigramas)
                    { 
                        AuxWordGeneration(possibleBigram.w1.ToString(), 0+ 1, possibleBigram.weight, possibleSolutions);
                    }
                }
            }
            //Solucion obtenida de la lista possible solutions
            //System.Console.WriteLine("Posible soluciones: ");
            Double maxFound = 0;
            foreach (var item in possibleSolutions)
            {
                //System.Console.WriteLine(item[0].ToString()+" "+item[1]);
                if ((Double)item[1] > maxFound)
                {
                    maxFound = (Double)item[1];
                    palabra = (String)item[0];
                }
                else if ((Double)item[1] == maxFound)
                {
                    palabra += " y " + (String)item[0];
                }
            }
            return palabra;
        }
        private void AuxWordGeneration(String currentWord,int step, Double currentWeight, List<Object[]> solution)
        {
            if (step+1 <= averageLength)
            {
                //System.Console.WriteLine("FFFF");
                List<Bigram> bigramas = bigramTable[step].FindAll(b1=>b1.w0==currentWord[currentWord.Length-1]);
                foreach (var possibleBigram in bigramas)
                {
                    AuxWordGeneration(currentWord + possibleBigram.w1, step + 1, currentWeight + possibleBigram.weight,solution);
                }
            }
            else
            {
                Object[] sol = new Object[2];
                sol[0] = currentWord;sol[1] = currentWeight;
                solution.Add(sol);
            }

        }
        public String WordGenerationUsingBigramsBS()
        {
            String palabra = "";
            List<Object[]> possibleSolutions = new List<object[]>();
            foreach (var item in bigramTable)
            {
                if (item.Key <= averageLength)
                {
                    //Initial case
                    List<Bigram> bigramas = new List<Bigram>();
                    List<Bigram> aux = item.Value;
                    foreach (var bg in aux)
                    {
                        if (binaryStructure[0]=="c")
                        {
                            if (!EsVocal(bg.w1))
                            {
                                bigramas.Add(bg);
                            }
                        }
                        else
                        {
                            if (EsVocal(bg.w1))
                            {
                                bigramas.Add(bg);
                            }
                        }
                    }
                    if (bigramas.Count==0)
                    {
                        return "Palabra no generada";
                    }
                    /*
                    Object[] result = GetHighestWeightBigram(bigramas);
                    AuxWordGeneration(((Bigram)result[0]).w1.ToString(), 1,(int)result[1],possibleSolutions);*/
                    foreach (var possibleBigram in bigramas)
                    {
                        AuxWordGenerationBS(possibleBigram.w1.ToString(), 0 + 1, possibleBigram.weight, possibleSolutions);
                    }
                }
            }
            //Solucion obtenida de la lista possible solutions
            //System.Console.WriteLine("Posible soluciones: ");
            Double maxFound = 0;
            foreach (var item in possibleSolutions)
            {
                //System.Console.WriteLine(item[0].ToString()+" "+item[1]);
                if ((Double)item[1] > maxFound)
                {
                    maxFound = (Double)item[1];
                    palabra = (String)item[0];
                }
                else if ((Double)item[1] == maxFound)
                {
                    palabra += " y " + (String)item[0];
                }
            }
            return palabra;
        }
        private void AuxWordGenerationBS(String currentWord, int step, Double currentWeight, List<Object[]> solution)
        {
            if (step + 1 <= averageLength)
            {
                List<Bigram> bigramas = new List<Bigram>();
                List<Bigram> aux = bigramTable[step].FindAll(b1=>b1.w0==currentWord[currentWord.Length-1]);
                foreach (var bg in aux)
                {
                    if (binaryStructure[step] == "c")
                    {
                        if (!EsVocal(bg.w1))
                        {
                            bigramas.Add(bg);
                        }
                    }
                    else
                    {
                        if (EsVocal(bg.w1))
                        {
                            bigramas.Add(bg);
                        }
                    }
                }
                if (bigramas.Count==0)
                {
                    return;
                }
                foreach (var possibleBigram in bigramas)
                {
                    AuxWordGenerationBS(currentWord + possibleBigram.w1, step + 1, currentWeight + possibleBigram.weight, solution);
                }
            }
            else
            {
                Object[] sol = new Object[2];
                sol[0] = currentWord; sol[1] = currentWeight;
                solution.Add(sol);
            }

        }
        public String WordGenerationUsingBigramsSequential()
        {
            String palabra = "";
            Bigram bigrama=GetMaxBigramByStep(0);
            palabra += bigrama.w1;
            palabra = AuxWordGenerationSequential(palabra, 1,bigrama.weight);
            return palabra;
        }
        private String AuxWordGenerationSequential(String palabra, int step, Double currentWeight)
        {
            if (step+1<=averageLength)
            {
                Bigram bigrama = GetMaxBigramByStep(step);
                palabra += bigrama.w1;
                return AuxWordGenerationSequential(palabra, step + 1, currentWeight + bigrama.weight);
            }
            else
            {
                return palabra;
            }
        }
        public String WordGenerationUsingBigramsSequentialBS()
        {
            String palabra = "";
            Bigram bigrama = GetMaxBigramByStepBS(0,binaryStructure[0]=="v");
            if (bigrama.w1=='-')
            {
                return "not found";
            }
            palabra += bigrama.w1;
            palabra = AuxWordGenerationSequentialBS(palabra, 1, bigrama.weight);
            return palabra;
        }
        private String AuxWordGenerationSequentialBS(String palabra, int step, Double currentWeight)
        {
            if (step + 1 <= averageLength)
            {
                Bigram bigrama = GetMaxBigramByStepBS(step, binaryStructure[step] == "v");
                if (bigrama.w1 == '-')
                {
                    return "not found";
                }
                palabra += bigrama.w1;
                return AuxWordGenerationSequentialBS(palabra, step + 1, currentWeight + bigrama.weight);
            }
            else
            {
                return palabra;
            }
        }
        private Bigram GetMaxBigramByStep(int step)
        {
            //Get max bigram
            Random rng = new Random();
            Bigram current = bigramTable[step][0];
            foreach (Bigram element in bigramTable[step])
            {
                if (element.weight > current.weight)
                {
                    current = element;
                }
                else
                {
                    if (element.weight == current.weight)
                    {
                        if (rng.Next(10) < 5)
                        {
                            current = element;
                        }
                    }
                }
            }
            return current;
        }
        private Bigram GetMaxBigramByStepBS(int step,bool vocal)
        {
            //Get max bigram
            Random rng = new Random();
            Bigram current = new Bigram(step,'-','-',0.0);
            foreach (Bigram element in bigramTable[step])
            {
                if ((vocal==EsVocal(element.w1))||(!vocal == !EsVocal(element.w1)))
                {
                    if (current.weight<element.weight)
                    {
                        current = element;
                    }
                    else if (current.weight==element.weight)
                    {
                        if (rng.Next(10)<5)
                        {
                            current = element;
                        }
                    }
                }
            }
            return current;
        }
        private Object[] GetHighestWeightBigram(List<Bigram> bigramas)
        {
            Random rng = new Random();
            Object[] result = new object[2];
            Double currentWeight = 0.0;
            foreach (Bigram element in bigramas)
            {
                if (element.weight>currentWeight)
                {
                    currentWeight = element.weight;
                    result[0] = element;result[1] = currentWeight;
                }
                else if (element.weight==currentWeight)
                {
                    if (rng.Next(10)<5)
                    {
                        currentWeight = element.weight;
                        result[0] = element; result[1] = currentWeight;
                    } 
                }
            }
            return result;
        }

        public override string ToString()
        {
            String cadena="Palabras: \n";
            foreach (var word in words)
            {
                cadena += word+" ";
            }
            cadena += "\n Estructura: \n";
            foreach (var item in binaryStructure)
            {
                cadena += item + " ";
            }
            return cadena;
        }
        private Boolean EsVocal(Char letra)
        {
            return ((letra == 'a') | (letra == 'e') | (letra == 'i') | (letra == 'o') | (letra == 'u'));
        }
        public String ShowBS()
        {
            String cadena = "";
            foreach (var item in binaryStructure)
            {
                cadena += item + " ";
            }
            return cadena;
        }
        //Compute levenshtein distance. Coded by Joshua Honig
        public static int LevenshteinDistance(String source, String target)
        {
            var sourceLength = source.Length;
            var targetLength = target.Length;

            var matrix = new int[sourceLength + 1, targetLength + 1];

            // First calculation, if one entry is empty return full length
            if (sourceLength == 0)
                return targetLength;

            if (targetLength == 0)
                return sourceLength;

            // Initialization of matrix with row size sourceLength and columns size targetLength
            for (var i = 0; i <= sourceLength; matrix[i, 0] = i++) { }
            for (var j = 0; j <= targetLength; matrix[0, j] = j++) { }

            // Calculate rows and collumns distances
            for (var i = 1; i <= sourceLength; i++)
            {
                for (var j = 1; j <= targetLength; j++)
                {
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 2; //I changed here 0:1 to 0:2 to use demerau distance

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            // return result
            return matrix[sourceLength, targetLength];
        }
    }
}
