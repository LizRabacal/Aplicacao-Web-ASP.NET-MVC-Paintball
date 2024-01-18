using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabalho.Models;
using Trabalho.Repository;

namespace Trabalho.Controllers
{
    public class LoginController : Controller
    {
        private readonly IadmRepository _admRepository;
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly ISessao _sessao;
        public LoginController(IadmRepository admRepository, ISessao sessao, IUsuarioRepository UsuarioRepository)
        {
            _admRepository = admRepository;
            _sessao = sessao;
            _UsuarioRepository = UsuarioRepository;

        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() != null) return RedirectToAction("Index", "Adm");
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Cliente");

            return View("Index");
        }
        public IActionResult Sair()
        {

            string sessaoadm = HttpContext.Session.GetString("sessaoadmlogado");
            string sessaousuario = HttpContext.Session.GetString("sessaousuariologado");
            if (!(string.IsNullOrEmpty(sessaoadm))){
                _sessao.RemoverSessao();
            }
            if (!(string.IsNullOrEmpty(sessaousuario))){
                _sessao.RemoverSessaoUsuario();
            }

            return RedirectToAction("Index", "Login");

        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {

            try
            {
                if (ModelState.IsValid)
                {


                    Adm usuariovalido = _admRepository.buscarporemail(login.email);

                    UsuarioModel uasuariovalido = _UsuarioRepository.buscarporemail(login.email);

                    if (usuariovalido != null)
                    {
                        if (usuariovalido.senhavalida(login.senha))
                        {
                            ViewData["LoginErrado"] = "";

                            _sessao.CriarSessaodoAdm(usuariovalido);

                            return RedirectToAction("Index", "Adm");
                        }
                        else
                        {
                           ViewData["LoginErrado"] = "Senha incorreta";
                        }
                    }
                    else if (uasuariovalido != null)
                    {


                        if (uasuariovalido.SenhaValida(login.senha))
                        {
                            ViewData["LoginErrado"] = "";

                            _sessao.CriarSessaodoUsuario(uasuariovalido);

                            return RedirectToAction("Index", "Cliente");
                        }
                        else
                        {
                            ViewData["LoginErrado"] = "Senha incorreta";
                        }



                    }
                    else
                    {
                        ViewData["LoginErrado"] = "Email e senha incorretos";
                    }


                }
                else
                {


                    return RedirectToAction("Index", "Login");
                }

                return View("Index", login);
            }
            catch (Exception erro)
            {
                return View();
            }
        }
    }
}