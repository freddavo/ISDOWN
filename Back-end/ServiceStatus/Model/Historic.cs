using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model
{
    [Table("historic")]
    public class Historic
    {
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("service_name")]
        public Servico Service { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("status")]
        public string Status { get; set; }
    }
}
