using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Factory;
using EPIMS_API.Domain.Model.Resource;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EPIMS_API.Infra.Factory
{
    /// <summary>
    /// 製品モデルを生成するファクトリー
    /// </summary>
    public class ProductModelFactory : IProductModelFactory
    {
        private readonly EPIMSContext context;

        public ProductModelFactory(EPIMSContext context)
        {
            this.context = context;
        }

        public ProductModel BuildModel(ProductData data)
        {
            //カテゴリー
            this.context.Entry(data).Reference(p => p.CategoryData).Load();
            //画像
            this.context.Entry(data).Collection(p => p.ProductImageList).Load();
            data.ProductImageList.ForEach(async data =>
            {
                if (File.Exists(data.ImagePath) == false) { return; }

                using (var memory = new MemoryStream())
                using (var fs = new FileStream(data.ImagePath, FileMode.Open))
                {
                    await fs.CopyToAsync(memory);
                    data.ImagePath = Convert.ToBase64String(memory.ToArray());
                }
            });

            return new ProductModel(data);
        }
    }
}
