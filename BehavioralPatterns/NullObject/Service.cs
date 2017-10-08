using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.NullObject
{
    class Service
    {
        private ILog log;

        public Service(ILog log)
        {
            this.log = log;
        }

        public void HandleRequestWithoutNullObject(string request)
        {
            if (log != null)
            {
                log.Write(request);
            }

            // more statements

            if (log != null)
            {
                log.Write(request);
            }
        }

        public void HandleRequestWithNullObject(string request)
        {
            log.Write(request);
        }

        public void HandleRequestWithNullPropagation(string request)
        {
            log?.Write(request);
        }
    }
}
