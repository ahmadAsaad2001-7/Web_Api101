using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class doctors
    {

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string speciality { get; set; }
        public char gender { get; set; }
      
        public virtual location? location { get; set; }
        public virtual int? LocationId { get; set; }


        public virtual ICollection<hospital_doctor> hospital_Doctors { get; set; } = new List<hospital_doctor>();
        public virtual ICollection<phones> phones { get; set; } = new List<phones>();
        public virtual ICollection<doctor_clinic> doctor_Clinics { get; set; } = new List<doctor_clinic>();

    }
}
