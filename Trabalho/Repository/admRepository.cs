using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Data;
using Trabalho.Models;

namespace Trabalho.Repository
{
    public class admRepository : IadmRepository
    {
        private readonly AdmContext _AdmContext;
        public admRepository(AdmContext AdmContext)
        {
            _AdmContext = AdmContext;
        }
        public Adm Adicionar(Adm adm)
        {
            _AdmContext.Adm.Add(adm);
            _AdmContext.SaveChanges();
            return adm;
        }


        public Adm buscarporemail(string email)
        {
            return _AdmContext.Adm.FirstOrDefault(x => x.email.ToLower() == email.ToLower());


        }


        public List<Adm> Listaradms()
        {
            return _AdmContext.Adm.ToList();
        }


        public void Deletar(Adm adm)
        {

            if (adm != null)
            {
                _AdmContext.Adm.Remove(adm);
                _AdmContext.SaveChanges();
            }
            else
            {
                // Você pode lidar com o caso em que a entidade não é encontrada, por exemplo, lançando uma exceção
                throw new InvalidOperationException("Adm não encontrado para exclusão.");
            }
        }


        public void Editar(Adm adm){

               if (adm != null)
            {
                _AdmContext.Adm.Update(adm);
                _AdmContext.SaveChanges();
            }
            else
            {
                // Você pode lidar com o caso em que a entidade não é encontrada, por exemplo, lançando uma exceção
                throw new InvalidOperationException("Adm não encontrado para exclusão.");
            }

        }

        public Adm EncontrarAdmporId(int Id)
        {  
            return _AdmContext.Adm.FirstOrDefault(x => x.Id == Id);

        }
    }
}