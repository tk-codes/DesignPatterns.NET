using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Composite
{
    interface IFileSystemComponent
    {
        void PrintName(string prefix);
    }

    // Leaf
    class File : IFileSystemComponent
    {
        public string Name { get; set; }
        public File(string name)
        {
            this.Name = name;
        }

        public void PrintName(string prefix = "")
        {
            Console.WriteLine("{0} {1}", prefix, Name);
        }
    }

    // Composite
    class Folder : IFileSystemComponent
    {
        private readonly List<IFileSystemComponent> _fsComponents;
        public string Name { get; set; }

        public Folder(string name)
        {
            this.Name = name;
            this._fsComponents = new List<IFileSystemComponent>();
        }

        public void Add(IFileSystemComponent component)
        {
            this._fsComponents.Add(component);
        }

        public void Remove(IFileSystemComponent component)
        {
            this._fsComponents.Remove(component);
        }

        public void PrintName(string prefix = "")
        {
            Console.WriteLine("{0} {1}", prefix, Name);
            foreach (var fileSystemComponent in _fsComponents)
            {
                fileSystemComponent.PrintName(prefix + "\t");
            }
        }
    }
}
