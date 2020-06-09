using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Common.CommonModel.Models;

namespace Api1.Api1Model.Models
{
    /// <summary>
    /// 人-タスク
    /// </summary>
    public class PersonTask : ApiBase
    {
        // ここにカラムを書く
        [Column("V_PERSON_CHARGE_ID")]
        public int PersonChargeId { get; set; }

        [Column("V_TASK_ID")]
        public string TaskId { get; set; }

        // ここにナビゲーションプロパティを書く
        public Person Person { get; set; }

    }
}