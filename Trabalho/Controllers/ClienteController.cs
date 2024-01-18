using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trabalho.Models;
using Trabalho.Repository;

namespace Trabalho.Controllers
{
    public class ClienteController : Controller
    {
          private readonly ISessao _sessao;
        private readonly IclienteRepository _repositorio;
        private readonly IUsuarioRepository _UsuarioRepository;
        public ClienteController(IclienteRepository repositorio, IUsuarioRepository UsuarioRepository, ISessao sessao)
        {
                    _sessao = sessao;
            _repositorio = repositorio;
            _UsuarioRepository = UsuarioRepository;
        }
        public IActionResult Index()
        {

            string sessaousuario = HttpContext.Session.GetString("sessaousuariologado");
            if (string.IsNullOrEmpty(sessaousuario))
            {
                return RedirectToAction("Index", "Login");

            }
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaousuario);
            return View(usuario);
        }




        public IActionResult DeletarUsuario(int id)
        {
            _sessao.RemoverSessaoUsuario();
            UsuarioModel itemParaExcluir = _UsuarioRepository.existe(id);

            _UsuarioRepository.Remover(itemParaExcluir);

            return RedirectToAction("Index");

        }

        public IActionResult Cadastro()
        {
            string sessaoadm = HttpContext.Session.GetString("sessaoadmlogado");

            string sessaousuario = HttpContext.Session.GetString("sessaousuariologado");

            if (string.IsNullOrEmpty(sessaousuario) && string.IsNullOrEmpty(sessaoadm))
            {

                return RedirectToAction("Index", "Login");

            }
            if (sessaousuario != null)
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaousuario);

                ViewData["UsuarioId"] = usuario.Id;
            }
            else if (sessaoadm != null)
            {
                ViewData["UsuarioId"] = -1;
            }

            return View();
        }
        public IActionResult CadastroUsuario()
        {
            return View();
        }
        public IActionResult Editar(int Id)
        {
            string sessaoadm = HttpContext.Session.GetString("sessaoadmlogado");


            ClienteModel cliente = _repositorio.existe(Id);

            if ((cliente != null) && !(string.IsNullOrEmpty(sessaoadm)))
            {
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }

        }
        public IActionResult EditarUsuario(int Id)
        {
            string sessaoadm = HttpContext.Session.GetString("sessaousuariologado");


            UsuarioModel usuario = _UsuarioRepository.existe(Id);

            if (!(string.IsNullOrEmpty(sessaoadm)))
            {
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }

        }

        public IActionResult Listar()

        {
            string sessaoadm = HttpContext.Session.GetString("sessaoadmlogado");

            List<ClienteModel> clientes = _repositorio.ListarClientes();
            if (!(string.IsNullOrEmpty(sessaoadm)))
            {
                return View(clientes);
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }
        public IActionResult ListarPorId()
        {
            string sessaousuario = HttpContext.Session.GetString("sessaousuariologado");

            if (!(string.IsNullOrEmpty(sessaousuario)))
            {
                UsuarioModel usu = JsonConvert.DeserializeObject<UsuarioModel>(sessaousuario);
                List<ClienteModel> clientes = _repositorio.ListarClientesPorId(usu.Id);


                return View(clientes);
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
        }


        public IActionResult Remover(int Id)
        {
            ClienteModel cliente = _repositorio.existe(Id);

            if (cliente != null)
            {
                _repositorio.Remover(cliente);
                return RedirectToAction("Listar", "Cliente");
            }
            else
            {
                return RedirectToAction("Listar", "Cliente");
            }
        }


        [HttpPost]



        public IActionResult Cadastro(ClienteModel clienteModel)
        {
            string sessaoadm = HttpContext.Session.GetString("sessaoadmlogado");
            string sessaousuario = HttpContext.Session.GetString("sessaousuariologado");

            _repositorio.Cadastrar(clienteModel);
            if (!(string.IsNullOrEmpty(sessaoadm))) return RedirectToAction("Index", "Adm");
            if (!(string.IsNullOrEmpty(sessaousuario))) return RedirectToAction("Index", "Cliente");
            return RedirectToAction("Index", "Home");

        }



        [HttpPost]
        public IActionResult Editar(ClienteModel clienteatualizado)
        {
            _repositorio.Editar(clienteatualizado);

            return RedirectToAction("Listar", "Cliente");
        }
        [HttpPost]
        public IActionResult EditarUsuario(UsuarioModel Usuarioatualizado)
        {
            _UsuarioRepository.Editar(Usuarioatualizado);

            return RedirectToAction("Index", "Cliente");
        }


        [HttpPost]



        public IActionResult CadastroUsuario(UsuarioModel UsuarioModel)
        {
            _UsuarioRepository.Cadastrar(UsuarioModel);
            return RedirectToAction("Index", "Adm"); ;
        }





    }
}