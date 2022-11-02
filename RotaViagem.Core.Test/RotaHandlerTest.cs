using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace RotaViagem.Core.Test
{
    public class RotaHandlerTest
    {
        [Fact]
        public void MapperToGraph_Sucesso()
        {
            string input = "GUA,BRC,10\n";
            input += "BRC,SCL,5\n";
            input += "GUA,CDG,75\n";
            input += "GUA,SCL,20\n";
            input += "GUA,ORL,56\n";
            input += "ORL,CDG,5\n";
            input += "SCL,ORL,20";

            var rotaHandler = new RotaHandler();
            var node = rotaHandler.MapperToGraph(input);
            
            node.Should().NotBeNullOrEmpty();
            node.ContainsKey("GUA").Should().BeTrue();
            node.ContainsKey("BRC").Should().BeTrue();
            node.ContainsKey("SCL").Should().BeTrue();
            node.ContainsKey("CDG").Should().BeTrue();
            node.ContainsKey("ORL").Should().BeTrue();

        }


        [Fact]
        public void PathEdges_Sucesso()
        {
            var nodes = new Node[]
            {
                new Node("A"),
                new Node("B"),
                new Node("C"),
            };
            nodes[0].ConnectTo(nodes[1], 10);
            nodes[1].ConnectTo(nodes[2], 20);
            nodes[2].ConnectTo(nodes[0], 40);
            var listNodes = new List<string>();
            var listEdges = new List<int>();
            RotaHandler.PathEdges(
                nodes,
                n =>
                {
                    listNodes.Add(n.Label);
                },
                e =>
                {
                    listEdges.Add(e.Value);
                });
            listNodes.Should().HaveCount(3);
            listNodes[0].Should().Be("A");
            listNodes[1].Should().Be("B");
            listNodes[2].Should().Be("C");
            listEdges.Should().HaveCount(2);
            listEdges[0].Should().Be(10);
            listEdges[1].Should().Be(20);
        }


        [Fact]
        public void Calc_Sucesso()
        {
            string input = "GUA,BRC,10\n";
            input += "BRC,SCL,5\n";
            input += "GUA,CDG,75\n";
            input += "GUA,SCL,20\n";
            input += "GUA,ORL,56\n";
            input += "ORL,CDG,5\n";
            input += "SCL,ORL,20";

            var rotaHandler = new RotaHandler();
            rotaHandler.MapperToGraph(input);
            var nodes = rotaHandler.Calc("GUA", "CDG");

            nodes.Should().NotBeNullOrEmpty();
            nodes.Should().HaveCount(5);
            nodes[0].Label.Should().Be("GUA");
            nodes[1].Label.Should().Be("BRC");
            nodes[2].Label.Should().Be("SCL");
            nodes[3].Label.Should().Be("ORL");
            nodes[4].Label.Should().Be("CDG");

        }

    }
}