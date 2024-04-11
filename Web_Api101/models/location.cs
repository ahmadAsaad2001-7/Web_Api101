using System.ComponentModel.DataAnnotations;

namespace Web_Api101.models
{
    public class location
    {
        [Key]
        public int id { get; set; }
        public string location_name { get; set; }
        public ICollection<clinics> clinics_locations { get; set; }=new List<clinics> ();
        public ICollection<doctors> doctors_locations { get; set; } = new List<doctors>();

        public ICollection<hospitals> hospitals_locations { get; set; } = new List<hospitals>();
        public ICollection<patient> patients_locations { get; set; } = new List<patient>();

    }
}
