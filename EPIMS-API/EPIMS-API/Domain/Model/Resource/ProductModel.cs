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

        public ProductModel(ProductData data)
        {
            this.data = data;
        }

        public int ProductNo { get { return this.data.ProductNo; } }

        public string ProductName { get { return data.ProductName; } }

        public string ModelName { get { return data.ModelName; } }

        public string ShopCode { get { return data.ShopCode; } }

        public string Maker { get { return data.Maker; } }

        public int CategoryNo { get { return data.Category.CategoryNo; } }

        public string CategoryName { get { return data.Category.CategoryName; } }
    }
}
