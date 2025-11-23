using System;
using System.Security.Cryptography;
using System.Text;

public class Generator
{
    public int Comprimento { get; set; }
    public bool InputMaiusculas { get; set; }
    public bool InputMinusculas { get; set; }
    public bool InputNumeros { get; set; }
    public bool InputEspeciais { get; set; }

    const string caracteresMaisculos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string caracteresMinusculos = "abcdefghijklmnopqrstuvwxyz";
    const string numeros = "0123456789";
    const string especiais = "!@#$%^&*()-_=+[]{}| ;:'\",.<>?/`~";


    // Construtor com valores padrão
    public Generator(int comprimento = 9, bool maiusculas = true, bool minusculas = true, 
                     bool numeros = true, bool especiais = true) 
    {
        Comprimento = comprimento;
        InputMaiusculas = maiusculas;
        InputMinusculas = minusculas;
        InputNumeros = numeros;
        InputEspeciais = especiais;
    } // Gerador aleatório

    public string GerarSenha()
    {
        if (!InputMaiusculas && !InputMinusculas && !InputNumeros && !InputEspeciais)
        {
            throw new Exception("Pelo menos um tipo de caractere deve ser selecionado!");
        }

        if (Comprimento < 8)
        {
            throw new Exception("O comprimento mínimo deve ser 8 caracteres! (Mínimo recomendado)");
        }

        string permitidos = ConstruirSenha();

        // Gerar senha aleatória
        return SenhaAleatoria(permitidos);
    }

    private string ConstruirSenha() //Adicionando todos os caracteres que o usuario selecionou
    {
        StringBuilder conjunto = new StringBuilder(); //StringBuilder para construir o conjunto de caracteres

        if (InputMaiusculas)
            conjunto.Append(caracteresMaisculos);
        
        if (InputMinusculas)
            conjunto.Append(caracteresMinusculos);
        
        if (InputNumeros)
            conjunto.Append(numeros);
        
        if (InputEspeciais)
            conjunto.Append(especiais);

        return conjunto.ToString();
    }

    private string SenhaAleatoria(string permitidos)
    {
        StringBuilder senha = new StringBuilder();
        byte[] randomBytes = new byte[Comprimento];

        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) //biblioteca para gerar números aleatórios seguros
        {
            rng.GetBytes(randomBytes); // Preencher o array com bytes aleatórios como segurança

            for (int i = 0; i < Comprimento; i++)
            {
                int index = randomBytes[i] % permitidos.Length;
                senha.Append(permitidos[index]);
            }
        }

        if (!ValidarSenha(senha.ToString()))
        {
            // Se não passar na validação gera novamente
            return SenhaAleatoria(permitidos);
        }

        return senha.ToString();
    }

    private bool ValidarSenha(string senha)
    {
        if (InputMaiusculas && !ContemCaractere(senha, caracteresMaisculos))
            return false;
        
        if (InputMinusculas && !ContemCaractere(senha, caracteresMinusculos))
            return false;
        
        if (InputNumeros && !ContemCaractere(senha, numeros))
            return false;
        
        if (InputEspeciais && !ContemCaractere(senha, especiais))
            return false;

        return true;
    }

    private bool ContemCaractere(string senha, string caracteres)
    {
        foreach (char c in senha)
        {
            if (caracteres.Contains(c.ToString()))
                return true;
        }
        return false;
    }

    // Método auxiliar para avaliar força da senha gerada
    public string AvaliarForca(string senha)
    {
        int pontuacao = 0;

        if (senha.Length >= 8) pontuacao++;
        if (senha.Length >= 12) pontuacao++;
        if (senha.Length >= 16) pontuacao++;
        
        if (ContemCaractere(senha, caracteresMaisculos)) pontuacao++;
        if (ContemCaractere(senha, caracteresMinusculos)) pontuacao++;
        if (ContemCaractere(senha, numeros)) pontuacao++;
        if (ContemCaractere(senha, especiais)) pontuacao += 2;

        if (pontuacao <= 3) return "Fraca";
        if (pontuacao <= 5) return "Média";
        if (pontuacao <= 7) return "Forte";
        return "Muito Forte";
    }
}