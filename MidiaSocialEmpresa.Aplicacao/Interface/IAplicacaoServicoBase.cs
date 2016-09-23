using System.Collections.Generic;

namespace MidiaSocialEmpresa.Aplicacao.Interface
{
    public interface IAplicacaoServicoBase<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity RetornaPorId(int id);
        IEnumerable<TEntity> RetornarTodos();
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        void Dispose();
    }
}
