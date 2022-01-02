﻿using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Factory
{
    public interface IProductDetailModelFactory
    {
        /// <summary>
        /// 製品詳細モデルを生成する。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProductDetailModel BuildModel(ProductDetailData data);
    }
}
