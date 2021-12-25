using EPIMS_API.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.Product
{
    public class GetAllProductResponse : BaseResponse
    {

        public IEnumerable<ProductData> ProductDatas { get; set; }

        public GetAllProductResponse() : base()
        {
            ProductDatas = new List<ProductData>();
        }
    }
}
