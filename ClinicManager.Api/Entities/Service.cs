namespace ClinicManager.Api.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Value { get; set; }
        public int Duration { get; set; }
    }
}
