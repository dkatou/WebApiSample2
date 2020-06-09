using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// 投稿
    /// </summary>
    public class Post : ApiBase
    {
        // ここにカラムを書く
        [Column("V_POST_ID")]
        public int PostId { get; set; }

        [Column("N_TITLE")]
        public string Title { get; set; }

        [Column("N_CONTENT")]
        public string Content { get; set; }

        [Column("V_BLOG_ID")]
        public int BlogId { get; set; }

        // ここにナビゲーションプロパティを書く
        public List<PostChild> PostChilds { get; set; }
        public Blog Blog { get; set; }
    }
}