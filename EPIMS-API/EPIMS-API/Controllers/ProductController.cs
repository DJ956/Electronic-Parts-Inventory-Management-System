using EPIMS_API.Domain.Model.Request.Product;
using EPIMS_API.Domain.Model.Response.Product;
using EPIMS_API.Domain.Repository;
using EPIMS_API.Domain.Service.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Controllers
{
    /// <summary>
    /// 製品コントローラー
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository) : base()
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// 製品の登録
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("registry")]
        public async Task<ActionResult<RegistryProductResponse>> RegistryProcut(RegistryProductRequest request)
        {
            var service = new ProductService(this.productRepository);
            var response = await service.RegistryProcut(request);

            if (response.ReturnCode == 0)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        /// <summary>
        /// 製品をすべて取得する
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public ActionResult<GetAllProductResponse> GetAllProduct()
        {
            var service = new ProductService(this.productRepository);
            return Ok(service.GetAllProduct());
        }

        /// <summary>
        /// 製品を検索する
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        [HttpGet("{productNo}")]
        public ActionResult<GetProductResponse> GetProduct(int productNo)
        {
            var service = new ProductService(this.productRepository);
            var response = service.GetProduct(productNo);
            if (response.ReturnCode == 0)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
