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
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository) : base()
        {
            this.repository = repository;
        }

        /// <summary>
        /// 製品の登録
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("registry")]
        public async Task<ActionResult<RegistryProductResponse>> RegistryProcut(RegistryProductRequest request)
        {
            var service = new ProductService(this.repository);
            var response = await service.RegistryProcut(request);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 製品をすべて取得する
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<GetProductListResponse>> GetAllProduct()
        {
            var service = new ProductService(this.repository);
            var response = await service.GetAllProduct();
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 製品を検索する
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        [HttpGet("{productNo}")]
        public async Task<ActionResult<GetProductResponse>> GetProduct(int productNo)
        {
            var service = new ProductService(this.repository);
            var response = await service.GetProduct(productNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// カテゴリ番号と一致する製品を取得する
        /// </summary>
        /// <param name="categoryNo">カテゴリ番号</param>
        /// <returns></returns>
        [HttpGet("categoryNo/{categoryNo}")]
        public async Task<ActionResult<GetProductListResponse>> GetProductListByCategory(int categoryNo)
        {
            var service = new ProductService(this.repository);
            var response = await service.GetProductListByCategory(categoryNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }
    }
}
