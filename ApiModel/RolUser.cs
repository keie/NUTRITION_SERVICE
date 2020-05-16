

using LinqKit;

namespace ApiModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;


    [Table("rol_user")]
    public class RolUser
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 IdUser { get; set; }

        [ForeignKey("idUser")]
        public virtual User User { get; set; }

        public Int64 IdRol { get; set; }
        
        [ForeignKey("idRol")]
        public virtual Rol Rol { get; set; }
        
    }
}
