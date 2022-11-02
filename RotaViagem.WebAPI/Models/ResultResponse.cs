namespace RotaViagem.WebAPI.Models
{
    public class ResultResponse<T>
    {
        public T Data { get; set; }
        public ResultResponseStatus Status { get; set; }
        public string Mensagem { get; set; }

        internal static ResultResponse<T> FactoryErro(Exception ex)
        {
            return new ResultResponse<T>()
            {
                Mensagem = ex.Message,
                Status = ResultResponseStatus.Erro
            };
        }
    }
}
