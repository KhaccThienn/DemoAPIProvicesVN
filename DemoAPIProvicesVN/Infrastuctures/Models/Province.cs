namespace DemoAPIProvicesVN.Infrastuctures.Models
{
    public class Province
    {
        public string? Code                     { get; set; }
        public string? Name                     { get; set; }
        public string? Name_En                  { get; set; }
        public string? Full_Name                { get; set; }
        public string? Full_Name_En             { get; set; }
        public string? Code_Name                { get; set; }
        public int?    Administrative_Unit_Id   { get; set; }
        public int?    Administrative_Region_Id { get; set; }
        public string? Region_Name              { get; set; }
        public string? Unit_Name                { get; set; }
        public string? Region_Name_En           { get; set; }
        public string? Unit_Name_En             { get; set; }
    }
}
