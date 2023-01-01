using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly SqlContext _context;
        public ProjetoRepository(SqlContext context)// injeção de dependência/ligando o Context
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();//Listando dados da tabela Projetos
        }
             
    }
}
