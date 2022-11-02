namespace RotaViagem.Core
{
    public class RotaHandler
    {
        public IDictionary<string, Node> vertex;

        public static void PathEdges(Node[]? path, Action<Node> nodeExec, Action<Node.Edge> edgeExec)
        {
            if(path == null || !path.Any())
            {
                return;
            }
            for (int i = 0; i < path.Length - 1; i++)
            {
                nodeExec(path[i]);
                var edge = path[i].Edges.First(x => x.Node2 == path[i + 1]);
                edgeExec(edge);
            }
            nodeExec(path.Last());
        }

        public Node[]? Calc(string origem, string target)
        {
            Dijkstra dijkstra = new Dijkstra();
            
            return dijkstra.FindShortestPath(vertex[origem], vertex[target]);
        }

        public IDictionary<string, Node> MapperToGraph(string input)
        {
            var rows = input.Split('\n');
            var tuples = rows.Select(x => x.Split(','));

            var vertexHash = new HashSet<string>(tuples.SelectMany(x => x.Take(2)));
            vertex = vertexHash.ToDictionary(k=>k, n => new Node(n));


            foreach (var tuple in tuples)
            {
                vertex[tuple[0]].ConnectTo(vertex[tuple[1]], int.Parse(tuple[2]));
            }
            return vertex;
        }
    }
}