using DesenvolvimentoWeb.Projeto02.Dados;
using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvimentoWeb.Projeto02.Controllers
{
    public class EventosController : Controller
    {
        private EventosDaoImpl _eventosDaoImpl {get;set;}

        //EventosContext é passado por Injecao de Dependencia
        public EventosController(EventosContext ctx)
        {
            _eventosDaoImpl = new EventosDaoImpl(ctx);
        }

        public IActionResult Index()
        {
            return View();
        }

        //Inclusão do Evento
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult IncluirEvento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IncluirEvento(Evento evento, IFormFile Foto)
        {
            if (Foto != null)
            {
                evento.MimeType = Foto.ContentType;
                evento.Foto = Foto.ToByteArray();
            }

            _eventosDaoImpl.ProcessarDB(evento, TipoOperacaoBd.Added);
            return RedirectToAction("ListarEventos");
        }

        //Buscando a Imagem
        public FileResult BuscarFoto(int id)
        {
            var evento = _eventosDaoImpl.BuscarPorId(id);
            return File(evento.Foto, evento.MimeType);
        }

        //Listando Eventos
        public IActionResult ListarEventos()
        {
            var lista = _eventosDaoImpl.Listar();
            return View(lista);
        }

        //Alterando Eventos
        [HttpGet]
        public IActionResult AlterarEvento(int id)
        {
            return ExecutarEvento(id, "AlterarEvento");
        }
        [HttpPost]
        public IActionResult AlterarEvento(Evento evento, IFormFile Foto)
        {
            if (Foto != null)
            {
                evento.MimeType = Foto.ContentType;
                evento.Foto = Foto.ToByteArray();
            }

            _eventosDaoImpl.ProcessarDB(evento, TipoOperacaoBd.Modified);

            return RedirectToAction("ListarEventos");
        }

        //Ver os Detalhes
        public IActionResult VerDetalhes(int id)
        {
            return ExecutarEvento(id, "VerDetalhes");
        }

        //Remover Evento
        [HttpGet]
        public IActionResult RemoverEvento(int id)
        {
            return ExecutarEvento(id, "RemoverEvento");
        }
        [HttpPost]
        public IActionResult RemoverEvento(Evento evento)
        {
            _eventosDaoImpl.ProcessarDB(evento, TipoOperacaoBd.Deleted);

            return RedirectToAction("ListarEventos");
        }

        //Action HTTPGet Comum (Compartilhado)
        [HttpGet]
        private IActionResult ExecutarEvento(int id, string viewName)
        {
            var evento = _eventosDaoImpl.BuscarPorId(id);
            if (evento == null)
            {
                @ViewData["MensagemErro"] = "Nenhum evento encontrado";
                return View("_Erro");
            }
            return View(viewName, evento);
        }

    }
}