# PasswordGenerator

## 📚 Sobre o Projeto

Projeto de estudo da linguagem **C#** que implementa um gerador de senhas seguras com base nos requisitos do usuário.

## ✨ Funcionalidades

- ✅ Gera senhas com comprimento personalizável (mínimo 8 caracteres)
- ✅ Permite escolher os tipos de caracteres:
  - Letras maiúsculas (A-Z)
  - Letras minúsculas (a-z)
  - Números (0-9)
  - Caracteres especiais (!@#$%^&\*...)
- ✅ Geração criptograficamente segura usando `RNGCryptoServiceProvider`
- ✅ Validação para garantir que a senha contenha pelo menos um caractere de cada tipo selecionado
- ✅ Avaliação de força da senha (Fraca, Média, Forte, Muito Forte)

## 🏗️ Estrutura do Projeto

```
PasswordGenerator/
├── src/
│   ├── Generator.cs          # Classe principal com lógica de geração de senhas
│   ├── Program.cs             # Programa de demonstração
│   └── PasswordGenerator.csproj
└── README.md
```

## 🚀 Como Executar

```bash
cd src
dotnet run
```

## 💡 Exemplo de Uso

```csharp
// Criar gerador: 16 caracteres com todos os tipos
Generator gen = new Generator(16, true, true, true, true);

// Gerar senha
string senha = gen.GerarSenha();

// Avaliar força
string forca = gen.AvaliarForca(senha);

Console.WriteLine($"Senha: {senha}");
Console.WriteLine($"Força: {forca}");
```


## 📝 Objetivo de Aprendizado

Este projeto foi desenvolvido para praticar conceitos  da linguagem C#, incluindo:

- Sintaxe e estruturas da linguagem
- Boas práticas de programação
- Validação e tratamento de erros
