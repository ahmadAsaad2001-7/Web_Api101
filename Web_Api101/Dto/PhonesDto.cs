namespace Web_Api101.Dto
{
    public class PhonesDto
    {

        public int Id { get; set; }
        public string phone_number { get; set; }
        public int? hospitalId { get; set; }
        public int? doctorId { get; set; }
        public int? clinicId { get; set; }

    }
}
