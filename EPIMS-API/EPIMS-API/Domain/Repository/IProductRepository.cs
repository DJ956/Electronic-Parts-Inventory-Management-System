using EPIMS_API.Domain.Model.Request.Product;
using EPIMS_API.Domain.Model.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Repository
{
    public interface IProductRepository
    {
        Task<RegistryProductResponse> RegistryProcut(RegistryProductRequest request);
        Task<GetProductListResponse> GetAllProduct();
        Task<GetProductResponse> GetProduct(int productNo);
        Task<GetProductListResponse> GetProductListByCategory(int categoryNo);
    }
}
