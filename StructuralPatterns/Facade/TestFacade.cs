namespace StructuralPatterns.Facade;

public class TestFacade
{
    public static void Run()
    {
        // Client uses facade which abstracts the interaction with the sub-processes
        var compiler = new Compiler();
        compiler.Compile(@"~\hello.cs", @"~\hello.il");
    }
}