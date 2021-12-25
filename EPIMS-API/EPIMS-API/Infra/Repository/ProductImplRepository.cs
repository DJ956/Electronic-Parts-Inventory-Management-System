using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Request.Product;
using EPIMS_API.Domain.Model.Response.Product;
using EPIMS_API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Infra.Repository
{
    public class ProductImplRepository : IProductRepository
    {
        private readonly EPIMSContext context;

        public ProductImplRepository(EPIMSContext context)
        {
            this.context = context;
        }

        public GetAllProductResponse GetAllProduct()
        {
            GetAllProductResponse response = new GetAllProductResponse();
            response.ProductDatas = this.context.ProductDatas;
            return response;
        }

        public GetProductResponse GetProduct(int productNo)
        {
            GetProductResponse response = new GetProductResponse();
            ProductData productData = this.context.ProductDatas.Where(p => p.ProductNo == productNo).FirstOrDefault();
            if (productData == null)
            {
                response = new GetProductResponse();
                response.ReturnCode = 1;
                response.Message = $"製品が見つかりませんでした。(製品番号={productNo})";
                return response;
            }
            CategoryData categoryDate = this.context.CategoryDatas.Where(c => c.CategoryNo == productData.CategoryFk).FirstOrDefault();
            if (categoryDate != null)
            {
                productData.CategoryFk = categoryDate.CategoryNo;
                productData.Category = categoryDate;
            }

            response = new GetProductResponse(productData);
            return response;
        }

        public async Task<RegistryProductResponse> RegistryProcut(RegistryProductRequest request)
        {
            RegistryProductResponse response = new RegistryProductResponse();

            var data = new ProductData()
            {
                ProductName = request.ProductName,
                ShopCode = request.ShopCode,
                ModelName = request.ModelName,
                Maker = request.Maker,
                CategoryFk = request.CategoryNo,
            };

            await this.context.AddAsync(data);
            int ret = await this.context.SaveChangesAsync();

            if (ret > 0)
            {
                return response;
            }
            else
            {
                response.ReturnCode = 1;
                response.Message = "製品の登録に失敗しました。";
                return response;
            }
        }
    }
}
