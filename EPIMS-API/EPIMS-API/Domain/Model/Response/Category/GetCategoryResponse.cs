using EPIMS_API.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response.Category
{
    public class GetCategoryResponse : BaseResponse
    {

        public CategoryData CategoryDate { get; set; }

        public GetCategoryResponse() : base()
        {
            CategoryDate = new CategoryData();
        }
    }
}
