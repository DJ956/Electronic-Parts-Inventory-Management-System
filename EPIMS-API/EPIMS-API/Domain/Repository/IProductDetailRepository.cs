using EPIMS_API.Domain.Model.Response.ProductDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Repository
{
    public interface IProductDetailRepository
    {
        Task<GetProductDetailListResponse> GetAllProductDetail();
        Task<GetProductDetailResponse> GetProductDetail(int productNo);
    }
}
