using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Request.Product;
using EPIMS_API.Domain.Model.Resource;
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

        /// <summary>
        /// 全ての製品を取得する
        /// </summary>
        /// <returns></returns>
        public GetProductListResponse GetAllProduct()
        {
            GetProductListResponse response = new GetProductListResponse();
            this.context.ProductDatas.ToList().ForEach(p =>
            {
                var category = this.context.CategoryDatas.Where(c => c.CategoryNo == p.CategoryNo).First();
                p.CategoryData = category;
                var model = new ProductModel(p);
                response.ProductModelList.Add(model);
            });

            return response;
        }

        /// <summary>
        /// 製品番号と一致する製品を取得
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
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
            CategoryData categoryDate = this.context.CategoryDatas.Where(c => c.CategoryNo == productData.CategoryNo).FirstOrDefault();
            if (categoryDate != null)
            {
                productData.CategoryNo = categoryDate.CategoryNo;
                productData.CategoryData = categoryDate;
            }

            response = new GetProductResponse(productData);
            return response;
        }

        /// <summary>
        /// 製品を登録する
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RegistryProductResponse> RegistryProcut(RegistryProductRequest request)
        {
            RegistryProductResponse response = new RegistryProductResponse();

            var data = new ProductData()
            {
                ProductName = request.ProductName,
                ShopCode = request.ShopCode,
                ModelName = request.ModelName,
                Maker = request.Maker,
                CategoryData = new CategoryData(request.CategoryNo),
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


        /// <summary>
        /// カテゴリ番号と一致する製品を取得する。
        /// </summary>
        /// <param name="categoryNo">カテゴリ番号</param>
        /// <returns></returns>
        public GetProductListResponse GetProductListByCategory(int categoryNo)
        {
            var response = new GetProductListResponse();

            var list = this.context.ProductDatas.Where(p => p.CategoryNo == categoryNo);
            if (list == null)
            {
                response.ReturnCode = 1;
                response.Message = $"製品が見つかりませんでした。(カテゴリ番号={categoryNo})";
                return response;
            }

            list.ToList().ForEach(p =>
            {
                var category = this.context.CategoryDatas.Where(c => c.CategoryNo == categoryNo).First();
                p.CategoryData = category;
                var model = new ProductModel(p);
                response.ProductModelList.Add(model);
            });

            return response;
        }
    }
}
