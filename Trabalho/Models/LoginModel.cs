using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string email  { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string senha { get; set; }
    }
}