using EPIMS_API.Domain.Model.Response.ProductDetail;
using EPIMS_API.Domain.Repository;
using EPIMS_API.Domain.Service.ProductDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Controllers
{
    /// <summary>
    /// 製品詳細 API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailRepository repository;

        public ProductDetailController(IProductDetailRepository repository) : base()
        {
            this.repository = repository;
        }

        /// <summary>
        /// 製品詳細を全て取得する。
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<GetProductDetailListResponse>> GetAllProductDetail()
        {
            var service = new ProductDetailService(this.repository);
            var response = await service.GetAllProductDetail();
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 製品番号をもとに製品詳細を取得する。
        /// </summary>
        /// <param name="productNo">製品番号</param>
        /// <returns></returns>
        [HttpGet("{productNo}")]
        public async Task<ActionResult<GetProductDetailResponse>> GetProductDetail(int productNo)
        {
            var service = new ProductDetailService(this.repository);
            var response = await service.GetProductDetail(productNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

    }
}
