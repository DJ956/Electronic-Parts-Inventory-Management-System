using EPIMS_API.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Repository
{
    public interface ICodeMasterRepository
    {
        /// <summary>
        /// コードマスタデータを取得する
        /// </summary>
        /// <param name="id">識別コード</param>
        /// <param name="code">コード値</param>
        /// <returns></returns>
        Task<CodeMasterData> GetCodeMaster(string id, string code);
    }
}
