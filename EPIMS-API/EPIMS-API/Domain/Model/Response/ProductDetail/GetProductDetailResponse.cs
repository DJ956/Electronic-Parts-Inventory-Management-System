using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.ProductDetail
{
    public class GetProductDetailResponse : BaseResponse
    {
        public GetProductDetailResponse() : base() { }

        public GetProductDetailResponse(ProductDetailModel model) : base()
        {
            this.ProductDetail = model;
        }

        /// <summary>
        /// 製品詳細
        /// </summary>
        public ProductDetailModel ProductDetail { get; set; }
    }
}
