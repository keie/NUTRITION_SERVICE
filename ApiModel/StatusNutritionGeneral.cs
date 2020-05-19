using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiModel
{
    public class StatusNutritionGeneral
    {
        [Key]
        public int id { get; set; }
        public float firstValue { get; set; }
        public float secondValue { get; set; }
        public int idKgVal { get; set; }
        public int idSizeVal { get; set; }
        
        public int idPreference { get; set; }
        public virtual List<PersonalReference> pReferences { get; set; }
        public virtual List<KgValue> kgValues { get; set; }
        public virtual List<SizeValue> sizeValues { get; set; }
    }
}