using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model
{
    [Table("fails")]
    public class Fails
    {
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("resolution_time")]
        public TimeSpan Time { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
