using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class doctor_clinic
    {
        [Key]
        public int clinic_id { get; set; }
        [Key]
        public int doctor_id { get; set; }

        public virtual doctors doctor { get; set; }
        public virtual clinics clinic { get; set; }
    }
}
