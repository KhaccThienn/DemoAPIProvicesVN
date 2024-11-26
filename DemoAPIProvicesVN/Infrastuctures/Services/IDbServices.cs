namespace DemoAPIProvicesVN.Infrastuctures.Services
{
    public interface IDbServices
    {
        Task<IEnumerable<AdministrativeRegion>> GetAllAdministrativeRegionsAsync();
        Task<IEnumerable<AdministrativeUnit>>   GetAllAdministrativeUnitsAsync();
        Task<IEnumerable<Province>>             GetAllProvincesAsync();
        Task<IEnumerable<Province>>             GetAllProvincesByAdminisTrativeUnitCodeAsync(int id);
        Task<IEnumerable<Province>>             GetAllProvincesByAdminisTrativeRegionCodeAsync(int id);
        Task<Province>                          GetProvinceByCodeAsync(string code);
        Task<IEnumerable<Province>>             SearchProvincesAsync(string searchTerm);
        Task<IEnumerable<District>>             GetAllDistrictsAsync();
        Task<District>                          GetDistrictByCodeAsync(string code);
        Task<IEnumerable<District>>             GetDistrictsByProvinceCodeAsync(string provinceCode);
        Task<IEnumerable<District>>             SearchDistrictsAsync(string searchTerm);

        Task<IEnumerable<Ward>>                 GetAllWardsAsync(int pageNumber, int pageSize);
        Task<Ward>                              GetWardByCodeAsync(string code);
        Task<IEnumerable<Ward>>                 GetWardsByDistrictCodeAsync(string districtCode, int pageNumber, int pageSize);
        Task<IEnumerable<Ward>>                 SearchWardsAsync(string searchTerm, int pageNumber, int pageSize);
    }
}
