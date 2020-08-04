using DesenvolvimentoWeb.Projeto02.Models;
namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public class EventosDaoImpl : Dao<Evento>
    {
        public EventosDaoImpl(EventosContext context) : base(context)
        {
        }
    }
}