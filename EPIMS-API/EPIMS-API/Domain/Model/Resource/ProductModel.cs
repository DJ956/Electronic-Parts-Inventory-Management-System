using EPIMS_API.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Resource
{
    /// <summary>
    /// 製品データモデル
    /// </summary>
    public class ProductModel
    {

        private ProductData data;

        public ProductData ProductData { get; private set; }

        public ProductModel(ProductData data)
        {
            this.data = data;
        }


    }
}
