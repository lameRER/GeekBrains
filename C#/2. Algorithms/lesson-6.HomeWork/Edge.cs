namespace lesson_6.HomeWork
{
    public class Edge
    {
        public Vertex From { get; }
        public Vertex To { get; }
        public int Weight { get; }

        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString() => $"{From} {To}";
    }
}