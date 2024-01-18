using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Data { get; set; }
        public string Quantidade { get; set; }
        public string Forma { get; set; }

        public int UsuarioId { get; set; }
        // Propriedade de navegação
        public virtual UsuarioModel Usuario { get; set; }
    }
}