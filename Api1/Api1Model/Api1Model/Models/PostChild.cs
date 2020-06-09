using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// 投稿（子）
    /// </summary>
    public class PostChild : ApiBase
    {
        // ここにカラムを書く
        [Column("V_POST_CHILD_ID")]
        public int PostChildId { get; set; }

        [Column("N_POST_CHILD_NAME")]
        public string PostChildName { get; set; }

        [Column("V_POST_ID")]
        public int PostId { get; set; }

        // ここにナビゲーションプロパティを書く
        public Post Post { get; set; }
    }
}