using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Response.Category;
using EPIMS_API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Service.Category
{
    public class CategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 全てのカテゴリーを取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryData> GetAllCategory()
        {
            return this.repository.GetAllCategory();
        }

        /// <summary>
        /// カテゴリーを取得する
        /// </summary>
        /// <param name="categoryNo"></param>
        /// <returns></returns>
        public GetCategoryResponse GetCategory(int categoryNo)
        {
            return this.repository.GetCategory(categoryNo);
        }
    }
}
