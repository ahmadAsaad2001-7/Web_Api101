using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class clinics
    {
        [Key]
        public int Id { get; set; }
        public string worktime { get; set; }
        public virtual location? loc { get; set; }
        public virtual int ? locid { get; set; }
        public virtual ICollection<phones> Phones { get; set; } = new List<phones>();
        public virtual ICollection<doctor_clinic> doctor_Clinics { get; set; } = new List<doctor_clinic>();
    }
}
