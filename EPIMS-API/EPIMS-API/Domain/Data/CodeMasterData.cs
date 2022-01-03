using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Data
{
    public class CodeMasterData
    {
        public CodeMasterData() { }

        /// <summary>
        /// コードマスタ番号
        /// </summary>
        [Key]
        public int CodeMasterNo { get; set; }

        /// <summary>
        /// 識別コード
        /// </summary>
        [NotNull]
        [MaxLength(4)]
        public string ID { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        [NotNull]
        [MaxLength(100)]
        public string Desc { get; set; }

        /// <summary>
        /// コード値
        /// </summary>
        [NotNull]
        [MaxLength(3)]
        public string Code { get; set; }

        /// <summary>
        /// コード値名
        /// </summary>
        [NotNull]
        [MaxLength(100)]
        public string CodeName { get; set; }
    }
}
