using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace MidiaSocialEmpresa.Dominio.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public TEntity Adicionar(TEntity obj)
        {
            return _repositorio.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repositorio.Atualizar(obj);
        }

        public void Excluir(TEntity obj)
        {
            _repositorio.Excluir(obj);
        }

        public TEntity RetornaPorId(int id)
        {
            return _repositorio.RetornaPorId(id);
        }

        public IEnumerable<TEntity> RetornarTodos()
        {
            return _repositorio.RetornarTodos();
        }

        public IEnumerable<TEntity> PesquisaPorExpressao(Func<TEntity, bool> expr)
        {
            return _repositorio.PesquisaPorExpressao(expr);
        }
        public TEntity RetornaPorExpressao(Func<TEntity, bool> expr)
        {
            return _repositorio.RetornaPorExpressao(expr);
        }
        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
