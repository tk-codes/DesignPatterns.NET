using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Adapter
{
    public class TurkeyObjectAdapter : IDuck
    {
        private readonly ITurkey _turkey;

        public TurkeyObjectAdapter(ITurkey turkey)
        {
            this._turkey = turkey;
        }

        public void Quack()
        {
            _turkey.Gobble();
        }

        public void Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                _turkey.Fly();
            }
        }
    }
}
