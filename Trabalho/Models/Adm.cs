namespace Trabalho.Models;

public class Adm
{

public int Id { get; set; }

public string Nome { get; set; }

public string Celular  { get; set; }

public string email { get; set; }
public string senha { get; set; }

public bool senhavalida(string Senha){
    return senha == Senha;
}



}
