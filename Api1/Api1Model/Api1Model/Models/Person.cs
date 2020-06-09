using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// 人
    /// </summary>
    public class Person : ApiBase
    {
        // ここにカラムを書く
        [Column("V_PERSON_ID")]
        public int PersonId { get; set; }

        [Column("N_PERSON_FIRST_NAME")]
        public string PersonFirstName { get; set; }

        [Column("N_PERSON_LAST_NAME")]
        public string PersonLastName { get; set; }

        // ここにナビゲーションプロパティを書く
        public List<PersonTask> PersonTasks { get; set; }
    }
}