using System.ComponentModel.DataAnnotations;

namespace ApiModel
{
    public class StatusNutritionImc
    {
        [Key]
        public int id { get; set; }
        public float firstRange { get; set; }
        public float secondRange { get; set; }
        public byte boolDelete { get; set; }
    }
}