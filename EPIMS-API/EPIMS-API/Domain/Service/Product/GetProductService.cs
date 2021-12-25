using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Service.Product
{
    public class GetProductService : BaseService
    {

        public GetProductResponse response;

        public GetProductService(EPIMSContext context) : base(context)
        {
            response = new GetProductResponse();
        }

        /// <summary>
        /// 製品を取得する
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        public async Task<bool> GetProduct(int productNo)
        {
            GetProductResponse response = new GetProductResponse();

            var data = this.context.ProductDatas.Where(p => p.ProductNo == productNo).FirstOrDefault();
            //存在チェック
            if (data == null)
            {
                response.ReturnCode = 1;
                response.Message = $"製品が見つかりませんでした。(製品番号 ={ productNo})";
                return false;
            }

            //カテゴリー名取得
            CategoryData categoryData = this.context.CategoryDatas.Where(c => c.CategoryNo == data.CategoryFk).FirstOrDefault();


            return true;
        }
    }
}
