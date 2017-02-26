using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory
{
    public interface Dough
    {
        string GetName();
    }

    public class ThickCrustDough : Dough
    {
        private string name = "Extra thick crust dough";

        public string GetName()
        {
            return name;
        }
    }

    public class ThinCrustDough : Dough
    {
        private string name = "Thin crust dough";

        public string GetName()
        {
            return name;
        }
    }
}
