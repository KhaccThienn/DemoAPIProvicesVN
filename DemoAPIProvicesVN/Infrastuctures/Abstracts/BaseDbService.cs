namespace DemoAPIProvicesVN.Infrastuctures.Abstracts
{
    public abstract class BaseDbService
    {
        protected abstract string ConnectionString { get; }

        public OracleConnection GetConnection() => new(ConnectionString);

        protected async Task<TResult> ExecuteSqlQueryAsync<TResult>(Func<OracleConnection, Task<TResult>> func)
        {
            using var conn = new OracleConnection(ConnectionString);
            await conn.OpenAsync();
            return await func(conn);
        }

        protected TResult ExecuteSqlQuery<TResult>(Func<OracleConnection, TResult> func)
        {
            using var conn = new OracleConnection(ConnectionString);
            conn.Open();
            return func(conn);
        }

        protected static OracleCommand CreateSpCommand(OracleConnection conn, string spName)
        {
            var command         = conn.CreateCommand();
            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        protected async Task<ResponseDataModel<TData>> ExecuteSqlGetResponseAndData<TData>(
            string paraMessName,
            string paraCodeName,
            string paraRsName,
            OracleDynamicParameters parameters,
            Func<OracleConnection, Task<TData>> func,
            long? successCode = null)
        {
            // output
            parameters.Add(paraRsName,   dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            parameters.Add(paraCodeName, dbType: OracleMappingType.Int32,     direction: ParameterDirection.Output);
            parameters.Add(paraMessName, dbType: OracleMappingType.Varchar2,  direction: ParameterDirection.Output, size: 200);

            var data     = await ExecuteSqlQueryAsync(conn => func(conn));
            var code     = parameters.Get<long>(paraCodeName);
            var response = new ResponseDataModel<TData>
            {
                IsSuccessResponse = code == successCode,
                Code              = code,
                Message           = parameters.Get<string>(paraMessName)
            };
            response.Data = data;

            return response;
        }

        protected Task<ResponseModel> ExecuteSqlQueryGetCodeAndMess(
            string spName,
            string paraMessName,
            string paraCodeName,
            Action<OracleParameterCollection> setParamAction = null)
        {
            return ExecuteSqlQuery(conn =>
            {
                var command    = CreateSpCommand(conn, spName);
                var parameters = command.Parameters;

                if (setParamAction != null) setParamAction(parameters);
                parameters.SetOutputParameter(paraCodeName, paraMessName);

                // Execute the Stored Procedure
                command.ExecuteNonQuery();

                // Get the output values
                var response = parameters.GetResponseModel(paraMessName, paraCodeName);
                return Task.FromResult(response);
            });
        }
    }

}
