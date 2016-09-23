using System;
using System.Collections.Generic;


namespace MidiaSocialEmpresa.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity RetornaPorId(int id);
        IEnumerable<TEntity> PesquisaPorExpressao(Func<TEntity, bool> expr);
        TEntity RetornaPorExpressao(Func<TEntity, bool> expr);
        IEnumerable<TEntity> RetornarTodos();
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        void Dispose();
    }
}
