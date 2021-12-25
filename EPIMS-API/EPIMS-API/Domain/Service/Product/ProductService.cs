using EPIMS_API.Domain.Model.Request.Product;
using EPIMS_API.Domain.Model.Response.Product;
using EPIMS_API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Service.Product
{
    public class ProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 製品を登録する
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RegistryProductResponse> RegistryProcut(RegistryProductRequest request)
        {
            return await this.repository.RegistryProcut(request);
        }

        /// <summary>
        /// 製品をすべて取得する
        /// </summary>
        /// <returns></returns>
        public GetAllProductResponse GetAllProduct()
        {
            return this.repository.GetAllProduct();
        }

        /// <summary>
        /// 製品を取得する
        /// </summary>
        /// <param name="productNo">製品番号</param>
        /// <returns></returns>
        public GetProductResponse GetProduct(int productNo)
        {
            return this.repository.GetProduct(productNo);
        }
    }
}
