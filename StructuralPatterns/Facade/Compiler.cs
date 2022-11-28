using System;

namespace StructuralPatterns.Facade;

// Facade
public class Compiler
{
    public void Compile(string sourceCodePath, string targetPath)
    {
        Console.WriteLine($"Compiler: Starting to compile source code from {sourceCodePath}");

        // Subsystem 1
        var lexer = new Lexer(sourceCodePath);
        
        // Subsystem 2
        var parser = new Parser(lexer);
        var program = parser.Parse();

        // Subsystem 3
        var checker = new Checker(program);
        var isSemanticallyCorrect = checker.Check();

        // Subsystem 4
        if (isSemanticallyCorrect)
        {
            var generator = new Generator(program);
            generator.Generate(targetPath);
        }
        else
        {
            Console.WriteLine("Source code has errors");
        }
    }
}