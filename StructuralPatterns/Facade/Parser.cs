using System;

namespace StructuralPatterns.Facade;

public class Parser
{
    private readonly Lexer _lexer;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
    }

    public ProgramNode Parse()
    {
        var token = _lexer.ReadToken();
        
        Console.WriteLine("Parser: Parsing the token");
        return new ProgramNode();
    }
}

public class ProgramNode
{
}