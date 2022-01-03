using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Infra.Repository
{
    public class CodeMasterImplRepository : ICodeMasterRepository
    {
        private readonly EPIMSContext context;

        public CodeMasterImplRepository(EPIMSContext context)
        {
            this.context = context;
        }

        public async Task<CodeMasterData> GetCodeMaster(string id, string code)
        {
            var data = this.context.CodeMasters.Where(c => c.ID == id && c.Code == code);
            return data.FirstOrDefault();
        }
    }
}
