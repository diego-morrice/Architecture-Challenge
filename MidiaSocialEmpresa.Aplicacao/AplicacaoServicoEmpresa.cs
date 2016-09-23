
using MidiaSocialEmpresa.Aplicacao.Interface;
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;

namespace MidiaSocialEmpresa.Aplicacao
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
