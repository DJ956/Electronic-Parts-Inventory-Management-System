using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.ProductDetail
{
    public class GetProductDetailListResponse : BaseResponse
    {
        public GetProductDetailListResponse() : base()
        {
            this.ProductDetailDatas = new List<ProductDetailModel>();
        }

        /// <summary>
        /// 製品詳細リスト
        /// </summary>
        public IList<ProductDetailModel> ProductDetailDatas { get; set; }
    }
}
