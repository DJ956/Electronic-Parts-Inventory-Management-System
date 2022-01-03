using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.Inventory
{
    public class GetInventoryListResponse : BaseResponse
    {
        public GetInventoryListResponse() : base()
        {
            Inventories = new List<InventoryModel>();
        }

        /// <summary>
        /// 在庫情報リスト
        /// </summary>
        public IList<InventoryModel> Inventories { get; set; }
    }
}
