using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// ブログ
    /// </summary>
    public class Blog : ApiBase
    {
        // ここにカラムを書く
        [Column("V_BLOG_ID")]
        public int BlogId { get; set; }

        [Column("N_URL")]
        public string Url { get; set; }

        // ここにナビゲーションプロパティを書く
        public List<Post> Posts { get; set; }
        public List<Note> Notes { get; set; }
        public List<Viewer> Viewers { get; set; }
    }
}