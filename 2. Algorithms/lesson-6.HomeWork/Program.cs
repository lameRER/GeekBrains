using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace lesson_6.HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var lVertex = new List<Vertex>();
            var graph = new Graph();

            const int n = 7;
            
            for (var i = 1; i <= n; i++)
            {
                lVertex.Add(new Vertex(i));
            }

            for (var i = 0; i < n; i++)
            {
                graph.AddVertex(lVertex[i]);
            }
            
            Graph.AddEdge(lVertex[0],lVertex[1], 2);
            Graph.AddEdge(lVertex[0],lVertex[2], 8);
            Graph.AddEdge(lVertex[2],lVertex[3], 9);
            Graph.AddEdge(lVertex[1],lVertex[4], 4);
            Graph.AddEdge(lVertex[1],lVertex[5], 1);
            Graph.AddEdge(lVertex[5],lVertex[4], 5);
            Graph.AddEdge(lVertex[4],lVertex[5], 7);
            
            GetMatrix(graph);
            Console.WriteLine();
            for (var i = 0; i < n; i++)
            {
                GetVertex(graph, lVertex[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Вoлновой алгоритм:");
            Console.WriteLine(graph.Wave(lVertex[0], lVertex[4]));
            Console.WriteLine(graph.Wave(lVertex[1], lVertex[3]));
            Console.WriteLine();
            {
                Console.WriteLine("BFS:");
                graph.BreadthFirstSearch(lVertex[0], out var vertices, out var edges);
                GetFirstSearch(edges);
            }
            Console.WriteLine();
            {
                Console.WriteLine("DFS:");
                graph.DeepFirstSearch(lVertex[0], out var vertices, out var edges);
                GetFirstSearch(edges);
            }
        }

        private static void GetFirstSearch(List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                Console.WriteLine("{0}=>({1})=>{2}", edge.From, edge.Weight, edge.To);
            }
        }

        private static void GetVertex(Graph graph, Vertex vertex)
        {
            Console.Write("{0}: ", vertex.Value);
            foreach (var item in graph.GetVertexLists(vertex))
            {
                Console.Write("{0}, ", item.Value);
            }
            Console.WriteLine();
        }

        private static void GetMatrix(Graph graph)
        {
            var matrix = graph.GetMatrix();
            Console.WriteLine();
            Console.Write("    ");
            for (var i = 0; i < graph.VertexCount(); i++)
            {
                Console.Write("{0}: ", i + 1);
            }

            Console.WriteLine();
            for (var i = 0; i < graph.VertexCount(); i++)
            {
                Console.Write("{0}: ", i + 1);
                for (var j = 0; j < graph.VertexCount(); j++)
                {
                    if (matrix[i, j] != 0) Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("|{0}|", matrix[i, j]);
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}