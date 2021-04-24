using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model
{
    [Table("person")]
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }
    }
}