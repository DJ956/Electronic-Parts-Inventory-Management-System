using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Factory;
using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Infra.Factory
{
    public class ProductDetailModelFactory : IProductDetailModelFactory
    {

        private readonly EPIMSContext context;

        public ProductDetailModelFactory(EPIMSContext context)
        {
            this.context = context;
        }

        public ProductDetailModel BuildModel(ProductDetailData data)
        {
            var model = new ProductDetailModel(data);
            return model;
        }
    }
}
