

namespace ApiModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("[user]")]public class User
    {
        [Key]
        public Int64 id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("lastname")]
        public string lastname { get; set; }
        [Column("birthday")]
        public DateTime birthday { get; set; }
        [Column("address")]
        public string address { get; set; }
        [Column("username")]
        public string username { get; set; }
        [Column("password")]
        public string password { get; set; }
        public Byte boolDelete {get;set;}
        public virtual List<Rol> Roles { get; set; }

    }
}
