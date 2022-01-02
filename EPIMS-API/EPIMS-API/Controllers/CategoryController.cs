using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Response.Category;
using EPIMS_API.Domain.Repository;
using EPIMS_API.Domain.Service.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Controllers
{
    /// <summary>
    /// カテゴリーコントローラー
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository) : base()
        {
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// カテゴリーをすべて取得
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("all")]
        public ActionResult<GetAllCategoryResponse> GetAllCategory()
        {
            var service = new CategoryService(this.categoryRepository);
            return Ok(service.GetAllCategory());
        }

        /// <summary>
        /// カテゴリーを検索
        /// </summary>
        /// <param name="categoryNo"></param>
        /// <returns></returns>
        [HttpGet("{categoryNo}")]
        public ActionResult<GetCategoryResponse> GetCategory(int categoryNo)
        {
            var service = new CategoryService(this.categoryRepository);

            GetCategoryResponse response = service.GetCategory(categoryNo);
            if (response.CategoryData == null)
            {
                response.ReturnCode = 1;
                response.Message = $"カテゴリーが見つかりませんでした。(カテゴリー番号={categoryNo})";
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
