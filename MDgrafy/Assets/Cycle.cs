using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDgrafy.Assets
{
    public static class Cycle
    {
        private static List<Vertex> vertexes;
        private static List<Edge> edges;

        public static List<Vertex> Vertexes { get { return vertexes; } set { vertexes = value; } }
        public static List<Edge> Edges { get { return edges; } set { edges = value; } }
        public static string ShowCycles3()
        {
            StringBuilder sb = new StringBuilder();

            var list = new List<List<int>>();

            for (int i = 0; i < Edge.Connections.Count(); i++)
            {
                list.Add(new List<int> { Edge.Connections[i][0], Edge.Connections[i][1] });
                list.Add(new List<int> { Edge.Connections[i][1], Edge.Connections[i][0] });
            }

            for (int i = 0; i < list.Count(); i++)
            {
                sb.Append($"{i} - ");
                for (int j = 0; j < list[i].Count(); j++)
                {
                    sb.Append($"{list[i][j]} ");
                }
                sb.Append("\n");
            }

            sb.Append("\n"); sb.Append("\n");

            var results = new List<List<int>>();

            for (int i = 0; i < list.Count(); i++)
            {
                var temp = list.Where(x => x[1] == list[i][0]).ToList();
                if(temp.Count >= 2)
                {
                    for (int j = 0; j < temp.Count(); j++)
                    {
                        for (int k = 1; k < temp.Count(); k++)
                        {
                            var temp2 = list.Where(x => x[0] == temp[j][0] && x[1] == temp[k][0] && temp[k][0] != temp[j][0]).ToList();
                            if (temp2.Count() >= 1)
                            {
                                var tempList = new List<int>() { list[i][0], temp[j][0], temp[k][0] };
                                tempList.Sort();

                                bool toAdd = true;

                                for (int l = 0; l < results.Count(); l++)
                                {
                                    var resList = results[l];
                                    resList.Sort();
                                    if(resList.SequenceEqual(tempList))
                                    {
                                        toAdd = false;
                                        break;
                                    }
                                }

                                if(toAdd) results.Add(new List<int> { list[i][0], temp[j][0], temp[k][0] });
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < results.Count(); i++)
            {
                for (int j = 0; j < results[i].Count(); j++)
                {
                    sb.Append($"{results[i][j] }");
                }
                sb.Append("\n");
            }

            sb.Append("\n"); sb.Append("\n");

            for (int i = 0; i < Edge.Connections.Count(); i++)
            {
                sb.Append($"{i} - ");
                for (int j = 0; j < Edge.Connections[i].Count() - 1; j++)
                {
                    sb.Append($"{Edge.Connections[i][j]} ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

    }
}
