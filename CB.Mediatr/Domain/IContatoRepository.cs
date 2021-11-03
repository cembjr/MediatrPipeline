using System.Threading.Tasks;

namespace CB.MediatrPipeline.Domain
{
    public interface IContatoRepository
    {
        void Adicionar(Contato contato);
        bool ContatoJaExiste(string telefone);
    }
}
