using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class burns
    {
        [Key]
        public int Id { get; set; }
        public string area { get; set; }
        public int degree { get; set; }
        public string sensitivity { get; set; }
        public virtual ICollection<burn_patient> burn_Patients { get; set; } = new List<burn_patient>();

            
       
    }
}
