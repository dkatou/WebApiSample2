using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// 会社
    /// </summary>
    public class Company : ApiBase
    {
        // ここにカラムを書く
        [Column("V_COMPANY_ID")]
        public int CompanyId { get; set; }

        [Column("N_COMPANY_NAME")]
        public string CompanyName { get; set; }

        // ここにナビゲーションプロパティを書く
        public List<CompanyChild> CompanyParentChilds { get; set; }
        public List<CompanyChild> CompanyChildChilds { get; set; }
    }
}