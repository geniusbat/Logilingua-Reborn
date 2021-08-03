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
        List<List<int>> similarityMatrix;
        List<String> wordList;
        List<List<int>> communitiesGenerated; //List of lists where each integer is the id of wordList
        //Remember this is the pure max distance, not added by one to generate similarity matrix
        int maxDistanceValue;
        //Constructor
        public GraphPlotting(String cadena)
        {
            wordList = DataReader.Read("../../Datos/"+cadena+".txt");
            distanceMatrix = GetDistanceMatrix(cadena);
            similarityMatrix = new List<List<int>>();
            /*
            List<int> aux = new List<int>();
            aux.Add(0); aux.Add(3); aux.Add(4); aux.Add(2); similarityMatrix.Add(aux);
            List<int> aux0 = new List<int>();
            aux0.Add(3); aux0.Add(0); aux0.Add(2); aux0.Add(1); similarityMatrix.Add(aux0);
            List<int> aux1 = new List<int>();
            aux1.Add(4); aux1.Add(2); aux1.Add(0); aux1.Add(1); similarityMatrix.Add(aux1);
            List<int> au2 = new List<int>();
            au2.Add(2); au2.Add(1); au2.Add(1); au2.Add(0); similarityMatrix.Add(au2);
            Console.WriteLine("Similarity Matrix: ");
            PrintMatrix(similarityMatrix,false);
            Console.WriteLine(similarityMatrix[0][1]);
            */
            similarityMatrix = GetSimilarityMatrix(distanceMatrix,maxDistanceValue);
            //PrintMatrix(distanceMatrix,true);
            //PrintMatrix(similarityMatrix,false);
            foreach (var item in wordList)
            {
                Console.Write(item + "; ");
            }
            /*
            //Automatic weights
            Console.WriteLine("True beginning:");
            ClusteringAutomaticNodeWeight(true,0);
            Console.WriteLine(communitiesGenerated.Count()+" were found");
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 2");
            ClusteringAutomaticNodeWeight(false, 2);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 5");
            ClusteringAutomaticNodeWeight(false, 5);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 5% of the wordList size");
            ClusteringAutomaticNodeWeight(false, wordList.Count()/5);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            */
            //Manual weights
            /*
            float weight = 1;
            Console.WriteLine("\nTrue beginning:");
            ClusteringManualWeight(true, 0,weight);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 1");
            ClusteringManualWeight(false, 1,weight);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 4");
            ClusteringManualWeight(false, 4,weight);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 5% of the wordList size");
            ClusteringManualWeight(false, wordList.Count() / 5,weight);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            */
            //Manual weights, corrected
            /*
            float weight = 1f;
            Console.WriteLine("\nTrue beginning:");
            ClusteringManualWeightCorrected(true, 0, weight);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            Console.WriteLine("Rating: " + ClusteringRating());
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 1");
            ClusteringManualWeightCorrected(false, 1, weight);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            Console.WriteLine("Rating: " + ClusteringRating());
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 4");
            ClusteringManualWeightCorrected(false, 4, weight);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            Console.WriteLine("Rating: " + ClusteringRating());
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            Console.WriteLine("With max community size at 5% of the wordList size");
            ClusteringManualWeightCorrected(false, wordList.Count() / 5, weight);
            Console.WriteLine(communitiesGenerated.Count() + " were found");
            Console.WriteLine("Rating: " + ClusteringRating());
            //PrintMatrix(communitiesGenerated,false);
            ShowClusterOnConsole();
            */
            EasyClustering(1);
            ShowClusterOnConsole();
            /*
            float weight = 0.5f;
            int generations = 100;
            bool firstTime = true;
            float inc = 0.5f;
            float bestWeight = 0.2f;
            float bestRating = 0;
            List<List<int>> bestCommunityGenerated = new List<List<int>>();
            //
            Console.WriteLine("\nMANUAL WEIGHT, CORRECTED:");
            for (int i = 0; i < generations; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j==0)
                    {
                        ClusteringManualWeightCorrected(true, 0, weight);
                        float rt = ClusteringRating();
                        //Console.WriteLine("True beginning: " + communitiesGenerated.Count() + " communities were found"
                        //+" with rating: " + rt);
                        if (rt>bestRating)
                        {
                            bestWeight = weight;
                            bestRating = rt;
                            bestCommunityGenerated = communitiesGenerated;
                        }
                    }
                    else if (j == 1)
                    {
                        ClusteringManualWeightCorrected(false, 1, weight);
                        float rt = ClusteringRating();
                        //Console.WriteLine("Max initial community size 1: " + communitiesGenerated.Count() + " communities were found"
                        //    + " with rating: " + rt);
                        if ((rt > bestRating)||(firstTime))
                        {
                            bestWeight = weight;
                            bestRating = rt;
                            bestCommunityGenerated = communitiesGenerated;
                            firstTime = false;
                        }
                    }
                    else if (j ==2)
                    {
                        ClusteringManualWeightCorrected(false, 2, weight);
                        float rt = ClusteringRating();
                        //Console.WriteLine("Max initial community size 2: " + communitiesGenerated.Count() + " communities were found"
                        //+" with rating: " + rt);
                        if (rt > bestRating)
                        {
                            bestWeight = weight;
                            bestRating = rt;
                            bestCommunityGenerated = communitiesGenerated;
                        }
                    }
                    else if (j == 3)
                    {
                        ClusteringManualWeightCorrected(false, 5, weight);
                        float rt = ClusteringRating();
                        //Console.WriteLine("Max initial community size 5: " + communitiesGenerated.Count() + " communities were found"
                        //+" with rating: " + rt);
                        if (rt > bestRating)
                        {
                            bestWeight = weight;
                            bestRating = rt;
                            bestCommunityGenerated = communitiesGenerated;
                        }
                    }
                }
                weight += inc;
            }
            communitiesGenerated = bestCommunityGenerated;
            Console.WriteLine("The best community has size "+communitiesGenerated.Count()+" and rating "+bestRating+" with weight "+bestWeight);
            ShowClusterOnConsole();
            Console.WriteLine("\nAUTOMATIC WEIGHT:");
            weight = 1f;
            generations = 100;
            firstTime = true;
            inc = 0.5f;
            bestWeight = 0.2f;
            bestRating = 0;
            bestCommunityGenerated = new List<List<int>>();
            for (int i = 0; i < generations; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                    {
                        ClusteringAutomaticNodeWeight(true, 0);
                        float rt = ClusteringRating();
                        //Console.WriteLine("True beginning: " + communitiesGenerated.Count() + " communities were found"
                        //+" with rating: " + rt);
                        if (rt > bestRating)
                        {
                            bestWeight = weight;
                            bestRating = rt;
                            bestCommunityGenerated = communitiesGenerated;
                        }
                    }
                    else if (j == 1)
                    {
                        ClusteringAutomaticNodeWeight(false, 1);
                        float rt = ClusteringRating();
                        //Console.WriteLine("Max initial community size 1: " + communitiesGenerated.Count() + " communities were found"
                        //    + " with rating: " + rt);
                        if ((rt > bestRating) || (firstTime))
                        {
                            bestWeight = weight;
                            bestRating = rt;
                            bestCommunityGenerated = communitiesGenerated;
                            firstTime = false;
                        }
                    }
                    else if (j == 2)
                    {
                        ClusteringAutomaticNodeWeight(false, 2);
                        float rt = ClusteringRating();
                        //Console.WriteLine("Max initial community size 2: " + communitiesGenerated.Count() + " communities were found"
                        //+" with rating: " + rt);
                        if (rt > bestRating)
                        {
                            bestWeight = weight;
                            bestRating = rt;
                            bestCommunityGenerated = communitiesGenerated;
                        }
                    }
                    else if (j == 3)
                    {
                        ClusteringAutomaticNodeWeight(false, 5);
                        float rt = ClusteringRating();
                        //Console.WriteLine("Max initial community size 5: " + communitiesGenerated.Count() + " communities were found"
                        //+" with rating: " + rt);
                        if (rt > bestRating)
                        {
                            bestWeight = weight;
                            bestRating = rt;
                            bestCommunityGenerated = communitiesGenerated;
                        }
                    }
                }
                weight += inc;
            }
            communitiesGenerated = bestCommunityGenerated;
            Console.WriteLine("The best community has size " + communitiesGenerated.Count() + " and rating " + bestRating );
            ShowClusterOnConsole();
            */
        }
