namespace RadiDemoBackend.Models
{
    public class Measurement
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime? PayedAt { get; set; }
    }
}
