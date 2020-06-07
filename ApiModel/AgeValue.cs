using System.ComponentModel.DataAnnotations;

namespace ApiModel
{
    public class AgeValue
    {
        [Key]
        public int id { get; set; }
        public int firstValue { get; set; }
        public int secondValue { get; set; }
        public byte boolDelete { get; set; }
    }
}