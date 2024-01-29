using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using ControleDeContatos.Repositorio.Contratos;
using Microsoft.AspNetCore.Mvc;

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
            return View(_contatoRepositorio.Buscar());
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
        public IActionResult ConfirmacaoApagar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Adicionado";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch(System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar contato";
                return RedirectToAction("Index");
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
                    TempData["MensagemSucesso"] = "Contato Editado";
                    return RedirectToAction("Index");

                }  TempData["MensagemErro"] = "Erro ao editar contato";
                return RedirectToAction("Index");
                return View("Editar", contato);
            }
            catch(System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao editar contato";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _contatoRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Contato deletado";
                return RedirectToAction("Index");
            }
            catch(System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao apagar contato";
                return RedirectToAction("Index");
            }
        }
    }
}
