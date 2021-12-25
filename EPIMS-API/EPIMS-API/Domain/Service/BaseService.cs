using EPIMS_API.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Service
{
    public class BaseService
    {
        protected readonly EPIMSContext context;

        public BaseService(EPIMSContext context)
        {
            this.context = context;
        }
    }
}
