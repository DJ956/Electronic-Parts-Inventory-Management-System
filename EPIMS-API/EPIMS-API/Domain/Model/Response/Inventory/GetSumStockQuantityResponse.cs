using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.Inventory
{
    public class GetSumStockQuantityResponse : BaseResponse
    {
        public GetSumStockQuantityResponse() : base() { }

        public int SumStockQuantity { get; set; }
    }
}
