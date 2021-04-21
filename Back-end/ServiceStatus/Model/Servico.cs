using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model
{
    [Table("service")]
    public class Servico
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("service_name")]
        public string Name { get; set; }
        [Column("status")]
        public string Status { get; set; }
    }
}
