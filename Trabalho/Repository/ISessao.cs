using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;

namespace Trabalho.Repository
{
    public interface ISessao
    {
        void CriarSessaodoAdm(Adm adm);
        void CriarSessaodoUsuario(UsuarioModel usuario);

        void RemoverSessao();
        void RemoverSessaoUsuario();

        Adm BuscarSessao();
        UsuarioModel BuscarSessaoUsuario();
    }
}