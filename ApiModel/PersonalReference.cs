using System.ComponentModel.DataAnnotations;

namespace ApiModel
{
    public class PersonalReference
    {
        
        [Key]
       public int id { get; set; }
       public int age { get; set; }
       public byte greaterThan { get; set; }
       public byte smallerThan { get; set; }
       public char gender { get; set; }
       public byte boolDelete { get; set; }
    }
}