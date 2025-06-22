using System.ComponentModel.DataAnnotations;

namespace AtpPOO;

using System;

public class Program
{
    public static void Main(string[] args)
    {
        int tamanho = 2;
        Pessoa[] pessoa = new Pessoa[tamanho];

        for (int i = 0; i < tamanho; i++)
        {
            pessoa[i] = new Pessoa();

            
            while (true)
            {
                Console.WriteLine($"Digite o nome da pessoa {i + 1}:");
                string nomeDigitado = Console.ReadLine()!;

                if (Validacao.ValidaNome(nomeDigitado))
                {
                    pessoa[i].nome = nomeDigitado;
                    break;
                }
                else
                {
                    Console.WriteLine("Nome inválido! Deve ter pelo menos nome e sobrenome, e cada um com no mínimo 2 caracteres.");
                }
            }

           
            while (true)
            {
                Console.WriteLine($"Qual a data de nascimento do(a) pessoa {i + 1}? (formato DD-MM-AAAA):");
                string dataDigitada = Console.ReadLine()!;

                string[] dataDividida = dataDigitada.Split('-');
                if (dataDividida.Length != 3)
                {
                    Console.WriteLine("Data no formato inválido. Use DD-MM-AAAA.");
                    continue;
                }

                string diaSplit = dataDividida[0];
                string mesSplit = dataDividida[1];
                string anoSplit = dataDividida[2];

                bool anoValido = int.TryParse(anoSplit, out int ano);

                if (!anoValido)
                {
                    Console.WriteLine("Ano inválido, digite corretamente.");
                    continue;
                }

                int idadeCalculada = Validacao.ValidaIdade(ano);
                if (idadeCalculada != -1)
                {
                    pessoa[i].dataNatal = dataDigitada;
                    pessoa[i].idade = idadeCalculada;
                    break;
                }
                else
                {
                    Console.WriteLine("Data de Nascimento inválida! A pessoa precisa ter mais que 0 e menos que 150 anos.");
                }
            }

            
            while (true)
            {
                Console.WriteLine($"Digite o e-mail da pessoa {i + 1}:");
                string emailDigitado = Console.ReadLine()!;

                if (Validacao.ValidaEmail(emailDigitado))
                {
                    pessoa[i].email = emailDigitado;
                    break;
                }
                else
                {
                    Console.WriteLine("Email inválido! Deve conter '@' e pelo menos 3 caracteres antes e depois.");
                }
            }

            Console.WriteLine("\n✅ Pessoa cadastrada com sucesso:");
            Console.WriteLine($"Nome: {pessoa[i].nome}");
            Console.WriteLine($"Data de Nascimento: {pessoa[i].dataNatal}");
            Console.WriteLine($"Idade: {pessoa[i].idade} anos");
            Console.WriteLine($"Email: {pessoa[i].email}");
            Console.WriteLine("--------------------------------------------\n");
        }

        Pessoa[] resultado = Calcular(pessoa);
        Console.WriteLine("\n📌 Pessoa mais nova:");
        Console.WriteLine($"Nome: {resultado[0].nome}, Idade: {resultado[0].idade}");

        Console.WriteLine("\n📌 Pessoa mais velha:");
        Console.WriteLine($"Nome: {resultado[1].nome}, Idade: {resultado[1].idade}");
        
        GerarRelatorio(pessoa);

    }

    public static Pessoa[] Calcular(Pessoa[] pessoas)
    {
        if (pessoas == null || pessoas.Length == 0)
        {
            return new Pessoa[0];
        }

        Pessoa maisNovo = pessoas[0];
        Pessoa maisVelho = pessoas[0];

        foreach (var pessoa in pessoas)
        {
            if (pessoa.idade < maisNovo.idade)
            {
                maisNovo = pessoa;
            }

            if (pessoa.idade > maisVelho.idade)
            {
                maisVelho = pessoa;
            }
        }

        return [maisNovo, maisVelho];
    }

    public static void GerarRelatorio(Pessoa[] pessoas)
    {
        string caminhoArquivo = "relatorio_pessoas.txt";

        using (StreamWriter writer = new StreamWriter(caminhoArquivo))
        {
            writer.WriteLine("========= Relatório de Pessoas =========\n");

            for (int i = 0; i < pessoas.Length; i++)
            {
                writer.WriteLine($"Pessoa {i + 1}:");
                writer.WriteLine($"Nome: {pessoas[i].nome}");
                writer.WriteLine($"Data de Nascimento: {pessoas[i].dataNatal}");
                writer.WriteLine($"Idade: {pessoas[i].idade} anos");
                writer.WriteLine($"Email: {pessoas[i].email}");
                writer.WriteLine("--------------------------------------------\n");
            }

            writer.WriteLine("========= Fim do Relatório =========");
        }

        Console.WriteLine($"\n📄 Relatório gerado com sucesso em '{caminhoArquivo}'");
    }

}
