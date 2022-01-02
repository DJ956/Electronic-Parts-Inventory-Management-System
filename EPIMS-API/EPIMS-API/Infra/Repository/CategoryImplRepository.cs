using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Response.Category;
using EPIMS_API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Infra.Repository
{
    public class CategoryImplRepository : ICategoryRepository
    {
        private readonly EPIMSContext context;

        public CategoryImplRepository(EPIMSContext context)
        {
            this.context = context;
        }

        public GetAllCategoryResponse GetAllCategory()
        {
            var response = new GetAllCategoryResponse();
            response.CategoryDatas = this.context.CategoryDatas.ToList();
            return response;
        }

        public GetCategoryResponse GetCategory(int categoryNo)
        {
            GetCategoryResponse response = new GetCategoryResponse();
            CategoryData categoryData = this.context.CategoryDatas.Where(c => c.CategoryNo == categoryNo).FirstOrDefault();
            response.CategoryData = categoryData;

            return response;
        }
    }
}
