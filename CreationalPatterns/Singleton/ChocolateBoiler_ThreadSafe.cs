using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Singleton
{
    public sealed class ChocolateBuilder_ThreadSafe
    {
        public bool Empty { get; set; }
        public bool Boiled { get; set; }

        // singleton instance
        private static volatile ChocolateBuilder_ThreadSafe instance;
        private static object syncLock = new object();

        private ChocolateBuilder_ThreadSafe()
        {
            this.Empty = true;
            this.Boiled = false;
        }

        public static ChocolateBuilder_ThreadSafe Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if(instance == null)
                        {
                            instance = new ChocolateBuilder_ThreadSafe();
                        }                 
                    }  
                }
                return instance;
            }
        }

        public void Fill()
        {
            // To fill the boiler, it must be empty, and once it's full, we set the empty and boiled flags
            if (this.Empty)
            {
                this.Empty = false;
                this.Boiled = false;

                // fill the boiler with a milk/chocolate mixture
            }
        }

        public void Drain()
        {
            // To drain the boiler, it must be full and also boiled.
            // Once it is drained we set the Empty property back to true
            if (!this.Empty && this.Boiled)
            {
                // drain the boiled milk and chocolate
                this.Empty = true;
            }
        }

        public void Boil()
        {
            // To boil the mixture, the boiler has to be full and not already boiled.
            // Once it is boiled we set the boiled flag to true
            if (!this.Empty && !this.Boiled)
            {
                // bring the contents to a boil
                this.Boiled = true;
            }
        }
    }
}
