using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;

namespace Trabalho.Repository
{
    public interface IclienteRepository
    {
        ClienteModel Cadastrar(ClienteModel clientemodel);
        void Editar(ClienteModel clientemodel);
        void Remover(ClienteModel clientemodel);
        List<ClienteModel> ListarClientes();
        List<ClienteModel> ListarClientesPorId(int Id);
        ClienteModel existe(int id);

    }
}