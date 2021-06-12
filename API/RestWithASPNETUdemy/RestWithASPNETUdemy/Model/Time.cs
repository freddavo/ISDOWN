using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("time")]
    public class Time
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("time")]
        public string Tempo { get; set; }
    }
}
