using DesenvolvimentoWeb.Projeto02.Models;
using System.Collections.Generic;
using System.Linq;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public class ParticipantesDaoImpl : Dao<Participante>
    {
        private readonly EventosContext _context;

        public ParticipantesDaoImpl(EventosContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Participante> ListarPorEvento(int IdEvento)
        {
            return _context.Participantes.Where(x => x.IdEvento == IdEvento).ToList();
        }
    }
}
