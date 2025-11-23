using System;
using System.Linq;

public class Progam
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--GERANDO SENHAS--\n");

        Console.WriteLine("Senha com todos os tipos");
        Generator gen1 = new Generator(16, true, true, true, true);
        string senha1 = gen1.GerarSenha();
        Console.WriteLine($"Senha gerada: {senha1}");
        Console.WriteLine($"Comprimento: {senha1.Length}");
        Console.WriteLine($"Força: {gen1.AvaliarForca(senha1)}");
        Console.WriteLine();

        Console.WriteLine("Senha com maiúsculas + números");
        Generator gen2 = new Generator(12, true, false, true, false);
        string senha2 = gen2.GerarSenha();
        Console.WriteLine($"Senha gerada: {senha2}");
        Console.WriteLine($"Comprimento: {senha2.Length}");
        Console.WriteLine($"Força: {gen2.AvaliarForca(senha2)}");
        Console.WriteLine();

        Console.WriteLine("TSenha com só minúsculas");
        Generator gen3 = new Generator(8, false, true, false, false);
        string senha3 = gen3.GerarSenha();
        Console.WriteLine($"Senha gerada: {senha3}");
        Console.WriteLine($"Comprimento: {senha3.Length}");
        Console.WriteLine($"Força: {gen3.AvaliarForca(senha3)}");
        Console.WriteLine();

        Console.WriteLine("Gerando 5 senhas diferentes ( todos tipos)");
        Generator gen5 = new Generator(12, true, true, true, true);
        for (int i = 1; i <= 5; i++)
        {
            string senha = gen5.GerarSenha();
            Console.WriteLine($"{i}. {senha} - Força: {gen5.AvaliarForca(senha)}");
        }
        Console.WriteLine();

    }
}
