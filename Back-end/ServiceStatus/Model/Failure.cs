using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model
{
    [Table("failure")]
    public class Failure
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("resolution_time")]
        public TimeSpan Time { get; set; } //TimeSpan?
        [Column("description")]
        public string Description { get; set; }
    }
}
