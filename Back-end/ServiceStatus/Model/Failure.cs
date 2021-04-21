using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model
{
    [Table("failure")]
    public class Failure
    {
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("resolution_time")]
        public TimeSpan Time { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
