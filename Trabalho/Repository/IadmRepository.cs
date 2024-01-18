using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;

namespace Trabalho.Repository
{
    public interface IadmRepository
    {
        Adm buscarporemail (string email);
        Adm Adicionar(Adm adm);
        Adm EncontrarAdmporId(int Id);
        List<Adm> Listaradms();

        void Deletar(Adm adm);

        void Editar(Adm adm);
       
    }
}