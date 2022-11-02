namespace RotaViagem.WebAPI.Models
{
    public class Rota
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Value { get; set; }

        public override string? ToString()
        {
            return $"{From},{To},{Value}";
        }
    }
}
