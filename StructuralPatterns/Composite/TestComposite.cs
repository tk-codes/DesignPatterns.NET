using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Composite
{
    class TestComposite
    {
        public static void Run()
        {
            Folder mainFolder = new Folder("Main Folder");
            Folder subFolder1 = new Folder("Sub Folder 1");
            Folder subFolder2 = new Folder("Sub Folder 2");

            mainFolder.Add(subFolder1);
            mainFolder.Add(subFolder2);
            mainFolder.Add(new File("File 1 in Main Folder"));

            subFolder1.Add(new File("File 1 in Sub Folder 1"));
            subFolder1.Add(new File("File 2 in Sub Folder 1"));

            subFolder2.Add(new File("File 1 in Sub Folder 2"));
            subFolder2.Add(new Folder("Empty folder in Sub Folder 2"));

            mainFolder.PrintName();
            Console.ReadKey();
        }
    }
}
