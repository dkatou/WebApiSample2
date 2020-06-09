using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api1.Api1Model.Models
{
    public class JoinA
    {
        [Column("V_JOIN_A_ID")]
        public int JoinAId { get; set; }

        [Column("V_BLOG_ID")]
        public int BlogId { get; set; }
    }
}