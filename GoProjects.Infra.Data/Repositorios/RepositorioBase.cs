using System;
using System.Collections.Generic;
using GoProjects.Dominio.Interfaces.Repositorios;
using GoProjects.Infra.Data.Contexto;
using System.Linq;
using System.Data.Entity;

namespace GoProjects.Infra.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {

        protected MidiaSocialEmpresaContext BD = new MidiaSocialEmpresaContext();

        public TEntity Adicionar(TEntity obj)
        {
            var entidade = BD.Set<TEntity>().Add(obj);
            BD.SaveChanges();
            return entidade;
        }

        public void Atualizar(TEntity obj)
        {
            BD.Entry(obj).State = EntityState.Modified;
            BD.SaveChanges();
        }

        public void Excluir(TEntity obj)
        {
            BD.Set<TEntity>().Remove(obj);
            BD.SaveChanges();
        }

        public TEntity RetornaPorId(int id)
        {
            return BD.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> RetornarTodos()
        {
            return BD.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> PesquisaPorExpressao(Func<TEntity, bool> expr)
        {
            return BD.Set<TEntity>().Where(expr);
        }
        public TEntity RetornaPorExpressao(Func<TEntity, bool> expr)
        {
            return BD.Set<TEntity>().FirstOrDefault(expr);
        }

        public IEnumerable<TEntity> RetornarTodosSemTrack(TEntity obj)
        {
            return BD.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
