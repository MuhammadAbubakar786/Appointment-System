namespace AppointmentSystem.Core.Options
{
    public class DatabaseConfigurationOptions
    {
        public const string SectionName = "ConnectionString";
        public string DefaultConnection { get; set; }
    }
}
