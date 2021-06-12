using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("maintenance")]
    public class Maintenance
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("data")]
        public string Manutencao { get; set; }
    }
}
