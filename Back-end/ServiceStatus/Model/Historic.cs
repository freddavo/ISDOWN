using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model
{
    [Table("historic")]
    public class Historic
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("service_name")]
        public Servico Service { get; set; }
        [Column("failure")]
        public Failure Failure { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("status")]
        public string Status { get; set; }
    }
}
