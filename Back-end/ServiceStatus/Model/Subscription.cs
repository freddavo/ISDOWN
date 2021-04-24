using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model
{
    [Table("subscription")]
    public class Subscription
    {
        [Column("service_name")]
        public Servico Service { get; set; }
        [Column("person_id")]
        public Person person { get; set; }
        [Column("date")]
        public DateTime Data { get; set; }
    }
}