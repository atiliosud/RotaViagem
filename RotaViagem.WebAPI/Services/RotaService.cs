using RotaViagem.Core;
using RotaViagem.WebAPI.Models;
using RotaViagem.WebAPI.Repositories;

namespace RotaViagem.WebAPI.Services
{
    public class RotaService
    {
        internal ResultResponse<RotaNovaRequest> InsertRota(RotaNovaRequest request)
        {
            var repository = new RotaRepository();
            try
            {

                repository.InsertRota(request.ToRota());
            }
            catch (Exception ex)
            {
                return ResultResponse<RotaNovaRequest>.FactoryErro(ex);
            }
            return new ResultResponse<RotaNovaRequest>()
            {
                Data = request,
                Mensagem = "Salvo com sucesso",
                Status = ResultResponseStatus.Sucesso
            };
        }

        internal ResultResponse<RotaConsultarResponse> CalcRota(RotaConsultarRequest request)
        {
            try
            {
                var repository = new RotaRepository();
                var rotas = repository.GetAllRotasDistinct();
                var str = String.Join('\n', rotas);
                var rotaHandler = new RotaHandler();
                rotaHandler.MapperToGraph(str);

                var path = rotaHandler.Calc(request.De.Trim(), request.Para.Trim());
                var list = new List<string>();
                var data = new RotaConsultarResponse();
                RotaHandler.PathEdges(
                    path,
                    node => { list.Add(node.Label); },
                    edge => { data.Valor += edge.Value; });
                data.Rota = list.ToArray();
                return new ResultResponse<RotaConsultarResponse>()
                {
                    Data = data,
                    Mensagem = "Dado recuperado com sucesso",
                    Status = ResultResponseStatus.Sucesso
                };
            }
            catch (Exception ex)
            {

                return ResultResponse<RotaConsultarResponse>.FactoryErro(ex);
            }
        }
    }
}
