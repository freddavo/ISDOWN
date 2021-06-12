using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("services")]
    public class Servico
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("maintenance")]
        public string Maintenance { get; set; }
    }
}
