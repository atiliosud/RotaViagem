namespace RotaViagem.WebAPI.Models
{
    public class RotaNovaRequest
    {
        public string De { get; set; }
        public string Para { get; set; }
        public int Custo { get; set; }

        internal Rota ToRota()
        {
            return new Rota()
            {
                From = De,
                To = Para,
                Value = Custo
            };
        }
    }
}
