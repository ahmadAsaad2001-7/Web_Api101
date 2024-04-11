using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class hospital_doctor
    {
        [Key]
        public int hospital_id { get; set; }
        [Key]
        public int doctor_id { get; set; }
        public virtual hospitals hospital { get; set; }
        public virtual doctors doctor { get; set; }

    }
}
