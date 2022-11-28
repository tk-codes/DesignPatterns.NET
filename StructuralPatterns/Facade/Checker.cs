using System;

namespace StructuralPatterns.Facade;

public class Checker
{
    private readonly ProgramNode _program;
    
    public Checker(ProgramNode program)
    {
        _program = program;
    }

    public bool Check()
    {
        Console.WriteLine("Checker: Run semantic checks");

        return true;
    }
}