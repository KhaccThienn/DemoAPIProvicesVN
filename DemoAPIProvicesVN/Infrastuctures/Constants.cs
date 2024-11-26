namespace DemoAPIProvicesVN.Infrastuctures
{
    public static class Constants
    {
        // ConnStr
        public const string OrclDb                                    = "OrclDb";

        // Stored Procedures
        public const string GetAllAdministrative_Regions              = "GetAllAdministrative_Regions";
        public const string GetAllAdministrative_Units                = "GetAllAdministrative_Units";
        public const string GetAllDistricts                           = "GetAllDistricts";
        public const string GetAllProvinces                           = "GetAllProvinces";
        public const string GetAllProvincesByAdminisTrativeRegionCode = "GetAllProvincesByAdminisTrativeRegionCode";
        public const string GetAllProvincesByAdminisTrativeUnitCode   = "GetAllProvincesByAdminisTrativeUnitCode";
        public const string GetAllWards                               = "GetAllWards";
        public const string GetProvinceByCode                         = "GetProvinceByCode";
        public const string GetDistrictsByProvinceCode                = "GetDistrictsByProvinceCode";
        public const string GetDistrictByCode                         = "GetDistrictByCode";
        public const string GetWardsByDistrictCode                    = "GetWardsByDistrictCode";
        public const string GetWardByCode                             = "GetWardByCode";
        public const string SearchProvinces                           = "SearchProvinces";
        public const string SearchDistricts                           = "SearchDistricts";
        public const string SearchWards                               = "SearchWards";

        // Parameters
        public const string ResultSet                                 = "p_result";
        public const string Code                                      = "p_code";
        public const string Id                                        = "p_id";
        public const string ProviceCode                               = "p_province_code";
        public const string DistrictCode                              = "p_district_code";
        public const string SearchTerm                                = "p_search_term";
        public const string PageNumber                                = "p_page_number";
        public const string PageSize                                  = "p_page_size";

    }
}
