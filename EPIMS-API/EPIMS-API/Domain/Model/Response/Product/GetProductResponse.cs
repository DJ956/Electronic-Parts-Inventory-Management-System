﻿using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.Product
{
    public class GetProductResponse : BaseResponse
    {

        public ProductModel ProductModel { get; set; }

        public GetProductResponse() : base() { }

        public GetProductResponse(ProductData data)
        {
            ProductModel = new ProductModel(data);
        }
    }
}
