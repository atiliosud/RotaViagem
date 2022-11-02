using RotaViagem.WebAPI.Models;

namespace RotaViagem.WebAPI.Repositories
{
    public class RotaRepository
    {
        private const string path = "rotas.csv";
        internal void InsertRota(Rota rota)
        {
            var str = rota.ToString();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(str);
            }
        }

        internal IEnumerable<Rota> GetAllRotasDistinct()
        {
            var list = new List<Rota>();
            if (File.Exists(path))
            {
                var fileRead = File.ReadAllText(path);
                var rows = fileRead.Split('\n');
                var tuples = rows.Select(x => x.Split(','));

                foreach (var tuple in tuples)
                {
                    if(tuple.Length > 2)
                    {
                        var rota = new Rota()
                        {
                            From = tuple[0].Trim(),
                            To = tuple[1].Trim(),
                            Value = int.Parse(tuple[2])
                        };

                        if (!list.Any(x => x.Equals(rota)))
                        {
                            list.Add(rota);
                        }
                         
                    }
                }
                
            }
            return list;
        }
    }
}
