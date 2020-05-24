using System.ComponentModel.DataAnnotations;

namespace ApiModel
{
    public class Grade
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
        public char gender { get; set; }
        public byte boolDelete { get; set; }
    }
}