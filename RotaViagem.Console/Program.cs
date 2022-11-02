using RotaViagem.Core;

namespace RotaViagem
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileRead = File.ReadAllText(args[0]);
            Console.WriteLine(fileRead);
            var rotaHandler = new RotaHandler();
            rotaHandler.MapperToGraph(fileRead);

            while (true)
            {
                Console.Write("Digite a rota: ");
                var input = Console.ReadLine();
                var points = input.Split('-');
                var path = rotaHandler.Calc(points[0].Trim(), points[1].Trim());
                int sum = 0;
                var output = "Melhor Rota: ";
                RotaHandler.PathEdges(
                    path, 
                    node => { output = output + node.Label + " - "; },
                    edge => { sum += edge.Value; });


                Console.WriteLine($"{output}ao custo de ${sum}");

            }
        }
    }
}
