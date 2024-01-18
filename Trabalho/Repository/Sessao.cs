using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;
using Trabalho.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Trabalho.Data;

namespace Trabalho.Repository
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor varivelhttp;

        public Sessao(IHttpContextAccessor variavel)
        {
            varivelhttp = variavel;
        }
        public Adm BuscarSessao()
        {
            string sessaoadm = varivelhttp.HttpContext.Session.GetString("sessaoadmlogado");
            if (string.IsNullOrEmpty(sessaoadm)) return null;
            return JsonConvert.DeserializeObject<Adm>(sessaoadm);

        }

        public void RemoverSessao()
        {
            varivelhttp.HttpContext.Session.Remove("sessaoadmlogado");

        }
        public void RemoverSessaoUsuario()
        {
            varivelhttp.HttpContext.Session.Remove("sessaousuariologado");

        }

        public void CriarSessaodoAdm(Adm adm)
        {

            varivelhttp.HttpContext.Session.SetString("sessaoadmlogado", JsonConvert.SerializeObject(adm));
        }

        public void CriarSessaodoUsuario(UsuarioModel usuario)
        {
            varivelhttp.HttpContext.Session.SetString("sessaousuariologado", JsonConvert.SerializeObject(usuario));
        }

        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaousuario = varivelhttp.HttpContext.Session.GetString("sessaousuariologado");
            if (string.IsNullOrEmpty(sessaousuario)) return null;
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaousuario);
        }
    }
}