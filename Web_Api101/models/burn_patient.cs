using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class burn_patient
    {
        [Key]
        public int burn_id { get; set; }
        [Key]
        public int patient_id { get; set; }
        public virtual burns burn { get; set; } 
        public virtual patient patient { get; set; }

    }
}
