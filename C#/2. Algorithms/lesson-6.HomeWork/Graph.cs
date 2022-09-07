using System.Collections.Generic;
using System.Linq;

namespace lesson_6.HomeWork
{
    public class Graph
    {
        private readonly List<Vertex> _vertexes = new List<Vertex>();

        public int VertexCount() => _vertexes.Count;

        public void AddVertex(Vertex vertex)
        {
            _vertexes.Add(vertex);
        }

        public static void AddEdge(Vertex from, Vertex to, int weight = 1)
        {
            from.Edges.Add(new Edge(from, to, weight));
            to.Edges.Add(new Edge(from, to, weight));
        }

        public int[,] GetMatrix()
        {
            var matrix = new int[_vertexes.Count, _vertexes.Count];
            foreach (var edge in _vertexes.SelectMany(vertex => vertex.Edges))
            {
                matrix[edge.From.Value - 1, edge.To.Value - 1] = edge.Weight;
            }
            return matrix;
        }

        /// <summary>
        /// Список смежных вершин
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vertex> GetVertexLists(Vertex vertex)
        {
            return (from edge in vertex.Edges where edge.From == vertex select edge.To).ToList();
        }

        /// <summary>
        /// Вoлновой алгоритм
        /// </summary>
        /// <returns></returns>
        public bool Wave(Vertex start, Vertex finish)
        {
            var list = new List<Vertex> {start};
            for (var i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var item in GetVertexLists(vertex).Where(item => !list.Contains(item)))
                {
                    list.Add(item);
                }
            }
            return list.Contains(finish);
        }

        public void BreadthFirstSearch(Vertex vertex, out List<Vertex> vertices, out List<Edge> edges)
        {
            var visited = new bool[_vertexes.Count];
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            var queue = new Queue<Vertex>();
            queue.Enqueue(vertex);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if(visited[current.Value]) continue;
                vertices.Add(current);
                visited[current.Value] = true;
                foreach (var edge in current.Edges.Where(edge => !visited[edge.To.Value] && !queue.Contains(edge.To)))
                {
                    queue.Enqueue(edge.To);
                    edges.Add(edge);
                }
            }
        }
        
        public void DeepFirstSearch(Vertex root, out List<Vertex> nodes, out List<Edge> edges)
        {
            var visited = new bool[_vertexes.Count];
            nodes = new List<Vertex>();
            edges = new List<Edge>();
            var stack = new Stack<Vertex>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var current = stack.Pop();
                if (visited[current.Value])
                    continue;
                nodes.Add(current);
                visited[current.Value] = true;
                foreach (var edge in current.Edges.Where(edge => !visited[edge.To.Value] && !stack.Contains(edge.To)))
                {
                    stack.Push(edge.To);
                    edges.Add(edge);
                }
            }
        }
    }
}