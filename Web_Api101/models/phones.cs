using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class phones
    {
        [Key]
        public int Id { get; set; }
        public string phone_number { get; set; }
        public virtual hospitals? hospitals { get; set; }
        public int? hospitalId { get; set; }
        public virtual patient?  patient { get; set; }
        public int? patientId { get; set; }
        public virtual doctors? doctors { get; set; }
        public int? doctorId { get; set; }
        public virtual clinics? clinics { get; set; }
        public int? clinicId { get; set; }


    }
}
