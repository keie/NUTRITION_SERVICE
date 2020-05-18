using System.ComponentModel.DataAnnotations;

namespace ApiModel
{
    public class SizeValue
    {
        [Key]
        public int id { get; set; }
        public float firstValye { get; set; }
        public float secondValue { get; set; }
    }
}