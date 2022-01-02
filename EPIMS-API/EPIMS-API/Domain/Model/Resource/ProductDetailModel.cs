using EPIMS_API.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Resource
{
    public class ProductDetailModel
    {

        private readonly ProductDetailData data;

        public ProductDetailModel(ProductDetailData data)
        {
            this.data = data;
        }


        /// <summary>
        /// 製品
        /// </summary>
        public ProductData ProductData { get { return this.data.ProductData; } }

        /// <summary>
        /// 金額
        /// </summary>
        public int Price { get { return this.data.Price; } }

        /// <summary>
        /// 個数名
        /// </summary>
        public string CountName { get { return this.data.CountName; } }

        /// <summary>
        /// データシートファイルパス
        /// </summary>
        public string DataSheetPath { get { return this.data.DataSheetPath; } }

        /// <summary>
        /// 仕様
        /// </summary>
        public string SpecDesc { get { return this.data.SpecDesc; } }

        /// <summary>
        /// 商品URL
        /// </summary>
        public string Url { get { return this.data.Url; } }
    }
}
