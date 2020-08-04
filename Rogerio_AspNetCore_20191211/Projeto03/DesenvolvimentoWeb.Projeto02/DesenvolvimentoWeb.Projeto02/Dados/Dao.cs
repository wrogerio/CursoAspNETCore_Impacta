using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public abstract class Dao<T> where T : class
    {
        private readonly EventosContext _eventosContext;

        public Dao(EventosContext EventosContext)
        {
            _eventosContext = EventosContext;
        }

        public void ProcessarDB(T obj, TipoOperacaoBd tipo)
        {
            _eventosContext.Entry<T>(obj).State = (EntityState)tipo;
            _eventosContext.SaveChanges();
        }

        public IEnumerable<T> Listar()
        {
            return _eventosContext.Set<T>().ToList();
        }

        public T BuscarPorId(int id)
        {
            return _eventosContext.Set<T>().Find(id);
        }
    }
}
