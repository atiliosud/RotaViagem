# Rota de Viagem Yamaha #
Escolha a roteiro de viagem com menor preço independente da quantidade de conexões.
Para isso precisamos inserir as rotas através de um arquivo de entrada.

## Solução ##
A demanda foi identificada compatível com um problema já conhecido na computação.
O problema do caminha mais curto (CPT), logo para isso foi usado um algorítmo já conhecido.
Foi usado o algorítimo de Dijkstra para encontra a rota mais barata.

## Estrutura ##
A solução em .NET possúi 4 projetos: Console, WebAPI, Core e Test.
O Core é responsavel pelo calculo.
O Console e WebAPI são interfaces que se comunicam com o Core.
O Test é um projeto simples de teste.
