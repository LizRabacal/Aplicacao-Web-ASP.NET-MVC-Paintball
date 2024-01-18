using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;

namespace Trabalho.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel Cadastrar(UsuarioModel Usuariomodel);
        void Editar(UsuarioModel Usuariomodel);
        void Remover(UsuarioModel Usuariomodel);
        List<UsuarioModel> ListarUsuarios();
        UsuarioModel existe(int id);

          UsuarioModel buscarporemail(string email);
    }
}