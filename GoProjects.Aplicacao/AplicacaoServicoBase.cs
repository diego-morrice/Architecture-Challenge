
using GoProjects.Aplicacao.Interface;
using GoProjects.Dominio.Interfaces.Servicos;
using System;

namespace GoProjects.Aplicacao
{
    public class AplicacaoServicoBase<TEntity> : IDisposable, IAplicacaoServicoBase<TEntity> where TEntity : class
    {

        private readonly IServicoBase<TEntity> _serviceBase;

        public AplicacaoServicoBase(IServicoBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public TEntity Adicionar(TEntity obj)
        {
            return _serviceBase.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _serviceBase.Atualizar(obj);
        }

        public void Excluir(TEntity obj)
        {
            _serviceBase.Excluir(obj);
        }

        public TEntity RetornaPorId(int id)
        {
            return _serviceBase.RetornaPorId(id);
        }

        public System.Collections.Generic.IEnumerable<TEntity> RetornarTodos()
        {
            return _serviceBase.RetornarTodos();
        }
        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
