namespace WebApplication2.Model
{
    public class Measurement
    {
        public Guid Id { get; set; }
        public string? MeasurePointId { get; set; }
        public string? PersonId { get; set; }
        public float Value{ get; set; }
        public DateTime TimeStamp { get; set; }

        public Measurement()
        {
            Id = Guid.NewGuid();
        }
    }
}
