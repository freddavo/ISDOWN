using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSUAAPI.Model
{
    [Table("services")]
    public class Service
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("maintenance")]
        public string Maintenance { get; set; }
    }
  
}
