using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesenvolvimentoWeb.Projeto02.Dados;
using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesenvolvimentoWeb.Projeto02.Controllers
{
    public class ParticipantesController : Controller
    {
        private EventosDaoImpl _eventosDaoImpl { get; set; }
        private ParticipantesDaoImpl _participanteDaoImpl { get; set; }

        public ParticipantesController(EventosContext ctx)
        {
            _eventosDaoImpl = new EventosDaoImpl(ctx);
            _participanteDaoImpl = new ParticipantesDaoImpl(ctx);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IncluirParticipante()
        {
            ViewBag.ListaDeEventos = new SelectList(_eventosDaoImpl.Listar(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        public IActionResult IncluirParticipante(Participante participante)
        {
            if(participante.IdEvento == 0)
                ModelState.AddModelError("IdEvento", "Informe um evento");

            if (participante.Cpf != null)
            {
                if (!participante.Cpf.ValidarCPF())
                    ModelState.AddModelError("Cpf", "Cpf inválido");
            }
            else
            {
                ModelState.AddModelError("Cpf", "Informe um CPF");
            }

            if (!ModelState.IsValid)
                return IncluirParticipante();

            _participanteDaoImpl.ProcessarDB(participante, TipoOperacaoBd.Added);

            return RedirectToAction("Index");
        }

        public IActionResult ListarParticipantesAjax(int idEvento)
        {
            ViewBag.ListaDeEventos = new SelectList(_eventosDaoImpl.Listar(), "Id", "Descricao");
            if(idEvento == 0)
            {
                return View();
            }
            else
            {
                var listaDeEventos = _participanteDaoImpl.ListarPorEvento(idEvento);
                return PartialView("_ListarParticipantes", listaDeEventos);
            }
        }
    }
}