private List<List<int>> GetDistanceMatrix(String cadena)
{
    List<List<int>> matrix = new List<List<int>>();
    List<String> wordList = DataReader.Read("../../Datos/"+cadena+".txt");
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
            if (i==j)
            {
                row.Add(0);
            }
            else
            {
                int dist = Word.LevenshteinDistance(wordList[i], wordList[j]);
                row.Add(dist);
                //Check if higher value
                if (dist>maxValue)
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
    int maxValue = distanceMatrix[0][0];
    foreach (List<int> row in distanceMatrix)
    {
        int maxDistance = row.Max();
        if (maxDistance > maxValue)
        {
            maxValue = maxDistance;
        }
    }
    maxValue += 1;
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
private List<List<int>> GetSimilarityMatrix(List<List<int>> distanceMatrix, int maxValue)
{
    maxValue += 1;
    List<List<int>> similarityMatrix = new List<List<int>>();
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
public void PrintMatrix(List<List<int>> matrix,bool stopAtRow)
{
    foreach (List<int> row in matrix)
    {
        foreach (int dist in row)
        {
            Console.Write(dist+"; ");
        }
        Console.WriteLine("");
        if (stopAtRow)
        {
            break;
        }
    }
}
/*  
 *  TODO explain better
 This algorithm was based on the: Weighted graph clustering for community detection of large social
 networks, by the  National Grand Fundamental Research 973 Program of China under Grant No.2013CB329606;
 National Natural Science Foundation of China under Grant No.91124002; National Science and Technology Support
 Program of China under Grant No.2013BAH43F00-01; Chinese Universities Scientific Fund(BUPT2014RC0701)
 It is an agglomerative algorithm, it starts with all words in their own communities, each one having a density equal
 to the sum of weights of node, 2 options are proposed:
    a) Density is the sum of weights of edges inside the community divided by the number of nodes in it.
    b) All nodes have the same importance, that will be fed manually.
 Then we check for possible additions to the community (this happens when the ratio of the sum of weights of the edges between the communities is higher or equal to the sum of densities of the communities, this measure is attractiveness).
 The algorithm stops when no more changes are done or there is only one community left.
TODO, rn the code looks for the first cluster to mix, not the one with highest atractiveness
 */
        private void EasyClustering(int weight)
        {
            //Assign each word to its own community
            List<List<int>> clustering = new List<List<int>>();
            for (int i = 0; i < wordList.Count(); i++)
            {
                List<int> newList = new List<int>();
                newList.Add(i);
                clustering.Add(newList);
            }
            //Go through communities and add merge them if all the distances of words between communities are under the weight
            for (int i = 0; i < clustering.Count(); i++)
            {
                for (int j = 0; j < clustering.Count(); j++)
                {
                    if (i != j)
                    {
                        List<int> communityA = clustering[i];
                        List<int> communityB = clustering[j];
                        bool merge = true;
                        foreach (int posA in communityA)
                        {
                            foreach (int posB in communityB)
                            {
                                if (distanceMatrix[posA][posB] > weight)
                                {
                                    merge = false;
                                    break;
                                }
                            }
                            if (!merge)
                            {
                                break;
                            }
                        }
                        //Communities can be merged
                        if (merge)
                        {
                            communityA.AddRange(communityB);
                        }
                    }
                }
            }
            Console.WriteLine("ST");
            communitiesGenerated = clustering;
        }
            private void TestClustering()
        {
            List<List<int>> clustering = new List<List<int>>();
            List<int> aux = new List<int>();
            aux.Add(1);clustering.Add(aux); 
            List<int> aux0 = new List<int>();
            aux0.Add(2); clustering.Add(aux0);
            List<int> aux1 = new List<int>();
            aux1.Add(3); clustering.Add(aux1);
            List<int> aux2 = new List<int>();
            aux2.Add(4); clustering.Add(aux2);
            clustering = AuxClusteringAutomaticNodeWeight(clustering);
            communitiesGenerated = clustering;
        }
        private void ClusteringAutomaticNodeWeight(bool trueBeginning, int maxInitialSize)
        {
            List<List<int>> clustering = new List<List<int>>();
            //Add each word as its own community
            if (trueBeginning)
            {
                for (int i = 0; i < wordList.Count(); i++)
                {
                    List<int> newList = new List<int>();
                    newList.Add(i);
                    clustering.Add(newList);
                }
            }
            //Add words to communities but assign the same words to the same community up to a max of maxInitialSize 
            //This is because as communities grow it is harder to add new words
            else
            {
                //Dictionary is used to quickly assign words that are the same into the same cluster
                Dictionary<String, int> dic = new Dictionary<string, int>();
                for (int i = 0; i < wordList.Count(); i++)
                {
                    String wordAux = wordList[i];
                    if (dic.ContainsKey(wordAux))
                    {
                        if (clustering[dic[wordAux]].Count() < maxInitialSize)
                        {
                            clustering[dic[wordAux]].Add(i);
                        }
                    }
                    else
                    {
                        List<int> newList = new List<int>();
                        newList.Add(i);
                        clustering.Add(newList);
                        dic.Add(wordAux, clustering.Count() - 1);
                    }
                }
            }
            //Console.WriteLine("Initial clustering: ");
            //PrintMatrix(clustering, false);
            clustering = AuxClusteringAutomaticNodeWeight(clustering);
            communitiesGenerated = clustering;
        }
        private List<List<int>> AuxClusteringAutomaticNodeWeightOLD(List<List<int>> clustering)
        {
            //Iterate through communities and check if it would like change
            for (int i = 0; i < clustering.Count(); i++)
            {
                //Stop if only one community remeaning
                if (clustering.Count()==1)
                {
                    break;
                }
                //Get community and density of A
                List<int> communityA = clustering[i];
                float densityA = GetDensityOfCommunity(communityA);
                //Go through all other communities until one wants to change, then break and start again
                for (int j = 0; j < clustering.Count(); j++)
                {
                    //Only operate if different communities
                    if (i != j)
                    {
                        //Get community B info
                        List<int> communityB = clustering[j];
                        float densityB = GetDensityOfCommunity(communityB);
                        float attractiveness = ComputeAttractiveness(communityA, communityB);
                        //Check if attractiveness is higher than necessary threshold
                        //Console.WriteLine("Attract: " + attractiveness);
                        float denst = densityA + densityB;
                        //Console.WriteLine("Total weight: " + denst);
                        //Console.Write("communityA: ");
                        //PrintList(communityA);
                        //Console.Write("communityB: ");
                        //PrintList(communityB);
                        if (attractiveness >= densityA+densityB)
                        {
                            //PrintList(communityA);
                            communityA = communityA.Concat(communityB).ToList();
                            //Console.Write("Final communityA: ");
                            //PrintList(communityA);
                            //Update clustering and reset indexes to start again
                            clustering[i] = communityA;
                            clustering.RemoveAt(j);
                            i = 0;
                            j = 0;
                            break;
                        }
                    }
                }
            }
            return clustering;
        }
        private List<List<int>> AuxClusteringAutomaticNodeWeight(List<List<int>> clustering)
        {
            //Iterate through communities and check if it would like change
            for (int i = 0; i < clustering.Count(); i++)
            {
                //Stop if only one community remeaning
                if (clustering.Count() == 1)
                {
                    break;
                }
                //Get community and density of A
                List<int> communityA = clustering[i];
                float densityA = GetDensityOfCommunity(communityA);
                //Initialize the community with most attractiveness
                List<int> communityB = new List<int>();
                float attractiveness = 0;
                int communityPos = new int();
                //Go through all other communities to get the one with highest attractiveness
                for (int j = 0; j < clustering.Count(); j++)
                {
                    //Only operate if different communities
                    if (i != j)
                    {
                        //Get info on the next community
                        List<int> currCommunity = clustering[j];
                        float currAttractiveness = ComputeAttractiveness(communityA, currCommunity);
                        //Check if it is a better option than the previous community
                        if (currAttractiveness>attractiveness)
                        {
                            communityB = currCommunity;
                            attractiveness = currAttractiveness;
                            communityPos = j;
                        }
                    }
                }
                //Now communityB and attractiveness give the cluster with highest attractiveness for communityA (i)
                //Check if attractiveness is higher than necessary threshold
                float densityB = GetDensityOfCommunity(communityB);
                if (attractiveness >= densityA + densityB)
                {
                    communityA = communityA.Concat(communityB).ToList();
                    //Update clustering and reset index to start again
                    clustering[i] = communityA;
                    clustering.RemoveAt(communityPos);
                    i = 0;
                }
            }
            return clustering;
        }
        private void ClusteringManualWeight(bool trueBeginning, int maxInitialSize, float nodeWeight)
        {
            List<List<int>> clustering = new List<List<int>>();
            //Add each word as its own community
            if (trueBeginning)
            {
                for (int i = 0; i < wordList.Count(); i++)
                {
                    List<int> newList = new List<int>();
                    newList.Add(i);
                    clustering.Add(newList);
                }
            }
            //Add words to communities but assign the same words to the same community up to a max of maxInitialSize 
            //This is because as communities grow it is harder to add new words
            else
            {
                //Dictionary is used to quickly assign words that are the same into the same cluster
                Dictionary<String, int> dic = new Dictionary<string, int>();
                for (int i = 0; i < wordList.Count(); i++)
                {
                    String wordAux = wordList[i];
                    if (dic.ContainsKey(wordAux))
                    {
                        if (clustering[dic[wordAux]].Count() < maxInitialSize)
                        {
                            clustering[dic[wordAux]].Add(i);
                        }
                    }
                    else
                    {
                        List<int> newList = new List<int>();
                        newList.Add(i);
                        clustering.Add(newList);
                        dic.Add(wordAux, clustering.Count() - 1);
                    }
                }
            }
            //Console.WriteLine("Initial clustering: ");
            //PrintMatrix(clustering, false);
            clustering = AuxClusteringManualWeight(clustering,nodeWeight);
            communitiesGenerated = clustering;
        }
        private List<List<int>> AuxClusteringManualWeight(List<List<int>> clustering, float nodeWeight)
        {
            //Iterate through communities and check if it would like change
            for (int i = 0; i < clustering.Count(); i++)
            {
                //Stop if only one community remeaning
                if (clustering.Count() == 1)
                {
                    break;
                }
                //Get community and density of A
                List<int> communityA = clustering[i];
                float densityA = communityA.Count() * nodeWeight;
                //Go through all other communities until one wants to change, then break and start again
                for (int j = 0; j < clustering.Count(); j++)
                {
                    //Only operate if different communities
                    if (i != j)
                    {
                        //Get community B info
                        List<int> communityB = clustering[j];
                        float densityB = communityB.Count() * nodeWeight;
                        float attractiveness = ComputeAttractiveness(communityA, communityB);
                        //Check if attractiveness is higher than necessary threshold
                        //Console.WriteLine("Attract: " + attractiveness);
                        float denst = densityA + densityB;
                        //Console.WriteLine("Total weight: " + denst);
                        //Console.Write("communityA: ");
                        //PrintList(communityA);
                        //Console.Write("communityB: ");
                        //PrintList(communityB);
                        if (attractiveness >= densityA + densityB)
                        {
                            //PrintList(communityA);
                            communityA = communityA.Concat(communityB).ToList();
                            //Console.Write("Final communityA: ");
                            //PrintList(communityA);
                            //Update clustering and reset indexes to start again
                            clustering[i] = communityA;
                            clustering.RemoveAt(j);
                            i = 0;
                            j = 0;
                            break;
                        }
                    }
                }
            }
            return clustering;
        }
        private void ClusteringManualWeightCorrected(bool trueBeginning, int maxInitialSize, float nodeWeight)
        {
            List<List<int>> clustering = new List<List<int>>();
            //Add each word as its own community
            if (trueBeginning)
            {
                for (int i = 0; i < wordList.Count(); i++)
                {
                    List<int> newList = new List<int>();
                    newList.Add(i);
                    clustering.Add(newList);
                }
            }
            //Add words to communities but assign the same words to the same community up to a max of maxInitialSize 
            //This is because as communities grow it is harder to add new words
            else
            {
                //Dictionary is used to quickly assign words that are the same into the same cluster
                Dictionary<String, int> dic = new Dictionary<string, int>();
                for (int i = 0; i < wordList.Count(); i++)
                {
                    String wordAux = wordList[i];
                    if (dic.ContainsKey(wordAux))
                    {
                        if (clustering[dic[wordAux]].Count() < maxInitialSize)
                        {
                            clustering[dic[wordAux]].Add(i);
                        }
                    }
                    else
                    {
                        List<int> newList = new List<int>();
                        newList.Add(i);
                        clustering.Add(newList);
                        dic.Add(wordAux, clustering.Count() - 1);
                    }
                }
            }
            //Console.WriteLine("Initial clustering: ");
            //PrintMatrix(clustering, false);
            clustering = AuxClusteringManualWeightCorrected(clustering, nodeWeight);
            communitiesGenerated = clustering;
        }
        private List<List<int>> AuxClusteringManualWeightCorrected(List<List<int>> clustering, float nodeWeight)
        {
            //Iterate through communities and check if it would like change
            for (int i = 0; i < clustering.Count(); i++)
            {
                //Stop if only one community remeaning
                if (clustering.Count() == 1)
                {
                    break;
                }
                //Get community and density of A
                List<int> communityA = clustering[i];
                float densityA = communityA.Count() * nodeWeight;
                //Go through all other communities until one wants to change, then break and start again
                for (int j = 0; j < clustering.Count(); j++)
                {
                    //Only operate if different communities
                    if (i != j)
                    {
                        //Get community B info
                        List<int> communityB = clustering[j];
                        float densityB = communityB.Count() * nodeWeight;
                        float attractiveness = ComputeAttractiveness(communityA, communityB);
                        //Check if attractiveness is higher than necessary threshold
                        //Console.WriteLine("Attract: " + attractiveness);
                        float denst = densityA + densityB;
                        if (attractiveness >= densityA + densityB)
                        {
                            //Check if A is also the best option for B
                            float att = 0f;
                            List<int> comm = communityA;
                            for (int h = 0; h < clustering.Count(); h++)
                            {
                                if (h!=j)
                                {
                                    List<int> curCom = clustering[h];
                                    float curAtt = ComputeAttractiveness(communityB, curCom);
                                    if (curAtt>att)
                                    {
                                        att = curAtt;
                                        comm = curCom;
                                    }
                                }
                            }
                            //Only merge communities if A is the best option for B
                            if (comm.Equals(communityA)) { 
                                communityA = communityA.Concat(communityB).ToList();
                                //Update clustering and reset indexes to start again
                                clustering[i] = communityA;
                                clustering.RemoveAt(j);
                                i = 0;
                                j = 0;
                                break;
                            }
                        }
                    }
                }
            }
            return clustering;
        }
        private float ComputeAttractiveness(List<int> communityA, List<int> communityB)
        {
            float attractiveness = 0f;
            for (int i = 0; i < communityA.Count(); i++)
            {
                for (int j = 0; j < communityB.Count(); j++)
                {
                    int celli = communityA[i];
                    int cellj = communityB[j];
                    attractiveness += similarityMatrix[celli][cellj];
                }
            }
            attractiveness = attractiveness / (communityA.Count() * communityB.Count());
            return attractiveness;
        }
        private float GetDensityOfCommunity(List<int> community)
        {
            float sum = 0f;
            //Only try to do the sum if there are at least 2 or more nodes inside community
            if (community.Count() != 1)
            {
                for (int i = 0; i < community.Count(); i++)
                {
                    for (int j = 0; j < community.Count(); j++)
                    {
                        //Only sum if nodes are different
                        if (i != j)
                        {
                            sum += similarityMatrix[i][j];
                        }
                    }
                }
            }
            sum = sum / community.Count();
            return sum;
        }
        private void PrintList(List<int> lista)
        {
            foreach (var item in lista)
            {
                Console.Write(item + "; ");
            }
            Console.WriteLine("");
        }
        private void ShowClusterOnConsole()
        {
            foreach (List<int> cluster in communitiesGenerated)
            {
                foreach (int id in cluster)
                {
                    Console.Write(wordList[id] + "; ");
                }
                Console.WriteLine("");
            }
        }
        private float ClusteringRating()
        {
            float ret = 0f;
            for (int i = 0; i < communitiesGenerated.Count(); i++)
            {
                List<int> communityA = communitiesGenerated[i];
                float weightInside = ComputeCommunityEdgesTotalWeight(communityA);
                float totalWeightOutside = 0f;
                for (int j = 0; j < communitiesGenerated.Count(); j++)
                {
                    if (i!=j)
                    {
                        List<int> communityB = communitiesGenerated[j];
                        float weightOutside = ComputeAttractiveness(communityA, communityB)*(communityA.Count()*communityB.Count());
                        totalWeightOutside += weightOutside;
                    }
                }
                ret = ret + ((weightInside/communityA.Count()-(totalWeightOutside)));
            }
            ret /= 2;
            ret += communitiesGenerated.Count() * 20;
            return ret;
        }
        private float ComputeCommunityEdgesTotalWeight(List<int> communityA)
        {
            float ret = 0f;
            for (int i = 0; i < communityA.Count(); i++)
            {
                for (int j = 0; j < communityA.Count(); j++)
                {
                    if (i!=j)
                    {
                        ret += similarityMatrix[i][j];
                    }
                }
            }
            //Divide by 2 as we compute weights twice
            ret /= 2;
            return ret;
        }
    }
}
