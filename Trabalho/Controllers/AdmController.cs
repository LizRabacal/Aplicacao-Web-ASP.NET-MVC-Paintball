using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trabalho.Models;
using Trabalho.Repository;
using Newtonsoft.Json;
using Trabalho.Data;

namespace Trabalho.Controllers;

public class AdmController : Controller
{
    private readonly IadmRepository _admRepository;
          private readonly ISessao _sessao;
    public AdmController(IadmRepository admRepository, ISessao sessao)
    {
        _sessao = sessao;
        _admRepository = admRepository;
    }
    public IActionResult Index()

    {
        string sessaoadm = HttpContext.Session.GetString("sessaoadmlogado");

        if (string.IsNullOrEmpty(sessaoadm))
        {
            return RedirectToAction("Index", "Login");

        }
        Adm adm = JsonConvert.DeserializeObject<Adm>(sessaoadm);

        return View(adm);
    }

    public IActionResult Cadastro()
    {
        return View();
    }
    public IActionResult Editar(int Id)
    {
        Adm adm = _admRepository.EncontrarAdmporId(Id);

        return View(adm);

    }
    public IActionResult Inicio()
    {
        return View();
    }



    [HttpPost]
    public IActionResult Cadastro(Adm adm)
    {
        _admRepository.Adicionar(adm);
        return RedirectToAction("Index", "Adm");
    }
    public IActionResult Deletar(int id)
    {
        _sessao.RemoverSessao();
        Adm itemParaExcluir = _admRepository.EncontrarAdmporId(id);
    
       _admRepository.Deletar(itemParaExcluir);

        return RedirectToAction("Index");

    }

    [HttpPost]
    public IActionResult Editar(Adm adm)
    {
        _admRepository.Editar(adm);
        return RedirectToAction("Index", "Adm");
    }

}