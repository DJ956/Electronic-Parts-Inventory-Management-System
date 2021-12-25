using EPIMS_API.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.Category
{
    public class GetAllCategoryResponse : BaseResponse
    {
        public List<CategoryData> CategoryDatas { get; set; }

        public GetAllCategoryResponse() : base()
        {
            CategoryDatas = new List<CategoryData>();
        }
    }
}
