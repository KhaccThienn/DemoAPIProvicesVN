namespace DemoAPIProvicesVN.Infrastuctures.Models
{
    [Table("ADMINISTRATIVE_REGIONS")]
    public class AdministrativeRegion
    {
        public int?    Id           { get; set; }
        public string? Name         { get; set; }
        public string? Name_En      { get; set; }
        public string? Code_Name    { get; set; }
        public string? Code_Name_En { get; set; }
    }
}
