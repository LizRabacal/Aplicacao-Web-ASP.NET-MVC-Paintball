using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.data;
using Trabalho.Models;

namespace Trabalho.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly UsuarioContext _Usuariocontext;
        public UsuarioRepository(UsuarioContext Usuariocontext)
        {
            _Usuariocontext = Usuariocontext;
        }

        public UsuarioModel Cadastrar(UsuarioModel Usuariomodel)
        {
            _Usuariocontext.Usuario.Add(Usuariomodel);
            _Usuariocontext.SaveChanges();
            return Usuariomodel;


        }

        public void Editar(UsuarioModel Usuariomodel)
        {

            _Usuariocontext.Update(Usuariomodel);
            _Usuariocontext.SaveChanges();
         

        }

        public UsuarioModel existe(int id)
        {
            return _Usuariocontext.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> ListarUsuarios()
        {
            return _Usuariocontext.Usuario.ToList();
        }

        public void Remover(UsuarioModel Usuariomodel)
        {
            _Usuariocontext.Remove(Usuariomodel);
            _Usuariocontext.SaveChanges();
            
        }

         public UsuarioModel buscarporemail(string email)
        {
            return _Usuariocontext.Usuario.FirstOrDefault(x => x.Email == email);


        }

      
    }
}