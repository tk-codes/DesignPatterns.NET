using System;

namespace StructuralPatterns.Facade;

public class Generator
{
    private readonly ProgramNode _program;
    
    public Generator(ProgramNode program)
    {
        _program = program;
    }

    public void Generate(string targetPath)
    {
        Console.WriteLine($"Generator: Generate IL code at {targetPath}");
    }
}