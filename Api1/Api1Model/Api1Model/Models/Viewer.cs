using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// 閲覧者
    /// </summary>
    public class Viewer : ApiBase
    {
        // ここにカラムを書く
        [Column("V_VIEWER_ID")]
        public int Id { get; set; }

        [Column("N_VIEWER_NAME")]
        [StringLength(10, ErrorMessage = "ViewerName length over")]
        public string Name { get; set; }

        [Column("V_PERSON_ID")]
        public int PersonId { get; set; }

        [Column("D_VIWE_DATETIME")]
        public DateTime ViewDateTime{ get; set; }

        [Column("V_BLOG_ID")]
        public int BlogId { get; set; }

        // ここにナビゲーションプロパティを書く
        public Blog Blog { get; set; }
    }
}