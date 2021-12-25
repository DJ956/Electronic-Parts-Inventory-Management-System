using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Data
{
    /// <summary>
    /// カテゴリー
    /// </summary>
    public class CategoryData
    {

        /// <summary>
        /// カテゴリー番号
        /// </summary>
        [Key]
        [NotNull]
        public int CategoryNo { get; set; }

        /// <summary>
        /// カテゴリー名
        /// </summary>
        [NotNull]
        [MaxLength(200)]
        public string CategoryName { get; set; }

    }
}
