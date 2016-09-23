
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;

namespace MidiaSocialEmpresa.Dominio.Servicos
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
