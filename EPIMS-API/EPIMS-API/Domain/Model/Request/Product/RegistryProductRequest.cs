using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Request.Product
{
    /// <summary>
    /// 製品登録リクエスト
    /// </summary>
    public class RegistryProductRequest
    {

        /// <summary>
        /// 製品名
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        /// <summary>
        /// 型番
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ModelName { get; set; }

        /// <summary>
        /// 通販コード
        /// </summary>
        [MaxLength(50)]
        public string ShopCode { get; set; }

        /// <summary>
        /// メーカー
        /// </summary>
        [MaxLength(50)]
        public string Maker { get; set; }

        /// <summary>
        /// カテゴリー番号
        /// </summary>
        [Required]
        public int CategoryNo { get; set; }
    }
}
