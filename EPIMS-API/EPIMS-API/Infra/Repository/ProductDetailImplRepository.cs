using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Factory;
using EPIMS_API.Domain.Model.Response.ProductDetail;
using EPIMS_API.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Infra.Repository
{
    public class ProductDetailImplRepository : IProductDetailRepository
    {

        private readonly EPIMSContext context;
        private readonly IProductDetailModelFactory factory;

        public ProductDetailImplRepository(EPIMSContext context,
            IProductDetailModelFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        /// <summary>
        /// 全ての製品詳細を取得する
        /// </summary>
        /// <returns></returns>
        public async Task<GetProductDetailListResponse> GetAllProductDetail()
        {
            var response = new GetProductDetailListResponse();

            this.context.ProductDetailDatas.ToList().ForEach(d =>
            {
                var model = this.factory.BuildModel(d);
                response.ProductDetailDatas.Add(model);
            });

            return response;
        }

        /// <summary>
        /// 製品番号をもとに製品詳細を取得する
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        public async Task<GetProductDetailResponse> GetProductDetail(int productNo)
        {
            var response = new GetProductDetailResponse();
            var data = this.context.ProductDetailDatas.Where(p => p.ProductNo == productNo);
            if (data == null)
            {
                response.ReturnCode = 1;
                response.Message = $"製品詳細が見つかりませんでした。(製品番号={productNo})";
                return response;
            }

            response.ProductDetail = this.factory.BuildModel(data.First());
            return response;
        }
    }
}
