using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.Product
{
    public class GetProductListResponse : BaseResponse
    {
        public GetProductListResponse() : base()
        {
            ProductModelList = new List<ProductModel>();
        }

        /// <summary>
        /// 製品リスト
        /// </summary>
        public List<ProductModel> ProductModelList { get; set; }
    }
}
