using CB.MediatrPipeline.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.MediatrPipeline.Data
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly List<Contato> contatoList = new();

        public void Adicionar(Contato contato) => contatoList.Add(contato);

        public bool ContatoJaExiste(string telefone) => contatoList.FirstOrDefault(f => f.Telefone == telefone) == null;
    }
}
