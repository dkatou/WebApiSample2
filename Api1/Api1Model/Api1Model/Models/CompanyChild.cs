using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// 会社CHILD
    /// </summary>
    public class CompanyChild : ApiBase
    {
        // ここにカラムを書く
        [Column("V_COMPANY_PARENT_ID")]
        public int CompanyParentId { get; set; }

        [Column("V_COMPANY_CHILD_ID")]
        public int CompanyChildId { get; set; }

        // ここにナビゲーションプロパティを書く
        public Company CompanyP { get; set; }
        public Company CompanyC { get; set; }
    }
}