using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// ノート
    /// </summary>
    public class Note : ApiBase
    {
        // ここにカラムを書く
        [Column("V_NOTE_ID")]
        public int NoteId { get; set; }

        [Column("N_CONTENT")]
        public string Content { get; set; }

        [Column("V_BLOG_ID")]
        public int BlogId { get; set; }

        // ここにナビゲーションプロパティを書く
        public Blog Blog { get; set; }
    }
}