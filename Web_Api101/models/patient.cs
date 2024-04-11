using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Web_Api101.models
{
    public class patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public char gender { get; set; }
        public string Phone { get; set; }

        public virtual location loc { get; set; }
        public virtual int? locid { get; set; }
        public virtual ICollection<burn_patient> burn_Patients { get; set; }


        public virtual ICollection<phones> Phones { get; set; }
    }
}
