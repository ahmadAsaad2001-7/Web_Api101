using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class hospitals
    {
        [Key]
        public int id { get; set; }
        public string hospital_name { get; set; }
        public virtual location? loc { get; set; }
        public virtual int? locid { get; set; }


        public virtual ICollection<hospital_doctor> hospital_Doctors { get; set; } = new List<hospital_doctor>();
        public virtual ICollection<phones> Phones { get; set; } = new List<phones>();


    }
}
