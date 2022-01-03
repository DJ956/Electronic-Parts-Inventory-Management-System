using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.Inventory
{
    public class GetInventoryResponse : BaseResponse
    {
        public GetInventoryResponse() : base() { }

        /// <summary>
        /// 在庫管理モデル
        /// </summary>
        public InventoryModel Inventory { get; set; }
    }
}
