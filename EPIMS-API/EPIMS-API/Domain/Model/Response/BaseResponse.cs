using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Response
{
    public class BaseResponse
    {
        /// <summary>
        /// リターンコード
        /// </summary>
        public int ReturnCode { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get; set; }

        public BaseResponse()
        {
            ReturnCode = 0;
            Message = "";
        }
    }
}
