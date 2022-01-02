using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Factory
{
    public interface IProductModelFactory
    {
        /// <summary>
        /// 製品モデルを生成する
        /// </summary>
        /// <param name="data">製品データ</param>
        /// <returns></returns>
        ProductModel BuildModel(ProductData data);
    }
}
