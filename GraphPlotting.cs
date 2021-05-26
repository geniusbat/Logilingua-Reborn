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
            clustersGenerated = DensityBasedClustering(4, 3f);

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
            List<int> corePoints = new List<int>();
            List<int> otherPoints = new List<int>();
            //Get core points
            for (int i = 0; i < wordList.Count(); i++)
            {
                int curPoints = 0;
                //I is the tested potential core point
                for (int j = 0; j < wordList.Count(); j++)
                {
                    if (i!=j)
                    {
                        //Check if j is within distance eps
                        if (distanceMatrix[i][j]<=eps)
                        {
                            curPoints += 1;
                        }
                    }
                }
                //Check if the point can be a core point
                if (curPoints>=minPoints)
                {
                    corePoints.Add(i);
                }
                else
                {
                    otherPoints.Add(i);
                }
            }

            var clusters = new List<List<int>>();
            //Cluster core points
            List<int> alreadyClustered = new List<int>();
            foreach (int pointA in corePoints)
            {
                List<int> community = new List<int>();
                community.Add(pointA);
                alreadyClustered.Add(pointA);
                foreach (int pointB in corePoints)
                {
                    if ((pointA!=pointB)&&(!alreadyClustered.Contains(pointB))) {
                        if (distanceMatrix[pointA][pointB] <= eps)
                        {
                            community.Add(pointB);
                            alreadyClustered.Add(pointB);
                        }
                    }
                }
                clusters.Add(community);
            }
            //PrintList(corePoints);
            //PrintList(otherPoints);
            //Print current clusters
            //PrintCluster(clusters);
            //Cluster all other points, basically check if leftover points are noise or border points
            foreach (int point in otherPoints)
            {
                int nearbyCorePoint = distanceMatrix[point][0];
                //Check if near another core point
                foreach (int corePoint in corePoints)
                {
                    int dist = distanceMatrix[point][corePoint];
                    if (dist<distanceMatrix[point][nearbyCorePoint])
                    {
                        nearbyCorePoint = corePoint;
                    }
                }
                //Assign to nearby corepoint if under eps
                if (distanceMatrix[point][nearbyCorePoint]<=eps)
                {
                    //Get cluster that nearbyCorePoint is from
                    foreach (List<int> comm in clusters)
                    {
                        if (comm.Contains(nearbyCorePoint))
                        {
                            comm.Add(point);
                            break;
                        }
                    }
                }
                else
                {
                    List<int> com = new List<int>();
                    com.Add(point);
                    clusters.Add(com);
                }
            }
            return clusters;
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
    }
}
