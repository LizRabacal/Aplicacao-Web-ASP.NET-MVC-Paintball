using Trabalho.Models;

public class UsuarioModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool Usuario { get; set; } = true;


    public bool SenhaValida(string senha)
    {
        return Senha == senha;
    }
}
