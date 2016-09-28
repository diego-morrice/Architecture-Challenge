
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Repositorios;
using GoProjects.Dominio.Interfaces.Servicos;

namespace GoProjects.Dominio.Servicos
{
    public class ServicoEmpresa : ServicoBase<Empresa>, IServicoEmpresa
    {
        private readonly IRepositorioEmpresa _repositorioEmpresa;

        public ServicoEmpresa(IRepositorioEmpresa repositorioEmpresa)
            : base(repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;
        }
    }
}
