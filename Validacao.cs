public class Validacao
{
    // Valida a idade com base no ano de nascimento
    public static int ValidaIdade(int ano)
    {
        int idade = DateTime.Now.Year - ano;
        if (idade > 0 && idade < 150)
        {
            return idade;
        }
        else
        {
            return -1;
        }
    }

    // Valida o nome
    public static bool ValidaNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return false;

        // Quebra o nome por espaços
        string[] partes = nome.Trim().Split(' ');

        // Deve ter pelo menos duas partes (nome e sobrenome)
        if (partes.Length < 2)
            return false;

        // Cada parte deve ter pelo menos 2 caracteres
        foreach (var parte in partes)
        {
            if (parte.Length < 2)
                return false;
        }

        return true;
    }

    // Valida o email
    public static bool ValidaEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        // Verifica se contém "@"
        if (!email.Contains('@'))
            return false;

        string[] partes = email.Split('@');

        // Deve ter exatamente duas partes: antes e depois do arroba
        if (partes.Length != 2)
            return false;

        string antesDoArroba = partes[0];
        string depoisDoArroba = partes[1];

        // Verifica se ambas as partes têm pelo menos 3 caracteres
        if (antesDoArroba.Length < 3 || depoisDoArroba.Length < 3)
            return false;

        return true;
    }

    // Valida o ano de nascimento
    public static bool ValidaAnoNascimento(int ano)
    {
        int idade = DateTime.Now.Year - ano;
        return idade > 0 && idade < 150;
    }
}
