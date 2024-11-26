namespace DemoAPIProvicesVN.Infrastuctures.Services
{
    public class DbServices(IConfiguration configuration) : BaseScopeDbService(configuration.GetConnectionString(Constants.OrclDb)), IDbServices
    {
        public Task<IEnumerable<AdministrativeRegion>> GetAllAdministrativeRegionsAsync()
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<AdministrativeRegion>(Constants.GetAllAdministrative_Regions, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<AdministrativeUnit>> GetAllAdministrativeUnitsAsync()
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<AdministrativeUnit>(Constants.GetAllAdministrative_Units, parameters, commandType: CommandType.StoredProcedure);
        }

        // Province
        public Task<IEnumerable<Province>> GetAllProvincesAsync()
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<Province>(Constants.GetAllProvinces, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<Province> GetProvinceByCodeAsync(string code)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.Code, value: code, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryFirstOrDefaultAsync<Province>(Constants.GetProvinceByCode, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<Province>> GetAllProvincesByAdminisTrativeUnitCodeAsync(int id)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.Id, value: id, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<Province>(Constants.GetAllProvincesByAdminisTrativeUnitCode, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<Province>> GetAllProvincesByAdminisTrativeRegionCodeAsync(int id)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.Id, value: id, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<Province>(Constants.GetAllProvincesByAdminisTrativeRegionCode, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<Province>> SearchProvincesAsync(string searchTerm)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.SearchTerm, value: searchTerm, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<Province>(Constants.SearchProvinces, parameters, commandType: CommandType.StoredProcedure);
        }

        // District
        public Task<IEnumerable<District>> GetAllDistrictsAsync()
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<District>(Constants.GetAllDistricts, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<District> GetDistrictByCodeAsync(string code)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.Code, value: code, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryFirstOrDefaultAsync<District>(Constants.GetDistrictByCode, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<District>> GetDistrictsByProvinceCodeAsync(string provinceCode)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.ProviceCode, value: provinceCode, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<District>(Constants.GetDistrictsByProvinceCode, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<District>> SearchDistrictsAsync(string searchTerm)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.SearchTerm, value: searchTerm, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<District>(Constants.SearchDistricts, parameters, commandType: CommandType.StoredProcedure);
        }

        // Ward
        public Task<IEnumerable<Ward>> GetAllWardsAsync(int pageNumber, int pageSize)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.PageNumber, value: pageNumber, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
            parameters.Add(Constants.PageSize,   value: pageSize,   dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<Ward>(Constants.GetAllWards, parameters, commandType: CommandType.StoredProcedure);
        }
       
        public Task<Ward> GetWardByCodeAsync(string code)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.Code, value: code, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryFirstOrDefaultAsync<Ward>(Constants.GetWardByCode, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<Ward>> GetWardsByDistrictCodeAsync(string districtCode, int pageNumber, int pageSize)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.DistrictCode, value: districtCode, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
            parameters.Add(Constants.PageNumber, value: pageNumber, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
            parameters.Add(Constants.PageSize, value: pageSize, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<Ward>(Constants.GetWardsByDistrictCode, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<Ward>> SearchWardsAsync(string searchTerm, int pageNumber, int pageSize)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add(Constants.SearchTerm, value: searchTerm, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
            parameters.Add(Constants.PageNumber, value: pageNumber, dbType: OracleMappingType.Int32,    direction: ParameterDirection.Input);
            parameters.Add(Constants.PageSize,   value: pageSize,   dbType: OracleMappingType.Int32,    direction: ParameterDirection.Input);

            parameters.Add(Constants.ResultSet, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return Connection.QueryAsync<Ward>(Constants.SearchWards, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
