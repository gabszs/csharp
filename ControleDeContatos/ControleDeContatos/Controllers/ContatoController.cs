using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Delete(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato deletado com sucesso";
                }
                else
                {
                    TempData["MessagemErro"] = $"Houve um erro no exclusao do contato";
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MessagemErro"] = $"Houve um erro ({error.Message}) na exclusao do contato";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception error)
            {
                TempData["MessagemErro"] = $"Houve um erro ({error.Message}) no cadastro do contato";
                throw;
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception error)
            {
                TempData["MessagemErro"] = $"Houve um erro ({error.Message}) na edicao do contato";
                throw;
            }
        }
    }
}
