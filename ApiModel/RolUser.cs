

namespace ApiModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    public class RolUser
    {
        private int Id { get; set; }
        
        [ForeignKey("idUser")]
        public virtual User IdUser { get; set; }

        [ForeignKey("idRol")]
        public virtual Rol IdRol { get; set; }
    }
}
