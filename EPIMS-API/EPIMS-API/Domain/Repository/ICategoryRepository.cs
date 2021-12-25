using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Model.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryData> GetAllCategory();
        GetCategoryResponse GetCategory(int categoryNo);
    }
}
