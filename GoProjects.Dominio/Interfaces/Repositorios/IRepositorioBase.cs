using System;
using System.Collections.Generic;

namespace GoProjects.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
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
