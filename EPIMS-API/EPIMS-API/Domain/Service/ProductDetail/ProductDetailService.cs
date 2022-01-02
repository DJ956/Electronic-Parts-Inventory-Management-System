using EPIMS_API.Domain.Model.Response.ProductDetail;
using EPIMS_API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Service.ProductDetail
{
    public class ProductDetailService
    {
        private readonly IProductDetailRepository repository;

        public ProductDetailService(IProductDetailRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 全ての製品詳細を取得する
        /// </summary>
        /// <returns></returns>
        public Task<GetProductDetailListResponse> GetAllProductDetail()
        {
            return this.repository.GetAllProductDetail();
        }

        /// <summary>
        /// 製品番号と一致する製品詳細を取得する
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        public Task<GetProductDetailResponse> GetProductDetail(int productNo)
        {
            return this.repository.GetProductDetail(productNo);
        }
    }
}
