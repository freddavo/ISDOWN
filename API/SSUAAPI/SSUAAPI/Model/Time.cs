using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSUAAPI.Model
{
    [Table("times")]
    public class Time
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("tempo")]
        public string Tempo { get; set; }
    }
}
