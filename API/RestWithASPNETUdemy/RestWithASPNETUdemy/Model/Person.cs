using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("times")]
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("tempo")]
        public string Tempo { get; set; }
        /*[Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }*/
    }
}
