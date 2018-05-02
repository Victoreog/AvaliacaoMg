using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AvaliacaoMg.Presentation.Models;
using AvaliacaoMg.Data.Context;
using AvaliacaoMg.Data.Repositories;
using AvaliacaoMg.Data.ViewModels;

namespace AvaliacaoMg.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private ClienteRepository _clienteRepository;

        //HOME
        public HomeController(AvaliacaoMgContext context)
        {
            _clienteRepository = new ClienteRepository(context);
        }

        public IActionResult Index(ClienteViewModel clienteViewModel)
        {
            var clientes = _clienteRepository.GetAllWithIncludes();

            return View(clientes);
        }

        //INCLUIR
        [HttpGet]
        public ActionResult Incluir()
        {
            ViewBag.Acao = "Incluir";

            return View("Cadastrar", new ClienteViewModel());
        }

        [HttpPost]
        public ActionResult Incluir(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Add(clienteViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Acao = "Incluir";
                return View("Cadastrar", clienteViewModel);
            }
        }

        //EDITAR
        [HttpGet]
        public ActionResult Editar(int IdCliente)
        {
            ViewBag.Acao = "Editar";
            var cliente = _clienteRepository.GetByIdWithIncludes(IdCliente);
            
            return View("Cadastrar", cliente);
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.UpdateWithIncludes(clienteViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Acao = "Editar";
                return View("Cadastrar", clienteViewModel);
            }
        }

        //REMOVER
        [HttpPost]
        public ActionResult Remover(int IdCliente)
        {
            var cliente = _clienteRepository.GetByIdWithIncludes(IdCliente);
            _clienteRepository.Remove(cliente);

            return RedirectToAction("Index");
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected override void Dispose(bool disposing)
        {
            _clienteRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
