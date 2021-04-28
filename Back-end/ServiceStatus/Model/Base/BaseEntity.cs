using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStatus.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
