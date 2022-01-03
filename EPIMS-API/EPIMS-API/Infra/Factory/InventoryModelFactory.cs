using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Factory;
using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Infra.Factory
{
    public class InventoryModelFactory : IInventoryModelFactory
    {

        private readonly EPIMSContext context;

        public InventoryModelFactory(EPIMSContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 在庫情報モデル生成
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public InventoryModel BuildModel(InventoryData data)
        {
            var model = new InventoryModel(data);
            //コードマスタ名称取得
            var codeMaster = context.CodeMasters.Where(c => c.ID == "IVNT" && c.Code == data.StatusCode).FirstOrDefault();
            if (codeMaster != null)
            {
                model.StatucCodeaName = codeMaster.CodeName;
            }


            return model;
        }
    }
}
