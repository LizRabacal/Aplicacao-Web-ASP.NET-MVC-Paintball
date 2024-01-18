using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trabalho.data;
using Trabalho.Models;

namespace Trabalho.Repository
{
    public class clienteRepository : IclienteRepository
    {

        private readonly ClienteContext _clientecontext;
        public clienteRepository(ClienteContext clientecontext)
        {
            _clientecontext = clientecontext;
        }

        public ClienteModel Cadastrar(ClienteModel clientemodel)
        {
            _clientecontext.Cliente.Add(clientemodel);
            _clientecontext.SaveChanges();
            return clientemodel;


        }

        public void Editar(ClienteModel clientemodel)
        {

            _clientecontext.Update(clientemodel);
            _clientecontext.SaveChanges();
         

        }

        public ClienteModel existe(int id)
        {
            return _clientecontext.Cliente.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> ListarClientes()
        {
            return _clientecontext.Cliente.ToList();
        }
        public List<ClienteModel> ListarClientesPorId(int Id)
        {
           return _clientecontext.Cliente.Where(x => x.UsuarioId == Id).ToList();


        }

        public void Remover(ClienteModel clientemodel)
        {
            _clientecontext.Remove(clientemodel);
            _clientecontext.SaveChanges();
            
        }

      
    }
}