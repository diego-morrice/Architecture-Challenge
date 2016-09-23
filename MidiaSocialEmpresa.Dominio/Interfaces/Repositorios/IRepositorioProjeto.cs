using System.Collections.Generic;
using MidiaSocialEmpresa.Dominio.Entidades;

namespace MidiaSocialEmpresa.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioProjeto : IRepositorioBase<Projeto>
    {
        IEnumerable<Projeto> PesquisaPorNome(string nome);
        bool ValidarNomeJaCadastrado(Projeto usuario);
        Projeto CriarProjeto(Projeto usuario);
        void AtualizarProjeto(Projeto usuario);
    }
}
