using System.ComponentModel.DataAnnotations;

namespace ApiModel
{
    public class KgValue
    {
        [Key]
        public int id { get; set; }
        public double firstValue { get; set; }
        public double secondValue { get; set; }
    }
}