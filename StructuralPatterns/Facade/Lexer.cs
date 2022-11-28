using System;

namespace StructuralPatterns.Facade;

public class Lexer
{
    private readonly string _sourceCodePath;
    
    public Lexer(string sourceCodePath)
    {
        _sourceCodePath = sourceCodePath;
    }

    public Token ReadToken()
    {
        Console.WriteLine("Lexer: Scanning token from source code");
        return new Token();
    }
}

public class Token{}