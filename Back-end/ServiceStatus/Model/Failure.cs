using System;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStatus.Model.Base;

namespace ServiceStatus.Model
{
    [Table("failure")]
    public class Failure : BaseEntity
    {
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("resolution_time")]
        public TimeSpan Time { get; set; } //TimeSpan?
        [Column("description")]
        public string Description { get; set; }
    }
}
