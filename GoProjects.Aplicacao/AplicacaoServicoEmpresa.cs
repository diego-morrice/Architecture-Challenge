
using GoProjects.Aplicacao.Interface;
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Servicos;

namespace GoProjects.Aplicacao
{
    public class AplicacaoServicoEmpresa : AplicacaoServicoBase<Empresa>, IAplicacaoServicoEmpresa
    {
        public readonly IServicoEmpresa _servicoEmpresa;

        public AplicacaoServicoEmpresa(IServicoEmpresa servicoEmpresa)
            : base(servicoEmpresa)
        {
            _servicoEmpresa = servicoEmpresa;
        }
    }
}
