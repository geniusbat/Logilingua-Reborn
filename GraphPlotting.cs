using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logilingua_Reborn
{
    class GraphPlotting
    {
        List<List<int>> distanceMatrix;
        //List<List<int>> similarityMatrix;
        List<List<int>> clustersGenerated;
        List<String> wordList;
        int maxDistanceValue;
        public GraphPlotting(String cadena)
        {
            wordList = DataReader.Read("../../Datos/" + cadena + ".txt");
            distanceMatrix = GetDistanceMatrix(cadena);
            //similarityMatrix = new List<List<int>>();
            //similarityMatrix = GetSimilarityMatrix(distanceMatrix);
            clustersGenerated = DensityBasedClustering(1, 2f);
            Console.WriteLine("RESULT");
            ShowClusterOnConsole();
        }
        private List<List<int>> GetDistanceMatrix(String cadena)
        {
            List<List<int>> matrix = new List<List<int>>();
            List<String> wordList = DataReader.Read("../../Datos/" + cadena + ".txt");
            //Also get max distance
            int maxValue = 0;
            //Rows
            for (int i = 0; i < wordList.Count(); i++)
            {
                List<int> row = new List<int>();
                //Colums
                for (int j = 0; j < wordList.Count(); j++)
                {
                    //This is when the cell is the same word
                    if (i == j)
                    {
                        row.Add(0);
                    }
                    else
                    {
                        int dist = Word.LevenshteinDistance(wordList[i], wordList[j]);
                        row.Add(dist);
                        //Check if higher value
                        if (dist > maxValue)
                        {
                            maxValue = dist;
                        }
                    }
                }
                matrix.Add(row);
            }
            maxDistanceValue = maxValue;
            return matrix;
        }
        private List<List<int>> GetSimilarityMatrix(List<List<int>> distanceMatrix)
        {
            List<List<int>> similarityMatrix = new List<List<int>>();
            //Get highest distance value in the matrix
            int maxValue = maxDistanceValue + 1;
            //Reverse the distance matrix to make the values imply the similarity between words (aka big values big similarity)
            foreach (List<int> row in distanceMatrix)
            {
                List<int> auxRow = new List<int>();
                foreach (int distance in row)
                {
                    auxRow.Add(maxValue - distance);
                }
                similarityMatrix.Add(auxRow);
            }
            return similarityMatrix;
        }
        private List<List<int>> DensityBasedClustering(int minPoints,float eps)
        {
            Console.WriteLine(distanceMatrix[0][1]);
            List<List<int>> clusters = new List<List<int>>();
            List<int> visited = new List<int>();
            List<int> noisePoints = new List<int>();
            for (int i = 0; i < wordList.Count(); i++)
            {
                if (!visited.Contains(i))
                {
                    visited.Add(i);
                    //Get neighbors
                    List<int> neighbors = new List<int>();
                    for (int j = 0; j < wordList.Count(); j++)
                    {
                        if (i!=j)
                        {
                            if (distanceMatrix[i][j]<=eps)
                            {
                                neighbors.Add(j);
                            }
                        }
                    }
                    /*
                    if (wordList[i]=="mother")
                    {
                        PrintList(neighbors);
                    }*/
                    //Make core point if necessary
                    if (neighbors.Count()>=minPoints)
                    {
                        List<int> community = new List<int>();
                        community.Add(i);
                        //Expand community
                        for (int h = 0; h < neighbors.Count(); h++)
                        {
                            int item = neighbors[h];
                            if (!visited.Contains(item))
                            {
                                visited.Add(item);
                                if (distanceMatrix[i][item]<=eps)
                                {
                                    List<int> aux = new List<int>();
                                    //Get neighbors of item
                                    for (int j = 0; j < wordList.Count(); j++)
                                    {
                                        if (item != j)
                                        {
                                            if (distanceMatrix[item][j] <= eps)
                                            {
                                                aux.Add(j);
                                            }
                                        }
                                    }
                                    if (aux.Count() >= eps)
                                    {
                                        neighbors = neighbors.Union(aux).ToList();
                                        h = 0;
                                    }
                                }
                                if (!PointIsInAnyCluster(item, clusters))
                                {
                                    community.Add(item);
                                }
                            }
                        }
                        clusters.Add(community);
                    }
                    else
                    {
                        noisePoints.Add(i);
                        List<int> aux = new List<int>();
                        aux.Add(i);
                        clusters.Add(aux);
                    }
                }
            }
            return clusters;
        }

        private bool PointIsInAnyCluster(int point,List<List<int>> clusters)
        {
            foreach (List<int> c in clusters)
            {
                if (c.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }

        private float DistanceBetweenCommunities(List<int> communityA, List<int> communityB)
        {
            float ret = 0f;
            foreach (int a in communityA)
            {
                foreach (int b in communityB)
                {
                    ret += distanceMatrix[a][b];
                }
            }
            return ret;
        }
        private void ShowClusterOnConsole()
        {
            foreach (List<int> cluster in clustersGenerated)
            {
                foreach (int id in cluster)
                {
                    Console.Write(wordList[id] + "; ");
                }
                Console.WriteLine("");
            }
        }
        private void PrintCluster(List<List<int>>clusterIn)
        {
            foreach (List<int> cluster in clusterIn)
            {
                foreach (int id in cluster)
                {
                    Console.Write(wordList[id] + "; ");
                }
                Console.WriteLine("");
            }
        }
        private void PrintList(List<int> lista)
        {
            foreach (var item in lista)
            {
                Console.Write(item + "; ");
            }
            Console.WriteLine("");
        }

        private Dictionary<int, List<List<int>>> HierarchycalClustering()
        {
            int iteration = 0;
            Dictionary<int, List<List<int>>> clusters = new Dictionary<int, List<List<int>>>();
            List<List<int>> generation = new List<List<int>>();
            //Initial situation
            for (int i = 0; i < wordList.Count(); i++)
            {
                List<int> l = new List<int>();
                l.Add(i);
                generation.Add(l);
            }
            clusters[0] = generation;
            //Iterate
            int maxIterations = 10;
            while (iteration<maxIterations) 
            {
                //Get previous generation to cluster
                generation = new List<List<int>>(clusters[clusters.Count() - 1]);
                //Break if all elements in one cluster
                if (generation.Count()==1)
                {
                    break;
                }
                //Continue if else
                List<List<int>> visited = new List<List<int>>();
                for (int i = 0; i < generation.Count(); i++)
                { 
                    List<int> comA = generation[i];
                    visited.Add(comA);
                    int minDist = 0;
                    bool firstTime = true;
                    List<int> bestCom = new List<int>();
                    //Look for best option
                    for (int j = 0; j < generation.Count(); j++)
                    {
                        if (i!=j)
                        {
                            List<int> comB = generation[j];
                            if (!visited.Contains(comB)) //Make sure cluster j wasn't visited
                            {
                                int distance = GetDistanceBetweenCommunities(comA, comB);
                                if ((distance < minDist) || (firstTime))
                                {
                                    firstTime = false;
                                    minDist = distance;
                                    bestCom = comB;
                                }
                            }
                        }
                    }
                    //Make sure that A's best option is B's best option too
                    if (bestCom.Count()!=0)
                    {
                        List<int> aux = new List<int>();
                        firstTime = true;
                        for (int j = 0; j < generation.Count(); j++)
                        {
                            List<int> comC = generation[j];
                            if (!visited.Contains(comC)) //Make sure cluster j wasn't visited
                            {
                                int distance = GetDistanceBetweenCommunities(bestCom, comC);
                                if ((distance < minDist) || (firstTime))
                                {
                                    firstTime = false;
                                    minDist = distance;
                                    aux = comC;
                                }
                            }
                        }
                        if (aux==comA)
                        {
                            //Add B to visited if so
                            visited.Add(bestCom);
                        }
                    }
                }
                //Add to dictionary
                clusters[iteration] = generation;
                //Increase iteration
                iteration += 1;
            }
            return clusters;
        }
        //Distance is measured as the average of distances
        private int GetDistanceBetweenCommunities(List<int> comA,List<int> comB)
        {
            int ret = 0;
            foreach (int wordA in comA)
            {
                foreach (int wordB in comB)
                {
                    ret += distanceMatrix[wordA][wordB];
                }
            }
            ret /= wordList.Count();
            return ret;
        }
    }
}
