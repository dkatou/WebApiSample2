using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.CommonModel.Models
{
    public class ApiBase
    {
        [Column("TS_STAMP")]
        public DateTime TsStamp { get; set; }

        [Column("US_STAMP")]
        public string UsStamp { get; set; }

        [Column("AS_STAMP")]
        public string AsStamp { get; set; }

        [Column("F_ACTIVE")]
        public int ActiveFlag { get; set; }

        public void SetBaseData(DateTime dt, string user, string app)
        {
            this.TsStamp = dt;
            this.UsStamp = user;
            this.AsStamp = app;
            this.ActiveFlag = 1;
        }
    }
}